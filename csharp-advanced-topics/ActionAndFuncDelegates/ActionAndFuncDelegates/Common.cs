using System.ComponentModel;

namespace ActionAndFuncDelegates
{
    public class Common
    {
        public string Substring { get; set; } = string.Empty;
        public string[] Arr { get; set; } = Array.Empty<string>();
        public List<string> Results { get; set; } = new List<string>();
        public bool IsValidInputFlag { get; set; }
        public string Message { get; set; } = string.Empty;

        public static void PrintFilteredList(List<string> filteredList)
        {
            Console.WriteLine(string.Join("\n", filteredList) + "\n");
        }

    }
}
