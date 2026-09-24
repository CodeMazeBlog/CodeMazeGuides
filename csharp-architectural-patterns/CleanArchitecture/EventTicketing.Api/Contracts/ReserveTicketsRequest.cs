using System.ComponentModel.DataAnnotations;

namespace EventTicketing.Api.Contracts;

public sealed record ReserveTicketsRequest([property: Range(1, 20)] int Quantity);
