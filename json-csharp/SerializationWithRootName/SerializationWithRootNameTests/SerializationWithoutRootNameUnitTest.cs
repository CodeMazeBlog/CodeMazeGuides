using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationWithRootName;
using System.Reflection;
using System.Text;
using System;

[TestClass]
public class SerializationUnitTest
{
	private Car car;
	private string _owner = "";

	[TestInitialize]
	public void Initialize()
	{
		//Arrange
		car = new Car
		{
			Make = "Rolls Royce",
			Model = "Phantom",
			Year = 2022
		};
    }

	[TestMethod]
	public void WhenSerializeWithWrapper_ThenOutputWithRootName()
	{
        //Arrange
        string expectedJson = "{\"MyCar\":{\"Make\":\"Rolls Royce\",\"Model\":\"Phantom\",\"Year\":2022}}";

        //Act
        string json = CarJsonSerializer.SerializeWithWrapper(car);

		//Assert
		Assert.IsNotNull(json);
        Assert.AreEqual(expectedJson, json);
    }

	[TestMethod]
	public void WhenSerializeWithAnonymousClass_ThenOutputWithRootName()
	{
        //Arrange
        string expectedJson = "{\"MyCar\":{\"Make\":\"Rolls Royce\",\"Model\":\"Phantom\",\"Year\":2022}}";

        //Act
        string json = CarJsonSerializer.SerializeWithAnonymousClass(car);

		//Assert
		Assert.IsNotNull(json);
        Assert.AreEqual(expectedJson, json);
    }

	[TestMethod]
	public void WhenSerializeWithCustomSerializer_ThenOutputWithRootName()
	{
        //Arrange
        string expectedJson = "{\"MyCar\":{\"Make\":\"Rolls Royce\",\"Model\":\"Phantom\",\"Year\":2022}}";

        //Act
        string json = CarJsonSerializer.SerializeWithCustomSerializer(car);

		//Assert
		Assert.IsNotNull(json);
        Assert.AreEqual(expectedJson, json);
    }

	[TestMethod]
	public void WhenSerializeWithDynamicTypes_ThenOutputWithRootName()
	{
        //Arrange
        string expectedJson = "{\"MyCar\":{\"Make\":\"Rolls Royce\",\"Model\":\"Phantom\",\"Year\":2022}}";

        //Act
        string json = CarJsonSerializer.SerializeWithDynamicTypes(car);

		//Assert
		Assert.IsNotNull(json);
        Assert.AreEqual(expectedJson, json);
    }

	[TestMethod]
	public void WhenSerializeWithJsonSerializerSettings_ThenOutputWithRootName()
	{
        //Arrange
        string expectedJson = "{\"$type\":\"SerializationWithRootName.Car, SerializationWithRootName\",\"Make\":\"Rolls Royce\",\"Model\":\"Phantom\",\"Year\":2022}";

        //Act
        string json = CarJsonSerializer.SerializeWithJsonSerializerSettings(car);

		//Assert
		Assert.IsNotNull(json);
        Assert.AreEqual(expectedJson, json);
    }

	[TestMethod]
	public void WhenSerializeToXmlWithRootName_ThenOutputWithRootName()
	{
		//Arrange
		string expectedXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><MyCar xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Make>Rolls Royce</Make>\r\n  <Model>Phantom</Model>\r\n  <Year>2022</Year>\r\n</MyCar>";

        //Act
        string xml = CarXMLSerializer.SerializeToXmlWithRootName(car);

		//Assert
		Assert.IsNotNull(xml);
        Assert.AreEqual(expectedXml.Replace("\r", "").Replace("\n", ""), xml.Replace("\r","").Replace("\n",""));
    }
}