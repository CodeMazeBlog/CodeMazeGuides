using System.Reflection;

namespace ITextAddTextToPDFs
{
    public static class SampleDocument
    {
        public static string CurrentExecutablePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        public static string Get(string fileName)
        {
            var fullFileName = Path.Combine(CurrentExecutablePath, "SampleDocuments", fileName);
            if (!File.Exists(fullFileName))
            {
                throw new FileNotFoundException($"File {fullFileName} not found");
            }

            return fullFileName;
        }

        public static string CreateFile(string newFileName)
        {
            var file = Path.Combine(CurrentExecutablePath, "SampleDocuments", newFileName);
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            return file;
        }
    }
}
