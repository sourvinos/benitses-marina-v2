using API.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using API.Features.HullTypes;
using API.Features.BoatUsages;
using API.Features.Reservations;
using API.Features.Berths;
using API.Features.Boats.Admin;
using API.Features.PeriodTypes;
using API.Features.SeasonTypes;
using API.Features.Prices;

namespace API.Infrastructure.Classes {

    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<IdentityUser>(options) {

        // FK Tables
        public DbSet<Berth> Berths { get; set; }
        public DbSet<PeriodType> PeriodTypes { get; set; }
        public DbSet<SeasonType> SeasonTypes { get; set; }
        // Boats
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatFishingLicence> BoatFishingLicences { get; set; }
        public DbSet<BoatInsurance> BoatInsurances { get; set; }
        public DbSet<BoatUsage> BoatUsages { get; set; }
        public DbSet<HullType> HullTypes { get; set; }
        // Reservations
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationBerth> ReservationBerths { get; set; }
        public DbSet<ReservationCaptain> ReservationCaptains { get; set; }
        // Prices
        public DbSet<Price> Prices { get; set; }
        // The rest
        public DbSet<Token> Tokens { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        private static void ApplyConfigurations(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PriceConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }

}