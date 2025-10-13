using API.Infrastructure.Classes;

namespace API.Features.Items {

    public static class ItemMappingDomainToDto {

        public static ItemReadDto Get(Item item) {
            return new ItemReadDto {
                Id = item.Id,
                Code = item.Code,
                Description = item.Description,
                EnglishDescription = item.EnglishDescription,
                HullType = new SimpleEntity {
                    Id = item.HullType.Id,
                    Description = item.HullType.Description
                },
                PeriodType = new SimpleEntity {
                    Id = item.PeriodType.Id,
                    Description = item.PeriodType.Description
                },
                SeasonType = new SimpleEntity {
                    Id = item.SeasonType.Id,
                    Description = item.SeasonType.Description
                },
                IsIndividual = item.IsIndividual,
                Length = item.Length,
                NetAmount = item.NetAmount,
                VatPercent = item.VatPercent,
                VatAmount = item.VatAmount,
                GrossAmount = item.GrossAmount,
                PostAt = item.PostAt,
                PostUser = item.PostUser,
                PutAt = item.PutAt,
                PutUser = item.PutUser
            };
        }

    }

}