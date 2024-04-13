using InMemoryZipFilesInNet.Services;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace InMemoryZipFilesInNet;

public class GetZipFile(IEnumerable<IService> allServices) : IGetFile
{
    private readonly IService[] _allServices = allServices.ToArray();

    public string ContentType => "application/zip";

    public Stream GenerateFileOnFlyReturnStream() =>
        GetServicesAsZipStream(_allServices);

    public byte[] GenerateFileOnFlyReturnBytes() =>
        GetServicesAsZipBytes(_allServices);

    public async Task<Stream> GenerateFileOnFlyReturnStreamAsync() =>
        await GetServicesAsZipStreamAsync(_allServices);

    private static MemoryStream GetServicesAsZipStream(IService[] services)
    {
        var stream = new MemoryStream();
        GenerateArchive(stream, services);
        _ = stream.Seek(0, SeekOrigin.Begin);

        return stream;
    }

    private async static Task<MemoryStream> GetServicesAsZipStreamAsync(IService[] services)
    {
        var stream = new MemoryStream();
        await GenerateArchiveAsync(stream, services);
        _ = stream.Seek(0, SeekOrigin.Begin);

        return stream;
    }

    private static byte[] GetServicesAsZipBytes(IService[] services)
    {
        var stream = new MemoryStream();
        GenerateArchive(stream, services);

        return stream.ToArray();
    }

    private static void GenerateArchive(Stream stream, IService[] services)
    {
        using var archive = new ZipArchive(stream, ZipArchiveMode.Create, true);
        foreach (IService service in services)
        {
            var name = $"{service.Name}.txt";
            var content = service.GetData();

            using var inZipFile = archive.CreateEntry(name).Open();
            using var fileStreamWriter = new StreamWriter(inZipFile);
            fileStreamWriter.Write(content);
        }
    }

    private async static Task GenerateArchiveAsync(Stream stream, IService[] services)
    {
        using var archive = new ZipArchive(stream, ZipArchiveMode.Create, true);
        foreach (IService service in services)
        {
            var name = $"{service.Name}.txt";
            var content = await service.GetDataAsync();

            using var inZipFile = archive.CreateEntry(name).Open();
            using var fileStreamWriter = new StreamWriter(inZipFile);
            fileStreamWriter.Write(content);
        }
    }
}
