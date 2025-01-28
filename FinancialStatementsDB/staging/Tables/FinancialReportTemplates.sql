CREATE TABLE [staging].[FinancialReportTemplates] (
    [Id]               INT           NOT NULL,
    [ErpId]            INT           NOT NULL,
    [name]             VARCHAR (100) NULL,
    [mfSpecification]  VARCHAR (100) NULL,
    [validFrom]        DATE          NULL,
    [validTo]          DATE          NULL,
    [lastModification] DATE          NULL,
    [dataSource]       VARCHAR (30)  NULL,
    CONSTRAINT [PK_staging_FinancialReportTemplates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

