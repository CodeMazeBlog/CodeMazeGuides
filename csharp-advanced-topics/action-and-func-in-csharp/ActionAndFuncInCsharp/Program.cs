namespace ActionAndFuncInCsharp
{
    /// <summary>
    /// Action and function delegates basic usage.
    /// </summary>
    public class Program
    {
        
        /// <summary>
        /// Init the console app.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var person = new Person ("John", "Papa");

            var p = new PersonGreeter();
            p.SayHelloWithBasicDelegate(person);
            p.SayHelloWithAction(person);
            p.SayHelloWithFunc(person);
        }

        

    }

}