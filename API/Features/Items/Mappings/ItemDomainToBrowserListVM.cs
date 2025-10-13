using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace API.Features.Items {

    public static class ItemMappingDomainToBrowserListVM {

        public static IEnumerable<ItemBrowserListVM> Get(IQueryable<Item> items) {
            return [.. items.Select(x => new ItemBrowserListVM {
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