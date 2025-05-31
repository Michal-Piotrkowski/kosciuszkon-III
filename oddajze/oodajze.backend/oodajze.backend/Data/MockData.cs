using oodajze.backend.Models;
using System;
using System.Collections.Generic;

public static class MockData
{
    public static List<CollectionPoint> GetCollectionPoints()
    {
        return new List<CollectionPoint>
        {
            new CollectionPoint
            {
                Name = "Punkt Ekologiczny Warszawa",
                Description = "Punkt zbiórki elektroodpadów.",
                Address = "ul. Ekologiczna 12, Warszawa",
                Latitude = 52.2297,
                Longitude = 21.0122
            },
            new CollectionPoint
            {
                Name = "Punkt Recyklingu Kraków",
                Description = "Zbieramy plastiki, baterie i sprzęt elektroniczny.",
                Address = "ul. Zielona 5, Kraków",
                Latitude = 50.0647,
                Longitude = 19.9450
            }
        };
    }

    public static List<CouponTemplate> GetCouponTemplates()
    {
        return new List<CouponTemplate>
        {
            new CouponTemplate
            {
                Title = "10% zniżki na zakupy w EkoSklep",
                Description = "Kupon na zniżkę do wykorzystania w EkoSklep",
                PointsRequired = 100,
                ImageUrl = "https://example.com/coupon1.png",
                Available = true
            },
            new CouponTemplate
            {
                Title = "Darmowa torba materiałowa",
                Description = "Wymień punkty na torbę eko!",
                PointsRequired = 50,
                ImageUrl = "https://example.com/coupon2.png",
                Available = true
            }
        };
    }

    public static List<User> GetMockUsers()
    {
        var collectionPoints = GetCollectionPoints();

        return new List<User>
        {
            new User
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Phone = "123456789",
                Email = "anna@example.com",
                PasswordHash = "fakehashedpassword1",
                TotalPoints = 150,
                JoinDate = DateTime.Now.AddMonths(-2),
                RedeemedCoupons = new List<UserCoupon>
                {
                    new UserCoupon
                    {
                        RedeemedAt = DateTime.Now.AddDays(-5),
                        IsUsed = false,
                        RedemptionCode = "REDEEM123"
                    }
                },
                CollectionVisitQrDataHistory = new List<CollectionVisitQrData>
                {
                    new CollectionVisitQrData
                    {
                        ScannedAt = DateTime.Now.AddDays(-3),
                        PointsEarned = 50,
                        CollectionPoint = collectionPoints[0],
                        Products = new List<ProductQrData>
                        {
                            new ProductQrData
                            {
                                ProductCode = "PLAST123",
                                Name = "Butelka PET",
                                Description = "Plastikowa butelka 1.5L",
                                BatchNumber = "BCH123",
                                MaterialType = "Plastik",
                                RecyclingCode = "1",
                                Points = 25
                            },
                            new ProductQrData
                            {
                                ProductCode = "ELEC456",
                                Name = "Stary telefon",
                                Description = "Zepsuty telefon komórkowy",
                                BatchNumber = "BCH456",
                                MaterialType = "Elektronika",
                                RecyclingCode = "4",
                                Points = 25
                            }
                        }
                    }
                }
            },
            new User
            {
                FirstName = "Kamil",
                LastName = "Wiśniewski",
                Phone = "987654321",
                Email = "kamil@example.com",
                PasswordHash = "fakehashedpassword2",
                TotalPoints = 200,
                JoinDate = DateTime.Now.AddMonths(-1),
                CollectionVisitQrDataHistory = new List<CollectionVisitQrData>()
            }
        };
    }
}
