namespace ActionDelegatesInCSharp.Classes;
public class ActionDelegateSoundMaker
{  
    public void Make(Action soundMaker)
    {
        soundMaker();
    }
}
