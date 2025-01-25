using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class Attachment
{
    public int Id { get; set; }

    public int ErpId { get; set; }

    public int? FinancialReportId { get; set; }

    public string? Name { get; set; }

    public string? MimeType { get; set; }

    public long? Size { get; set; }

    public int? PageCount { get; set; }

    public string? Digest { get; set; }

    public string? Language { get; set; }

    public virtual FinancialReport? FinancialReport { get; set; }
}
