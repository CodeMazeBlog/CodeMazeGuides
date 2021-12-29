using System;

namespace PropertyPatternsTest
{
    //let's declare a data model that is small, but contains enough property nesting to show our point
    record Order(Payment Payment, Customer Customer);
    record Payment(Price Price, DateTime? PaymentDate = null);
    record Price(string Currency, decimal Amount);
    record Customer(string Name, string Group);
}