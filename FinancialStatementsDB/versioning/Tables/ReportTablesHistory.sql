CREATE TABLE [versioning].[ReportTablesHistory] (
    [Id]                INT           NOT NULL,
    [FinancialReportId] INT           NULL,
    [name]              VARCHAR (100) NULL,
    [data]              MONEY         NULL,
    [SysStartTime]      DATETIME2 (7) NOT NULL,
    [SysEndTime]        DATETIME2 (7) NOT NULL
);

