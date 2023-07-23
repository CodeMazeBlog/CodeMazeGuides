using Firebase.Interfaces;
using Firebase.Models;
using Firebase.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firebase.Pages.Firestore
{
    public class IndexModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;

        public List<Shoe>? Shoes;

        public IndexModel(IFirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        public async Task OnGetAsync()
        {

            Shoes = await _firestoreService.GetAll();
        }
    }
}
