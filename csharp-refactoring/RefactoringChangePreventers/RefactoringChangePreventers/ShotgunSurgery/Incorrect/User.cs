namespace RefactoringChangePreventers.ShotgunSurgery.Incorrect;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Action> Actions { get; set; }

    public void ModifyFirstName(string firstName)
    {
        FirstName = firstName;
        var action = new Action
        {
            ActionName = nameof(ModifyFirstName),
            UserId = Id,
        };
        Actions.Add(action);
    }

    public void ModifyLastName(string lastName)
    {
        LastName = lastName;
        var action = new Action
        {
            ActionName = nameof(ModifyLastName),
            UserId = Id,
        };
        Actions.Add(action);
    }
}