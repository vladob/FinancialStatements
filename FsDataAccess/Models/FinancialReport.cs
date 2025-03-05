using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class FinancialReport
{
    public int Id { get; set; }
    public int ErpId { get; set; }
    public int? FinancialStatementId { get; set; }
    public int? AnnualReportId { get; set; }
    public int? TemplateId { get; set; }
    public string? Currency { get; set; }
    public string? TaxOfficeCode { get; set; }
    public string? DataAvailability { get; set; }
    public DateOnly? LastModification { get; set; }
    public string? DataSource { get; set; }
    public virtual AnnualReport? AnnualReport { get; set; }
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual FinancialStatement? FinancialStatement { get; set; }
    public virtual ICollection<ReportContent> ReportContents { get; set; } = new List<ReportContent>();
    public virtual ICollection<ReportTable> ReportTables { get; set; } = new List<ReportTable>();
}
