CREATE TABLE [staging].[FinancialReports] (
    [Id]                   INT          NOT NULL,
    [ErpId]                INT          NOT NULL,
    [FinancialStatementId] INT          NULL,
    [AnnualReportId]       INT          NULL,
    [TemplateId]           INT          NULL,
    [currency]             VARCHAR (9)  NULL,
    [taxOfficeCode]        VARCHAR (3)  NULL,
    [dataAvailability]     VARCHAR (30) NULL,
    [lastModification]     DATE         NULL,
    [dataSource]           VARCHAR (30) NULL,
    CONSTRAINT [PK_staging_FinancialReports] PRIMARY KEY CLUSTERED ([Id] ASC)
);

