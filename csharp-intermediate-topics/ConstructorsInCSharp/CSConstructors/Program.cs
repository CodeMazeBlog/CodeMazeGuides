namespace CSConstructors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person1 = new Person();
            person1.Display();

            var person2 = new Person("John Doe");
            person2.Display();

            var copyPerson = new Person(person2);
            copyPerson.Display();

            var student = new Student("John Doe", 30, "IT");
            student.Print();

            //This will throw error
            //SingletonClass singletonClass = new SingletonClass();
            var singletonClass = SingletonClass.GetInstance();
        }
    }
}
