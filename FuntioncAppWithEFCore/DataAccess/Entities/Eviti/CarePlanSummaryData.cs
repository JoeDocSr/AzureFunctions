using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.DataAccess.Entities.Eviti
{
    public partial  class CarePlanSummaryData
    {
        public string PayerName { get; set; }
        public string PayerLobName { get; set; }
        public string PatientFullName { get; set; }
        public string Gender { get; set; }
        public Guid GUID { get; set; }
        public Guid CancerTypeGUID { get; set; }    
        public string CancerType { get; set; }
        public string Pathology { get; set; }   
        public Guid CancerPathologyGUID { get; set; }
        public Guid CancerStageGUID { get; set; }
        public string Stage { get; set; }
        public string PrimaryStandardCode { get; set; }
        public string CarePlanName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LineOfTreatment { get; set; }
        public string TreatmentGoal { get; set; }
        public string CarePlanDrugNames { get; set; }
        public string BioMarkerAndValuesGuids { get; set; }
        public string SubscriberInsuredID { get; set; }
        public string PatientHeight { get; set; }
        public string PatientWeight { get; set; }
        public int BodySurfaceArea { get; set; }
        public string ICDCode { get; set; }
    }
}
