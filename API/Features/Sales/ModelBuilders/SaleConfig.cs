using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Sales {

    internal class SaleConfig : IEntityTypeConfiguration<Sale> {

        public void Configure(EntityTypeBuilder<Sale> entity) {
            entity.HasKey("InvoiceId");
            entity.Property(x => x.InvoiceId).IsFixedLength().HasMaxLength(36).IsRequired(true);
        }

    }

}