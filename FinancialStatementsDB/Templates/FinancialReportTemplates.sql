CREATE TABLE [templates].[FinancialReportTemplates] (
    [Id]               INT IDENTITY(1,1)                           NOT NULL, -- Local identifier
    [ErpId]            INT                                         NOT NULL, -- API: id, Description: identifier of the financial report template, maximum ten digits integer
    [name]             VARCHAR (100)                               NULL, -- API: nazov, Description: name of the template
    [mfSpecification]  VARCHAR (100)                               NULL, -- API: nariadenieMF, Description: specification of the Ministry of Finance regulation
    [validFrom]        DATE                                        NULL, -- API: platneOd, Description: validity of the template from the date
    [validTo]          DATE                                        NULL, -- API: platneDo, Description: validity of the template until the date
    [SysStartTime]     DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]       DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_FinancialReportTemplates] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[FinancialReportTemplatesHistory], DATA_CONSISTENCY_CHECK=ON));

