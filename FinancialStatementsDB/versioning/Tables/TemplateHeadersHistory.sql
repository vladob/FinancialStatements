CREATE TABLE [versioning].[TemplateHeadersHistory] (
    [Id]              INT           NOT NULL,
	[TemplateTableId]	INT					NOT NULL,	-- Description: Foreign key referencing [TemplateTable].[Id]
	[textSk]			VARCHAR(MAX)		NULL,		-- API: text, Description: description of the column
	[textEn]			VARCHAR(MAX)		NULL,		-- API: text, Description: description of the column
	[rowPosition]		INT					NULL,		-- API: riadok, Description: row position in the header
	[columnPosition]	INT					NULL,		-- API: stlpec, Description: column position in the header
	[columnSpan]		INT					NULL,		-- API: sirkaStlpca, Description: number of columns
	[rowSpan]			INT					NULL,		-- API: vyskaRiadku, Description: number of rows
    [SysStartTime]    DATETIME2 (7) NOT NULL,
    [SysEndTime]      DATETIME2 (7) NOT NULL
);

