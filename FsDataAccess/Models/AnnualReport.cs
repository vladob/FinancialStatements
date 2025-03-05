using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class AnnualReport
{
    public int Id { get; set; }
    public int ErpId { get; set; }
    public string? TitleAe { get; set; }
    public string? Type { get; set; }
    public string? FundName { get; set; }
    public string? LeiCode { get; set; }
    public string? PeriodFrom { get; set; }
    public string? PeriodTo { get; set; }
    public DateOnly? SubmissionDate { get; set; }
    public DateOnly? AssemblyDate { get; set; }
    public string? DataAvailability { get; set; }
    public int? AccountingEntityId { get; set; }
    public DateOnly? LastModification { get; set; }
    public string? DataSource { get; set; }
    public virtual ICollection<AnnualReportAttachment> AnnualReportAttachments { get; set; } = new List<AnnualReportAttachment>();
    public virtual ICollection<FinancialReport> FinancialReports { get; set; } = new List<FinancialReport>();
    public virtual ICollection<AccountingEntityStaging> AccountingEntities { get; set; } = new List<AccountingEntityStaging>();
}
