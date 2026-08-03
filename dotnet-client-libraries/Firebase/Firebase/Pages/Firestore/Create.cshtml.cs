using Firebase.Dtos;
using Firebase.Interfaces;
using Firebase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firebase.Pages.Firestore
{
    public class CreateModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;
        private readonly IFirebaseStorageService _storageService;

        [BindProperty]
        public ShoeDto Shoe { get; set; }

        public CreateModel(IFirestoreService firestoreService, IFirebaseStorageService storageService)
        {
            _firestoreService = firestoreService;
            _storageService = storageService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var photoUri = await _storageService.UploadFile(Shoe.Name, Shoe.Image);

            await _firestoreService.Add(new Shoe
            {
                Name = Shoe.Name,
                Brand = Shoe.Brand,
                Price = Shoe.Price,
                ImageUri = photoUri,
            });

            return RedirectToPage("Index");
        }
    }
}
