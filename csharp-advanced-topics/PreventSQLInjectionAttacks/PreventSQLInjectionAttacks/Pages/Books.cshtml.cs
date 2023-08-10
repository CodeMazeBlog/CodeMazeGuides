using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PreventSQLInjectionAttacks.Data;
using PreventSQLInjectionAttacks.Models;
using System.Data;

namespace PreventSQLInjectionAttacks.Pages
{
    public class BooksModel : PageModel
    {
        private readonly DataContext _dataContext;
        private readonly string _connectionString;

        public IList<Book> BooksEFCore { get; set; }
        public IList<Book> BooksDapper { get; set; }
        public IList<Book> BooksADO { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedTable { get; set; } = "EFCore";

        public BooksModel(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public void OnGet(string searchTerm)
        {
            if (!string.IsNullOrEmpty(SelectedTable))
            {
                if (SelectedTable == "EFCore")
                {
                    BooksEFCore = string.IsNullOrEmpty(searchTerm)
                        ? GetAllBooksUsingEFCore()
                        : SearchBooksUsingTitleEFCore(searchTerm);
                }
                else if (SelectedTable == "Dapper")
                {
                    BooksDapper = string.IsNullOrEmpty(searchTerm)
                        ? GetAllBooksUsingDapper()
                        : SearchBooksUsingTitleDapper(searchTerm);
                }
                else
                {
                    BooksADO = string.IsNullOrEmpty(searchTerm)
                        ? GetAllBooksUsingADO()
                        : SearchBooksUsingTitleADO(searchTerm);
                }
            }
        }

        private IList<Book> SearchBooksUsingTitleEFCore(string title)
        {
            return _dataContext.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        private IList<Book> SearchBooksUsingTitleEFCoreSqlQuery(string title)
        {
            return _dataContext.Books.FromSqlRaw($"SELECT * FROM Books WHERE Title LIKE '%{title}%'").ToList();
        }

        private IList<Book> GetAllBooksUsingEFCore()
        {
            return _dataContext.Books.ToList();
        }

        private IList<Book> GetAllBooksUsingDapper()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Books";

            return connection.Query<Book>(query).ToList();
        }

        private IList<Book> GetAllBooksUsingADO()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT * FROM Books", connection);
            var books = new List<Book>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var book = new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2)
                    };

                    books.Add(book);
                }
            }

            return books;
        }

        private IList<Book> SearchBooksUsingTitleDapper(string title)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Books WHERE Title LIKE @SearchTerm";

            return connection.Query<Book>(query, new { SearchTerm = $"%{title}%" }).ToList();
        }

        private IList<Book> SearchBooksUsingTitleADO(string title)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT * FROM Books WHERE Title LIKE @SearchTerm", connection);
            command.Parameters.Add(new SqliteParameter("@SearchTerm", DbType.String) { Value = $"%{title}%" });

            var books = new List<Book>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var book = new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2)
                    };

                    books.Add(book);
                }
            }

            return books;
        }

        public IActionResult OnGetChangeTable(string table)
        {
            if (table == "EFCore" || table == "Dapper" || table == "ADO")
            {
                SelectedTable = table;
            }

            return RedirectToPage("/Books");
        }
    }
}
