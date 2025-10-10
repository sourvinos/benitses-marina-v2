using API.Features.Berths;
using API.Features.Boats.Admin;
using API.Features.BoatUsages;
using API.Features.Customers.Admin;
using API.Features.DocumentTypes;
using API.Features.HullTypes;
using API.Features.Nationalities;
using API.Features.PaymentMethods;
using API.Features.PeriodTypes;
using API.Features.Prices;
using API.Features.Reservations;
using API.Features.Sales;
using API.Features.SeasonTypes;
using API.Features.TaxOffices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions {

    public static class ModelValidations {

        public static void AddModelValidation(IServiceCollection services) {
            services.AddTransient<IValidator<BerthWriteDto>, BerthValidator>();
            services.AddTransient<IValidator<BoatWriteDto>, BoatValidator>();
            services.AddTransient<IValidator<BoatUsageWriteDto>, BoatUsageValidator>();
            services.AddTransient<IValidator<CustomerWriteDto>, CustomerValidator>();
            services.AddTransient<IValidator<DocumentTypeWriteDto>, DocumentTypeValidator>();
            services.AddTransient<IValidator<HullTypeWriteDto>, HullTypeValidator>();
            services.AddTransient<IValidator<NationalityWriteDto>, NationalityValidator>();
            services.AddTransient<IValidator<PaymentMethodWriteDto>, PaymentMethodValidator>();
            services.AddTransient<IValidator<PeriodTypeWriteDto>, PeriodTypeValidator>();
            services.AddTransient<IValidator<PriceWriteDto>, PriceValidator>();
            services.AddTransient<IValidator<ReservationWriteDto>, ReservationValidator>();
            services.AddTransient<IValidator<SaleWriteDto>, SaleValidator>();
            services.AddTransient<IValidator<SeasonTypeWriteDto>, SeasonTypeValidator>();
            services.AddTransient<IValidator<TaxOfficeWriteDto>, TaxOfficeValidator>();
        }

    }

}