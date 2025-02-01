using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class FinancialReportTemplateStaging
{
    public int ErpId { get; set; }
    public string? Name { get; set; }
    public string? MfSpecification { get; set; }
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    public virtual ICollection<TemplateTableStaging> TemplateTables { get; set; } = new List<TemplateTableStaging>();
}
