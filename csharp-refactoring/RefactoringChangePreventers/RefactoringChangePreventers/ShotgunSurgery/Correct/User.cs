namespace RefactoringChangePreventers.ShotgunSurgery.Correct;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Action> Actions { get; set; }

    public void ModifyFirstName(string firstName)
    {
        FirstName = firstName;
        AddAction(nameof(ModifyFirstName));
    }

    public void ModifyLastName(string lastName)
    {
        LastName = lastName;
        AddAction(nameof(ModifyLastName));
    }

    private void AddAction(string actionName)
    {
        var action = new Action
        {
            ActionName = actionName,
            UserId = Id,
            CreatedAt = DateTime.Now
        };
        Actions.Add(action);
    }
}