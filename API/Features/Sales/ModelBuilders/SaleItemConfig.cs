using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Sales {

    internal class SaleItemConfig : IEntityTypeConfiguration<SaleItem> {

        public void Configure(EntityTypeBuilder<SaleItem> entity) {
            entity.Property(x => x.NetAmountPreDiscount).HasComputedColumnSql("(`Qty` * `UnitPrice`)", stored: false);
            entity.Property(x => x.NetAmountPostDiscount).HasComputedColumnSql("(`NetAmountPreDiscount` - `DiscountAmount`)", stored: false);
            entity.Property(x => x.VatAmount).HasComputedColumnSql("((`NetAmountPostDiscount` * `VatPercent`) / 100)", stored: false);
            entity.Property(x => x.GrossAmount).HasComputedColumnSql("(`NetAmountPostDiscount` + `VatAmount`)", stored: false);
        }

    }

}