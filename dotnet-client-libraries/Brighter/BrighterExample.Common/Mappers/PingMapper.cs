namespace BrighterExample.Common;

public class PingEventMapper : IAmAMessageMapper<PingEvent>
{
    public Message MapToMessage(PingEvent request)
    {
        var header = new MessageHeader(
            messageId: request.Id,
            topic: "ping.event",
            messageType: MessageType.MT_EVENT
        );
        var body = new MessageBody(
            JsonSerializer.Serialize(request, JsonSerialisationOptions.Options)
        );
        var message = new Message(header, body);

        return message;
    }

    public PingEvent MapToRequest(Message message)
    {
        var pingCommand = JsonSerializer.Deserialize<PingEvent>(
            message.Body.Value,
            JsonSerialisationOptions.Options
        );
        ArgumentNullException.ThrowIfNull(pingCommand, nameof(pingCommand));

        return pingCommand;
    }
}
