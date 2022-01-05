namespace ActionAndFuncDelegateInCSharp.Model
{
    public class Bank
    {
        public string GetBankId(Person person) => "Bank [GYU]: " + person.NationalIdentity;
    }
}