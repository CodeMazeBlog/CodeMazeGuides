namespace HowToCallSignalRAspDotNet.Models
{
    public interface IRandomizerClient
    {
        Task SendClientRandomEvenNumber(int number);
    }
}
