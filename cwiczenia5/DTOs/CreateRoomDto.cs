using System.ComponentModel.DataAnnotations;

namespace cwiczenia5.DTOs;

public class CreateRoomDto
{
    [Required]
    public int Id { get; set; }
    [MaxLength(100), Required]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100), Required]
    public string BuildingCode { get; set; } = string.Empty;
    [Required]
    public int Floor { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public bool HasProjector { get; set; }
    [Required]
    public bool IsActive { get; set; }
}