CREATE TABLE [dbo].[FinancialReports] (
    [Id]                   INT                                         NOT NULL,
    [ErpId]                INT                                         NOT NULL,
    [FinancialStatementId] INT                                         NULL,
    [AnnualReportId]       INT                                         NULL,
    [TemplateId]           INT                                         NULL,
    [currency]             VARCHAR (9)                                 NULL,
    [taxOfficeCode]        VARCHAR (3)                                 NULL,
    [dataAvailability]     VARCHAR (30)                                NULL,
    [lastModification]     DATE                                        NULL,
    [dataSource]           VARCHAR (30)                                NULL,
    [SysStartTime]         DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]           DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_FinancialReports] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AnnualReportId]) REFERENCES [dbo].[AnnualReports] ([Id]),
    FOREIGN KEY ([FinancialStatementId]) REFERENCES [dbo].[FinancialStatements] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[FinancialReportsHistory], DATA_CONSISTENCY_CHECK=ON));

