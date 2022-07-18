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
    public class Program
    {
        public static IndexWriter Writer;
        public static RAMDirectory Directory;

        public static void Main(string[] args)
        {
            Index(GetData());
            UpdateIndex();
            var run = true;
            while (run)
            {
                Console.WriteLine($"{Environment.NewLine} Enter Search Criteria or Just Press Enter to End Program:");
                run = RunSearch();
            }
        }

        public static List<Person> GetData()
        {
            var persons = new List<Person>()
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

            return persons;
        }

        public static void Index(List<Person> people)
        {
            Console.WriteLine("Beginning Index");

            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            Directory = new RAMDirectory();
            var config = new IndexWriterConfig(lv, a);
            Writer = new IndexWriter(Directory, config);

            var guidField = new StringField("GUID", "", Field.Store.YES);
            var fNameField = new TextField("FirstName", "", Field.Store.YES);
            var mNameField = new TextField("MiddleName", "", Field.Store.YES);
            var lNameField = new TextField("LastName","",Field.Store.YES);
            var descriptionField = new TextField("Description","",Field.Store.YES);

            var d = new Document()
            {
                guidField,
                fNameField,
                mNameField,
                lNameField,
                descriptionField
            };

            foreach (Person person in people)
            {
                guidField.SetStringValue(person.GUID);
                fNameField.SetStringValue(person.FirstName);
                mNameField.SetStringValue(person.MiddleName);
                lNameField.SetStringValue(person.LastName);
                descriptionField.SetStringValue(person.Description);

                Writer.AddDocument(d);
            }
            
            Writer.Commit();
            Console.WriteLine("Completed Index");
        }

        private static void UpdateIndex()
        {
            Console.WriteLine("Beginning Index Update");

            var personGuidToBeUpdated = Guid.NewGuid().ToString();

            var guidField = new StringField("GUID", personGuidToBeUpdated, Field.Store.YES);
            var fNameField = new TextField("FirstName", "AddedFirstName", Field.Store.YES);
            var mNameField = new TextField("MiddleName", "AddedMiddleName", Field.Store.YES);
            var lNameField = new TextField("LastName", "AddedLastName", Field.Store.YES);
            var descriptionField = new TextField("Description", "Added Description", Field.Store.YES);

            var d = new Document()
            {
                guidField,
                fNameField,
                mNameField,
                lNameField,
                descriptionField
            };
            AddToIndex(d);

            fNameField.SetStringValue("UpdateFirstName");
            mNameField.SetStringValue("UpdatedMiddleName");
            lNameField.SetStringValue("UpdatedLastName");
            descriptionField.SetStringValue("Updated Description");
            ChangeInIndex(d, personGuidToBeUpdated);

            DeleteFromIndex(personGuidToBeUpdated);

            Console.WriteLine("Completed Index Update");
        }

        public static void AddToIndex(Document d)
        {
            Writer.AddDocument(d);
            Writer.Commit();
        }

        public static void ChangeInIndex(Document d, string guid)
        {
            Writer.UpdateDocument(new Term("GUID", guid), d);
            Writer.Commit();
        }

        public static void DeleteFromIndex(string guid)
        {
            Writer.DeleteDocuments(new Term("GUID", guid));
            Writer.Commit();
        }

        public static bool RunSearch()
        {
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input)) 
            {
                Writer.Dispose();
                Directory.Dispose();
                return false; 
            }

            foreach (var s in Search(input))
            {
                Console.WriteLine(s);
            }

            return true;
        }
        
        public static List<string> Search(string input)
        {
            const LuceneVersion lv = LuceneVersion.LUCENE_48;
            Analyzer a = new StandardAnalyzer(lv);
            var dirReader = DirectoryReader.Open(Directory);
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