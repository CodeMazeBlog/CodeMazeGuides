
namespace WriteFileToTempFolder
{
    public static class TempFileCreator
    {
        public static void CreateTempFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write("Your message");
            }
        }
    }
}
