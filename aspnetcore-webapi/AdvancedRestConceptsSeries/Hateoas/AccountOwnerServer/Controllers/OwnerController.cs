using AccountOwnerServer.Filters;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace AccountOwnerServer.Controllers;

[Route("api/owners")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly LinkGenerator _linkGenerator;

    public OwnerController(ILoggerManager logger,
        IRepositoryWrapper repository,
        LinkGenerator linkGenerator)
    {
        _logger = logger;
        _repository = repository;
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetOwners([FromQuery] OwnerParameters ownerParameters)
    {
        if (!ownerParameters.ValidYearRange)
        {
            return Problem(
                detail: "maxYearOfBirth must be greater than or equal to minYearOfBirth.",
                statusCode: StatusCodes.Status400BadRequest);
        }

        var owners = await _repository.Owner.GetOwners(ownerParameters);

        var metadata = new
        {
            owners.TotalCount,
            owners.PageSize,
            owners.CurrentPage,
            owners.TotalPages,
            owners.HasNext,
            owners.HasPrevious
        };

        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metadata);

        _logger.LogInfo($"Returned {owners.TotalCount} owners from database.");

        var shapedOwners = owners.Select(o => o.Entity).ToList();

        var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"]!;

        if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
            return Ok(shapedOwners);

        for (var index = 0; index < owners.Count; index++)
            shapedOwners[index].Add("Links", CreateLinksForOwner(owners[index].Id, ownerParameters.Fields));

        var ownersWrapper = new LinkCollectionWrapper<Entity>(shapedOwners);

        return Ok(CreateLinksForOwners(ownersWrapper));
    }

    [HttpGet("{id}", Name = "OwnerById")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public IActionResult GetOwnerById(Guid id, [FromQuery] string? fields)
    {
        var owner = _repository.Owner.GetOwnerById(id, fields);

        if (owner.Id == Guid.Empty)
        {
            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"]!;

        if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
        {
            _logger.LogInfo($"Returned shaped owner with id: {id}");
            return Ok(owner.Entity);
        }

        owner.Entity.Add("Links", CreateLinksForOwner(owner.Id, fields));

        return Ok(owner.Entity);
    }

    [HttpPost]
    public IActionResult CreateOwner([FromBody] Owner owner)
    {
        if (owner.IsObjectNull())
        {
            _logger.LogError("Owner object sent from client is null.");
            return BadRequest("Owner object is null");
        }

        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid owner object sent from client.");
            return BadRequest("Invalid model object");
        }

        _repository.Owner.CreateOwner(owner);
        _repository.Save();

        return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
    {
        if (owner.IsObjectNull())
        {
            _logger.LogError("Owner object sent from client is null.");
            return BadRequest("Owner object is null");
        }

        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid owner object sent from client.");
            return BadRequest("Invalid model object");
        }

        var dbOwner = _repository.Owner.GetOwnerById(id);

        if (dbOwner.IsEmptyObject())
        {
            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        _repository.Owner.UpdateOwner(dbOwner, owner);
        _repository.Save();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOwner(Guid id)
    {
        var owner = _repository.Owner.GetOwnerById(id);

        if (owner.IsEmptyObject())
        {
            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        _repository.Owner.DeleteOwner(owner);
        _repository.Save();

        return NoContent();
    }

    private List<Link> CreateLinksForOwner(Guid id, string? fields = "")
    {
        var links = new List<Link>
        {
            new(_linkGenerator.GetUriByAction(HttpContext, nameof(GetOwnerById), values: new { id, fields })!,
                "self",
                "GET"),

            new(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteOwner), values: new { id })!,
                "delete_owner",
                "DELETE"),

            new(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateOwner), values: new { id })!,
                "update_owner",
                "PUT")
        };

        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForOwners(LinkCollectionWrapper<Entity> ownersWrapper)
    {
        ownersWrapper.Links.Add(new Link(
            _linkGenerator.GetUriByAction(HttpContext, nameof(GetOwners), values: null)!,
            "self",
            "GET"));

        return ownersWrapper;
    }
}
