namespace oodajze.backend.Data;

public class MockSeeder
{
    private readonly AppDbContext _context;

    public MockSeeder(AppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!_context.CollectionPoints.Any())
        {
            var points = MockData.GetCollectionPoints();
            _context.CollectionPoints.AddRange(points);
            await _context.SaveChangesAsync();  
        }

        if (!_context.CouponTemplates.Any())
        {
            var coupons = MockData.GetCouponTemplates();
            _context.CouponTemplates.AddRange(coupons);
            await _context.SaveChangesAsync();  
        }

        if (!_context.Users.Any())
        {
            var users = MockData.GetMockUsers();
            _context.Users.AddRange(users);
        }

        await _context.SaveChangesAsync();
    }
}