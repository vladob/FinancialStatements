using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateTable
{
    public int Id { get; set; }
    public int? FinancialReportTemplateId { get; set; }
    public string? NameSk { get; set; }
    public string? NameEn { get; set; }
    public int? NumberOfDataColumns { get; set; }
    public int? NumberOfColumns { get; set; }
    public virtual FinancialReportTemplate? FinancialReportTemplate { get; set; }
    public virtual ICollection<TemplateHeader> TemplateHeaders { get; set; } = new List<TemplateHeader>();
    public virtual ICollection<TemplateRow> TemplateRows { get; set; } = new List<TemplateRow>();
}
