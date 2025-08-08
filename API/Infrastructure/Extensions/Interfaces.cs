using API.Features.BoatTypes;
using API.Infrastructure.Account;
using API.Infrastructure.Auth;
using API.Infrastructure.EmailServices;
using API.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions {

    public static class Interfaces {

        public static void AddInterfaces(IServiceCollection services) {

            services.AddScoped<Token>();

            services.AddTransient<IBoatTypeRepository, BoatTypeRepository>();
            services.AddTransient<IBoatTypeValidation, BoatTypeValidation>();

            services.AddTransient<IEmailAccountSender, EmailAccountSender>();
            services.AddTransient<IEmailQueueRepository, EmailQueueRepository>();
            services.AddTransient<IEmailUserDetailsSender, EmailUserDetailsSender>();

            services.AddTransient<IUserRepository, UserRepository>();
        }

    }

}