using System;

namespace CSConstructors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.display();

            Person person2 = new Person("Mahesh");
            person2.display();

            Person copyPerson = new Person(person2);
            copyPerson.display();

            Student student = new Student("Mahesh", 30, "IT");
            student.print();

            //This will throw error
            //SingletonClass singletonClass = new SingletonClass();
            SingletonClass singletonClass = SingletonClass.getInstance();
        }
    }
}
