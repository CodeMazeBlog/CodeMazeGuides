namespace UsingResultPatternInNETWebAPI.Repositories;

public class InMemoryContactsRepository : IContactsRepository
{
    private readonly List<Contact> _contacts =
    [
        new Contact
        {
            Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"), 
            Email = "jdoe@unknown.com"
        }
    ];

    public IEnumerable<Contact> GetAll()
    {
        return _contacts;
    }

    public Contact? GetById(Guid id)
    {
        return _contacts.Find(c => c.Id == id);
    }

    public Contact Create(Contact contact)
    {
        if (contact.Id == Guid.Empty)
        {
            contact.Id = Guid.NewGuid();
        }

        _contacts.Add(contact);
        return contact;
    }

    public bool ExistsByEmail(string email)
    {
        return _contacts.Exists(c => c.Email == email);
    }
}