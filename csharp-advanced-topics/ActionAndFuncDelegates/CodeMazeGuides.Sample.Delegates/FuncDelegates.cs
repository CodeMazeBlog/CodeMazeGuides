 
namespace CodeMazeGuides.Sample.Delegates
{


    public static class FuncDelegates
    {
    	public static Func<string> ComputeRandom = () => { 
            var random = new Random(); 
            var str = string.Empty;
            for (var i = 0; i < 10; i++)
            {
				str = string.Concat(str, random.Next(10).ToString());
			}
               
            return str; 
        };
		//string result = computeRandom(); // Invokes the Func and gets a random number.

		public static int Cube(int x) => x * x *x ;
		//int cubeResult = cube(3);

		public static Func<string, int, string> DisplayStdInfo = (stdName, stdAge) => $"Name: {stdName}, Age: {stdAge}";
		//string stdInfo= displayStdInfo("Charice", 10); // Formats a string with count. 
    }
}
