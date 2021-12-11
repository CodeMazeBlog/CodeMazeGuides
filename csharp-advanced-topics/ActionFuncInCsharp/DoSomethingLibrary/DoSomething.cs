namespace DoSomethingLibrary
{
    public class DoSomething
    {
        public static void LongProcess(Action reportProgress)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);

                reportProgress(); //Hey whoever is calling me, it's time to report progress!
            }
        }

        public static void LongProcess(Action<int> reportProgress)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);

                reportProgress(i); //Hey whoever is calling me, it's time to report progress, and now I'm sending you how many repetitions we had so far!
            }
        }
        
        public static void InteractiveProcess(Func<bool> keepRepeating)
        {
            do
            {
                /*
                A very complicated process that do nothing
                ...
                */
                Thread.Sleep(1000);
            } while (keepRepeating()); //Hey whoever is calling me, should I keep repeating?
        }

        public static void InteractiveProcess(Func<int, bool> keepRepeating)
        {
            var runTimes = 0;
            do
            {
                runTimes++;
                /*
                A very complicated process that do nothing
                ...
                */
                Thread.Sleep(1000);
            } while (keepRepeating(runTimes)); //Hey whoever is calling me, should I keep repeating?
        }


        public static void DoSomethingWithAction(int maxNumber, int divideBy, Action<int> itemFoundAction)
        {
            var itemsDividedBy3 = 0;

            for (int i = 0; i < maxNumber; i++)
            {
                if (i % divideBy == 0)
                {
                    itemFoundAction(i);
                    itemsDividedBy3++;
                }
            }
        }

        public static void DoSomethingWithFunc(int maxNumber, int divideBy, Func<int, int> itemFoundFunc)
        {
            var itemsDividedBy3 = 0;

            for (int i = 0; i < maxNumber; i++)
            {
                if (i % divideBy == 0)
                {
                    itemFoundFunc(i);
                    itemsDividedBy3++;
                }
            }

        }
    }
}