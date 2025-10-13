namespace API.Features.Items {

    public static class ItemMappingDtoPutToDomain {

        public static Item Put(Item x, ItemWriteDto item) {
            return new Item {
                Id = item.Id,
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
                PostAt = x.PostAt,
                PostUser = x.PostUser,
                PutAt = item.PutAt,
                PutUser = item.PutUser
            };
        }

    }

}