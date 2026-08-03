namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Incorrect;

public class PhysicalEducationTeacher : Teacher
{
    public override string ShowCurriculum()
    {
        return new PhysicalEducationCurriculum().GetPlannedEducationalOutcomes();
    }
}