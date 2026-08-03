namespace JsonSerializeToDictionaryDataModel;

public sealed record Customer(string Address, string PhoneNumber, Person Client, Guid CustomerId);