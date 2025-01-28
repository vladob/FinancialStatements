CREATE TABLE [staging].[TemplateTables] (
    [Id]                        INT           NOT NULL,
    [FinancialReportTemplateId] INT           NULL,
    [name]                      VARCHAR (100) NULL,
    CONSTRAINT [PK_staging_TemplateTables] PRIMARY KEY CLUSTERED ([Id] ASC)
);

