namespace UsingADiscardVariableInCSharp
{
    public class DiscardExamples
    {
        public static (bool result, string errorMessage) GetNumber(string input)
        {
            bool result = int.TryParse(input, out _);

            if (!result)
            {
                return (false, "Not a valid number");
            }

            return (true, "");
        }

        public static void GetType(object[] objects)
        {
            foreach (var item in objects)
            {
                Console.WriteLine(item switch
                {
                    string => "it's a string",
                    int => "it's an int",
                    _ => "Neither string nor int"
                });
            }
        }

        public static (int, int, int) GetSum(int num1, int num2)
        {
            return (num1, num2, num1 + num2);
        }
    }
}
