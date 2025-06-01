using oodajze.backend.Dtos;
using oodajze.backend.DTOs;
using oodajze.backend.Models;

namespace oodajze.backend.Services
{
    public interface IUsersService
    {
        List<UserRankingDto> GetTopUsersByPoints(int count = 10);
        List<UserCouponDto> GetActiveCouponsForUser(int userId);
        UserDto GetUserById(int userId);
        Task<(bool Success, int NewTotalPoints)> RedeemQrCodeAndAddPointsAsync(string qrCode);
    }
}