using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? organizerName)
    {
        return Ok(service.GetAll(organizerName));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok(service.GetById(id));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateReservationDto room)
    {
        var createdReservation = service.Add(room);
        
        return CreatedAtAction(
            nameof(GetById), 
            new { id = createdReservation.Id },
            createdReservation
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateReservationDto room
    )
    {
        try
        {
            return Ok(service.Update(id, room));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            service.Remove(id);
            return NoContent();
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}