﻿using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class TemplateHeader
{
    public int Id { get; set; }
    public int? ErpId { get; set; }
    public int? TemplateTableId { get; set; }
    public string? TextSk { get; set; }
    public string? TextEn { get; set; }
    public int? RowPosition { get; set; }
    public int? ColumnPosition { get; set; }
    public int? ColumnSpan { get; set; }
    public int? RowSpan { get; set; }
    public virtual TemplateTable? TemplateTable { get; set; }
}
