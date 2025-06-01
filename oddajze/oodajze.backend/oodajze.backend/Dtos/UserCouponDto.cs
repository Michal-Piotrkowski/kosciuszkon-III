namespace oodajze.backend.Dtos;

public class UserCouponDto
{
    public int Id { get; set; }
    public DateTime RedeemedAt { get; set; }
    public bool IsUsed { get; set; }
    public string RedemptionCode { get; set; }
    public string CouponName { get; set; }
    public string CouponDescription { get; set; }
}
