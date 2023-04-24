using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Context;
using RecordsAsModelClasses.Core.DTOs;
using RecordsAsModelClasses.Core.Entities;

namespace RecordsAsModelClasses.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarDbContext _context;

    public CarsController(CarDbContext context)
    {
        _context = context;
    }

    [HttpPost("create-car")]
    public async Task<IActionResult> CreateCarAsync()
    {
        var car = new Car(1, "Toyota", "Crown", 1952);

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return Ok(car);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDto updatedCar)
    {
        var car = await _context
            .Cars
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (car == null)
        {
            return NotFound();
        }

        _context.Entry(car).CurrentValues.SetValues(updatedCar);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("car/{id:int}")]
    public async Task<IActionResult> UpdateCarUsingRecords(int id, [FromBody] Car updatedCar)
    {
        var car = await _context
            .Cars
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (car == null)
        {
            return NotFound();
        }

        car = car with {Make = updatedCar.Make, Model = updatedCar.Model, Year = updatedCar.Year};

        _context.Cars.Update(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("create-vintage-car")]
    public async Task<ActionResult<VintageCarDto>> CreateVintageCar([FromBody] VintageCarDto carDto)
    {
        var car = new VintageCar
        {
            Make = carDto.Make,
            Model = carDto.Model,
            Year = carDto.Year
        };

        _context.VintageCars.Add(car);
        await _context.SaveChangesAsync();

        return Ok(carDto);
    }

    [HttpPut("vintage-car/{id:int}")]
    public async Task<IActionResult> UpdateVintageCar(int id, [FromBody] VintageCarDto vintageCarDto)
    {
        var car = await _context.VintageCars.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        car.Make = vintageCarDto.Make;
        car.Model = vintageCarDto.Model;
        car.Year = vintageCarDto.Year;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}