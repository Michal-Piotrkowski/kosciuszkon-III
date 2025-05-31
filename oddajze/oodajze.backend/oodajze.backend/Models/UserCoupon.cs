namespace oodajze.backend.Models;

public class UserCoupon
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string CouponTemplateId { get; set; }
    public DateTime RedeemedAt { get; set; }
    public bool IsUsed { get; set; }
    public string RedemptionCode { get; set; }
}

