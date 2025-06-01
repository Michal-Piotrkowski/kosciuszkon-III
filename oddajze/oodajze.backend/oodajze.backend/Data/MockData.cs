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
            },
            new CollectionPoint
            {
                Name = "Punkt Zbiórki Wrocław",
                Description = "Zbiórka elektrośmieci i plastików.",
                Address = "ul. Wrocławska 22, Wrocław",
                Latitude = 51.1079,
                Longitude = 17.0385
            },
            new CollectionPoint
            {
                Name = "Punkt Recyklingu Gdańsk",
                Description = "Ekologiczny punkt recyklingu.",
                Address = "ul. Nadmorska 10, Gdańsk",
                Latitude = 54.3520,
                Longitude = 18.6466
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
            },
            new CouponTemplate
            {
                Title = "Bezpłatny bilet do kina ekologicznego",
                Description = "Wykorzystaj punkty na bilet do kina promującego ekologię",
                PointsRequired = 150,
                ImageUrl = "https://example.com/coupon3.png",
                Available = true
            },
            new CouponTemplate
            {
                Title = "Zniżka 20 zł na zakupy w sklepie zero waste",
                Description = "Kupon rabatowy na zakupy w sklepie zero waste",
                PointsRequired = 120,
                ImageUrl = "https://example.com/coupon4.png",
                Available = true
            }
        };
    }

    public static List<User> GetMockUsers()
    {
        var collectionPoints = GetCollectionPoints();
        var couponTemplates = GetCouponTemplates();

        return new List<User>
        {
            new User
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Phone = "123456789",
                Username = "anowak",
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
                        RedemptionCode = "REDEEM123",
                        CouponTemplateId = 0 
                    }
                },
                CollectionVisitQrDataHistory = new List<CollectionVisitQrData>
                {
                    new CollectionVisitQrData
                    {
                        ScannedAt = DateTime.Now.AddDays(-3),
                        PointsEarned = 50,
                        CollectionPoint = collectionPoints[0],
                        QrCode = Guid.NewGuid().ToString(),
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
                            },
                            new ProductQrData
                            {
                                ProductCode = "9002490100070",
                                Name = "RedBull 250ml",
                                Description = "Napój energetyczny RedBull Energy Drink 250ml",
                                BatchNumber = "BCH456",
                                MaterialType = "Metal",
                                RecyclingCode = "1",
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
                Username = "kamilw",
                PasswordHash = "fakehashedpassword2",
                TotalPoints = 200,
                JoinDate = DateTime.Now.AddMonths(-1),
                RedeemedCoupons = new List<UserCoupon>
                {
                    new UserCoupon
                    {
                        RedeemedAt = DateTime.Now.AddDays(-10),
                        IsUsed = true,
                        RedemptionCode = "REDEEM456",
                        CouponTemplateId = 1
                    },
                    new UserCoupon
                    {
                        RedeemedAt = DateTime.Now.AddDays(-1),
                        IsUsed = false,
                        RedemptionCode = "REDEEM789",
                        CouponTemplateId = 2
                    }
                },
                CollectionVisitQrDataHistory = new List<CollectionVisitQrData>
                {
                    new CollectionVisitQrData
                    {
                        ScannedAt = DateTime.Now.AddDays(-7),
                        PointsEarned = 80,
                        CollectionPoint = collectionPoints[2],
                        QrCode = Guid.NewGuid().ToString(),
                        Products = new List<ProductQrData>
                        {
                            new ProductQrData
                            {
                                ProductCode = "BAT123",
                                Name = "Zużyte baterie",
                                Description = "Baterie AAA",
                                BatchNumber = "BCH789",
                                MaterialType = "Bateria",
                                RecyclingCode = "5",
                                Points = 40
                            },
                            new ProductQrData
                            {
                                ProductCode = "PLAST789",
                                Name = "Puszka po napoju",
                                Description = "Aluminiowa puszka",
                                BatchNumber = "BCH999",
                                MaterialType = "Metal",
                                RecyclingCode = "2",
                                Points = 40
                            }
                        }
                    },
                    new CollectionVisitQrData
                    {
                        ScannedAt = DateTime.Now.AddDays(-2),
                        PointsEarned = 60,
                        CollectionPoint = collectionPoints[1], 
                        QrCode = "QRNEW123456",
                        Products = new List<ProductQrData>
                        {
                            new ProductQrData
                            {
                                ProductCode = "ELEC999",
                                Name = "Stara ładowarka",
                                Description = "Uszkodzona ładowarka do telefonu",
                                BatchNumber = "BCH321",
                                MaterialType = "Elektronika",
                                RecyclingCode = "4",
                                Points = 60
                            }
                        }
                    }
                }
            },
            new User
            {
                FirstName = "Marta",
                LastName = "Kowalska",
                Username = "martak",
                Phone = "555666777",
                Email = "marta@example.com",
                PasswordHash = "fakehashedpassword3",
                TotalPoints = 80,
                JoinDate = DateTime.Now.AddMonths(-3),
                RedeemedCoupons = new List<UserCoupon>(), 
                CollectionVisitQrDataHistory = new List<CollectionVisitQrData>() 
            }
        };
    }
    
    public static List<CollectionVisitQrData> GetCollectionVisitQrData()
{
    var collectionPoints = GetCollectionPoints();
    var users = GetMockUsers();

    return new List<CollectionVisitQrData>
    {
        new CollectionVisitQrData
        {
            Id = 1,
            CollectionPointId = 1,
            UserId = null,
            QrCode = "QR123456789",
            ScannedAt = DateTime.Now.AddDays(-3),
            PointsEarned = 50,
            CollectionPoint = collectionPoints[0],
            User = null,
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
        },
        new CollectionVisitQrData
        {
            Id = 2,
            CollectionPointId = 3,
            UserId = null,
            QrCode = "QR987654321",
            ScannedAt = DateTime.Now.AddDays(-7),
            PointsEarned = 80,
            CollectionPoint = collectionPoints[2],
            User = null,
            Products = new List<ProductQrData>
            {
                new ProductQrData
                {
                    ProductCode = "BAT123",
                    Name = "Zużyte baterie",
                    Description = "Baterie AAA",
                    BatchNumber = "BCH789",
                    MaterialType = "Bateria",
                    RecyclingCode = "5",
                    Points = 40
                },
                new ProductQrData
                {
                    ProductCode = "PLAST789",
                    Name = "Puszka po napoju",
                    Description = "Aluminiowa puszka",
                    BatchNumber = "BCH999",
                    MaterialType = "Metal",
                    RecyclingCode = "2",
                    Points = 40
                }
            }
        },
        new CollectionVisitQrData
        {
            Id = 3,
            CollectionPointId = 2,
            UserId = null,
            QrCode = "QRNEW123456",
            ScannedAt = DateTime.Now.AddDays(-2),
            PointsEarned = 60,
            CollectionPoint = collectionPoints[1],
            User = null,
            Products = new List<ProductQrData>
            {
                new ProductQrData
                {
                    ProductCode = "ELEC999",
                    Name = "Stara ładowarka",
                    Description = "Uszkodzona ładowarka do telefonu",
                    BatchNumber = "BCH321",
                    MaterialType = "Elektronika",
                    RecyclingCode = "4",
                    Points = 60
                }
            }
        }
    };
}

}
