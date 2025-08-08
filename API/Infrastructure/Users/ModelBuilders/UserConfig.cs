using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Users {

    internal class UserConfig : IEntityTypeConfiguration<UserExtended> {

        public void Configure(EntityTypeBuilder<UserExtended> entity) { }

    }

}