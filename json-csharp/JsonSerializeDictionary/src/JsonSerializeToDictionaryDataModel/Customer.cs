namespace JsonSerializeToDictionaryDataModel;

public sealed record class Customer(string Address, string PhoneNumber, Person Client, Guid CustomerId);