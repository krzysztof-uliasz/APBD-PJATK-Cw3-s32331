using cwiczenia5.Models;

namespace cwiczenia5.Repositories;

public interface IRoomRepository
{
    IEnumerable<Room> GetAll(); 
    IEnumerable<Room> GetByBuildingCode(string buildingCode);
    Room? GetById(int id);
    void Add(Room room);
    bool Update(Room room);
    void Remove(Room room);
    bool Exists(int id);
}