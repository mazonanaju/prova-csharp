using Microsoft.EntityFrameworkCore;
namespace Turistando.Models;

public class PasseiosDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Point> Points => Set<Point>();
    public DbSet<TourPoint> TourPoints => Set<TourPoint>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<TourPoint>()
            .HasKey(tp => new { tp.TourID, tp.PointID });

        model.Entity<TourPoint>()
            .HasOne(tp => tp.Tour)
            .WithMany(t => t.TourPoints)
            .HasForeignKey(tp => tp.TourID);

        model.Entity<TourPoint>()
            .HasOne(tp => tp.Point)
            .WithMany(p => p.TourPoints)
            .HasForeignKey(tp => tp.PointID);
    }
}