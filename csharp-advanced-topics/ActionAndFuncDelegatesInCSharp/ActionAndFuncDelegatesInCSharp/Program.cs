using ActionAndFuncDelegatesInCSharp;

var marks = new List<int> { 50, 50, 45 };

string CalculateGrade(Func<int, string> calculateGrade)
{
    var total = marks.Sum();
    var grade = calculateGrade(total);
    return grade;
}

var grade = new Grade();
CalculateGrade(grade.CalculateGradeFromTotalMarks);

Action<List<int>> calculateAverage = grade.CalculateAverageMarks;
calculateAverage(marks);


// Using Lambda Expression to instantiate Action<T> delegate
Action<List<int>> printAverageScores = delegate(List<int> marksList)
{
    var average = marksList.Average();
    Console.WriteLine($"The Average Mark is: {average}");
};

printAverageScores(marks);