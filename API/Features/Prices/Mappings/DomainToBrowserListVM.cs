using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace API.Features.Prices {

    public static class PriceMappingDomainToBrowserListVM {

        public static IEnumerable<PriceListBrowserVM> Get(IQueryable<Price> prices) {
            return [.. prices.Select(x => new PriceListBrowserVM {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                NetAmount = x.NetAmount.ToString("F", CultureInfo.InvariantCulture),
                VatAmount = x.VatAmount.ToString("F", CultureInfo.InvariantCulture),
                GrossAmount = x.GrossAmount.ToString("F", CultureInfo.InvariantCulture)
            })];
        }

    }

}