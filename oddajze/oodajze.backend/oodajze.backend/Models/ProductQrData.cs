using System.ComponentModel.DataAnnotations;

namespace oodajze.backend.Models;

public class ProductQrData
{
    [Key]
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BatchNumber { get; set; }
    public string MaterialType { get; set; }
    public string RecyclingCode { get; set; }
    public string? ImageUrl { get; set; }
    public int Points { get; set; }
}