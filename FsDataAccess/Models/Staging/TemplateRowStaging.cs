using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateRowStaging
{
    public int Id { get; set; }
    public int? RowNumber { get; set; }
    public string? TextSk { get; set; }
    public string? TextEn { get; set; }
    public string? Designation { get; set; }
    public virtual TemplateTableStaging? TemplateTable { get; set; }
}
