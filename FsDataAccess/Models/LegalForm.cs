using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class LegalForm
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? TitleEng { get; set; }

    public string? TitleSk { get; set; }
}
