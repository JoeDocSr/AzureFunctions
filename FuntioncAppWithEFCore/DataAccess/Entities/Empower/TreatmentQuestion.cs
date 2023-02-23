using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class TreatmentQuestion
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Question { get; set; } = null!;

    public string? YesAction { get; set; }

    public string? NoAction { get; set; }

    public string? MessageToProvider { get; set; }

    public string? MessageToPatient { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? ReferenceText { get; set; }

    public virtual ICollection<TreatmentQuestionToDataTagConnector> TreatmentQuestionToDataTagConnectors { get; } = new List<TreatmentQuestionToDataTagConnector>();
}
