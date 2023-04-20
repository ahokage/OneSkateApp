using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System;
using OneSkate.Web.Models;

namespace OneSkate.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<RacerRace> RacerRaces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RacerRace>()
                .HasOne(r => r.Race)
                .WithMany(r => r.Racers)
                .HasForeignKey(r => r.RaceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RacerRace>()
                .HasOne(r => r.Racer)
                .WithMany(r => r.Races)
                .HasForeignKey(r => r.RacerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Race)
                .WithMany(x => x.Results)
                .HasForeignKey(r => r.RaceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Racer)
                .WithMany(x => x.Results)
                .HasForeignKey(r => r.RacerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RacerRace>()
                    .HasKey(x => new { x.RacerId, x.RaceId });

            modelBuilder.Entity<Result>()
                .HasKey(x => new { x.RacerId, x.RaceId });
        }
    }
}