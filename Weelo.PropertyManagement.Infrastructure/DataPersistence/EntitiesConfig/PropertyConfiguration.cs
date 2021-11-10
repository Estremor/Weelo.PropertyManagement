using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Weelo.PropertyManagement.Infrastructure.DataPersistence.EntitiesConfig
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(e => e.IdProperty);

            builder.ToTable("Property");

            builder.Property(e => e.IdProperty).ValueGeneratedOnAdd();

            builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)").IsRequired();

            builder.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Owner");
        }
    }
}
