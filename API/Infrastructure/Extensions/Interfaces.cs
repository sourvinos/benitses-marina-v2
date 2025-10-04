using API.Features.HullTypes;
using API.Features.BoatUsages;
using API.Features.Reservations;
using API.Infrastructure.Account;
using API.Infrastructure.Auth;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using API.Features.Boats.Admin;
using API.Features.Boats.Insurances;
using API.Features.PeriodTypes;
using API.Features.SeasonTypes;
using API.Features.Prices;
using API.Features.TaxOffices;
using API.Features.Nationalities;
using API.Features.Customers.Admin;

namespace API.Infrastructure.Extensions {

    public static class Interfaces {

        public static void AddInterfaces(IServiceCollection services) {

            services.AddScoped<Token>();

            services.AddTransient<IBoatRepository, BoatRepository>();
            services.AddTransient<IBoatValidation, BoatValidation>();
            services.AddTransient<IExpiredInsuranceRepository, ExpiredInsuranceRepository>();

            services.AddTransient<IBoatUsageRepository, BoatUsageRepository>();
            services.AddTransient<IBoatUsageValidation, BoatUsageValidation>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerValidation, CustomerValidation>();

            services.AddTransient<IHullTypeRepository, HullTypeRepository>();
            services.AddTransient<IHullTypeValidation, HullTypeValidation>();

            services.AddTransient<INationalityRepository, NationalityRepository>();
            services.AddTransient<INationalityValidation, NationalityValidation>();

            services.AddTransient<IPeriodTypeRepository, PeriodTypeRepository>();
            services.AddTransient<IPeriodTypeValidation, PeriodTypeValidation>();

            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IPriceValidation, PriceValidation>();

            services.AddTransient<ITaxOfficeRepository, TaxOfficeRepository>();
            services.AddTransient<ITaxOfficeValidation, TaxOfficeValidation>();

            services.AddTransient<ISeasonTypeRepository, SeasonTypeRepository>();
            services.AddTransient<ISeasonTypeValidation, SeasonTypeValidation>();

            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationValidation, ReservationValidation>();
            services.AddTransient<IReservationEmailSender, ReservationEmailSender>();

            services.AddTransient<IEmailAccountSender, EmailAccountSender>();
            services.AddTransient<IEmailQueueRepository, EmailQueueRepository>();
            services.AddTransient<IEmailUserDetailsSender, EmailUserDetailsSender>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserValidation<IUser>, UserValidation>();

        }

    }

}