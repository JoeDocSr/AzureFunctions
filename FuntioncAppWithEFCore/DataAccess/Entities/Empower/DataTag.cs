using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class DataTag
{
    public long Id { get; set; }

    public string TagName { get; set; } = null!;

    public string PayerLOBName { get; set; } = null!;

    public string PayerLOBGuid { get; set; } = null!;

    public Guid CancerTypeGuid { get; set; }

    public string CancerTypeName { get; set; } = null!;

    public string? PathlogyGuids { get; set; }

    public string? StageGuids { get; set; }

    public string? BioMarkerAndValueGuids { get; set; }

    public string? TreatmentGoalGuids { get; set; }

    public string? LineOfTreatmentGuids { get; set; }

    public string? RegimenGuids { get; set; }

    public string? RegimenNames { get; set; }

    public string? DrugGPIs { get; set; }

    public string? DrugNames { get; set; }

    public int? PatientAgeLessThan { get; set; }

    public int? PatientAgeGreaterThan { get; set; }

    public bool? SendToxicities { get; set; }

    public string? OverAllSurvivalRates { get; set; }

    public string? PatientGender { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual ICollection<TreatmentQuestionToDataTagConnector> TreatmentQuestionToDataTagConnectors { get; } = new List<TreatmentQuestionToDataTagConnector>();
}
