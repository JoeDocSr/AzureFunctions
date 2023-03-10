// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Empower.DataAccess.ApplicationContext.Empower.Configurations
{
    public partial class PatientClinicalDataDrugConfiguration : IEntityTypeConfiguration<PatientClinicalDataDrug>
    {
        public void Configure(EntityTypeBuilder<PatientClinicalDataDrug> entity)
        {
            entity.Property(e => e.Dose)
            .HasMaxLength(10)
            .IsFixedLength();
            entity.Property(e => e.DrugName).HasMaxLength(100);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PatientClinicalDataDrug> entity);
    }
}
