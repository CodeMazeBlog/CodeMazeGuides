using AutoMapper;
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
    private readonly IMapper _mapper;

    public CarsController(CarDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarAsync([FromBody] UpsertCarDto carDto)
    {
        var car = _mapper.Map<UpsertCarDto, Car>(carDto);

        _context.RecordCars.Add(car);

        await _context.SaveChangesAsync();

        var carResponse = _mapper.Map<Car, CarDto>(car);

        return CreatedAtAction(nameof(GetCar), new { car.Id }, carResponse);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] UpsertCarDto updatedCar)
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var car = await _context.RecordCars.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }

        var carResponse = _mapper.Map<Car, CarDto>(car);

        return Ok(carResponse);
    }

    // Uncomment this to test System.InvalidOperationException
    //[HttpPut("car/{id:int}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> UpdateCarUsingRecords(int id, [FromBody] UpsertCarDto updatedCar)
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

        car = car with
        {
            Make = updatedCar.Make,
            Model = updatedCar.Model,
            Year = updatedCar.Year
        };

        _context.RecordCars.Update(car);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}