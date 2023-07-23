using AutoFacImplementationWeb.Interface;

using System.Collections.Generic;

namespace Test.AutoFacImplementationWeb
{
    public class PersonBusinessTestImplementation : IPersonBusiness
    {
        public List<string> GetPersonList()
        {
            List<string> personList = new List<string>();
            personList.Add("Code Maze");
            personList.Add("John Doe");
            return personList;
        }
    }
}
