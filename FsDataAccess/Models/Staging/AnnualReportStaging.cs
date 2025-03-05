using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDataAccess.Models
{
    public class AnnualReportStaging
    {
        public int ErpId { get; set; }
        public int? AccountingEntityId { get; set; }
        public string? TitleAe { get; set; }
        public string? Type { get; set; }
        public string? FundName { get; set; }
        public string? LeiCode { get; set; }
        public string? PeriodFrom { get; set; }
        public string? PeriodTo { get; set; }
        public DateOnly? SubmissionDate { get; set; }
        public DateOnly? AssemblyDate { get; set; }
        public string? DataAvailability { get; set; }
        public DateOnly? LastModification { get; set; }
        public string? DataSource { get; set; }
//        public virtual ICollection<AnnualReportAttachment> AnnualReportAttachments { get; set; } = new List<AnnualReportAttachment>();
//        public virtual ICollection<FinancialReport> FinancialReports { get; set; } = new List<FinancialReport>();
    }
}
