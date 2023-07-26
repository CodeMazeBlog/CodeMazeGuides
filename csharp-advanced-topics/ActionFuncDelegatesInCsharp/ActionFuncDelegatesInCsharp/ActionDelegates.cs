using ActionFuncDelegatesInCsharp.Logger;

namespace ActionFuncDelegatesInCsharp
{
    public class ActionDelegates
    {
        private readonly ILogger _logger;
        public ActionDelegates(ILogger logger)
        {
            _logger = logger;
        }

        public void DelegateWithLambdaExpressionUsage(int a, int b, string operation)
        {
            Action<int, int, string> logOperation = (int x, int y, string operation) =>
            {
                switch (operation)
                {
                    case "+":

                        _logger.Log("{0}+{1}={2}", x, y, x + y); break;
                    case "-":
                        _logger.Log("{0}-{1}={2}", x, y, x - y); break;
                    case "*":
                        _logger.Log("{0}*{1}={2}", x, y, x * y); break;
                    case "/":
                        _logger.Log("{0}/{1}={2}", x, y, x / y); break;
                    default:
                        _logger.Log("Operation Not Supported"); break;
                }
            };
            logOperation(a, b, operation);
        }

        public void DelegateWithReferenceMethodUsage(string message)
        {
            Action<string> actionDelegate = new Action<string>(DisplayText);
            actionDelegate(message);
        }

        public void DelegateChainedUsage(int testValue)
        {
            Action<int> myChainAction = (int value) => { };
            myChainAction += (int age) =>
            {
                _logger.Log("Your age is :{0}", age);
            };

            myChainAction += (int examScore) =>
            {
                _logger.Log("Your Exam score is :{0}", Math.Min(examScore * 1.8, 100));
            };

            myChainAction += (int value) =>
            {
                _logger.Log("This number is {0}", value % 2 != 0 ? "ODD" : "EVEN");
            };

            myChainAction(testValue);
        }

        private void LogInfo(string message)
        {
            _logger.Log("INF:{0}", message);
        }

        private void DisplayText(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                _logger.Log("EmptyMessage");
            }
            else
            {
                _logger.Log("INF:{0}", message);
            }
        }
    }
}