using ConsumerApp.Domain.Model;

namespace ConsumerApp.Domain.Interfaces
{
    public interface ILoginApiRepository
    {
        Task<AccessToken> AuthenticateAsync();
    }
}
