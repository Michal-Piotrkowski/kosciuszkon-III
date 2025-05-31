using Microsoft.AspNetCore.Mvc;

namespace oodajze.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectionPointsController : ControllerBase
{
    private readonly AppDbContext _context;

    public CollectionPointsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var collectionPoints = _context.CollectionPoints.ToList();

        return Ok(collectionPoints);
    }
}