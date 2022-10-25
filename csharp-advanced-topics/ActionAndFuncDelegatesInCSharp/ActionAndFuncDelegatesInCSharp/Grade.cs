namespace ActionAndFuncDelegatesInCSharp
{
    public class Grade
    {
        public double AverageScore { get; set; }
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

        public void CalculateAverageMarks(List<int> marksList)
        {
            var average = marksList.Average();
            AverageScore = average;
        }
    }
}