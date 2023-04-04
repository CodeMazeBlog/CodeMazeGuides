namespace JsonSerializeToDictionaryDataModel;

public sealed record class Invoice(DateTime InvoiceDate, Guid InvoiceId, List<InvoiceLineItem> Items);