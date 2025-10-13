using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Items {

    internal class ItemConfig : IEntityTypeConfiguration<Item> {

        public void Configure(EntityTypeBuilder<Item> entity) {
            entity.Property(x => x.VatAmount).HasComputedColumnSql("((`NetAmount` * (`VatPercent` / 100)))", stored: false);
            entity.Property(x => x.GrossAmount).HasComputedColumnSql("(((`NetAmount` * (`VatPercent` / 100)) + `NetAmount`))", stored: false);
        }

    }

}