CREATE TABLE [versioning].[FinancialReportTemplatesHistory] (
    [Id]               INT           NOT NULL,
    [ErpId]            INT           NOT NULL,
    [name]             VARCHAR (100) NULL,
    [mfSpecification]  VARCHAR (100) NULL,
    [validFrom]        DATE          NULL,
    [validTo]          DATE          NULL,
    [lastModification] DATE          NULL,
    [dataSource]       VARCHAR (30)  NULL,
    [SysStartTime]     DATETIME2 (7) NOT NULL,
    [SysEndTime]       DATETIME2 (7) NOT NULL
);

