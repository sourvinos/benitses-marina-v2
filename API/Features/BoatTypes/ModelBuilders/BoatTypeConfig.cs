using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.BoatTypes {

    internal class BoatTypeConfig : IEntityTypeConfiguration<BoatType> {

        public void Configure(EntityTypeBuilder<BoatType> entity) {
            entity.Property(x => x.Description).HasMaxLength(128).IsRequired(true);
        }

    }

}