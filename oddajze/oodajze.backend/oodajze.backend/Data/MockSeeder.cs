using oodajze.backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace oodajze.backend.Data
{
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
            
            if (!_context.CollectionVisitQrData.Any())
            {
                var collectionPoints = _context.CollectionPoints.ToList();
                var visits = MockData.GetCollectionVisitQrData();

                foreach (var visit in visits)
                {
                    var matchedPoint = collectionPoints.FirstOrDefault(p =>
                        p.Name == visit.CollectionPoint.Name &&
                        p.Address == visit.CollectionPoint.Address);

                    if (matchedPoint != null)
                    {
                        visit.CollectionPointId = matchedPoint.Id;
                        visit.CollectionPoint = null;
                    }
                }

                _context.CollectionVisitQrData.AddRange(visits);
                await _context.SaveChangesAsync();
            }
            
            if (!_context.Users.Any())
            {
                var users = MockData.GetMockUsers();


                var couponTemplates = _context.CouponTemplates.ToList();
                var collectionPoints = _context.CollectionPoints.ToList();

                foreach (var user in users)
                {
                    if (user.RedeemedCoupons != null)
                    {
                        foreach (var userCoupon in user.RedeemedCoupons)
                        {
                            userCoupon.CouponTemplateId = couponTemplates.FirstOrDefault()?.Id ?? 0;
                        }
                    }
                    
                    if (user.CollectionVisitQrDataHistory != null)
                    {
                        foreach (var visit in user.CollectionVisitQrDataHistory)
                        {
                            var matchedPoint = collectionPoints.FirstOrDefault(p =>
                                p.Name == visit.CollectionPoint.Name &&
                                p.Address == visit.CollectionPoint.Address);

                            if (matchedPoint != null)
                            {
                                visit.CollectionPointId = matchedPoint.Id;
                                visit.CollectionPoint = null; 
                            }
                        }
                    }
                }

                _context.Users.AddRange(users);
                await _context.SaveChangesAsync();
            }
        }

    }
}
