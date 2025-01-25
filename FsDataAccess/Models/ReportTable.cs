using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class ReportTable
{
    public int Id { get; set; }

    public int? FinancialReportId { get; set; }

    public string? Name { get; set; }

    public decimal? Data { get; set; }

    public virtual FinancialReport? FinancialReport { get; set; }
}
