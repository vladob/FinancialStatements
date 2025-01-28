CREATE TABLE [indexing].[AccountingEntities_AnnualReports] (
    [AccountingEntityId] INT NOT NULL,
    [AnnualReportId]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountingEntityId] ASC, [AnnualReportId] ASC),
    FOREIGN KEY ([AccountingEntityId]) REFERENCES [dbo].[AccountingEntities] ([Id]),
    FOREIGN KEY ([AnnualReportId]) REFERENCES [dbo].[AnnualReports] ([Id])
);

