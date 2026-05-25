using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Mappers;
using cwiczenia5.Repositories;

namespace cwiczenia5.Services;

public class RoomService(IRoomRepository repository) : IRoomService
{
    public IEnumerable<RoomDto> GetAll(string? buildingCode)
    {
        return (string.IsNullOrEmpty(buildingCode)
                ? repository.GetAll()
                : repository.GetByBuildingCode(buildingCode))
            .Select(room => room.ToDto());
    }

    public RoomDto GetById(int id)
    {
        var room = repository.GetById(id);

        return room is null 
            ? throw new RoomNotFoundException(id) 
            : room.ToDto();
    }

    public RoomDto Add(CreateRoomDto room)
    {
        var roomToAdd = room.ToDomain();
        repository.Add(roomToAdd);
        
        return roomToAdd.ToDto();
    }

    public RoomDto Update(int id, UpdateRoomDto room)
    {
        var roomToUpdate = room.ToDomain();
        roomToUpdate.Id = id;

        return !repository.Update(roomToUpdate) 
            ? throw new RoomNotFoundException(id) 
            : roomToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var roomToDelete = repository.GetById(id);
        
        if (roomToDelete is null)
        {
            throw new RoomNotFoundException(id);
        }
        
        repository.Remove(roomToDelete);
    }
}