using Firebase.Data;
using Firebase.Models;
using Google.Cloud.Firestore;

namespace Firebase.Interfaces;

public interface IFirestoreService
{
    public Task<List<Shoe>> GetAll();

    public Task Add(Shoe shoe);
}
