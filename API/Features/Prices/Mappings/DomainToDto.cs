using API.Infrastructure.Classes;

namespace API.Features.Prices {

    public static class PriceMappingDomainToDto {

        public static PriceReadDto Get(Price price) {
            return new PriceReadDto {
                Id = price.Id,
                Code = price.Code,
                Description = price.Description,
                EnglishDescription = price.EnglishDescription,
                HullType = new SimpleEntity {
                    Id = price.HullType.Id,
                    Description = price.HullType.Description
                },
                PeriodType = new SimpleEntity {
                    Id = price.PeriodType.Id,
                    Description = price.PeriodType.Description
                },
                SeasonType = new SimpleEntity {
                    Id = price.SeasonType.Id,
                    Description = price.SeasonType.Description
                },
                IsIndividual = price.IsIndividual,
                Length = price.Length,
                NetAmount = price.NetAmount,
                VatPercent = price.VatPercent,
                VatAmount = price.VatAmount,
                GrossAmount = price.GrossAmount,
                PostAt = price.PostAt,
                PostUser = price.PostUser,
                PutAt = price.PutAt,
                PutUser = price.PutUser
            };
        }

    }

}