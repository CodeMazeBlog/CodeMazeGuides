using ActionsAndFuncs;


var dummy = new DummyWorker(1);

var powResult = dummy.DoTheFuncJob(SimplePow);
Console.WriteLine($"The result of SimplePow: {powResult}");

var duplicateResult = dummy.DoTheFuncJob(DuplicateIt);
Console.WriteLine($"The result of duplicateResult: {duplicateResult}");

var inlineResult = dummy.DoTheFuncJob(x => x * 5);
Console.WriteLine($"The result of inlineResult: {inlineResult}");

var inlineResult2 = dummy.DoTheFuncJob(x => { return x / 5; });
Console.WriteLine($"The result of inlineResult2: {inlineResult2}");

//inline Action taks one parameter
dummy.DoTheActionJob(x => Console.WriteLine($"The value of the fakeValue: {x}"));



// Dummy methods to be passed as Func
static double SimplePow(int number)
{
    return Math.Pow(number, 2);
}

static double DuplicateIt(int number)
{
    return number * 2;
}