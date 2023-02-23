using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class FileDatum
{
    public long Id { get; set; }

    public byte[] Document { get; set; } = null!;

    public virtual EmpowerFile IdNavigation { get; set; } = null!;
}
