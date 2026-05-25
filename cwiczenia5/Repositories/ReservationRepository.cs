using cwiczenia5.Data;
using cwiczenia5.Models;

namespace cwiczenia5.Repositories;

public class ReservationRepository : IReservationRepository
{
    private static int _nextId = 7; // start after seed data
    private readonly List<Reservation> _reservations = SeedData.Reservations;

    public IEnumerable<Reservation> GetAll()
    {
        return _reservations;
    }

    public IEnumerable<Reservation> GetByOrganizerName(string organizerName)
    {
        return _reservations.Where(x => x.OrganizerName == organizerName);
    }

    public Reservation? GetById(int id)
    {
        return _reservations.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Reservation reservation)
    {
        reservation.Id = _nextId++;
        _reservations.Add(reservation);
    }

    public bool Update(Reservation reservation)
    {
        var existing = GetById(reservation.Id);
        if (existing is null)
        {
            return false;
        }

        existing.RoomId = reservation.RoomId;
        existing.OrganizerName = reservation.OrganizerName;
        existing.Topic = reservation.Topic;
        existing.StartTime = reservation.StartTime;
        existing.EndTime = reservation.EndTime;
        existing.Date = reservation.Date;
        existing.Status = reservation.Status;
        return true;
    }

    public void Remove(Reservation reservation)
    {
        _reservations.Remove(reservation);
    }

    public bool Exists(int id)
    {
        return _reservations.Any(x => x.Id == id);
    }
}