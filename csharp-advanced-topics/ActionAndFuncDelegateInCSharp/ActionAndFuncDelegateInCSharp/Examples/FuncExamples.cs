using ActionAndFuncDelegateInCSharp.Model;

namespace ActionAndFuncDelegateInCSharp
{
    public class FuncExamples
    {
        public Func<int> RandomNumberGenerator { get; set; }

        public Func<Person, Bank, string> BankIdGetter { get; set; }

        public FuncExamples()
        {
            RandomNumberGenerator = () => new Random().Next();
            BankIdGetter = (person, bank) => bank.GetBankId(person);
        }
    }
}