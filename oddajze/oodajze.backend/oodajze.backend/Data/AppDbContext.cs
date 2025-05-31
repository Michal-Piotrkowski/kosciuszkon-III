using Microsoft.EntityFrameworkCore;

using oodajze.backend.Models; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CollectionPoint> CollectionPoints { get; set; }
    public DbSet<CouponTemplate> CouponTemplates { get; set; }
    public DbSet<UserCoupon> UserCoupons { get; set; }
    public DbSet<ProductQrData> ProductQrDatas { get; set; }
    public DbSet<CollectionVisitQrData> CollectionVisitQrDatas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.RedeemedCoupons)
            .WithOne()
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.CollectionVisitQrDataHistory)
            .WithOne(cv => cv.User)
            .HasForeignKey(cv => cv.UserId);

        modelBuilder.Entity<CollectionVisitQrData>()
            .HasOne(cv => cv.CollectionPoint)
            .WithMany()
            .HasForeignKey(cv => cv.CollectionPointId);

        modelBuilder.Entity<UserCoupon>()
            .HasOne<CouponTemplate>()
            .WithMany()
            .HasForeignKey(uc => uc.CouponTemplateId);
    }

}