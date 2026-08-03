namespace TaskVsThread;

public class CarBuildingWithTask : CarBuilding
{
    public static void Build(int horsePower, int suspensionCount)
    {
        var carBuilding = new CarBuildingWithTask();
        var bodyTask = Task.Run(() => carBuilding.BuildBody(100, 5, 2));
        var paintingTask = bodyTask.ContinueWith(
            task => carBuilding.Paint("red", task.Result.Width * task.Result.Length)
        );

        var engineTask = Task.Run(() => carBuilding.BuildEngine(horsePower));

        var suspensionTasks = Enumerable
            .Range(0, suspensionCount)
            .Select(i => Task.Run(() => carBuilding.BuildSuspension(40)));
        var suspensionsTask = Task.WhenAll(suspensionTasks)
            .ContinueWith(task => task.Result.ToList());

        try
        {
            var testingTask = Task.Run(() =>
                carBuilding.Test(bodyTask.Result, suspensionsTask.Result, engineTask.Result)
            );

            Task.WaitAll(testingTask, paintingTask);
        }
        catch (AggregateException exc)
        {
            throw exc.InnerExceptions[0];
        }
    }

    override protected Body BuildBody(int weight, int length, int width)
    {
        Task.Delay(CarBuilding.BODY_BUILD_TIME);
        return base.BuildBody(weight, length, width);
    }

    override protected Engine BuildEngine(int horsePower)
    {
        Task.Delay(CarBuilding.ENGINE_BUILD_TIME);
        return base.BuildEngine(horsePower);
    }

    override protected Suspension BuildSuspension(int supportedKg)
    {
        Task.Delay(CarBuilding.SUSPENSION_BUILD_TIME);
        return base.BuildSuspension(supportedKg);
    }

    override protected Painting Paint(string color, int bodyArea)
    {
        Task.Delay(CarBuilding.PAINTING_TIME);
        return base.Paint(color, bodyArea);
    }

    override protected void Test(Body body, IEnumerable<Suspension> suspensions, Engine engine)
    {
        Task.Delay(CarBuilding.TESTING_TIME);
        base.Test(body, suspensions, engine);
    }
}
