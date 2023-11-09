namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Incorrect;

public class PhysicalEducationCurriculum : Curriculum
{
    public override string GetPlannedEducationalOutcomes()
    {
        return "Educational outcomes for physical education";
    }
}