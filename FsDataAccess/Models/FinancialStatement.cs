﻿using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class FinancialStatement
{
    public int Id { get; set; }
    public int ErpId { get; set; }
    public int? AccountingEntityId { get; set; }
    public string? PeriodFrom { get; set; }
    public string? PeriodTo { get; set; }
    public DateOnly? SubmissionDate { get; set; }
    public DateOnly? PreparationDate { get; set; }
    public DateOnly? ApprovalDate { get; set; }
    public DateOnly? AssemblyDate { get; set; }
    public DateOnly? AuditorReportAttachmentDate { get; set; }
    public string? FundName { get; set; }
    public string? LeiCode { get; set; }
    public bool? Consolidated { get; set; }
    public bool? ConsolidatedCentralGovernment { get; set; }
    public bool? SummaryPublicAdministration { get; set; }
    public string? Type { get; set; }
    public DateOnly? LastModification { get; set; }
    public string? DataSource { get; set; }
    public virtual AccountingEntityStaging? AccountingEntity { get; set; }
    public virtual ICollection<FinancialReport> FinancialReports { get; set; } = new List<FinancialReport>();
    public virtual ICollection<AccountingEntityStaging> AccountingEntities { get; set; } = new List<AccountingEntityStaging>();
}
