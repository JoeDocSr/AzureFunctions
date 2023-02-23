
using System;

namespace EmpowerEligiblePatients
{
    public class ProxyPatients
    { 
        public long Id { get; set; }
        public string SubscriberIdentification { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientMiddleInitial { get; set; }
        public string PatientLastName { get; set; }
        public string? PatientGender { get; set; }
        public DateTime PatientDOB { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string PatientZipCode { get; set; }
        public string PayerName { get; set; }
        public string PayerLOBName { get; set; }
        public DateTime BenefitStartDate { get; set; }
        public DateTime BenefitEndDate { get; set; }
    

    }
}
