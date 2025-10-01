namespace API.Features.Prices {

    public static class PriceMappingDtoPostToDomain {

        public static Price Post(PriceWriteDto price) {
            return new Price {
                Code = price.Code,
                Description = price.Description,
                EnglishDescription = price.EnglishDescription,
                HullTypeId = price.HullTypeId,
                PeriodTypeId = price.PeriodTypeId,
                SeasonTypeId = price.SeasonTypeId,
                IsIndividual = price.IsIndividual,
                Length = price.Length,
                NetAmount = price.NetAmount,
                VatPercent = price.VatPercent,
                IsActive = price.IsActive,
                PostAt = price.PostAt,
                PostUser = price.PostUser,
                PutAt = price.PutAt,
                PutUser = price.PutUser
            };
        }

    }

}