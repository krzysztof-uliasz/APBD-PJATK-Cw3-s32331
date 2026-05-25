using cwiczenia5.DTOs;
using cwiczenia5.Models;

namespace cwiczenia5.Services;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetAll(DateOnly? date, string? status, int? roomId);
    ReservationDto GetById(int id);
    ReservationDto Add(CreateReservationDto reservation);
    ReservationDto Update(int id, UpdateReservationDto reservation);
    void Remove(int id);
}