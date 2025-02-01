CREATE TABLE [staging].[TemplateTables] (
    [Id]                            INT IDENTITY(1,1)   NOT NULL,   -- Local identifier
    [FinancialReportTemplateErpId]  INT                 NOT NULL,   -- Description: Reference to  [templates].[FinancialReportTemplate].[Id]
    [NameSk]                        VARCHAR(100)        NOT NULL,   -- API: (slovak) name of table, the object where key is the localization and the value is a string
    [NameEn]                        VARCHAR(100)        NULL,       -- API: (english) name of table, the object where key is the localization and the value is a string
    [NumberOfColumns]               INT                 NULL,       -- API: pocetStlpcov (not in API documentation, but is reutrned in API)
    [NumberOfDataColumns]           INT                 NULL,       -- API: pocetDatovychStlpcov (not in API documentation, but is reutrned in API)
    CONSTRAINT [PK_TemplateTables] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TemplateTables_FinancialReportTemplates] FOREIGN KEY ([FinancialReportTemplateErpId]) REFERENCES [staging].[FinancialReportTemplates] (ErpId),
);