using AutoFacImplementationWeb.Interface;

namespace Test.AutoFacImplementationWeb
{
    public class StringBusinessTestImplementation : IStringBusiness
    {
        public string StringToUpper(string personName)
        {
            return personName.ToUpper();
        }
    }
}
