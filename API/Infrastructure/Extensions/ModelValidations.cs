using API.Features.Boats.Admin;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions {

    public static class ModelValidations {

        public static void AddModelValidation(IServiceCollection services) {
            services.AddTransient<IValidator<BoatWriteDto>, BoatValidator>();
        }

    }

}