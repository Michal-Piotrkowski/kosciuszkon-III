using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oodajze.backend.Dtos;
using oodajze.backend.Models;
using oodajze.backend.Services;

namespace oodajze.backend.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IUsersService _usersService;

    public UsersController(AppDbContext context, IUsersService usersService)
    {
        _context = context;
        _usersService = usersService;
    }

    [HttpGet("me")]
    public IActionResult GetMe()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdString, out int userId))
        {
            return Unauthorized("Invalid user ID");
        }

        var userDto = _usersService.GetUserById(userId);
        if (userDto == null)
        {
            return NotFound("User not found");
        }

        return Ok(userDto);
    }

    [HttpGet("me/coupons")]
    public IActionResult GetMyActiveCoupons()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdString, out int userId))
        {
            return Unauthorized("Invalid user ID");
        }

        var coupons = _usersService.GetActiveCouponsForUser(userId);

        return Ok(coupons);
    }
    
    [HttpGet("lastReturns")]
    public async Task<IActionResult> GetLastReturns()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            Console.WriteLine($"[WARN] Nieprawidłowe ID użytkownika: {userIdString}");
            return BadRequest("Nieprawidłowe ID użytkownika");
        }

        Console.WriteLine($"[INFO] Pobieranie ostatnich wizyt dla użytkownika ID: {userId}");

        var lastVisits = await _context.CollectionVisitQrData
            .Where(cv => cv.UserId == userId)
            .OrderByDescending(cv => cv.ScannedAt)
            .Take(10)
            .Include(cv => cv.Products)
            .ToListAsync();

        Console.WriteLine($"[INFO] Znaleziono {lastVisits.Count} wizyt");

        foreach (var visit in lastVisits)
        {
            Console.WriteLine($"[INFO] Wizyta ID: {visit.Id}, Data: {visit.ScannedAt}, Liczba produktów: {visit.Products?.Count ?? 0}");

            if (visit.Products != null)
            {
                foreach (var product in visit.Products)
                {
                    Console.WriteLine($"[INFO]  - Produkt: ID={product.Id}, Name={product.Name}, Points={product.Points}, ImageUrl={product.ImageUrl}");
                }
            }
        }

        var lastProducts = lastVisits
            .SelectMany(cv => cv.Products.Select(p => new 
            {
                p.Id,
                p.Name,
                p.Points,
                p.ImageUrl,
                VisitDate = cv.ScannedAt
            }))
            .Take(10)
            .ToList();

        Console.WriteLine($"[INFO] Łącznie produktów do zwrócenia: {lastProducts.Count}");

        foreach (var p in lastProducts)
        {
            Console.WriteLine($"[INFO] Zwracany produkt: ID={p.Id}, Name={p.Name}, Points={p.Points}, VisitDate={p.VisitDate}");
        }

        return Ok(lastProducts);
    }
    [HttpGet("ranking")]
    public IActionResult GetTopCollectors()
    {
        var topUsers = _usersService.GetTopUsersByPoints();
        return Ok(topUsers);
    }
    
    [HttpPost("redeem")]
    public async Task<int?> RedeemQrCodeAndAddPointsAsync(string qrCode)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            throw new InvalidOperationException("Invalid user ID");
        }

        var collectionVisit = await _context.CollectionVisitQrData
            .FirstOrDefaultAsync(c => c.QrCode == qrCode);
        
        if (collectionVisit == null)
        {
            return null;
        }

        if (collectionVisit.UserId != null)
        {
            throw new InvalidOperationException("QR code already redeemed");
        }

        var currentUser = await _context.Users
            .Include(u => u.CollectionVisitQrDataHistory)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (currentUser == null)
        {
            throw new InvalidOperationException("User not found");
        }

        collectionVisit.UserId = userId;
        collectionVisit.User = currentUser;
    
        currentUser.TotalPoints += collectionVisit.PointsEarned;

        currentUser.CollectionVisitQrDataHistory ??= new List<CollectionVisitQrData>();
        currentUser.CollectionVisitQrDataHistory.Add(collectionVisit);

        try
        {
            await _context.SaveChangesAsync();
            return currentUser.TotalPoints;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Failed to save changes");
        }
    }


}