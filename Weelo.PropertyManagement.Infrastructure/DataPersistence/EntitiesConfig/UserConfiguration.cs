using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Weelo.PropertyManagement.Infrastructure.DataPersistence.EntitiesConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.IdUser);
            builder.Property(e => e.IdUser).ValueGeneratedOnAdd();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
        }
    }
}
