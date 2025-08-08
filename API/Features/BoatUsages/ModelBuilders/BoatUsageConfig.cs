using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.BoatUsages {

    internal class BoatUsageConfig : IEntityTypeConfiguration<BoatUsage> {

        public void Configure(EntityTypeBuilder<BoatUsage> entity) {
            entity.Property(x => x.Description).HasMaxLength(128).IsRequired(true);
        }

    }

}