using CsvHelper;
using CsvHelper.Configuration;
using Xunit;

namespace DelegateFuncAppSample;

public enum TypeMessageEnum
{
    WhatsApp = 0,
    Sms = 1,
    Email = 2
}

public record Messages
{
    public required int TypeMessage;
    public required string Recipient;
    public required string Message;
    public string? Email;
    public string? PhoneNumber;
}

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

public class SendNotifications
{
    public Func<Messages, Action> WhatsApp { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.WhatsApp) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending WhatsApp message to {messages.Recipient}: {messages.Message}");
    };

    public Func<Messages, Action> Sms { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Sms) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending SMS to {messages.Recipient}: {messages.Message}");
    };

    public Func<Messages, Action> Email { get; } = messages => () =>
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Email) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending Email to {messages.Recipient}: {messages.Message}");
    };

    public int[] CountTypes { get; set; } = new[] { 0, 0, 0 };
}


public class WhatsAppSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.WhatsApp) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending WhatsApp message to {messages.Recipient}: {messages.Message}");
    }
}

public class SmsSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Sms) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending SMS to {messages.Recipient}: {messages.Message}");
    }
}
public class EmailSender
{
    public void Send(Messages messages)
    {
        if (messages.TypeMessage != (int)TypeMessageEnum.Email) throw new Exception("Type mismatch");

        Console.WriteLine($"Sending Email to {messages.Recipient}: {messages.Message}");
    }
}

public class SenderProcess
{
    public Action<int, SendNotifications> Processed = (type, srvNotification) =>
    {
        var result = srvNotification.CountTypes[type] + 1;
        srvNotification.CountTypes[type] = result;
    };

    public SendNotifications? ProcessFile(string file, SendNotifications notificationService)
    {
        if (string.IsNullOrWhiteSpace(file) ||
            !File.Exists(file))
        {
            return null;
        }

        List<Messages>? records = null;
        
        var processMessages = new SenderProcess();
        using var reader = new StreamReader(file);

        try
        {
            Read();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading {ex.Message}");
        }

        try
        {
            processMessages.ProcessListMessages(records, notificationService, Processed);
            return notificationService;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while processing list: {ex.Message}");
        }
        
        
        void Read()
        {
            using var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<MessageMap>();
            records = new List<Messages>();
            var nRowCount = 0;

            while (csv.Read())
            {
                nRowCount++;
                try
                {
                    var record = csv.GetRecord<Messages>();
                    if (record == null)
                    {
                        throw new Exception($"Invalid row: {nRowCount}");
                    }

                    if (record.TypeMessage < 0 || record.TypeMessage >= notificationService.CountTypes.Length)
                    {
                        throw new Exception($"Invalid TypeMessage, row: {nRowCount}");
                    }

                    records.Add(record);
                }
                catch
                {
                    throw new Exception($"Error on row: {nRowCount}");
                }
            }

        }
    }

    public void ProcessListMessages(List<Messages>? records,
        SendNotifications notificationService,
        Action<int, SendNotifications> processed)
    {
        if (records == null) throw new Exception("Error on records.");

        try
        {
            foreach (var record in records)
            {
                Action sender;
                switch (record.TypeMessage)
                {
                    case (int)TypeMessageEnum.WhatsApp:
                        sender = notificationService.WhatsApp(record);
                        break;
                    case (int)TypeMessageEnum.Sms:
                        sender = notificationService.Sms(record);
                        break;
                    case (int)TypeMessageEnum.Email:
                        sender = notificationService.Email(record);
                        break;
                    default:
                        Console.WriteLine($"Type mismatch {record.TypeMessage}");
                        continue;
                }

                sender.Invoke();
                processed(record.TypeMessage, notificationService);
            }
        }
        catch
        {
            throw new Exception("Error on records.");
        }
    }

}