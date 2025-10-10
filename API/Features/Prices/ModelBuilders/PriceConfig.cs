using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Prices {

    internal class PriceConfig : IEntityTypeConfiguration<Price> {

        public void Configure(EntityTypeBuilder<Price> entity) {
            entity.Property(x => x.GrossAmount).HasComputedColumnSql("(((`NetAmount` * (`VatPercent` / 100)) + `NetAmount`))", stored: false);
        }

    }

}