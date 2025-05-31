using System.Collections.Generic;
using System.Linq;
using oodajze.backend.Models;

namespace oodajze.backend.Services
{
    
    public class CouponsService : ICouponsService
    {
        private readonly AppDbContext _context;

        public CouponsService(AppDbContext context)
        {
            _context = context;
        }

        public List<CouponTemplate> GetAvailableCouponTemplates()
        {
            return _context.CouponTemplates
                .Where(c => c.Available)
                .ToList();
        }
    }
}