using System;
using System.Collections.Generic;

namespace FsDataAccess.Models;

public partial class AccountingEntity
{
    public int Id { get; set; }

    public string ErpId { get; set; } = null!;

    public string? Cin { get; set; }

    public string? Tin { get; set; }

    public string? Sid { get; set; }

    public string? TitleAe { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Zip { get; set; }

    public DateOnly? Established { get; set; }

    public DateOnly? Cancellation { get; set; }

    public int? LegalFormId { get; set; }

    public int? SkNaceId { get; set; }

    public int? OrganizationSizeId { get; set; }

    public int? OwnershipTypeId { get; set; }

    public int? RegionId { get; set; }

    public int? DistrictId { get; set; }

    public int? RegisterredOfficeId { get; set; }

    public bool? Consolidated { get; set; }

    public string? DataSource { get; set; }

    public DateOnly? LastModification { get; set; }

    public virtual ICollection<FinancialStatement> FinancialStatementsNavigation { get; set; } = new List<FinancialStatement>();

    public virtual ICollection<AnnualReport> AnnualReports { get; set; } = new List<AnnualReport>();

    public virtual ICollection<FinancialStatement> FinancialStatements { get; set; } = new List<FinancialStatement>();
}
