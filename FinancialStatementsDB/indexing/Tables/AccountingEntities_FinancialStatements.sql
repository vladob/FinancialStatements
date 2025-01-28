CREATE TABLE [indexing].[AccountingEntities_FinancialStatements] (
    [AccountingEntityId]   INT NOT NULL,
    [FinancialStatementId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountingEntityId] ASC, [FinancialStatementId] ASC),
    FOREIGN KEY ([AccountingEntityId]) REFERENCES [dbo].[AccountingEntities] ([Id]),
    FOREIGN KEY ([FinancialStatementId]) REFERENCES [dbo].[FinancialStatements] ([Id])
);

