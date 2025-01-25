using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class ReportContent
{
    public int Id { get; set; }

    public int? FinancialReportId { get; set; }

    public string? CoverPageTitle { get; set; }

    public string? CoverPageIco { get; set; }

    public string? CoverPageDic { get; set; }

    public string? CoverPageSid { get; set; }

    public string? CoverPageAddress { get; set; }

    public string? CoverPageLegalFormId { get; set; }

    public string? CoverPageSkNaceId { get; set; }

    public string? CoverPageType { get; set; }

    public bool? CoverPageConsolidated { get; set; }

    public bool? CoverPageConsolidatedCg { get; set; }

    public bool? CoverPageSummaryPa { get; set; }

    public string? CoverPageTypeUnit { get; set; }

    public string? CommercialRegister { get; set; }

    public string? FundName { get; set; }

    public string? LeiCode { get; set; }

    public string? PeriodFrom { get; set; }

    public string? PeriodTo { get; set; }

    public string? PreviousPeriodFrom { get; set; }

    public string? PreviousPeriodTo { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public DateOnly? PreparationDate { get; set; }

    public DateOnly? AssemblyDate { get; set; }

    public DateOnly? AuditorReportAttachmentDate { get; set; }

    public virtual FinancialReport? FinancialReport { get; set; }
}
