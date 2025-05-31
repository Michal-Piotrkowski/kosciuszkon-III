using Microsoft.AspNetCore.Mvc;
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
    }
}