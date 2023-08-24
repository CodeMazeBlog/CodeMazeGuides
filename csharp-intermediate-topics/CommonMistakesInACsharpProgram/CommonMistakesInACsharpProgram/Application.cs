using System.Text;

namespace CommonMistakesInACsharpProgram
{
    public partial class Application
    {

        public class microwaveoven { } //wrong

        public class MicrowaveOven { } // right

        public interface Machine { } //wrong

        public interface IMachine { } //right

        int lv = 3; //wrong

        int no_si = 20; //wrong

        int levels = 3; //right

        int numberOfStudents = 20; //right

        int id = 0; //an exception

        //namespace Api.Services.Implementations.EntityService
               
        public const string FavoriteFood = "Egusi Soup"; //right

        public const string favoriteFood = "Egusi Soup"; //wrong
                                                         //
        public const string FAVORITEFOOD = "Egusi Soup"; //wrong

        public static bool MisplaceTypes()
        {
            Person personOne = new();
            Person personTwo = new();

            Console.WriteLine(personOne.Equals(personTwo)); //True

            Car carOne = new();
            Car carTwo = new();

            Console.WriteLine(carOne == carTwo); //False
            return carOne == carTwo;
        }

        public static string OverLookingExtensionTypes()
        {
            Person personOne = new();
            personOne.Name = "John";

            return personOne.PersonExtension();
        }

        public static string StringConcantenation()
        {
            string[] words = { " doe", " is", " a", " developer" };

            string introduction = default;

            foreach (string word in words)
            {
                introduction = introduction + word;
            }
            //Correct
            StringBuilder stringBuilder = new();

            foreach (string word in words)
            {
                stringBuilder.Append(word).Append(" ");
            }

            return introduction = stringBuilder.ToString();
        }

        public static void ImplicitVariableType()
        {
            var numberOne = 1887092567;
            var numberTwo = 7763487897987752893;
            var numberThree = 237837469237836282M;

            int numberOne_ = 1887092567;
            long numberTwo_ = 7763487897987752893;
            decimal numberThree_ = 237837469237836282M;
        }
    }  
}
