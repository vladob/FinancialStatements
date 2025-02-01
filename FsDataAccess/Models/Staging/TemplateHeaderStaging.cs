using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateHeaderStaging
{
    public int? RowPosition { get; set; }
    public int? ColumnPosition { get; set; }
    public string? TextSk { get; set; }
    public string? TextEn { get; set; }
    public int? RowSpan { get; set; }
    public int? ColumnSpan { get; set; }
    public virtual TemplateTableStaging? TemplateTable { get; set; }
}
