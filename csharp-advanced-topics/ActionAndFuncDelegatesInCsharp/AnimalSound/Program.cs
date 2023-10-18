using AnimalSound.Classes;

public class Program
{
    private static void Main(string[] args)
    {
        var maker = new DelegateSoundMaker();
        var sound = new Sounds();
        DelegateSoundMaker.SoundMaker soundMaker  = sound.Cow;
        soundMaker += sound.Goat;
        soundMaker += sound.Dog;


        maker.Make(soundMaker);
    }
}