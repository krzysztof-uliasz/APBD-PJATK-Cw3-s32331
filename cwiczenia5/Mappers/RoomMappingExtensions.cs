using cwiczenia5.DTOs;
using cwiczenia5.Models;

namespace cwiczenia5.Mappers;

public static class RoomMappingExtensions
{
    public static Room ToDomain(this RoomDto dto)
    {
        return new Room
        {
            Id = dto.Id,
            Name = dto.Name,
            BuildingCode = dto.BuildingCode,
            Floor = dto.Floor,
            Capacity = dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive,
        };
    }

    public static Room ToDomain(this CreateRoomDto dto)
    {
        return new Room
        {
            Name = dto.Name,
            BuildingCode = dto.BuildingCode,
            Floor = dto.Floor,
            Capacity = dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive,
        };
    }

    public static Room ToDomain(this UpdateRoomDto dto)
    {
        return new Room
        {
            Name = dto.Name,
            BuildingCode = dto.BuildingCode,
            Floor = dto.Floor,
            Capacity = dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive,
        };
    }
    
    public static RoomDto ToDto(this Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            BuildingCode = room.BuildingCode,
            Floor = room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive,
        };
    }
}