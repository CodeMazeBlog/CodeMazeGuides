using ActionAndFuncDelegatesInCSharp;

var marks = new List<int> { 50, 50, 45 };

string CalculateGrade(Func<int, string> calculateGrade)
{
    var total = marks.Sum();
    var grade = calculateGrade(total);
    Console.WriteLine($"Your grade is: {grade}");
    return grade;
}


var grades = new Grades();
CalculateGrade(grades.CalculateGradeFromTotalMarks);