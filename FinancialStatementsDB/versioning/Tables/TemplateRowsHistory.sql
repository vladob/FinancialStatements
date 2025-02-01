CREATE TABLE [versioning].[TemplateRowsHistory] (
    [Id]              INT           NOT NULL,
    [TemplateTableId]	INT					NOT NULL,   -- Description: Foreign key referencing [TemplateTable].[Id]
	[rowNumber]         INT                 NULL,       -- API: cisloRiadku, Description: serial number of the line
	[designation]       VARCHAR(100)        NULL,       -- API: oznacenie, Description: typically special code of the line
	[textSk]            VARCHAR(MAX)        NULL,       -- API: text, Description: description of the line
	[textEn]            VARCHAR(MAX)        NULL,       -- API: text, Description: description of the line
    [SysStartTime]    DATETIME2 (7) NOT NULL,
    [SysEndTime]      DATETIME2 (7) NOT NULL
);

