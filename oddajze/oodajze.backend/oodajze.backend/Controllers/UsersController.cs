using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        var user = _usersService.GetUserById(userId);
        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }

    [HttpGet("ranking")]
    [AllowAnonymous]
    public IActionResult GetTopCollectors()
    {
        var topUsers = _usersService.GetTopUsersByPoints();
        return Ok(topUsers);
    }
}