using PartialClasses;

var desiredInstance = GetDesiredDistance();
int GetDesiredDistance()
{
    try
    {
        return int.Parse(args[0]);
    }
    catch (Exception)
    {
        throw new ArgumentException("Please provide a valid integer as the only parameter");
    }
}
Console.WriteLine($"Our robot should cover distance of {desiredInstance}m");

var myRobot = new Robot();
myRobot.Recharge();
myRobot.PrintDiagnostics();

var jump = true;
while (myRobot.DistanceCovered < desiredInstance)
{
    if (jump)
    {
        myRobot.Jump();
    }
    else
    {
        myRobot.Walk();
    }
    jump = !jump;
    myRobot.PrintDiagnostics();
}
