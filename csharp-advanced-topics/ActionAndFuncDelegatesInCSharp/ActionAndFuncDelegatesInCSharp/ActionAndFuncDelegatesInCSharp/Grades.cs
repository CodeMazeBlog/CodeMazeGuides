namespace ActionAndFuncDelegatesInCSharp
{
    public class Grades
    {
        public string CalculateGradeFromTotalMarks(int totalMarks)
        {
            if (totalMarks >= 200)
                return "A";
            else if (totalMarks >= 150)
                return "B";
            else if (totalMarks >= 100)
                return "C";
            else
                return "D";

        }
    }
}
