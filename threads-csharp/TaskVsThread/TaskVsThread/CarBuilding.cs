using System.Collections.Concurrent;

namespace TaskVsThread;

public class CarBuilding
{
    public const int BODY_BUILD_TIME = 150;
    public const int ENGINE_BUILD_TIME = 100;
    public const int SUSPENSION_BUILD_TIME = 50;
    public const int PAINTING_TIME = 50;
    public const int TESTING_TIME = 100;

    protected CarBuilding() { }

    virtual protected Body BuildBody(int weight, int length, int width) =>
        new Body(weight, length, width);

    virtual protected Engine BuildEngine(int horsePower) => new Engine(horsePower);

    virtual protected Suspension BuildSuspension(int supportedKg) => new Suspension(supportedKg);

    virtual protected Painting Paint(string color, int bodyArea) => new Painting(color, bodyArea);

    virtual protected void Test(Body body, IEnumerable<Suspension> suspensions, Engine engine)
    {
        if (suspensions.Sum(s => s.SupportedKg) <= body.Weight || 
            engine.Horsepower * 4 <= body.Weight)
            throw new ArgumentException("The car weighs too much");
    }
}
