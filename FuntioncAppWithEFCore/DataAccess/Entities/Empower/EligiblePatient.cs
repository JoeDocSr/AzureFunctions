using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class EligiblePatient
{
    public long Id { get; set; }
    public string SubscriberIdentification { get; set; } = null!;
    public string PatientFirstName { get; set; } = null!;
    public string PatientLastName { get; set; } = null!;
    public Guid PatientGuid { get; set; }
    public DateTime PatientDOB { get; set; }
    public string PatientEmail { get; set; } = null!;
    public string PatientPhoneNumber { get; set; } = null!;
    public Guid CarePlanGuid { get; set; }
    public string TagConfigurationIds { get; set; } = null!;
    public string PayerName { get; set; } = null!;
    public string PayerLOBName { get; set; } = null!;
    public DateTime BenefitStartDate { get; set; }
    public DateTime BenefitEndDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool? IsRegistered { get; set; }
    public string? EmpowerClientId { get; set; }
    public DateTime? SentToClientOn { get; set; }
    public string? PatientGender { get; set; }
    public string? PatientMiddleInitial { get; set; }
    public string? PatientZipCode { get; set; }
    public DateTime ModifiedOn { get; set; }
}
