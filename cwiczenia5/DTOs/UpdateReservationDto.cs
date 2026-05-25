using System.ComponentModel.DataAnnotations;
using cwiczenia5.Enums;

namespace cwiczenia5.DTOs;

public class UpdateReservationDto : IValidatableObject
{
    [Required]
    public int RoomId { get; set; }
    [MaxLength(100), Required]
    public string OrganizerName { get; set; } = string.Empty;
    [MaxLength(100), Required]
    public string Topic { get; set; } = string.Empty;
    [Required]
    public TimeOnly StartTime { get; set; }
    [Required]
    public TimeOnly EndTime { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public ReservationStatus Status { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime <= StartTime)
            yield return new ValidationResult(
                "EndTime must be later than StartTime.",
                [nameof(EndTime)]);
    }
}