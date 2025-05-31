using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oodajze.backend.Models;

public class CollectionPoint
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }        
    public double Latitude { get; set; }      
    public double Longitude { get; set; }    
}