CREATE TABLE [staging].[ReportTables] (
    [Id]                INT           NOT NULL,
    [FinancialReportId] INT           NULL,
    [name]              VARCHAR (100) NULL,
    [data]              MONEY         NULL,
    CONSTRAINT [PK_staging_ReportTables] PRIMARY KEY CLUSTERED ([Id] ASC)
);

