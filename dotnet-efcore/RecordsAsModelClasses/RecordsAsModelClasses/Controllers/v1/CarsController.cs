using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordsAsModelClasses.Core.Context;
using RecordsAsModelClasses.Core.DTOs;
using RecordsAsModelClasses.Core.Entities.Records;

namespace RecordsAsModelClasses.Controllers.v1;

[Route("api/v1/cars")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarDbContext _context;

    public CarsController(CarDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarAsync()
    {
        var car = new RecordCar(1, "Toyota", "Crown", 1952);

        _context.RecordCars.Add(car);
        await _context.SaveChangesAsync();

        return Created("api/v1/cars", car);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDto updatedCar)
    {
        var car = await _context
            .RecordCars
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
    public async Task<IActionResult> UpdateCarUsingRecords(int id, [FromBody] RecordCar updatedRecordCar)
    {
        var car = await _context
            .RecordCars
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (car == null)
        {
            return NotFound();
        }

        car = car with { Make = updatedRecordCar.Make, Model = updatedRecordCar.Model, Year = updatedRecordCar.Year };

        _context.RecordCars.Update(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}