using API.Features.Boats;
using API.Features.HullTypes;
using API.Features.BoatUsages;
using API.Features.Reservations;
using API.Infrastructure.Account;
using API.Infrastructure.Auth;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions {

    public static class Interfaces {

        public static void AddInterfaces(IServiceCollection services) {

            services.AddScoped<Token>();

            services.AddTransient<IBoatRepository, BoatRepository>();
            services.AddTransient<IBoatValidation, BoatValidation>();

            services.AddTransient<IBoatUsageRepository, BoatUsageRepository>();
            services.AddTransient<IBoatUsageValidation, BoatUsageValidation>();

            services.AddTransient<IHullTypeRepository, HullTypeRepository>();
            services.AddTransient<IHullTypeValidation, HullTypeValidation>();

            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationValidation, ReservationValidation>();

            services.AddTransient<IEmailAccountSender, EmailAccountSender>();
            services.AddTransient<IEmailQueueRepository, EmailQueueRepository>();
            services.AddTransient<IEmailUserDetailsSender, EmailUserDetailsSender>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserValidation<IUser>, UserValidation>();

        }

    }

}