using oodajze.backend.Dtos;
using oodajze.backend.Models;

namespace oodajze.backend.Services
{
    public interface IUsersService
    {
        List<UserRankingDto> GetTopUsersByPoints(int count = 10);
        User? GetUserById(int userId);
        List<UserCouponDto> GetActiveCouponsForUser(int userId);
    }
}