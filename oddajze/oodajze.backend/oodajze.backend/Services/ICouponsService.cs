using oodajze.backend.Dtos;
using oodajze.backend.Models;

namespace oodajze.backend.Services
{
    public interface ICouponsService
    {
        List<CouponTemplate> GetAvailableCouponTemplates();
    }
}