CREATE TABLE [versioning].[TemplateTablesHistory] (
    [Id]                        INT           NOT NULL,
	[FinancialReportTemplateId] INT     NULL,	    -- Description: Reference to  [templates].[FinancialReportTemplate].[Id]
	[NameSk] VARCHAR(100)               NULL,		-- API: (slovak) name of table, the object where key is the localization and the value is a string
	[NameEn] VARCHAR(100)               NULL,		-- API: (english) name of table, the object where key is the localization and the value is a string
	[NumberOfColumns] INT               NULL,		-- API: pocetStlpcov (not in API documentation, but is reutrned in API)
	[NumberOfDataColumns] INT           NULL,		-- API: pocetDatovychStlpcov (not in API documentation, but is reutrned in API)
    [SysStartTime]              DATETIME2 (7) NOT NULL,
    [SysEndTime]                DATETIME2 (7) NOT NULL
);

