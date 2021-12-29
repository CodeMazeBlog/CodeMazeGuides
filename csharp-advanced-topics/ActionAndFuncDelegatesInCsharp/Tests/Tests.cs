using Delegates;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void whenOddNumberIsFiltered_DelegateLogsOnlyOddNumbers()
        {
            Func<int, bool> oddNumber = (num) => num % 2 == 1;
            var loggerParam = string.Empty;
            var logger = new Moq.Mock<Action<string>>();            
            logger.Setup(x => x(It.IsAny<string>()))
                .Callback<string>(x => loggerParam = x);                
            
            Program.GenerateData(oddNumber, logger.Object);

            logger.Verify(x => x(It.IsAny<string>()), Times.Once());
            Assert.True(loggerParam.Split(',').All(s => oddNumber(int.Parse(s))));
        }

        [Fact]
        public void whenEvenNumberIsFiltered_DelegateLogsOnlyEvenNumbers()
        {
            Func<int, bool> evenNumber = (num) => num % 2 == 0;
            var loggerParam = string.Empty;
            var logger = new Moq.Mock<Action<string>>();
            logger.Setup(x => x(It.IsAny<string>()))
                .Callback<string>(x => loggerParam = x);

            Program.GenerateData(evenNumber, logger.Object);

            logger.Verify(x => x(It.IsAny<string>()), Times.Once());
            Assert.True(loggerParam.Split(',').All(s => evenNumber(int.Parse(s))));
        }

    }
}