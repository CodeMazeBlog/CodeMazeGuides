using CheckOverlapDates;

Console.WriteLine(" Determine Whether Two Date Ranges Overlap");

var firstScenario = OverlapChecker.Overlap(new(2023, 01, 06), 
    new(2023, 01, 12), 
    new(2023, 01, 04), 
    new(2023, 01, 14));

Console.WriteLine(firstScenario);

var secondScenario = OverlapChecker.Overlap(new(2023, 01, 04), 
    new(2023, 01, 14), 
    new(2023, 01, 06), 
    new(2023, 01, 12));

Console.WriteLine(secondScenario);

var thirdScenario = OverlapChecker.Overlap(new(2023, 01, 04), 
    new(2023, 01, 12), 
    new(2023, 01, 07), 
    new(2023, 01, 15));

Console.WriteLine(thirdScenario);

var fourthScenario = OverlapChecker.Overlap(new(2023, 01, 07), 
    new(2023, 01, 15), 
    new(2023, 01, 04), 
    new(2023, 01, 12));

Console.WriteLine(fourthScenario);

var fifthScenario = OverlapChecker.Overlap(new(2023, 01, 07), 
    new(2023, 01, 15), 
    new(2023, 01, 16), 
    new(2023, 01, 22));

Console.WriteLine(fifthScenario);

Console.WriteLine(" ---");

var overlapTimeRange = OverlapChecker.OverlapTime(new TimeOnly(10, 00),
    new TimeOnly(12, 00),
    new TimeOnly(11, 00),
    new TimeOnly(15, 00));

Console.WriteLine(overlapTimeRange);

Console.WriteLine(" ---");

var dontOverlapTimeRange = OverlapChecker.OverlapTime(new(10, 00),
    new TimeOnly(12, 00),
    new TimeOnly(15, 00),
    new TimeOnly(16, 00));

Console.WriteLine(dontOverlapTimeRange);

Console.WriteLine(" ---");

var firstOverlapDateRange = new DateRange(new(2023, 01, 06), new(2023, 01, 12));
var secondOverlapDateRange = new DateRange(new(2023, 01, 04), new(2023, 01, 14));

Console.WriteLine(firstOverlapDateRange.Overlap(secondOverlapDateRange));

var firstDontOverlapDateRange = new DateRange(new(2023, 01, 07), new(2023, 01, 15));
var secondDontOverlapDateRange = new DateRange(new(2023, 01, 16), new(2023, 01, 22));

Console.WriteLine(firstDontOverlapDateRange.Overlap(secondDontOverlapDateRange));

Console.WriteLine(" ---");