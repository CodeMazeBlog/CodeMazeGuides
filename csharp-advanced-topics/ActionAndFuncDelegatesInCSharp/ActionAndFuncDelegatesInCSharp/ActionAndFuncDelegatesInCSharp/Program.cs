using ActionAndFuncDelegatesInCSharp;

var marks = new List<int> { 50, 50, 45 };

string CalculateGrade(Func<int, string> calculateGrade)
{
    var total = marks.Sum();
    var grade = calculateGrade(total);
    return grade;
}

var grades = new Grade();
CalculateGrade(grades.CalculateGradeFromTotalMarks);