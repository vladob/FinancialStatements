using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateRow
{
    public int Id { get; set; }

    public int? TemplateTableId { get; set; }

    public string? Code { get; set; }

    public int? RowNumber { get; set; }

    public string? Description { get; set; }

    public virtual TemplateTable? TemplateTable { get; set; }
}
