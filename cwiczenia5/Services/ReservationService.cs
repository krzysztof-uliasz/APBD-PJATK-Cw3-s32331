using cwiczenia5.DTOs;
using cwiczenia5.Exceptions;
using cwiczenia5.Mappers;
using cwiczenia5.Repositories;

namespace cwiczenia5.Services;

public class ReservationService(IReservationRepository repository) : IReservationService
{
    public IEnumerable<ReservationDto> GetAll(string? organizerName)
    {
        return (string.IsNullOrEmpty(organizerName)
                ? repository.GetAll()
                : repository.GetByOrganizerName(organizerName))
            .Select(reservation => reservation.ToDto());
    }

    public ReservationDto GetById(int id)
    {
        var reservation = repository.GetById(id);

        return reservation is null 
            ? throw new ReservationNotFoundException(id) 
            : reservation.ToDto();
    }

    public ReservationDto Add(CreateReservationDto reservation)
    {
        var reservationToAdd = reservation.ToDomain();
        repository.Add(reservationToAdd);
        
        return reservationToAdd.ToDto();
    }

    public ReservationDto Update(int id, UpdateReservationDto reservation)
    {
        var reservationToUpdate = reservation.ToDomain();
        reservationToUpdate.Id = id;

        return !repository.Update(reservationToUpdate) 
            ? throw new ReservationNotFoundException(id) 
            : reservationToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var reservationToDelete = repository.GetById(id);
        
        if (reservationToDelete is null)
        {
            throw new ReservationNotFoundException(id);
        }
        
        repository.Remove(reservationToDelete);
    }
}