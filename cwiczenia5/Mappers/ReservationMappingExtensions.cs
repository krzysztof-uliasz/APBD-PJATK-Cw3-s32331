using cwiczenia5.DTOs;
using cwiczenia5.Models;

namespace cwiczenia5.Mappers;

public static class ReservationMappingExtensions
{
    public static Reservation ToDomain(this ReservationDto dto)
    {
        return new Reservation
        {
            Id = dto.Id,
            RoomId = dto.RoomId,
            OrganizerName =  dto.OrganizerName,
            Topic =  dto.Topic,
            StartTime =  dto.StartTime,
            EndTime =  dto.EndTime,
            Date = dto.Date,
            Status = dto.Status,
        };
    }

    public static Reservation ToDomain(this CreateReservationDto dto)
    {
        return new Reservation
        {
            RoomId = dto.RoomId,
            OrganizerName =  dto.OrganizerName,
            Topic =  dto.Topic,
            StartTime =  dto.StartTime,
            EndTime =  dto.EndTime,
            Date = dto.Date,
            Status = dto.Status,
        };
    }

    public static Reservation ToDomain(this UpdateReservationDto dto)
    {
        return new Reservation
        {
            RoomId = dto.RoomId,
            OrganizerName =  dto.OrganizerName,
            Topic =  dto.Topic,
            StartTime =  dto.StartTime,
            EndTime =  dto.EndTime,
            Date = dto.Date,
            Status = dto.Status,
        };
    }
    
    public static ReservationDto ToDto(this Reservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            OrganizerName =  reservation.OrganizerName,
            Topic =  reservation.Topic,
            StartTime =  reservation.StartTime,
            EndTime =  reservation.EndTime,
            Date = reservation.Date,
            Status = reservation.Status,
        };
    }
}