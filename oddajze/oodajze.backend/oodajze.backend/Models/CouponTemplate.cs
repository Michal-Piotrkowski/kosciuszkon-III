namespace oodajze.backend.Models;

public class CouponTemplate
{
    public int Id { get; set; }              
    public string Title { get; set; }           
    public string Description { get; set; }     
    public int PointsRequired { get; set; }     
    public string ImageUrl { get; set; }        
    public bool Available { get; set; }         
}

