using ActionDelegatesInCSharp.Classes;

public class Program
{
    private static void Main(string[] args)
    {
        var maker = new ActionDelegateSoundMaker();
        var sound = new Sounds();
        Action soundMaker = sound.Cow;
        soundMaker += sound.Goat;
        soundMaker += sound.Dog;


        maker.Make(soundMaker);
    }
}