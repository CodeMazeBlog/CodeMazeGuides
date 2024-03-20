namespace UsingResultPatternInNETWebAPI.Repositories;

public interface IContactsRepository
{
    IEnumerable<Contact> GetAll();
    Contact? GetById(Guid id);
    Contact Create(Contact contact);
    bool ExistsByEmail(string email);
}