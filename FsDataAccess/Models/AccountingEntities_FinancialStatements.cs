public partial class AccountingEntities_FinancialStatements
{
    public int AccountingEntityId { get; set; }
    public int FinancialStatementId { get; set; }
    public string FinancialStatementErpId { get; set; } = null!;

//    public virtual AccountingEntity AccountingEntity { get; set; } = null!;
//    public virtual FinancialStatement FinancialStatement { get; set; } = null!;
}

