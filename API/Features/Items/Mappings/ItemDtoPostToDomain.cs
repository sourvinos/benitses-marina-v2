namespace API.Features.Items {

    public static class ItemMappingDtoPostToDomain {

        public static Item Post(ItemWriteDto item) {
            return new Item {
                Code = item.Code,
                Description = item.Description,
                EnglishDescription = item.EnglishDescription,
                HullTypeId = item.HullTypeId,
                PeriodTypeId = item.PeriodTypeId,
                SeasonTypeId = item.SeasonTypeId,
                IsIndividual = item.IsIndividual,
                Length = item.Length,
                NetAmount = item.NetAmount,
                VatPercent = item.VatPercent,
                IsActive = item.IsActive,
                PostAt = item.PostAt,
                PostUser = item.PostUser,
                PutAt = item.PutAt,
                PutUser = item.PutUser
            };
        }

    }

}