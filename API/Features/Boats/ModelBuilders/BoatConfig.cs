using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Features.Boats {

    internal class BoatConfig : IEntityTypeConfiguration<Boat> {

        public void Configure(EntityTypeBuilder<Boat> entity) {
            // PK
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            // Fks
            entity.Property(x => x.BoatTypeId).IsRequired(true);
            entity.Property(x => x.BoatUsageId).IsRequired(true);
            // Fields
            entity.Property(x => x.Description).HasMaxLength(128).IsRequired(true);
            entity.Property(x => x.Flag).HasMaxLength(128).IsRequired(true);
            entity.Property(x => x.Loa).HasColumnType("decimal(5,2)").IsRequired(true);
            entity.Property(x => x.Beam).HasColumnType("decimal(5,2)").IsRequired(true);
            entity.Property(x => x.Draft).HasColumnType("decimal(5,2)").IsRequired(true);
            entity.Property(x => x.RegistryPort).HasMaxLength(128).IsRequired(true);
            entity.Property(x => x.RegistryNo).HasMaxLength(128).IsRequired(true);
            entity.Property(x => x.IsAthenian).IsRequired(true);
            entity.Property(x => x.IsFishingBoat).IsRequired(true);
            entity.Property(x => x.IsActive).IsRequired(true);
            // Metadata
            entity.Property(x => x.PostAt).HasMaxLength(19).IsRequired(true);
            entity.Property(x => x.PostUser).HasMaxLength(255).IsRequired(true);
            entity.Property(x => x.PutAt).HasMaxLength(19);
            entity.Property(x => x.PutUser).HasMaxLength(255);
        }

    }

}