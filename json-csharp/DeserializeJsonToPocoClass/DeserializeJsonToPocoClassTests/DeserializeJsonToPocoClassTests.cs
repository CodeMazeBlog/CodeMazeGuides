using DeserializeJsonToPocoClass;
using DeserializeJsonToPocoClass.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeserializeJsonToPocoClassTests
{
    [TestClass]
    public class DeserializeJsonToPocoClassTests
    {
        [TestMethod]
        public void WhenRunningMain_ThenJsonIsDeserialized()
        {
            Program.Main();

            
            Assert.IsInstanceOfType(Program.DeserializedJsonCar, typeof(Car));
            Assert.IsNotNull(Program.DeserializedJsonCar.Year);
            Assert.IsNotNull(Program.DeserializedJsonCar.Make);
            Assert.IsNotNull(Program.DeserializedJsonCar.Model);
            Assert.IsNotNull(Program.DeserializedJsonCar.Features);

            Assert.IsInstanceOfType(Program.NewtonsoftDeserializedJsonCar, typeof(Car));
            Assert.IsNotNull(Program.NewtonsoftDeserializedJsonCar.Year);
            Assert.IsNotNull(Program.NewtonsoftDeserializedJsonCar.Make);
            Assert.IsNotNull(Program.NewtonsoftDeserializedJsonCar.Model);
            Assert.IsNotNull(Program.NewtonsoftDeserializedJsonCar.Features);
        }
    }
}