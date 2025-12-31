namespace API.Features.DryDocks {

    public static class DryDockMappingWrite {

        public static DryDock DtoToDomain(DryDockWriteDto writeDto) {
            return new DryDock {
                DryDockId = writeDto.DryDockId,
                BoatId = writeDto.BoatId,
                StatusId = writeDto.StatusId,
                NetAmount = writeDto.NetAmount,
                VatAmount = writeDto.VatAmount,
                IsPaid = writeDto.IsPaid,
                IsDeleted = writeDto.IsDeleted,
                PostAt = writeDto.PostAt,
                PostUser = writeDto.PostUser,
                PutAt = writeDto.PutAt,
                PutUser = writeDto.PutUser
            };
        }

    }

}