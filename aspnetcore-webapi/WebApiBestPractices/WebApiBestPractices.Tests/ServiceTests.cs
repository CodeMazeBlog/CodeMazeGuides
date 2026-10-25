using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;
using WebApiBestPractices.Api.Security;
using WebApiBestPractices.Application.Services;
using WebApiBestPractices.Domain.Contracts;
using WebApiBestPractices.Domain.Entities;
using WebApiBestPractices.Infrastructure.Repositories;

namespace WebApiBestPractices.Tests;

public class ServiceTests
{
    private static CancellationToken Ct => TestContext.Current.CancellationToken;

    [Fact]
    public async Task HybridCache_CallsTheRepositoryOnce_ForRepeatedReads()
    {
        var repository = new CountingOwnerRepository();
        var services = new ServiceCollection();
        services.AddHybridCache();
        await using var provider = services.BuildServiceProvider();
        var ownerService = new OwnerService(repository, provider.GetRequiredService<HybridCache>());

        await ownerService.GetByIdAsync(InMemoryOwnerRepository.JohnId, Ct);
        var owner = await ownerService.GetByIdAsync(InMemoryOwnerRepository.JohnId, Ct);

        Assert.Equal("John Keen", owner!.Name);
        Assert.Equal(1, repository.GetByIdCalls);
    }

    [Fact]
    public void PasswordHasher_VerifiesTheRightPassword_AndRejectsTheWrongOne()
    {
        var accountService = new AccountService(new PasswordHasher<AppUser>());
        var user = new AppUser { UserName = "john" };

        var hash = accountService.HashPassword(user, "Correct-Horse-1");

        Assert.NotEqual("Correct-Horse-1", hash);
        Assert.True(accountService.VerifyPassword(user, hash, "Correct-Horse-1"));
        Assert.False(accountService.VerifyPassword(user, hash, "wrong"));
    }

    [Fact]
    public void DataProtection_RoundTripsAProtectedValue()
    {
        var services = new ServiceCollection();
        services.AddDataProtection();
        using var provider = services.BuildServiceProvider();
        var protector = new OwnerIdProtector(provider.GetRequiredService<IDataProtectionProvider>());

        var protectedId = protector.Protect(InMemoryOwnerRepository.JohnId);

        Assert.NotEqual(InMemoryOwnerRepository.JohnId.ToString(), protectedId);
        Assert.Equal(InMemoryOwnerRepository.JohnId, protector.Unprotect(protectedId));
    }

    [Fact]
    public void RateLimiterOptions_DefaultRejectionStatusCode_Is503()
    {
        Assert.Equal(StatusCodes.Status503ServiceUnavailable, new RateLimiterOptions().RejectionStatusCode);
    }

    private sealed class CountingOwnerRepository : IOwnerRepository
    {
        private readonly InMemoryOwnerRepository _inner = new();
        public int GetByIdCalls { get; private set; }

        public Task<IReadOnlyList<Owner>> GetAllAsync(CancellationToken cancellationToken) => _inner.GetAllAsync(cancellationToken);
        public Task<Owner?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            GetByIdCalls++;
            return _inner.GetByIdAsync(id, cancellationToken);
        }
        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken) => _inner.EmailExistsAsync(email, cancellationToken);
        public Task AddAsync(Owner owner, CancellationToken cancellationToken) => _inner.AddAsync(owner, cancellationToken);
        public Task UpdateAsync(Owner owner, CancellationToken cancellationToken) => _inner.UpdateAsync(owner, cancellationToken);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken) => _inner.DeleteAsync(id, cancellationToken);
    }
}
