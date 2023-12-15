using CsvHelper.Configuration;

namespace DelegateFuncAppSample;

public sealed class MessageMap : ClassMap<Messages>
{
    public MessageMap()
    {
        Map(m => m.TypeMessage).Index(0);
        Map(m => m.Recipient).Index(1);
        Map(m => m.Message).Index(2);
        Map(m => m.Email).Index(3);
        Map(m => m.PhoneNumber).Index(4);
    }
}