using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RateLimiting;
using WebApiBestPractices.Api.Extensions;
using WebApiBestPractices.Api.Filters;
using WebApiBestPractices.Api.Logging;
using WebApiBestPractices.Application.Dtos;
using WebApiBestPractices.Application.Services;

namespace WebApiBestPractices.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/owners")]
[EnableRateLimiting(ServiceExtensions.PerClientRateLimit)]
public class OwnersController(
    IOwnerService ownerService,
    IOutputCacheStore outputCache,
    ILogger<OwnersController> logger) : ControllerBase
{
    [HttpGet]
    [OutputCache(PolicyName = ServiceExtensions.OwnersCachePolicy)]
    public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners(CancellationToken cancellationToken)
    {
        var owners = await ownerService.GetAllAsync(cancellationToken);
        logger.OwnersReturned(owners.Count);

        return Ok(owners);
    }

    [HttpGet("{id:guid}", Name = "OwnerById")]
    public async Task<ActionResult<OwnerDto>> GetOwnerById(Guid id, CancellationToken cancellationToken)
    {
        var owner = await ownerService.GetByIdAsync(id, cancellationToken);

        return owner is null ? NotFound() : Ok(owner);
    }

    [HttpPost]
    public async Task<ActionResult<OwnerDto>> CreateOwner(
        OwnerForCreationDto owner, CancellationToken cancellationToken)
    {
        var createdOwner = await ownerService.CreateAsync(owner, cancellationToken);
        await outputCache.EvictByTagAsync(ServiceExtensions.OwnersCacheTag, cancellationToken);

        return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter<ValidateOwnerExistsFilter>]
    public async Task<IActionResult> UpdateOwner(
        Guid id, OwnerForUpdateDto owner, CancellationToken cancellationToken)
    {
        await ownerService.UpdateAsync(id, owner, cancellationToken);
        await outputCache.EvictByTagAsync(ServiceExtensions.OwnersCacheTag, cancellationToken);

        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    [ServiceFilter<ValidateOwnerExistsFilter>]
    public async Task<IActionResult> DeleteOwner(Guid id, CancellationToken cancellationToken)
    {
        await ownerService.DeleteAsync(id, cancellationToken);
        await outputCache.EvictByTagAsync(ServiceExtensions.OwnersCacheTag, cancellationToken);

        return NoContent();
    }
}
