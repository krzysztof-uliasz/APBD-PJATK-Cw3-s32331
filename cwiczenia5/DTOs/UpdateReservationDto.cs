using System.ComponentModel.DataAnnotations;
using cwiczenia5.Enums;

namespace cwiczenia5.DTOs;

public class UpdateReservationDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int RoomId { get; set; }
    [MaxLength(100), Required]
    public string OrganizerName { get; set; } = string.Empty;
    [MaxLength(100), Required]
    public string Topic { get; set; } = string.Empty;
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public ReservationStatus Status { get; set; }
}