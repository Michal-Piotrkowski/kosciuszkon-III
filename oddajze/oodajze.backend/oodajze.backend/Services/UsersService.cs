using oodajze.backend.Dtos;
using oodajze.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace oodajze.backend.Services;

public class UsersService : IUsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.Id == userId);
    }

    public List<UserRankingDto> GetTopUsersByPoints(int count = 10)
    {
        return _context.Users
            .OrderByDescending(u => u.TotalPoints)
            .Take(count)
            .Select(u => new UserRankingDto
            {
                Id = u.Id,
                Username = u.Username,
                TotalPoints = u.TotalPoints
            })
            .ToList();
    }

    public List<UserCouponDto> GetActiveCouponsForUser(int userId)
    {
        return _context.UserCoupons
            .Where(uc => uc.UserId == userId && !uc.IsUsed)
            .Include(uc => uc.CouponTemplate) 
            .Select(uc => new UserCouponDto
            {
                Id = uc.Id,
                RedemptionCode = uc.RedemptionCode,
                RedeemedAt = uc.RedeemedAt,
                IsUsed = uc.IsUsed,
                CouponName = uc.CouponTemplate.Title, 
                CouponDescription = uc.CouponTemplate.Description
            })
            .ToList();
    }
}