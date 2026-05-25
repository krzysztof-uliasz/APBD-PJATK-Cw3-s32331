using cwiczenia5.Enums;
using cwiczenia5.Models;

namespace cwiczenia5.Data;

public static class SeedData
{
    public static List<Room> Rooms =>
    [
        new Room { Id = 1, Name = "Lab 101", BuildingCode = "A", Floor = 1, Capacity = 20, HasProjector = true, IsActive = true },
        new Room { Id = 2, Name = "Lab 202", BuildingCode = "A", Floor = 2, Capacity = 30, HasProjector = true, IsActive = true },
        new Room { Id = 3, Name = "Sala 301", BuildingCode = "B", Floor = 3, Capacity = 15, HasProjector = false, IsActive = true },
        new Room { Id = 4, Name = "Sala 402", BuildingCode = "B", Floor = 4, Capacity = 40, HasProjector = true, IsActive = false },
        new Room { Id = 5, Name = "Konferencyjna", BuildingCode = "C", Floor = 1, Capacity = 50, HasProjector = true, IsActive = true },
    ];

    public static List<Reservation> Reservations =>
    [
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Anna Kowalska", Topic = "Warsztaty HTTP", Date = new DateOnly(2026, 6, 1), StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(11, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 2, RoomId = 1, OrganizerName = "Jan Nowak", Topic = "REST API Design", Date = new DateOnly(2026, 6, 2), StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(12, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 3, RoomId = 2, OrganizerName = "Maria Wiśniewska", Topic = "Bazy danych", Date = new DateOnly(2026, 6, 3), StartTime = new TimeOnly(13, 0), EndTime = new TimeOnly(15, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 4, RoomId = 3, OrganizerName = "Piotr Zając", Topic = "Konsultacje", Date = new DateOnly(2026, 6, 4), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(9, 0), Status = ReservationStatus.Cancelled },
        new Reservation { Id = 5, RoomId = 5, OrganizerName = "Anna Kowalska", Topic = "Spotkanie zespołu", Date = new DateOnly(2026, 6, 5), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(16, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 6, RoomId = 2, OrganizerName = "Jan Nowak", Topic = "Code Review", Date = new DateOnly(2026, 6, 6), StartTime = new TimeOnly(11, 0), EndTime = new TimeOnly(12, 30), Status = ReservationStatus.Confirmed },
    ];
}