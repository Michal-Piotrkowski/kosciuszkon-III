namespace oodajze.backend.Models;

public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }             
    public string PasswordHash { get; set; } 
    public string Phone { get; set; }
    public int TotalPoints { get; set; }
    public List<UserCoupon> RedeemedCoupons { get; set; } = new List<UserCoupon>(); 
    public DateTime JoinDate { get; set; }
    public List<CollectionVisitQrData> CollectionVisitQrDataHistory { get; set; } = new List<CollectionVisitQrData>();
}