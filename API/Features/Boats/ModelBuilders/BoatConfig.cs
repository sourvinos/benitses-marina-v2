using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Boats {

    internal class BoatConfig : IEntityTypeConfiguration<Boat> {

        public void Configure(EntityTypeBuilder<Boat> entity) {
            entity.HasOne(x => x.Insurance).WithOne(x => x.Boat).HasForeignKey<BoatInsurance>(x => x.BoatId).IsRequired();
        }

    }

}