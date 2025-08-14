using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.HullTypes {

    internal class HullTypeConfig : IEntityTypeConfiguration<HullType> {

        public void Configure(EntityTypeBuilder<HullType> entity) {
            entity.Property(x => x.Description).HasMaxLength(128).IsRequired(true);
        }

    }

}