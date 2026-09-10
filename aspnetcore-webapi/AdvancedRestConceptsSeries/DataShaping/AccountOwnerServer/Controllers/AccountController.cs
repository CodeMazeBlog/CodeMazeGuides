using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

    public AccountController(ILoggerManager logger,
        IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entity>>> GetAccountsForOwner(Guid ownerId, [FromQuery] AccountParameters parameters)
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

        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public IActionResult GetAccountForOwner(Guid ownerId, Guid id, [FromQuery] string? fields)
    {
        var account = _repository.Account.GetAccountByOwner(ownerId, id);

        if (account.IsObjectNull())
        {
            _logger.LogError($"Account with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        return Ok(_repository.Account.GetAccountByOwner(ownerId, id, fields));
    }
}
