namespace ActionAndFuncDelegateInCSharp
{
    public class DelegatesDefinition
    {
        /// <summary>
        /// Get full name when first name and last name is supplied
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public string GetFullName(string firstName, string lastName) => $"{firstName} {lastName}";

        /// <summary>
        /// Gets the sum if two number
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        public void GetSumOfNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

    }
}