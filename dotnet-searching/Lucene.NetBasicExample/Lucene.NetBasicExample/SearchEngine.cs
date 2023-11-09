using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Lucene.NetBasicExample
{
    public class SearchEngine
    {
        public static IndexWriter Writer { get; set; }
        public static List<Person> Data { get; set; }
        private static RAMDirectory _directory;
        private static string _personGuidToBeUpdated;

        public static void GetData()
        {
            Data = new List<Person>()
            {
                new Person(Guid.NewGuid().ToString(),"Fred","George","Herb","A tall thin man."),
                new Person(Guid.NewGuid().ToString(),"Frank","Ed","Stevens","A short fat man."),
                new Person(Guid.NewGuid().ToString(),"Alfred","Edward","Stewart","A medium average man."),
                new Person(Guid.NewGuid().ToString(),"Joe","Rand","Smith","A very tall large man."),
                new Person(Guid.NewGuid().ToString(),"Abigal","Elizabeth","Spear","A tall thin woman."),
                new Person(Guid.NewGuid().ToString(),"Michael","Rose","Garcia","A small average woman."),
                new Person(Guid.NewGuid().ToString(),"Deborah","Jordan","Davis","A tall large woman."),
                new Person(Guid.NewGuid().ToString(),"Bertha","Madison","Jones","A short fat woman."),
                new Person(Guid.NewGuid().ToString(),"Clint","Johnny","Williams","A very tiny boy."),
                new Person(Guid.NewGuid().ToString(),"Susan","Michele","Brown","A very tiny girl.")
            };
        }

        public static void Index()
        {
            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            _directory = new RAMDirectory();
            var config = new IndexWriterConfig(lv, a);
            Writer = new IndexWriter(_directory, config);

            var guidField = new StringField("GUID", "", Field.Store.YES);
            var fNameField = new TextField("FirstName", "", Field.Store.YES);
            var mNameField = new TextField("MiddleName", "", Field.Store.YES);
            var lNameField = new TextField("LastName", "", Field.Store.YES);
            var descriptionField = new TextField("Description", "", Field.Store.YES);

            var d = new Document()
            {
                guidField,
                fNameField,
                mNameField,
                lNameField,
                descriptionField
            };

            foreach (Person person in Data)
            {
                guidField.SetStringValue(person.GUID);
                fNameField.SetStringValue(person.FirstName);
                mNameField.SetStringValue(person.MiddleName);
                lNameField.SetStringValue(person.LastName);
                descriptionField.SetStringValue(person.Description);

                Writer.AddDocument(d);
            }

            Writer.Commit();
        }

        public static void AddToIndex()
        {
            _personGuidToBeUpdated = Guid.NewGuid().ToString();

            var d = new Document()
            {
                new StringField("GUID", _personGuidToBeUpdated, Field.Store.YES),
                new TextField("FirstName", "AddedFirstName", Field.Store.YES),
                new TextField("MiddleName", "AddedMiddleName", Field.Store.YES),
                new TextField("LastName", "AddedLastName", Field.Store.YES),
                new TextField("Description", "Added Description", Field.Store.YES)
            };

            Writer.AddDocument(d);
            Writer.Commit();
        }

        public static void ChangeInIndex()
        {
            var d = new Document()
            {
                new StringField("GUID", _personGuidToBeUpdated, Field.Store.YES),
                new TextField("FirstName", "UpdateFirstName", Field.Store.YES),
                new TextField("MiddleName", "UpdatedMiddleName", Field.Store.YES),
                new TextField("LastName", "UpdatedLastName", Field.Store.YES),
                new TextField("Description", "Updated Description", Field.Store.YES)
            };

            Writer.UpdateDocument(new Term("GUID", _personGuidToBeUpdated), d);
            Writer.Commit();
        }

        public static void DeleteFromIndex()
        {
            Writer.DeleteDocuments(new Term("GUID", _personGuidToBeUpdated));
            Writer.Commit();
        }

        public static void Dispose()
        {
            Writer.Dispose();
            _directory.Dispose();
        }

        public static List<string> Search(string input)
        {
            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            var dirReader = DirectoryReader.Open(_directory);
            var searcher = new IndexSearcher(dirReader);

            string[] fnames = { "GUID", "FirstName", "MiddleName", "LastName", "Age", "Description" };
            var multiFieldQP = new MultiFieldQueryParser(lv, fnames, a);
            Query query = multiFieldQP.Parse(input.Trim());

            ScoreDoc[] docs = searcher.Search(query, null, 1000).ScoreDocs;

            var results = new List<string>();
            for (int i = 0; i < docs.Length; i++)
            {
                Document d = searcher.Doc(docs[i].Doc);
                string guid = d.Get("GUID");
                string firstname = d.Get("FirstName");
                string middlename = d.Get("MiddleName");
                string lastname = d.Get("LastName");
                string description = d.Get("Description");

                results.Add($"{guid} {firstname} {middlename} {lastname} {description}");
            }

            dirReader.Dispose();
            return results;
        }

    }
}
