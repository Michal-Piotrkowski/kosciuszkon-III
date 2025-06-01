using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace oodajze.backend.Models;

public class CollectionVisitQrData
{
    [Key]
    public int Id { get; set; }
    public int CollectionPointId { get; set; }
    public int? UserId { get; set; } 
    public string QrCode { get; set; }
    public DateTime ScannedAt { get; set; }
    public int PointsEarned { get; set; }
    public List<ProductQrData> Products { get; set; } = new List<ProductQrData>();
    public CollectionPoint? CollectionPoint { get; set; }
    public User? User { get; set; } 
}