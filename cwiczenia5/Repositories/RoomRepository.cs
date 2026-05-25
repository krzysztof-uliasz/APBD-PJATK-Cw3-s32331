using cwiczenia5.Data;
using cwiczenia5.Models;

namespace cwiczenia5.Repositories;

public class RoomRepository : IRoomRepository
{
    private static int _nextId = 6; // start after seed data
    private readonly List<Room> _rooms = SeedData.Rooms;
    
    public IEnumerable<Room> GetAll()
    {
        return _rooms;
    }

    public IEnumerable<Room> GetByBuildingCode(string buildingCode)
    {
        return _rooms.Where(x => x.BuildingCode == buildingCode);
    }

    public Room? GetById(int id)
    {
        return _rooms.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Room room)
    {
        room.Id = _nextId++;
        _rooms.Add(room);
    }

    public bool Update(Room room)
    {
        var existing = GetById(room.Id);
        if (existing is null)
        {
            return false;
        }
        
        existing.Name = room.Name;
        existing.BuildingCode = room.BuildingCode;
        existing.Floor = room.Floor;
        existing.Capacity = room.Capacity;
        existing.HasProjector = room.HasProjector;
        existing.IsActive = room.IsActive;
        return true;
    }

    public void Remove(Room room)
    {
        _rooms.Remove(room);
    }

    public bool Exists(int id)
    {
        return _rooms.Any(x => x.Id == id);
    }
}