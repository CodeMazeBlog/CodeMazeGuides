using AutoFacImplementationWeb.Interface;

namespace AutoFacImplementationWeb.Implementation
{
    public class StringBusiness : IStringBusiness
    {
        public string StringToUpper(string personName)
        {
            return personName.ToUpper();
        }
    }
}
