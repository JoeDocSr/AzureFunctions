using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class PatientClinicalDataDrug
{
    public long Id { get; set; }

    public long PatientClinicalDataId { get; set; }

    public string DrugName { get; set; } = null!;

    public string Dose { get; set; } = null!;
}
