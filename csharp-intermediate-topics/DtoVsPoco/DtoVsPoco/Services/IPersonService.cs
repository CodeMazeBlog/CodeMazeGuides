using DtoVsPoco.Dtos;

namespace DtoVsPoco.Services
{
    public interface IPersonService
    {
        Task<ICollection<PersonInfo>> GetPersonInfoData();
        Task<ICollection<PersonDetails>> GetPersonDetailsData();
    }
}
