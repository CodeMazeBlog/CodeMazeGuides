namespace ActionAndFuncInCsharp
{
    public class ActionMarketService
    {
        public static int Apples { get; set; }

        public Action BuyApple = RemoveApple;

        public Action<int> BuyApples = RemoveApples;

        public ActionMarketService(int apples)
        {
            Apples = apples;
        }

        private static void RemoveApple()
        {
            RemoveApples(1);
        }

        private static void RemoveApples(int applesToRemove)
        {
            if (Apples - applesToRemove >= 0)
            {
                Apples -= applesToRemove;
            }
        }
    }
}
