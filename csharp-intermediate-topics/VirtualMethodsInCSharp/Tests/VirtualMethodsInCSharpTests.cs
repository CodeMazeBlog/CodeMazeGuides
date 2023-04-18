using VirtualMethodsInCSharp;

namespace Tests
{
    [TestClass]
    public class VirtualMethodsInCSharpTests
    {
        [TestMethod]
        public void WhenIntroducingBaseClass_ThenCorrectResult()
        {
            var baseClass = new BaseClass();
            var baseClassIntroduction = baseClass.IntroduceYourSelf();

            Assert.AreEqual("I am the base class!", baseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClass_ThenCorrectResult()
        {
            BaseClass derivedClass = new DerivedClass();
            var derivedClassIntroduction = derivedClass.IntroduceYourSelf();

            Assert.AreEqual("I am the derived class!", derivedClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingBaseClassFromDerivedClass_ThenCorrectResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceBaseClass();

            Assert.AreEqual("I am the base class!", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClassNotOverriden_ThenCorrectResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceYourSelfNotOverriden();

            Assert.AreEqual("I am the base class!", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClassNewKeyword_ThenCorrectResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceYourSelfForNewKeyword();

            Assert.AreEqual("I am the derived class!", derivedClassBaseClassIntroduction);
        }

        [TestMethod]
        public void WhenIntroducingDerivedClassSealedKeyword_ThenCorrectResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassBaseClassIntroduction = derivedClass.IntroduceYourSelfForSealedKeyword();

            Assert.AreEqual("I am the derived class!", derivedClassBaseClassIntroduction);
        }
    }
}