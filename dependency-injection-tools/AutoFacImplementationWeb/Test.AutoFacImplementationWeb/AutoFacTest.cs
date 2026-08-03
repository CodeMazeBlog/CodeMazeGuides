using AutoFacImplementationWeb.Controllers;
using AutoFacImplementationWeb.Interface;

using Xunit;

namespace Test.AutoFacImplementationWeb
{
    public class AutoFacTest
    {
        private readonly PersonController _personController;
        private readonly IPersonBusiness _personBusiness;

        private readonly IStringBusiness _stringBusiness;

        public AutoFacTest()
        {

            _personBusiness = new PersonBusinessTestImplementation();
            _personController = new PersonController(_personBusiness);

            _stringBusiness = new StringBusinessTestImplementation();
        }

        [Fact]
        public void GetNameList_WhenCalled_ReturnsListOfNames()
        {
            //Act
            var result = _personController.GetPersonList();
            var expectedResult = _personBusiness.GetPersonList();
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetUpperCaseOfName_WhenCalled_ReturnsValueWithUpperCase()
        {
            //Act
            var stringHelperController = new StringHelperController
            {
                StringBusiness = _stringBusiness
            };
            var name = "code maze";
            var result = stringHelperController.GetUpperCase(name);
            var expectedResult = _stringBusiness.StringToUpper(name);
            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
