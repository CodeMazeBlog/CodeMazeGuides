using System.Data;

namespace ActionAndFuncDelegates
{
    public delegate void ShowPersonData();

    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void DisplayName()
        {
            Console.WriteLine(this.name);
        }

        public void DisplayAge()
        {
            Console.WriteLine(this.age + "\n");
        }
    }

    public class Examples
    {

        public void ActionExamples()
        {
            Person personTwo = new Person("Orlando", 27);

            Action showPersonDataWithAction = personTwo.DisplayName;
            showPersonDataWithAction();

            showPersonDataWithAction = personTwo.DisplayAge;
            showPersonDataWithAction();

            Action showDataWithAnonMethod = delegate () { personTwo.DisplayName(); };
            showDataWithAnonMethod();

            showDataWithAnonMethod = () => personTwo.DisplayAge();
            showDataWithAnonMethod();

            List<double> salaries = new List<double>();
            salaries.Add(800);
            salaries.Add(900);
            salaries.Add(1500);
            salaries.Add(750);
            salaries.Add(3000);
            salaries.Add(5000);

            salaries.ForEach(Print);

            Console.WriteLine();

            salaries.ForEach(delegate (double salary)
            {
                Console.WriteLine(salary + (salary * 0.2));
            });

            Console.WriteLine();

            salaries.ForEach((salary) =>
            {
                if (salary > 1000) Console.WriteLine(salary);
            });

            Console.WriteLine();

            Action<string, string> showFullName = showFullNameProc;

            void showFullNameProc(string fName, string lName) => Console.WriteLine(fName + " " + lName);
            showFullName("Justino", "Sachilombo");

            Console.WriteLine();

            void Print(double salary)
            {
                Console.WriteLine(salary);
            }
        }

        public void FuncExamples()
        {
            Func<string, string> mySelector = str => str.ToUpper();

            string[] listWords = { "MTV", "Apple" };

            IEnumerable<String> resWords = listWords.Select(mySelector);

            foreach (String word in resWords) Console.WriteLine(word);

            Console.WriteLine();

            Func<string, int, string> upperMethod = UppercaseString;
            string name = "Jay";
            int age = 48;

            Console.WriteLine(upperMethod(name, age));

            string UppercaseString(string strName, int age)
            {
                return (strName + "-" + age).ToUpper();
            }
        }

        public void DelegateExamples()
        {
            Person personOne = new Person("Justino", 27);

            ShowPersonData showPersonData = personOne.DisplayName;
            showPersonData();

            showPersonData = personOne.DisplayAge;
            showPersonData();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Examples examples = new Examples();

            examples.DelegateExamples();

            examples.ActionExamples();

            examples.FuncExamples();
        }

    }
}