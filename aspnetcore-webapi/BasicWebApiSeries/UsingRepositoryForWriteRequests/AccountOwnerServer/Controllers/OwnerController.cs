using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // No try/catch and no model-state guards. [ApiController] rejects an empty or
        // invalid body with a 400 and a ValidationProblemDetails before the action runs,
        // and everything else is handled by the IExceptionHandler in Program.cs.
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _repository.Owner.GetAllOwnersAsync();
            _logger.LogInfo("Returned all owners from database.");

            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResult);
        }

        // The route is named because CreatedAtRoute looks it up by name to build the
        // Location header. The name is OwnerById and it does not change with the method.
        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await _repository.Owner.GetOwnerByIdAsync(id);
            if (owner is null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _logger.LogInfo($"Returned owner with id: {id}");

            var ownerResult = _mapper.Map<OwnerDto>(owner);
            return Ok(ownerResult);
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            var owner = await _repository.Owner.GetOwnerWithDetailsAsync(id);
            if (owner is null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _logger.LogInfo($"Returned owner with details for id: {id}");

            var ownerResult = _mapper.Map<OwnerDto>(owner);
            return Ok(ownerResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            var ownerEntity = _mapper.Map<Owner>(owner);

            _repository.Owner.CreateOwner(ownerEntity);
            await _repository.SaveAsync();

            var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

            return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            var ownerEntity = await _repository.Owner.GetOwnerByIdAsync(id);
            if (ownerEntity is null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            // Map onto the entity we just read: properties the DTO does not carry, the
            // id and the accounts among them, keep the values they already have.
            _mapper.Map(owner, ownerEntity);

            _repository.Owner.UpdateOwner(ownerEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var owner = await _repository.Owner.GetOwnerByIdAsync(id);
            if (owner is null)
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            // The pre-check buys a readable error message. The foreign key is the real
            // guard: an account inserted between this check and the save makes the
            // delete fail with a DbUpdateException wrapping SqlException 547.
            var accounts = await _repository.Account.AccountsByOwnerAsync(id);
            if (accounts.Any())
            {
                _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts.");
                return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
            }

            _repository.Owner.DeleteOwner(owner);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
