using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventSQLInjectionAttacks.Data;
using PreventSQLInjectionAttacks.Models;

namespace PreventSQLInjectionAttacks.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly DataContext _dataContext;

        public CreateBookModel(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult OnPost(Book book)
        {
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            return RedirectToPage("Books");
        }
    }
}
