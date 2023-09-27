namespace ReturnFileWebApi.Interface
{
    public interface IFileService
    {
        Stream GetImageAsStream();
        byte[] GetImageAsByteArray();
    }
}
