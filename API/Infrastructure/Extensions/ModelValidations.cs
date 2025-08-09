using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using API.Features.Boats;

namespace API.Infrastructure.Extensions {

    public static class ModelValidations {

        public static void AddModelValidation(IServiceCollection services) {
            services.AddTransient<IValidator<BoatWriteDto>, BoatValidator>();
        }

    }

}