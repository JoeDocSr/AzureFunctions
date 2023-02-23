using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.DataAccess.Entities.Eviti
{
    public class evitiEligiblePatients
    {

        public Guid PatientGuid { get; set; }
        public Guid ProviderGuid { get; set; }
        public string? PayerName { get; set; }
        public Guid PayerGuid { get; set; }
        public string? PayerLobName { get; set; }
        public Guid PayerLineOfBusinessGuid { get; set; }
        public Guid DiagnosisGuid { get; set; }
        public Guid CarePlanGuid { get; set; }
        public string? PatientName { get; set; }
        public int PatientAge { get; set; }
        public string? Gender { get; set; }
        public string? EmailAddress { get; set; }
        public String? CancerType { get; set; }
        public Guid CancerTypeGUID { get; set; }
        public Guid CancerPathologyGUID { get; set; }
        public Guid CancerStageGUID { get; set; }
        public string? CarePlanName { get; set; }
        public Guid LineOfTreatmentGuid { get; set; }
        public Guid TreatmentGoalGuid { get; set; }
        public string? TreatmentGoal { get; set; }
        public string? CarePlanGPIs { get; set; }
        public Guid ReferenceGuid { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EligibilityStartDate { get; set; }
        public DateTime EligibilityEndDate { get; set; }
        public string? SubscriberInsuredID { get; set; }
        public string? PatientFirstName { get; set; }
        public string? PatientMiddleName { get; set; }
        public string? PatientLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Zipcode { get; set; }
        public string? LineOfTreatment { get; set; }
        public string? BioMarkerAndValuesGuids { get; set; }

    }





}
