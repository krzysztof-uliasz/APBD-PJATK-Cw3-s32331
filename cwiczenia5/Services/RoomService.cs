using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Mappers;
using cwiczenia5.Repositories;

namespace cwiczenia5.Services;

public class RoomService(
    IRoomRepository roomRepository,
    IReservationRepository reservationRepository) : IRoomService
{
    public IEnumerable<RoomDto> GetAll(string? buildingCode)
    {
        return (string.IsNullOrEmpty(buildingCode)
                ? roomRepository.GetAll()
                : roomRepository.GetByBuildingCode(buildingCode))
            .Select(room => room.ToDto());
    }

    public RoomDto GetById(int id)
    {
        var room = roomRepository.GetById(id);

        return room is null 
            ? throw new RoomNotFoundException(id) 
            : room.ToDto();
    }

    public RoomDto Add(CreateRoomDto room)
    {
        var roomToAdd = room.ToDomain();
        roomRepository.Add(roomToAdd);
        
        return roomToAdd.ToDto();
    }

    public RoomDto Update(int id, UpdateRoomDto room)
    {
        var roomToUpdate = room.ToDomain();
        roomToUpdate.Id = id;

        return !roomRepository.Update(roomToUpdate) 
            ? throw new RoomNotFoundException(id) 
            : roomToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var room = roomRepository.GetById(id);
        if (room is null)
            throw new RoomNotFoundException(id);

        var hasFutureReservations = reservationRepository.GetAll()
            .Any(r => r.RoomId == id && r.Date >= DateOnly.FromDateTime(DateTime.Today));

        if (hasFutureReservations)
            throw new RoomHasReservationsException(id);

        roomRepository.Remove(room);
    }
}