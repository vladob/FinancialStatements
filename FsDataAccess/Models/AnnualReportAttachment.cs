using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class AnnualReportAttachment
{
    public int Id { get; set; }

    public int ErpId { get; set; }

    public int? AnnualReportId { get; set; }

    public string? Name { get; set; }

    public string? MimeType { get; set; }

    public long? Size { get; set; }

    public string? Digest { get; set; }

    public virtual AnnualReport? AnnualReport { get; set; }
}
