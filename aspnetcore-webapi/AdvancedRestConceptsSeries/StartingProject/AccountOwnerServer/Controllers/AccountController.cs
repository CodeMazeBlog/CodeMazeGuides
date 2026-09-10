using Contracts;
using Entities.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AccountOwnerServer.Controllers;

[Route("api/owners/{ownerId}/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IRepositoryWrapper _repository;

    public AccountController(ILoggerManager logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAccountsForOwner(Guid ownerId)
    {
        var accounts = _repository.Account.GetAccountsByOwner(ownerId);

        _logger.LogInfo("Returned all accounts from database.");

        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public IActionResult GetAccountForOwner(Guid ownerId, Guid id)
    {
        var account = _repository.Account.GetAccountByOwner(ownerId, id);

        if (account.IsObjectNull())
        {
            _logger.LogError($"Account with id: {id}, hasn't been found in db.");
            return NotFound();
        }

        return Ok(account);
    }
}
