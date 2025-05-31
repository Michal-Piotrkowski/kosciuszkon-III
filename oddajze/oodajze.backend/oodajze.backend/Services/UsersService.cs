using oodajze.backend.Dtos;
using oodajze.backend.Models;

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
}