﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Empower.DataAccess.ApplicationContext.Empower.Configurations
{
    public partial class FileDatumConfiguration : IEntityTypeConfiguration<FileDatum>
    {
        public void Configure(EntityTypeBuilder<FileDatum> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FileDatum)
            .HasForeignKey<FileDatum>(d => d.Id)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_FileData_FileData");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FileDatum> entity);
    }
}