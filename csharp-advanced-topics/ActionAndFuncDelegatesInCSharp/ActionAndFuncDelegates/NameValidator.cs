public class NameValidator
{
    public bool IsNameValid()
    {
        string name = "Code Maze";
        return name.Length < 10;
    }

    public bool IsNameValid(string name)
    {
        return name.Length < 10;
    }
}