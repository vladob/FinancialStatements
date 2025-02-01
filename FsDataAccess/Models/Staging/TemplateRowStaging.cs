using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateRowStaging
{
    public int? RowNumber { get; set; }
    public string? TextSk { get; set; }
    public string? TextEn { get; set; }
    public string? Code { get; set; }
    public virtual TemplateTableStaging? TemplateTable { get; set; }
}
