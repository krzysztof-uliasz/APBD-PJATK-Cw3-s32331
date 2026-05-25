using cwiczenia5.DTOs;

namespace cwiczenia5.Services;

public interface IRoomService
{
    IEnumerable<RoomDto> GetAll(string? buildingCode);
    RoomDto GetById(int id);
    RoomDto Add(CreateRoomDto room);
    RoomDto Update(int id, UpdateRoomDto room);
    void Remove(int id);
}