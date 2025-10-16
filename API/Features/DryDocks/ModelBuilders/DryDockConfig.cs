using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.DryDocks {

    internal class DryDockConfig : IEntityTypeConfiguration<DryDock> {

        public void Configure(EntityTypeBuilder<DryDock> domainObject) {
            domainObject.Property(x => x.GrossAmount).HasComputedColumnSql("(`NetAmount` + `VatAmount`)", stored: false);
            domainObject.Property(x => x.Remarks).HasDefaultValue("");
        }

    }

}