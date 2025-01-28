CREATE TABLE [dbo].[FinancialReportTemplates] (
    [Id]               INT                                         NOT NULL,
    [ErpId]            INT                                         NOT NULL,
    [name]             VARCHAR (100)                               NULL,
    [mfSpecification]  VARCHAR (100)                               NULL,
    [validFrom]        DATE                                        NULL,
    [validTo]          DATE                                        NULL,
    [lastModification] DATE                                        NULL,
    [dataSource]       VARCHAR (30)                                NULL,
    [SysStartTime]     DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]       DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_FinancialReportTemplates] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[FinancialReportTemplatesHistory], DATA_CONSISTENCY_CHECK=ON));

