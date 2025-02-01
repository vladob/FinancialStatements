using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateTableStaging
{
    public int Id { get; set; }
    public int? FinancialReportTemplateId { get; set; }
    public string? NameSk { get; set; }
    public string? NameEn { get; set; }
    public int? NumberOfDataColumns { get; set; }
    public int? NumberOfColumns { get; set; }
    public virtual FinancialReportTemplateStaging? FinancialReportTemplate { get; set; }
    public virtual ICollection<TemplateHeaderStaging> TemplateHeaders { get; set; } = new List<TemplateHeaderStaging>();
    public virtual ICollection<TemplateRowStaging> TemplateRows { get; set; } = new List<TemplateRowStaging>();
}
