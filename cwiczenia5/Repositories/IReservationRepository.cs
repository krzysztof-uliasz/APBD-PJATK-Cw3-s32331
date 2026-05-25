using cwiczenia5.Models;

namespace cwiczenia5.Repositories;

public interface IReservationRepository
{
    IEnumerable<Reservation> GetAll(); 
    IEnumerable<Reservation> GetByOrganizerName(string organizerName);
    Reservation? GetById(int id);
    void Add(Reservation reservation);
    bool Update(Reservation reservation);
    void Remove(Reservation reservation);
    bool Exists(int id);
}