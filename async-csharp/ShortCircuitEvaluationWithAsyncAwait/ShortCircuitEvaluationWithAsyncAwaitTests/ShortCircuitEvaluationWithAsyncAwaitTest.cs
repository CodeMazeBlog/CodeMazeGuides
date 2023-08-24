using Moq;

namespace ShortCircuitEvaluationWithAsyncAwaitTests
{
    public class ShortCircuitEvaluationWithAsyncAwaitTest
    {
        private Mock<IUtility> _utilityMock;

        [SetUp]
        public void Setup()
        {
            _utilityMock = new Mock<IUtility>();

            _utilityMock.Setup(utility => utility.FirstCondition()).Returns(true);
            _utilityMock.Setup(utility => utility.FirstConditionAsync()).ReturnsAsync(true);
            _utilityMock.Setup(utility => utility.SecondCondition()).Returns(false);
            _utilityMock.Setup(utility => utility.SecondConditionAsync()).ReturnsAsync(false);
        }

        [Test]
        public void GivenConditionalAndEvaluation_WhenFirstConditionIsFalse_ThenSecondConditionIsNotEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (utility.SecondCondition() && utility.FirstCondition())
            {
                result = true;
            }

            Assert.That(result, Is.False);
            _utilityMock.Verify(utility => utility.SecondCondition(), Times.Once());
            _utilityMock.Verify(utility => utility.FirstCondition(), Times.Never());
        }

        [Test]
        public void GivenLogicalAndEvaluation_WhenFirstConditionIsFalse_ThenSecondConditionIsEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (utility.SecondCondition() & utility.FirstCondition())
            {
                result = true;
            }

            Assert.That(result, Is.False);
            _utilityMock.Verify(utility => utility.SecondCondition(), Times.Once());
            _utilityMock.Verify(utility => utility.FirstCondition(), Times.Once());
        }

        [Test]
        public void GivenConditionalOrEvaluation_WhenFirstConditionIsTrue_ThenSecondConditionIsNotEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (utility.FirstCondition() || utility.SecondCondition())
            {
                result = true;
            }

            Assert.That(result, Is.True);
            _utilityMock.Verify(utility => utility.FirstCondition(), Times.Once());
            _utilityMock.Verify(utility => utility.SecondCondition(), Times.Never());
        }

        [Test]
        public void GivenLogicalOrEvaluation_WhenFirstConditionIsTrue_ThenSecondConditionIsEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (utility.FirstCondition() | utility.SecondCondition())
            {
                result = true;
            }

            Assert.That(result, Is.True);
            _utilityMock.Verify(utility => utility.FirstCondition(), Times.Once());
            _utilityMock.Verify(utility => utility.SecondCondition(), Times.Once());
        }

        [Test]
        public async Task GivenAsyncConditionalAndEvaluation_WhenFirstConditionIsFalse_ThenSecondConditionIsNotEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (await utility.SecondConditionAsync() && await utility.FirstConditionAsync())
            {
                result = true;
            }

            Assert.That(result, Is.False);
            _utilityMock.Verify(utility => utility.SecondConditionAsync(), Times.Once());
            _utilityMock.Verify(utility => utility.FirstConditionAsync(), Times.Never());
        }

        [Test]
        public async Task GivenAsyncLogicalAndEvaluation_WhenFirstConditionIsFalse_ThenSecondConditionIsEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (await utility.SecondConditionAsync() & await utility.FirstConditionAsync())
            {
                result = true;
            }

            Assert.That(result, Is.False);
            _utilityMock.Verify(utility => utility.SecondConditionAsync(), Times.Once());
            _utilityMock.Verify(utility => utility.FirstConditionAsync(), Times.Once());
        }

        [Test]
        public async Task GivenAsyncConditionalOrEvaluation_WhenFirstConditionIsTrue_ThenSecondConditionIsNotEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (await utility.FirstConditionAsync() || await utility.SecondConditionAsync())
            {
                result = true;
            }

            Assert.That(result, Is.True);
            _utilityMock.Verify(utility => utility.FirstConditionAsync(), Times.Once());
            _utilityMock.Verify(utility => utility.SecondConditionAsync(), Times.Never());
        }

        [Test]
        public async Task GivenAsyncLogicalOrEvaluation_WhenFirstConditionIsTrue_ThenSecondConditionIsEvaluated()
        {
            var utility = _utilityMock.Object;
            var result = false;

            if (await utility.FirstConditionAsync() | await utility.SecondConditionAsync())
            {
                result = true;
            }

            Assert.That(result, Is.True);
            _utilityMock.Verify(utility => utility.FirstConditionAsync(), Times.Once());
            _utilityMock.Verify(utility => utility.SecondConditionAsync(), Times.Once());
        }
    }
}