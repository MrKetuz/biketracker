using Microsoft.EntityFrameworkCore;

namespace BiketrackerBackend.Data
{
    public class BiketrackerDbContext : DbContext
    {
        public BiketrackerDbContext(DbContextOptions<BiketrackerDbContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RoutePoint>()
                .HasKey(x => new
                {
                    x.RouteId,
                    x.Sequence
                });


            modelBuilder.Entity<RoutePoint>()
                .HasOne(x => x.Route)
                .WithMany(x => x.Points)
                .HasForeignKey(x => x.RouteId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RoutePoint> RoutePoints { get; set; }
    }
}
