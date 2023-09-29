namespace FuncDelegates
{
    public class FuncHandler
    {
        public static string GetNamesReturn(string FirstName, string SecondName, string ThirdName)
        {
            return string.Format("{0}-{1}-{2}",
                                  FirstName,
                                  SecondName,
                                  ThirdName);
        }

        public static int GetRandomNumber()
        {
            Random r = new();
            return r.Next(1, 100);
        }
    }
}