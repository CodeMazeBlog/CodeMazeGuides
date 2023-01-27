namespace ActionAndFuncDelegateInCSharpTests
{
    [TestClass]
    public class Tests
    {
        private Program _program;
        private int sum;

        [TestInitialize]
        public void Initialize()
        {
            _program = new Program();
        }

        [TestMethod]
        public void When_Invoked_Action_Delegate_For_Addition_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 12;
            var actual = no + no;
            _program.addition = AddNumers;

            //Act
            _program.addition(no, no);

            //Assert
            Assert.AreEqual(actual, sum);
        }

        [TestMethod]
        public void When_Invoked_Action_Delegate_For_Addition_With_Anonymous_Method_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 15;
            var actual = no + no;
            _program.addition = delegate (int no1, int no2) { sum = no1 + no2; };

            //Act
            _program.addition(no, no);

            //Assert
            Assert.AreEqual(actual, sum);
        }

        [TestMethod]
        public void When_Invoked_Action_Delegate_For_Addition_With_Lambda_Function_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 20;
            var actual = no + no;
            _program.addition = (no1, no2) => sum = no1 + no2;

            //Act
            _program.addition(no, no);

            //Assert
            Assert.AreEqual(actual, sum);
        }

        [TestMethod]
        public void When_Invoked_Func_Delegate_For_Multiplication_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 5;
            var actual = no * no;
            _program.multiply = MultiplyNumbers;

            //Act
            var expectedResult = _program.multiply(no, no);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }

        [TestMethod]
        public void When_Invoked_Func_Delegate_For_Multiplication_With_Anonymous_Method_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 6;
            var actual = no * no;
            _program.multiply = delegate (int no1, int no2)
            {
                return no1 * no2;
            };

            //Act
            var expectedResult = _program.multiply(no, no);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }

        [TestMethod]
        public void When_Invoked_Func_Delegate_For_Multiplication_With_Lambda_Function_Then_Should_Execute_Successfully()
        {
            //Setup
            var no = 8;
            var actual = no * no;
            _program.multiply = (no1, no2) => no1 * no2;

            //Act
            var expectedResult = _program.multiply(no, no);

            //Assert
            Assert.AreEqual(actual, expectedResult);
        }

        #region Private Methods

        private void AddNumers(int no1, int no2)
        {
            sum = no1 + no2;
        }

        private int MultiplyNumbers(int no1, int no2)
        {
            return no1 * no2;
        }

        #endregion Private Methods
    }
}