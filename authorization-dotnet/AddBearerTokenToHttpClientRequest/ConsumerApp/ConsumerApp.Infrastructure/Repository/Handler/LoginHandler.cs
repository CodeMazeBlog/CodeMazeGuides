using ConsumerApp.Domain.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerApp.Infrastructure.Repository.Handler
{
    public class LoginHandler : DelegatingHandler
    {
        private readonly ILoginApiRepository _loginApiRepository;

        public LoginHandler(ILoginApiRepository loginApiRepository)
        {
            _loginApiRepository = loginApiRepository;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _loginApiRepository.AuthenticateAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
