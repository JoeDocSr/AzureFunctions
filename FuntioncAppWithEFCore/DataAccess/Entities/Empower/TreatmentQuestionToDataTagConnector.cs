using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class TreatmentQuestionToDataTagConnector
{
    public long TagConfigurationId { get; set; }

    public long TreatmentQuestionConfigId { get; set; }

    public long Id { get; set; }

    public virtual DataTag TagConfiguration { get; set; } = null!;

    public virtual TreatmentQuestion TreatmentQuestionConfig { get; set; } = null!;
}
