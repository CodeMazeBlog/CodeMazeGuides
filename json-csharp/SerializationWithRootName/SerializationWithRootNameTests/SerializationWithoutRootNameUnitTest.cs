using Microsoft.VisualStudio.TestTools.UnitTesting;

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
		//Act
		string json = CarJsonSerializer.SerializeWithWrapper(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("MyCar"));
	}

	[TestMethod]
	public void WhenSerializeWithAnonymousClass_ThenOutputWithRootName()
	{
		//Act
		string json = CarJsonSerializer.SerializeWithAnonymousClass(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("MyCar"));
	}

	[TestMethod]
	public void WhenSerializeWithCustomSerializer_ThenOutputWithRootName()
	{
		//Act
		string json = CarJsonSerializer.SerializeWithCustomSerializer(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("MyCar"));
	}

	[TestMethod]
	public void WhenSerializeWithDynamicTypes_ThenOutputWithRootName()
	{
		//Act
		string json = CarJsonSerializer.SerializeWithDynamicTypes(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("MyCar"));
	}

	[TestMethod]
	public void WhenSerializeWithJsonSerializerSettings_ThenOutputWithRootName()
	{
		//Act
		string json = CarJsonSerializer.SerializeWithJsonSerializerSettings(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("Car"));
	}

	[TestMethod]
	public void WhenSerializeToXmlWithRootName_ThenOutputWithRootName()
	{
		//Act
		string json = CarXMLSerializer.SerializeToXmlWithRootName(car);

		//Assert
		Assert.IsNotNull(json);
		Assert.IsTrue(json.Contains("MyCar"));
	}
}