using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;



namespace Perfume.Services
{

    public class LuceneSearcher
    {
       // private const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly string indexPath = "LuceneIndex";

        public List<Specification> SearchSpecifications(string queryText, bool descending = false)
        {
            var dir = FSDirectory.Open(new DirectoryInfo(indexPath));
        //    var reader = DirectoryReader.Open(dir);
          //  var searcher = new IndexSearcher(reader);
          //  var analyzer = new StandardAnalyzer(AppLuceneVersion);
          //  var parser = new QueryParser(AppLuceneVersion, "Content", analyzer);

           // var query = parser.Parse(queryText);
           // var hits = searcher.Search(query, 10).ScoreDocs;

            var results = new List<Specification>();

           // foreach (var hit in hits)
            {
           //     var doc = searcher.Doc(hit.Doc);
                results.Add(new Specification
                {
             //       Id = int.Parse(doc.Get("Id")),
             //       Title = doc.Get("Title"),
             //       Content = doc.Get("Content"),
                });
            }

            return descending ? results.OrderByDescending(x => x.Title).ToList() : results;
        }
    }

}
