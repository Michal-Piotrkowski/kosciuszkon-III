using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace oodajze.backend.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController (AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("me")]
    public IActionResult GetMe()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userIdString, out int userId))
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
        else
        {
        
            return Unauthorized("Invalid user ID");
        }
        
    }
}