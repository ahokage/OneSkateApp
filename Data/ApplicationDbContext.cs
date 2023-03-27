using Microsoft.EntityFrameworkCore;
using OneSkate.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OneSkate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Race)
                .WithMany(x => x.Results)
                .HasForeignKey(r => r.RaceId)
                .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Racer>()
            //    .HasKey(r => new { r.ClubId });

            //modelBuilder.Entity<Racer>()
            //    .HasOne(r => r.Club)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
