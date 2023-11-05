using System.Text.RegularExpressions;

namespace CodeMazeGuides.CSBasic
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> pathList = new List<string> 
            {
                "C://Thisisavalidpath",
                "D://Thi*IsINVALID/<<",
                "E://Users/ValidPath/docs",
                "F://Users/Photos/Cats",
                "G://Inv@7***lidPath",
                "H://Test/This<IS>Ano<>therInvalidPath"
            };
            var convCheckResult = GetInvalidPaths(pathList);
            var linqCheckResult = GetInvalidPathsLINQ(pathList);
            var linqHeaderCheckResult = GetInvalidPathsLINQHeaderFormat(pathList);
            var regexCheckResult = GetInvalidPathsRegEx(pathList);

            List<string> validPaths = new List<string>();

            foreach (var path in linqCheckResult)
            {
                validPaths.Add(ReplaceInvalidChars(path, ""));
            }

            Console.WriteLine("Valid paths are:");

            foreach (var path in validPaths)
            {
                Console.WriteLine(path);
            }
        }

        public static List<string> GetInvalidPaths(List<string> paths)
        {
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).ToArray();
            List<string> result = new List<string>();

            foreach (var path in paths)
            {
                foreach (var ch in invalidChars) 
                {
                    if (path.Contains(ch))
                    {
                        result.Add(path);
                        break;
                    }
                }
            }

            return result;
        }

        public static List<string> GetInvalidPathsLINQ(List<string> paths)
        {
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).ToArray();

            return paths.Where(path => path.Any(x => invalidChars.Contains(x))).ToList();
        }

        public static List<string> GetInvalidPathsLINQHeaderFormat(List<string> paths)
        {
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).ToArray();

            var result = from path in paths
                         where path.Any(x => invalidChars.Contains(x))
                         select path;

            return result.ToList();
        }

        public static List<string> GetInvalidPathsRegEx(List<string> paths)
        {
            Regex invalidPath = new Regex("[" + Regex.Escape(new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars())) + "]");
            List<string> result = new List<string>();

            foreach (var path in paths) { if (invalidPath.IsMatch(path)) {  result.Add(path); } }

            return result;
        }

        public static string ReplaceInvalidChars(string path, string repChar)
        {
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).ToArray();

            return invalidChars.Aggregate(path, (a, b) => a.Replace(b.ToString(),repChar));
        }
    }
}