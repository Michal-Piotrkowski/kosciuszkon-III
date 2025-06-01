using oodajze.backend.Dtos;
using oodajze.backend.Models;
using Microsoft.EntityFrameworkCore;
using oodajze.backend.DTOs;

namespace oodajze.backend.Services;

public class UsersService : IUsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
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
    
    public UserDto GetUserById(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            Phone = user.Phone,
            TotalPoints = user.TotalPoints,
            JoinDate = user.JoinDate
        };
    }
    
    public async Task<(bool Success, int NewTotalPoints)> RedeemQrCodeAndAddPointsAsync(string qrCode)
    {
        var visit = await _context.CollectionVisitQrData
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.QrCode == qrCode);

        if (visit == null)
            return (false, 0);
        
        visit.User.TotalPoints += visit.PointsEarned;
        
        visit.ScannedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return (true, visit.User.TotalPoints);
    }

}