using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDataAccess.Models
{
    public class AccountingEntityStaging
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
        public string? LegalFormId { get; set; }
        public string? SkNaceId { get; set; }
        public string? OrganizationSizeId { get; set; }
        public string? OwnershipTypeId { get; set; }
        public string? RegionId { get; set; }
        public string? DistrictId { get; set; }
        public string? RegisterredOfficeId { get; set; }
        public bool? Consolidated { get; set; }
        public string? DataSource { get; set; }
        public DateOnly? LastModification { get; set; }
        public virtual ICollection<FinancialStatement> FinancialStatementsNavigation { get; set; } = new List<FinancialStatement>();
        public virtual ICollection<AnnualReport> AnnualReports { get; set; } = new List<AnnualReport>();
        public virtual ICollection<FinancialStatement> FinancialStatements { get; set; } = new List<FinancialStatement>();
    }
}
