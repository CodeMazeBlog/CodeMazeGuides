using Carter;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;
using System.Runtime.Serialization;

namespace BlogsAPI;

public class XmlNegotiator : IResponseNegotiator
{
    private const string _xmlMediaType = "application/xml";

    public bool CanHandle(MediaTypeHeaderValue accept)
        => accept.MatchesMediaType(_xmlMediaType);

    public async Task Handle<T>(HttpRequest req, HttpResponse res, T model, CancellationToken cancellationToken)
    {
        res.ContentType = _xmlMediaType;

        var serializer = new DataContractSerializer(model.GetType());

        using var ms = StreamManager.Instance.GetStream();
        serializer.WriteObject(ms, model);
        ms.Position = 0;

        await ms.CopyToAsync(res.Body, cancellationToken);
    }
}

public static class StreamManager
{
    public static readonly RecyclableMemoryStreamManager Instance = new();
}
