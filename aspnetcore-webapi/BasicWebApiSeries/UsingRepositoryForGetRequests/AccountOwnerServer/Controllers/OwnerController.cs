using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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

        // No try/catch anywhere in this controller. Exceptions are handled once, by the
        // IExceptionHandler registered in Program.cs.
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _repository.Owner.GetAllOwnersAsync();
            _logger.LogInfo("Returned all owners from database.");

            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResult);
        }

        [HttpGet("{id}")]
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
    }
}
