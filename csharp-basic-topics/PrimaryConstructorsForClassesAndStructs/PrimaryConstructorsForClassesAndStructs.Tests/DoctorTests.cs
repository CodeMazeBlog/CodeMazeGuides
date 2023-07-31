namespace PrimaryConstructorsForClassesAndStructs.Tests
{
    public class DoctorTests
    {
        [Fact]
        public void Test1()
        {
            var doctor = new Doctor(string.Empty);
            Assert.NotNull(doctor);
            Assert.NotNull(doctor.Name);
            Assert.False(doctor.Overworked);
        }
    }
}