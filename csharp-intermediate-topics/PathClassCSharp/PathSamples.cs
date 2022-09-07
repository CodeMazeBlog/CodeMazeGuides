namespace PathClassCSharp
{
    public class PathSamples
    {
        public static string path = @"C:\mydir\myfile.com";
        public static string result= "";

        public static string path1 = "c:\\temp";
        public static string path2 = "subdir\\file.txt";
        public static string combination = "";

        public static string[] paths = { @"d:\archives", "2001", "media", "images" };

        public static string p1 = @"d:\archives\";
        public static string p2 = "media";
        public static string p3 = "images";
        public static string p4 = "2001";
        public static string combined = "";
        public static ReadOnlySpan<char> filepath => "C:/Users/user1/file.exe".AsSpan();

        public static bool boolResult;
        public static string filePath = @"C:\MyDir\MySubDir\myfile.ext";
        public static string directoryName = "";

        public static string fileName = @"C:\mydir.old\myfile.ext";
        public static string extensionString = "";

        public static ReadOnlySpan<char> filename => "C:/Users/user1/file.exe".AsSpan();      

        public static string pathFile = @"C:\mydir.old\myfile.ext";
        public static string pathstring = @"C:\mydir.old\";

        public static string basePath = "C:/Utilities/";
        public static string relativePath = "./data/output.xml";
        public static string pathString = "";

        public static string fullPathString = @"C:\mydir\myfile.ext";
        public static string pathRoot ="";

        public static string pathFirstComponent = "D:/";
        public static string pathSecondComponent = "/users/user1/documents";
        public static string pathThirdComponent = "letters";

        public static string[] pathArrayComponent = { "D:/", "/users/user1/documents", "letters" };

        public static string file_name = @"C:\mydir\myfile.ext";
        public static string dir_path = @"C:\mydir\";

        public static string mydir_path = @"mydir";
        public static string PathResult = "";

        public static int nChars = 0;
        public static Span<Char> buffer => new Span<Char>(new String(' ', 100).ToCharArray());
    }
}
