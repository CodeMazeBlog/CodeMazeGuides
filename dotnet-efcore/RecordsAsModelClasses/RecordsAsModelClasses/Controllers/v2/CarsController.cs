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

        public CarsController(CarDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> CreateCar([FromBody] UpsertCarDto carDto)
        {
            var car = new Car
            {
                Make = carDto.Make,
                Model = carDto.Model,
                Year = carDto.Year
            };

            _context.ClassCars.Add(car);

            await _context.SaveChangesAsync();

            var carResponse = new CarDto(car.Id, car.Make, car.Model, car.Year);

            return CreatedAtAction(nameof(GetCar), new {car.Id}, carResponse);
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

            car.Model = carDto.Model;
            car.Make = carDto.Make;
            car.Year = carDto.Year;

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

            var carResponse = new CarDto(car.Id, car.Make, car.Model, car.Year);

            return Ok(carResponse);
        }
    }
}