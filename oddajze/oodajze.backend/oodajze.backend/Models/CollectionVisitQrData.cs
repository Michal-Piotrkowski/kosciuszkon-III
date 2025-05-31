using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace oodajze.backend.Models;

public class CollectionVisitQrData
{
    [Key]
    public string Id { get; set; }
    public string CollectionPointId { get; set; }
    public DateTime ScannedAt { get; set; }
    public int PointsEarned { get; set; }
    public List<ProductQrData> Products { get; set; } = new List<ProductQrData>();

    public CollectionPoint CollectionPoint { get; set; }

}