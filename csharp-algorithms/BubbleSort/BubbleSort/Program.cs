using BubbleSort;

var sorting = new Bubble();
var best = new int[2000];
sorting.GenerateRandomNumber(best, 10000);
sorting.DisplaySortTime(best);

var average = new int[20000];
sorting.GenerateRandomNumber(average, 10000);
sorting.DisplaySortTime(average);

var worst = new int[100000];
sorting.GenerateRandomNumber(worst, 10000);
sorting.DisplaySortTime(worst);