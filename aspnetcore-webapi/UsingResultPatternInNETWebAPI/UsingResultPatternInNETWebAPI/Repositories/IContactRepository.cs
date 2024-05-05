namespace UsingResultPatternInNETWebAPI.Repositories;

public interface IContactRepository
{
    IEnumerable<Contact> GetAll();
    Contact? GetById(Guid id);
    Contact Create(Contact contact);
    Contact? GetByEmail(string email);
}