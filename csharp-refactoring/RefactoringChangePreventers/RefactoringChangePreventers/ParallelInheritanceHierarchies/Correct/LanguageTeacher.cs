namespace RefactoringChangePreventers.ParallelInheritanceHierarchies.Correct;

public class LanguageTeacher : Teacher
{
    public override string ShowCurriculum()
    {
        return "Educational outcomes for language learning";
    }
}