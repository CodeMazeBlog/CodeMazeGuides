using PeriodicTimerCSharp;

Console.WriteLine("Enter array size");
var numOfElements = Convert.ToInt32(Console.ReadLine());

var timerTask = new PeriodicTimerMethods(TimeSpan.FromSeconds(1), numOfElements);
timerTask.Start();

Console.WriteLine("Press any key to stop the task");
Console.ReadKey();

await timerTask.StopTaskAsync();