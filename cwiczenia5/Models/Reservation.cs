using cwiczenia5.Enums;

namespace cwiczenia5.Models;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime Date { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
    public ReservationStatus Status { get; set; }
}