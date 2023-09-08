namespace Discards_
{
    public class DiscardExamples
    {
        public static bool GetNumber()
        {
            Console.WriteLine("Enter any number on the keyboard");
            var result = int.TryParse(Console.ReadLine(), out _);

            if (!result)
            {
                Console.WriteLine("Not a valid number");
            }

            return result;
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
