using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using oodajze.backend.Models;
using oodajze.backend.Services;

namespace oodajze.backend.Controllers
{
    [ApiController]
    [Route("coupons")]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsService _couponsService;

        public CouponsController(ICouponsService couponsService)
        {
            _couponsService = couponsService;
        }

        [HttpGet("templates")]
        public IActionResult GetAvailableCouponTemplates()
        {
            var coupons = _couponsService.GetAvailableCouponTemplates();
            return Ok(coupons);
        }

        [HttpPost("redeem")]
        public IActionResult RedeemCoupon([FromBody] RedeemCouponRequest request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out int userId))
                return Unauthorized("Invalid user ID");

            if (!_couponsService.TryRedeemCoupon(userId, request.CouponTemplateId, out string errorMessage))
                return BadRequest(new { error = errorMessage });

            return Ok(new { message = "Coupon redeemed successfully" });
        }
    }
}