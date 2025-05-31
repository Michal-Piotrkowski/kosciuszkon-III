namespace oodajze.backend.Models;

public class UserCoupon
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CouponTemplateId { get; set; }
    public DateTime RedeemedAt { get; set; }
    public bool IsUsed { get; set; }
    public string RedemptionCode { get; set; }
}

