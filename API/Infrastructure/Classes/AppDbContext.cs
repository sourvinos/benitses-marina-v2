using API.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using API.Features.HullTypes;
using API.Features.BoatUsages;
using API.Features.Boats;
using API.Features.Reservations;

namespace API.Infrastructure.Classes {

    public class AppDbContext : IdentityDbContext<IdentityUser> {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatInsurance> BoatInsurances { get; set; }
        public DbSet<BoatUsage> BoatUsages { get; set; }
        public DbSet<HullType> HullTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationBoatOwner> ReservationBoatOwners { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        private static void ApplyConfigurations(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }

}