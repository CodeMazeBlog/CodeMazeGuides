using System;

namespace FuncActionDelegatesInCsharp
{
    public class Program
    {
        public delegate void SaveFile(string text, string path);

        public static void SaveAsPdf(string text, string path)
        {
            Console.WriteLine(GetSaveAsText(text, "pdf", path));
        }

        public static void SaveAsDocx(string text, string path)
        {
            Console.WriteLine(GetSaveAsText(text, "docx", path));
        }

        public static string GetSaveAsText(string text, string fileType, string path)
            => $"Text {text} saved as a {fileType} file. Path: {path}";

        static void Main(string[] args)
        {
            var text = "Example text";
            var path = "C:\\";

            RunDelegateExample(text, path);
            RunActionExample(text, path);
            RunFuncExample(text, path);
        }

        public static void RunDelegateExample(string text, string path)
        {
            SaveFile save = SaveAsPdf;
            save += SaveAsDocx;

            save.Invoke(text, path);
        }

        public static void RunActionExample(string text, string path)
        {
            Action<string, string> SaveAsPdfAction = SaveAsPdf;

            Action<string, string> SaveAsTxtAction = delegate (string text, string path)
            {
                Console.WriteLine(GetSaveAsText(text, "txt", path));
            };

            Action<string, string> SaveAsDocxAction = (string text, string path) =>
                Console.WriteLine(GetSaveAsText(text, "docx", path));

            SaveNewFile(SaveAsDocxAction, text, path);
        }

        private static void SaveNewFile(Action<string, string> saveMethod, string text, string path)
        {
            saveMethod(text, path);
        }

        public static bool RunFuncExample(string text, string path)
        {
            Func<string, string, int> SaveAsDocxFunc = (string text, string path) =>
            {
                Console.WriteLine(GetSaveAsText(text, "docx", path));
                return text.Length;
            };

            var isSuccessful = SaveNewFile(SaveAsDocxFunc, text, path);
            return isSuccessful;
        }

        private static bool SaveNewFile(Func<string, string, int> saveMethod, string text, string path)
        {
            var textLength = saveMethod(text, path);
            return textLength > 0;
        }

    }
}
