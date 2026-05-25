using cwiczenia5.DTOs;
using cwiczenia5.Models;

namespace cwiczenia5.Services;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetAll(string? organizerName);
    ReservationDto GetById(int id);
    ReservationDto Add(CreateReservationDto reservation);
    ReservationDto Update(int id, UpdateReservationDto reservation);
    void Remove(int id);
}