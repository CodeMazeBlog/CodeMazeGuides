using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationWithRootName;


namespace SerializationWithRootNameTests
{
	[TestClass]
	public class SerializationUnitTest
	{
		public List<Car> cars = [];
		[TestInitialize]
		public void Initialize()
		{
			cars =
				[
					new Car { Make = "Toyota", Model = "Camry", Year = 2022 },
					new Car { Make = "Honda", Model = "Accord", Year = 2021 }
				];
		}

		[TestMethod]
		public void WhenJSONHasRootName_ThenOutputWithRootName()
		{
			string json = Serialization.SerializeToJsonWithRootName(cars);
			
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("car"));
		}

		[TestMethod]
		public void WhenXMLHasRootName_ThenOutputWithRootName()
		{
			string xml = Serialization.SerializeToXmlWithRootName(cars);
			
			Assert.IsNotNull(xml);
			Assert.IsTrue(xml.Contains("Car"));
		}
	}
}