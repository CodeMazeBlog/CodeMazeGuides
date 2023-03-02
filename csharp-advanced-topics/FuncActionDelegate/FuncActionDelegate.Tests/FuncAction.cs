namespace FuncActionDelegate.Tests
{
    public class FuncAction
    {
        [Fact]
        public void PrintDogSound_WhenPassToActionDelegate()
        {
            //arrange 
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Dog dog = new Dog();
            //declaration
            Action<string> PrintDogSoundDelegate = dog.PrintSound;


            //act
            //invocation
            PrintDogSoundDelegate("wuff!!!!");


            //assert
            stringWriter.ToString().Equals("wuff!!!!");


        }

        [Fact]
        public void ReturnDogSound_WhenPassToFuncDelegate()
        {
            //arrange 
            Dog dog = new Dog();
            //declaration
            Func<string, string> ReturnDogSoundDelegate = dog.MakeSound;


            //act
            //invocation
            var dogSound =  ReturnDogSoundDelegate("wuff!!!wuff!!!");


            //assert
            dogSound.Equals("wuff!!!wuff!!!");


        }
    }
}