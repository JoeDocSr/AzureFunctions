using Empower.DataAccess.Entities.Eviti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empower.DataAccess.ApplicationContext.Eviti.Configurations
{
    public partial class evitiEligiblePatientsConfiguration : IEntityTypeConfiguration<evitiEligiblePatients>
    {
        public void Configure(EntityTypeBuilder<evitiEligiblePatients> entity)
        {
            entity.HasNoKey();
            entity.Property(e => e.PatientGuid);
            entity.Property(e => e.ProviderGuid);
            entity.Property(e => e.PayerName);
            entity.Property(e => e.PayerGuid);
            entity.Property(e => e.PayerLobName);
            entity.Property(e => e.PayerLineOfBusinessGuid);
            entity.Property(e => e.DiagnosisGuid);
            entity.Property(e => e.CarePlanGuid);
            entity.Property(e => e.PatientName);
            entity.Property(e => e.PatientAge);
            entity.Property(e => e.Gender);
            entity.Property(e => e.EmailAddress);
            entity.Property(e => e.CancerType);
            entity.Property(e => e.CancerTypeGUID);
            entity.Property(e => e.CancerPathologyGUID);
            entity.Property(e => e.CancerStageGUID);
            entity.Property(e => e.CarePlanName);
            entity.Property(e => e.LineOfTreatmentGuid);
            entity.Property(e => e.TreatmentGoalGuid);
            entity.Property(e => e.CarePlanGPIs);
            entity.Property(e => e.ReferenceGuid);
            entity.Property(e => e.BirthDate);
            entity.Property(e => e.EligibilityStartDate);
            entity.Property(e => e.EligibilityEndDate);
            entity.Property(e => e.SubscriberInsuredID);
            entity.Property(e => e.PatientFirstName);
            entity.Property(e => e.PatientMiddleName);
            entity.Property(e => e.PatientLastName);
            entity.Property(e => e.PhoneNumber);
            entity.Property(e => e.Zipcode);
            entity.Property(e => e.BioMarkerAndValuesGuids);
            entity.Property(e => e.TreatmentGoal);
            entity.Property(e => e.LineOfTreatment);

            OnConfigurePartial(entity);

        }

        partial void OnConfigurePartial(EntityTypeBuilder<evitiEligiblePatients> entity);
    }
}
