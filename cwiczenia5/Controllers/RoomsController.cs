using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? buildingCode)
    {
        return Ok(service.GetAll(buildingCode));
    }
    
    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuilding([FromRoute] string buildingCode)
    {
        return Ok(service.GetAll(buildingCode));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok(service.GetById(id));
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateRoomDto room)
    {
        var createdRoom = service.Add(room);
        
        return CreatedAtAction(
            nameof(GetById), 
            new { id = createdRoom.Id },
            createdRoom
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateRoomDto room
    )
    {
        try
        {
            return Ok(service.Update(id, room));
        }
        catch (RoomNotFoundException e)
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
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomHasReservationsException e)
        {
            return Conflict(e.Message);
        }
    }
}