namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Correct;

public class PhysicalEducationTeacher : Teacher
{
    public override string ShowCurriculum()
    {
        return "Educational outcomes for physical education";
    }
}