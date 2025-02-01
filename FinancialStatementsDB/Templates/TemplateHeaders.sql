CREATE TABLE [templates].[TemplateHeaders] (
    [Id]				INT IDENTITY(1,1)	NOT NULL,	-- Local identifier
	[TemplateTableId]	INT					NOT NULL,	-- Description: Foreign key referencing [TemplateTable].[Id]
	[textSk]			VARCHAR(MAX)		NULL,		-- API: text, Description: description of the column
	[textEn]			VARCHAR(MAX)		NULL,		-- API: text, Description: description of the column
	[rowPosition]		INT					NULL,		-- API: riadok, Description: row position in the header
	[columnPosition]	INT					NULL,		-- API: stlpec, Description: column position in the header
	[columnSpan]		INT					NULL,		-- API: sirkaStlpca, Description: number of columns
	[rowSpan]			INT					NULL,		-- API: vyskaRiadku, Description: number of rows
    [SysStartTime]    DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateHeaders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TemplateHeaders_TemplateTables] FOREIGN KEY ([TemplateTableId]) REFERENCES [templates].[TemplateTables] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateHeadersHistory], DATA_CONSISTENCY_CHECK=ON));

