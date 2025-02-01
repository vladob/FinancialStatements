CREATE TABLE [templates].[TemplateTables] (
    [Id] INT IDENTITY(1,1)              NOT NULL,	-- Local identifier
	[FinancialReportTemplateId] INT     NULL,	    -- Description: Reference to  [templates].[FinancialReportTemplate].[Id]
	[NameSk] VARCHAR(100)               NULL,		-- API: (slovak) name of table, the object where key is the localization and the value is a string
	[NameEn] VARCHAR(100)               NULL,		-- API: (english) name of table, the object where key is the localization and the value is a string
	[NumberOfColumns] INT               NULL,		-- API: pocetStlpcov (not in API documentation, but is reutrned in API)
	[NumberOfDataColumns] INT           NULL,		-- API: pocetDatovychStlpcov (not in API documentation, but is reutrned in API)
    [SysStartTime]              DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]                DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateTables] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TemplateTables_FinancialReportTemplates] FOREIGN KEY ([FinancialReportTemplateId]) REFERENCES [templates].[FinancialReportTemplates] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateTablesHistory], DATA_CONSISTENCY_CHECK=ON));

