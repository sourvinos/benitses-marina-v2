using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using API.Infrastructure.Classes;

namespace API.Features.Prices {

    public static class PriceMappingDomainToListVM {

        public static IEnumerable<PriceListVM> Get(IQueryable<Price> prices) {
            return [.. prices.Select(x => new PriceListVM {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                HullType = new SimpleEntity{
                    Id = x.HullType.Id,
                    Description = x.HullType.Description
                },
                PeriodType = new SimpleEntity{
                    Id = x.PeriodType.Id,
                    Description = x.PeriodType.Description
                },
                SeasonType = new SimpleEntity{
                    Id = x.SeasonType.Id,
                    Description = x.SeasonType.Description
                },
                IsIndividual = x.IsIndividual,
                Length = x.Length,
                NetAmount = x.NetAmount.ToString("F", CultureInfo.InvariantCulture),
                VatAmount = x.VatAmount.ToString("F", CultureInfo.InvariantCulture),
                GrossAmount = x.GrossAmount.ToString("F", CultureInfo.InvariantCulture)
            })];
        }

    }

}