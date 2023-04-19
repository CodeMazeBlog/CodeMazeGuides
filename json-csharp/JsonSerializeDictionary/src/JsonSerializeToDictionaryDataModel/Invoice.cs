namespace JsonSerializeToDictionaryDataModel;

public sealed record Invoice(DateTime InvoiceDate, Guid InvoiceId, List<InvoiceLineItem> Items);