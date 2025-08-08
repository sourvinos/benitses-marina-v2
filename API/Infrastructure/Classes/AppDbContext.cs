using API.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using API.Features.BoatTypes;

namespace API.Infrastructure.Classes {

    public class AppDbContext : IdentityDbContext<IdentityUser> {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BoatType> BoatTypes { get; set; }
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