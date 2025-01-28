CREATE TABLE [dbo].[ReportTables] (
    [Id]                INT                                         NOT NULL,
    [FinancialReportId] INT                                         NULL,
    [name]              VARCHAR (100)                               NULL,
    [data]              MONEY                                       NULL,
    [SysStartTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]        DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_ReportTables] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FinancialReportId]) REFERENCES [dbo].[FinancialReports] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[ReportTablesHistory], DATA_CONSISTENCY_CHECK=ON));

