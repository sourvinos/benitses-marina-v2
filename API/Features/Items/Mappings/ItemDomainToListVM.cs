using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using API.Infrastructure.Classes;

namespace API.Features.Items {

    public static class ItemMappingDomainToListVM {

        public static IEnumerable<ItemListVM> Get(IQueryable<Item> items) {
            return [.. items.Select(x => new ItemListVM {
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