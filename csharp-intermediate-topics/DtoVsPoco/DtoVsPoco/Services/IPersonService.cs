using DtoVsPoco.Dtos;

namespace DtoVsPoco.Services
{
    public interface IPersonService
    {
        Task<ICollection<PersonDetails>> GetPersonDetailsData();
    }
}
