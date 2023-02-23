using Empower.DataAccess.Entities.Eviti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empower.DataAccess.ApplicationContext.Eviti.Configurations
{
    public partial class CarePlanSummaryDataConfiguration: IEntityTypeConfiguration<CarePlanSummaryData>
    {
        public void Configure(EntityTypeBuilder<CarePlanSummaryData> entity)
        {
            entity.HasNoKey();
            entity.Property(e => e.PayerName);
            entity.Property(e => e.PayerLobName);
            entity.Property(e => e.PatientFullName);
            entity.Property(e => e.Gender);
            entity.Property(e => e.CancerTypeGUID);
            entity.Property(e => e.CancerType);
            entity.Property(e => e.Pathology);
            entity.Property(e => e.CancerPathologyGUID);
            entity.Property(e => e.CancerStageGUID);
            entity.Property(e => e.Stage);
            entity.Property(e => e.PrimaryStandardCode);
            entity.Property(e => e.CarePlanName);
            entity.Property(e => e.StartDate);
            entity.Property(e => e.EndDate);
            entity.Property(e => e.LineOfTreatment);
            entity.Property(e => e.TreatmentGoal);
            entity.Property(e => e.CarePlanDrugNames);
            entity.Property(e => e.BioMarkerAndValuesGuids);
            entity.Property(e => e.SubscriberInsuredID);
            entity.Property(e => e.PatientHeight);
            entity.Property(e => e.PatientWeight);
            entity.Property(e => e.BodySurfaceArea);
            entity.Property(e => e.ICDCode);
           
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CarePlanSummaryData> entity);
    }
}
