// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Empower.DataAccess.ApplicationContext.Empower.Configurations
{
    public partial class EligiblePatientConfiguration : IEntityTypeConfiguration<EligiblePatient>
    {
        public void Configure(EntityTypeBuilder<EligiblePatient> entity)
        {
            entity.Property(e => e.BenefitEndDate).HasColumnType("datetime");
            entity.Property(e => e.BenefitStartDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmpowerClientId).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PatientDOB).HasColumnType("datetime");
            entity.Property(e => e.PatientEmail).HasMaxLength(100);
            entity.Property(e => e.PatientFirstName).HasMaxLength(50);
            entity.Property(e => e.PatientGender).HasMaxLength(10);
            entity.Property(e => e.PatientLastName).HasMaxLength(50);
            entity.Property(e => e.PatientMiddleInitial).HasMaxLength(30);
            entity.Property(e => e.PatientPhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PatientZipCode).HasMaxLength(10);
            entity.Property(e => e.PayerLOBName).HasMaxLength(100);
            entity.Property(e => e.PayerName).HasMaxLength(100);
            entity.Property(e => e.SentToClientOn).HasColumnType("datetime");
            entity.Property(e => e.SubscriberIdentification).HasMaxLength(50);
            entity.Property(e => e.TagConfigurationIds).HasMaxLength(1000);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EligiblePatient> entity);
    }
}
