namespace ActionAndFuncInCsharp
{
    /// <summary>
    /// Person class
    /// </summary>
    public class Person
    {
        /// <summary>
        /// New person instance
        /// </summary>
        /// <param name="fistName"></param>
        /// <param name="lastName"></param>
        public Person(string fistName, string lastName)
        {
            FirstName = fistName;
            LastName = lastName;
        }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; init; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; init; }

    }



}