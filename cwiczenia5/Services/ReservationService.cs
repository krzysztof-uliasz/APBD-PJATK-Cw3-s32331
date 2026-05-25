using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Mappers;
using cwiczenia5.Repositories;

namespace cwiczenia5.Services;

public class ReservationService(
    IReservationRepository reservationRepository,
    IRoomRepository roomRepository) : IReservationService
{
    public IEnumerable<ReservationDto> GetAll(DateOnly? date, string? status, int? roomId)
    {
        var result = reservationRepository.GetAll();

        if (date.HasValue)
            result = result.Where(r => r.Date == date.Value);

        if (!string.IsNullOrEmpty(status))
            result = result.Where(r => r.Status.ToString().ToLower() == status.ToLower());

        if (roomId.HasValue)
            result = result.Where(r => r.RoomId == roomId.Value);

        return result.Select(r => r.ToDto());
    }

    public ReservationDto GetById(int id)
    {
        var reservation = reservationRepository.GetById(id);

        return reservation is null 
            ? throw new ReservationNotFoundException(id) 
            : reservation.ToDto();
    }

    public ReservationDto Add(CreateReservationDto dto)
    {
        // 1. Room must exist
        var room = roomRepository.GetById(dto.RoomId);
        if (room is null)
            throw new RoomNotFoundException(dto.RoomId);

        // 2. Room must be active
        if (!room.IsActive)
            throw new RoomNotActiveException(dto.RoomId);

        // 3. No time overlap on the same day for the same room
        var conflict = reservationRepository.GetAll()
            .Any(r => r.RoomId == dto.RoomId
                      && r.Date == dto.Date
                      && r.StartTime < dto.EndTime
                      && dto.StartTime < r.EndTime);

        if (conflict)
            throw new ReservationConflictException(dto.RoomId);

        var reservationToAdd = dto.ToDomain();
        reservationRepository.Add(reservationToAdd);
        return reservationToAdd.ToDto();
    }

    public ReservationDto Update(int id, UpdateReservationDto reservation)
    {
        var reservationToUpdate = reservation.ToDomain();
        reservationToUpdate.Id = id;

        return !reservationRepository.Update(reservationToUpdate) 
            ? throw new ReservationNotFoundException(id) 
            : reservationToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var reservationToDelete = reservationRepository.GetById(id);
        
        if (reservationToDelete is null)
        {
            throw new ReservationNotFoundException(id);
        }
        
        reservationRepository.Remove(reservationToDelete);
    }
}