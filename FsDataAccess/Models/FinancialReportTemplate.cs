using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class FinancialReportTemplate
{
    public int Id { get; set; }

    public int ErpId { get; set; }

    public string? Name { get; set; }

    public string? MfSpecification { get; set; }

    public DateOnly? ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public DateOnly? LastModification { get; set; }

    public string? DataSource { get; set; }

    public virtual ICollection<TemplateTable> TemplateTables { get; set; } = new List<TemplateTable>();
}
