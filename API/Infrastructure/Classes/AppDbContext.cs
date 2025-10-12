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
using API.Features.TaxOffices;
using API.Features.Nationalities;
using API.Features.Customers.Admin;
using API.Features.DocumentTypes;
using API.Features.PaymentMethods;
using API.Features.Sales;

namespace API.Infrastructure.Classes {

    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<IdentityUser>(options) {

        #region DbSets

        public DbSet<Berth> Berths { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PeriodType> PeriodTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<SeasonType> SeasonTypes { get; set; }
        public DbSet<TaxOffice> TaxOffices { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatFishingLicence> BoatFishingLicences { get; set; }
        public DbSet<BoatInsurance> BoatInsurances { get; set; }
        public DbSet<BoatUsage> BoatUsages { get; set; }
        public DbSet<HullType> HullTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationBerth> ReservationBerths { get; set; }
        public DbSet<ReservationCaptain> ReservationCaptains { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        private static void ApplyConfigurations(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PriceConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleItemConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

    }

}