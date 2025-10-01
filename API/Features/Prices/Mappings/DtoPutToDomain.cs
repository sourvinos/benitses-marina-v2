namespace API.Features.Prices {

    public static class PriceMappingDtoPutToDomain {

        public static Price Put(Price x, PriceWriteDto price) {
            return new Price {
                Id = price.Id,
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
                PostAt = x.PostAt,
                PostUser = x.PostUser,
                PutAt = price.PutAt,
                PutUser = price.PutUser
            };
        }

    }

}