using VirtualMethodsInCSharp;

namespace Tests
{
    [TestClass]
    public class VirtualMethodsInCSharpUnitTests
    {
        [TestMethod]
        public void WhenIntroducingBaseClass_ThenBaseClassIntroduction()
        {
            var baseClass = new BaseClass();
            var baseClassIntroduction = baseClass.IntroduceYourSelf();

            Assert.AreEqual("Base class's IntroduceYourSelf method.", baseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClass_ThenDerivedClassIntroduction()
        {
            BaseClass derivedClass = new DerivedClass();
            var derivedClassIntroduction = derivedClass.IntroduceYourSelf();

            Assert.AreEqual("Derived class's IntroduceYourSelf method.", derivedClassIntroduction);
        }

        [TestMethod]
        public void WhenCallingBaseClassMethodFromDerivedClassMethod_ThenBaseClassIntroduction()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.CallBaseClassIntroduction();

            Assert.AreEqual("Base class's IntroduceBaseClass method.", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingBaseClassFromDerivedClass_ThenBaseClassIntroduction()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceBaseClass();

            Assert.AreEqual("Base class's IntroduceBaseClass method.", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClassNewKeyword_ThenDerivedClassIntroduction()
        {
            var derivedClassBaseClassIntroduction = DerivedClass.IntroduceYourSelfForNewKeyword();

            Assert.AreEqual("Derived class's IntroduceYourSelfForNewKeyword method.", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClassSealedKeyword_ThenDerivedClassIntroduction()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceYourSelfForSealedKeyword();

            Assert.AreEqual("Derived class's IntroduceYourSelfForSealedKeyword method.", derivedClassBaseClassIntroduction);
        }
    }
}