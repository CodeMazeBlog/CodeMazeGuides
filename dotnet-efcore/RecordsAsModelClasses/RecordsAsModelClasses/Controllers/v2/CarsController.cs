using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Context;
using RecordsAsModelClasses.Core.DTOs;
using RecordsAsModelClasses.Core.Entities.Classes;

namespace RecordsAsModelClasses.Controllers.v2
{
    [Route("api/v2/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(CarDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<CarDto>> CreateCar([FromBody] UpsertCarDto carDto)
        {
            var car = _mapper.Map<UpsertCarDto, Car>(carDto);

            _context.ClassCars.Add(car);

            await _context.SaveChangesAsync();

            var carResponse = _mapper.Map<Car, CarDto>(car);

            return CreatedAtAction(nameof(GetCar), new { car.Id }, carResponse);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] UpsertCarDto carDto)
        {
            var car = await _context
                .ClassCars
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (car == null)
            {
                return NotFound();
            }

            _mapper.Map<UpsertCarDto, Car>(carDto);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _context.ClassCars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var carResponse = _mapper.Map<Car, CarDto>(car);

            return Ok(carResponse);
        }
    }
}