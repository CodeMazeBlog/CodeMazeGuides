namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Incorrect;

public class LanguageCurriculum : Curriculum
{
    public override string GetPlannedEducationalOutcomes()
    {
        return "Educational outcomes for language learning";
    }
}