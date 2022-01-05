namespace ActionAndFuncDelegateInCSharp.Model
{
    public class Bank
    {
        public Person Person { get; }

        public Bank() { }

        public Bank(Person person)
        {
            Person = person;
        }

        public string GetBankId(Person person = null)
        {
            return "Bank [GYU]: " + (person ?? Person)?.NationalIdentity;
        }
    }
}