using Google.Cloud.Firestore;

namespace Firebase.Data;

[FirestoreData]
public class ShoeDocument
{
    [FirestoreDocumentId]
    public required string Id { get; set; }

    [FirestoreProperty]
    public required string Name { get; set; }

    [FirestoreProperty]
    public required string Brand { get; set; }

    [FirestoreProperty]
    public required string Price { get; set; }
    [FirestoreProperty]
    public string ImageUri { get; set; } = string.Empty;
}
