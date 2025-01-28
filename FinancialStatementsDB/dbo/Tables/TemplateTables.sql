CREATE TABLE [dbo].[TemplateTables] (
    [Id]                        INT                                         NOT NULL,
    [FinancialReportTemplateId] INT                                         NULL,
    [name]                      VARCHAR (100)                               NULL,
    [SysStartTime]              DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]                DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateTables] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FinancialReportTemplateId]) REFERENCES [dbo].[FinancialReportTemplates] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateTablesHistory], DATA_CONSISTENCY_CHECK=ON));

