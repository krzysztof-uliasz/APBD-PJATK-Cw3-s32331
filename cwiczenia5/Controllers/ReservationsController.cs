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
    public IActionResult GetAll(
        [FromQuery] DateOnly? date,
        [FromQuery] string? status,
        [FromQuery] int? roomId)
    {
        return Ok(service.GetAll(date, status, roomId));
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
    public IActionResult Add([FromBody] CreateReservationDto dto)
    {
        try
        {
            var created = service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomNotActiveException e)
        {
            return BadRequest(e.Message);
        }
        catch (ReservationConflictException e)
        {
            return Conflict(e.Message);
        }
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