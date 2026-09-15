using AccountOwnerServer.Filters;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace AccountOwnerServer.Controllers;

[Route("api/owners/{ownerId}/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly LinkGenerator _linkGenerator;

    public AccountController(ILoggerManager logger,
        IRepositoryWrapper repository,
        LinkGenerator linkGenerator)
    {
        _logger = logger;
        _repository = repository;
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetAccountsForOwner(Guid ownerId, [FromQuery] AccountParameters parameters)
    {
        var accounts = await _repository.Account.GetAccountsByOwner(ownerId, parameters);

        var metadata = new
        {
            accounts.TotalCount,
            accounts.PageSize,
            accounts.CurrentPage,
            accounts.TotalPages,
            accounts.HasNext,
            accounts.HasPrevious
        };

        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metadata);

        _logger.LogInfo($"Returned {accounts.TotalCount} accounts from database.");

        var shapedAccounts = accounts.Select(a => a.Entity).ToList();

        var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"]!;

        if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
            return Ok(shapedAccounts);

        for (var index = 0; index < accounts.Count; index++)
            shapedAccounts[index].Add("Links", CreateLinksForAccount(ownerId, accounts[index].Id, parameters.Fields));

        var accountsWrapper = new LinkCollectionWrapper<Entity>(shapedAccounts);

        return Ok(CreateLinksForAccounts(accountsWrapper));
    }

    [HttpGet("{id}")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public IActionResult GetAccountForOwner(Guid ownerId, Guid id, [FromQuery] string? fields)
    {
        var account = _repository.Account.GetAccountByOwner(ownerId, id, fields);

        if (account.Id == Guid.Empty)
        {
            _logger.LogError($"Account with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        var mediaType = (MediaTypeHeaderValue)HttpContext.Items["AcceptHeaderMediaType"]!;

        if (!mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase))
        {
            _logger.LogInfo($"Returned a shaped account with id: {id}");
            return Ok(account.Entity);
        }

        account.Entity.Add("Links", CreateLinksForAccount(ownerId, id, fields));

        return Ok(account.Entity);
    }

    private List<Link> CreateLinksForAccount(Guid ownerId, Guid id, string? fields = "")
    {
        var links = new List<Link>
        {
            new(_linkGenerator.GetUriByAction(HttpContext, nameof(GetAccountForOwner), values: new { ownerId, id, fields })!,
                "self",
                "GET")
        };

        return links;
    }

    private LinkCollectionWrapper<Entity> CreateLinksForAccounts(LinkCollectionWrapper<Entity> accountsWrapper)
    {
        accountsWrapper.Links.Add(new Link(
            _linkGenerator.GetUriByAction(HttpContext, nameof(GetAccountsForOwner), values: null)!,
            "self",
            "GET"));

        return accountsWrapper;
    }
}
