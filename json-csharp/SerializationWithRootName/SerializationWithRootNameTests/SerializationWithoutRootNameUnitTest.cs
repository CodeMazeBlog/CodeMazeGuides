using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationWithRootName;

namespace SerializationWithRootNameTests
{
	[TestClass]
	public class SerializationUnitTest
	{
		private string _model = "";
		private string _owner = "";

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			_model = "Ford";
			_owner = "John";
		}

		[TestMethod]
		public void WhenSerializeWithWrapper_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeWithWrapper(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("MyCar"));
		}

		[TestMethod]
		public void WhenSerializeWithAnonymousClass_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeWithAnonymousClass(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("MyCar"));
		}

		[TestMethod]
		public void WhenSerializeWithCustomSerializer_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeWithCustomSerializer(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("MyCar"));
		}

		[TestMethod]
		public void WhenSerializeWithDynamicTypes_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeWithDynamicTypes(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("MyCar"));
		}

		[TestMethod]
		public void WhenSerializeWithJsonSerializerSettings_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeWithJsonSerializerSettings(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("Car"));
		}

		[TestMethod]
		public void WhenSerializeToXmlWithRootName_ThenOutputWithRootName()
		{
			//Act
			string json = Serialization.SerializeToXmlWithRootName(_model, _owner);

			//Assert
			Assert.IsNotNull(json);
			Assert.IsTrue(json.Contains("MyCar"));
		}
	}
}