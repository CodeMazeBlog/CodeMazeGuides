namespace JsonSerializeToDictionaryDataModel;

public sealed record class Product(string Name, decimal CostPerItem, Guid ProductId);