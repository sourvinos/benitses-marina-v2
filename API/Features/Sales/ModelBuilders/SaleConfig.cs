using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Sales {

    internal class SaleConfig : IEntityTypeConfiguration<Sale> {

        public void Configure(EntityTypeBuilder<Sale> entity) {
            entity.HasKey("SaleId");
            entity.Property(x => x.SaleId).IsFixedLength().HasMaxLength(36).IsRequired(true);
            entity.Property(x => x.GrossAmount).HasComputedColumnSql("(`NetAmount` + `VatAmount`)", stored: false);
        }

    }

}