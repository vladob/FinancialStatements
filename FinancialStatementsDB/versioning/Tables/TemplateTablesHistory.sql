CREATE TABLE [versioning].[TemplateTablesHistory] (
    [Id]                        INT           NOT NULL,
    [FinancialReportTemplateId] INT           NULL,
    [name]                      VARCHAR (100) NULL,
    [SysStartTime]              DATETIME2 (7) NOT NULL,
    [SysEndTime]                DATETIME2 (7) NOT NULL
);

