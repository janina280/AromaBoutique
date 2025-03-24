using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Perfume.Models;
using Perfume.Services.Interfaces;

namespace Perfume.Services;

public interface ISearchEngine
{
    Task GetDataAsync();
    void Index();
    void AddToIndex(string productId, string description);
    void ChangeInIndex(string productId, string description);
    void DeleteFromIndex(string productId);
    List<string> Search(string input);
}

public class SearchEngine : IDisposable, ISearchEngine
{
    private static IndexWriter _writer { get; set; }
    private static List<PerfumeModel> _data { get; set; }
    private static RAMDirectory _directory;

    private readonly IPerfumeService _perfumeService;

    public SearchEngine(IPerfumeService perfumeService)
    {
        _perfumeService = perfumeService;
    }

    public async Task GetDataAsync()
    {
        _data = await _perfumeService.GetPerfumesAsync();
    }

    public void Index()
    {
        const LuceneVersion lv = LuceneVersion.LUCENE_48;
        Lucene.Net.Analysis.Analyzer a = new StandardAnalyzer(lv);
        _directory = new RAMDirectory();
        var config = new IndexWriterConfig(lv, a);
        _writer = new IndexWriter(_directory, config);

        var guidField = new StringField("GUID", "", Field.Store.YES);
        var descriptionField = new TextField("Description", "", Field.Store.YES);

        var d = new Document()
        {
            guidField,
            descriptionField
        };

        foreach (var person in _data)
        {
            guidField.SetStringValue(person.Id.ToString());
            descriptionField.SetStringValue(person.Description);

            _writer.AddDocument(d);
        }

        _writer.Commit();
    }

    public void AddToIndex(string productId, string description)
    {
        var d = new Document()
        {
            new StringField("GUID", productId, Field.Store.YES),
            new TextField("Description", description, Field.Store.YES)
        };

        _writer.AddDocument(d);
        _writer.Commit();
    }

    public void ChangeInIndex(string productId, string description)
    {
        var d = new Document()
        {
            new StringField("GUID", productId, Field.Store.YES),
            new TextField("Description", description, Field.Store.YES)
        };

        _writer.UpdateDocument(new Term("GUID", productId), d);
        _writer.Commit();
    }

    public void DeleteFromIndex(string productId)
    {
        _writer.DeleteDocuments(new Term("GUID", productId));
        _writer.Commit();
    }

    public void Dispose()
    {
        _writer.Dispose();
        _directory.Dispose();
    }

    public List<string> Search(string input)
    {
        const LuceneVersion lv = LuceneVersion.LUCENE_48;
        Lucene.Net.Analysis.Analyzer a = new StandardAnalyzer(lv);
        var dirReader = DirectoryReader.Open(_directory);
        var searcher = new IndexSearcher(dirReader);

        string[] fnames = ["GUID", "Description"];
        var multiFieldQp = new MultiFieldQueryParser(lv, fnames, a);
        var query = multiFieldQp.Parse(input.Trim());

        ScoreDoc[] docs = searcher.Search(query, null, 1000).ScoreDocs;

        var results =
            (from t in docs
                select searcher.Doc(t.Doc)
                into d
                let guid = d.Get("GUID")
                select guid).ToList();

        dirReader.Dispose();
        return results;
    }
}