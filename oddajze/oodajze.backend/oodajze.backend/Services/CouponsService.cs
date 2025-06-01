using System.Collections.Generic;
using System.Linq;
using oodajze.backend.Models;

namespace oodajze.backend.Services
{
    
    public class CouponsService : ICouponsService
    {
        private readonly AppDbContext _context;

        public CouponsService(AppDbContext context)
        {
            _context = context;
        }

        public List<CouponTemplate> GetAvailableCouponTemplates()
        {
            return _context.CouponTemplates
                .Where(c => c.Available)
                .ToList();
        }
        
        public bool TryRedeemCoupon(int userId, int couponTemplateId, out string errorMessage)
        {
            errorMessage = string.Empty;

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                errorMessage = "User not found";
                return false;
            }

            var couponTemplate = _context.CouponTemplates.FirstOrDefault(c => c.Id == couponTemplateId && c.Available);
            if (couponTemplate == null)
            {
                errorMessage = "Coupon template not found or not available";
                return false;
            }

            if (user.TotalPoints < couponTemplate.PointsRequired)
            {
                errorMessage = "Insufficient points";
                return false;
            }
        
            user.TotalPoints -= couponTemplate.PointsRequired;

            var userCoupon = new UserCoupon
            {
                UserId = user.Id,
                CouponTemplateId = couponTemplate.Id,
                RedeemedAt = DateTime.UtcNow,
                IsUsed = false,
                RedemptionCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()
            };

            _context.UserCoupons.Add(userCoupon);

            _context.SaveChanges();

            return true;
        }
    }
    
   
}