﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weelo.PropertyManagement.Domain.Entities;

namespace Weelo.PropertyManagement.Infrastructure.DataPersistence.EntitiesConfig
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.HasKey(e => e.IdPropertyImage);

            builder.ToTable("PropertyImage");

            builder.Property(e => e.IdPropertyImage).ValueGeneratedOnAdd();

            builder.Property(e => e.File)
                    .IsRequired()
                    .HasColumnType("image");

            builder.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.PropertyImages)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyImage_Property"); ;
        }
    }
}
