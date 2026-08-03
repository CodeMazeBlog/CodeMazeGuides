namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Incorrect;

public class LanguageTeacher : Teacher
{
    public override string ShowCurriculum()
    {
        return new LanguageCurriculum().GetPlannedEducationalOutcomes();
    }
}