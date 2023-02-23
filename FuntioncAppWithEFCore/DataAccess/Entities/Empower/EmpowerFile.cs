using System;
using System.Collections.Generic;

namespace Empower.DataAccess.Entities.Empower;

public partial class EmpowerFile
{
    public long Id { get; set; }

    public string FileName { get; set; } = null!;

    public string? Extension { get; set; }

    public long FileSize { get; set; }

    public string? MimeType { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public string Version { get; set; } = null!;

    public bool IsReadOnly { get; set; }

    public string? LogicalLocation { get; set; }

    public bool IsHidden { get; set; }

    public bool IsEncrypted { get; set; }

    public string? Comments { get; set; }

    public Guid? CreatedByUserID { get; set; }

    public Guid? ModifiedByUserID { get; set; }

    public bool IsCompressed { get; set; }

    public int CompressionType { get; set; }

    public long? CompressedFileSize { get; set; }

    public virtual FileDatum? FileDatum { get; set; }
}
