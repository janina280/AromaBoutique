using System;
using System.IO;
using iTextSharp.text.pdf;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Perfume.Services
{
    public class LuceneIndexer
    {
        //private const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly string indexPath = "LuceneIndex"; // Folder pentru index

        public void IndexSpecifications(List<Specification> specs)
        {
            var dir = FSDirectory.Open(new DirectoryInfo(indexPath));
           // var analyzer = new StandardAnalyzer(AppLuceneVersion);
           // var config = new IndexWriterConfig(AppLuceneVersion, analyzer);
           // using var writer = new IndexWriter(dir, config);

            foreach (var spec in specs)
            {
                var doc = new Document
                {
               //     new StringField("Id", spec.Id.ToString(), Field.Store.YES),
                //    new TextField("Title", spec.Title, Field.Store.YES),
                //    new TextField("Content", spec.Content, Field.Store.YES)
                };

               // writer.AddDocument(doc);
            }

           // writer.Commit();
        }
    }

    public class Specification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
