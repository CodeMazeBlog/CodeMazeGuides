namespace Discards_
{
    public class DiscardExamples
    {
        public bool GetNumber()
        {
            Console.WriteLine("Enter any number on the keyboard");
            var result = int.TryParse(Console.ReadLine(), out _);

            if (!result)
            {
                Console.WriteLine("Not a valid number");
            }

            return result;
        }

        public void GetType(object[] objects)
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
    }
}
