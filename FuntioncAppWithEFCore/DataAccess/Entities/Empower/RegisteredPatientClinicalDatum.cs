using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class RegisteredPatientClinicalDatum
{
    public long Id { get; set; }

    public long PatientEligibilityId { get; set; }

    public string ProviderName { get; set; } = null!;

    public string BusinessEntityName { get; set; } = null!;

    public string CancerType { get; set; } = null!;

    public string Pathology { get; set; } = null!;

    public string Stage { get; set; } = null!;

    public string LOT { get; set; } = null!;

    public DateTime TreatmentStartDate { get; set; }

    public DateTime TreatmentEndDate { get; set; }

    public long TreatmentPlanSummaryFileId { get; set; }
}
