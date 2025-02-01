CREATE TABLE [templates].[TemplateRows] (
    [Id]                INT IDENTITY(1,1)   NOT NULL,   -- Local identifier
    [TemplateTableId]	INT					NOT NULL,   -- Description: Foreign key referencing [TemplateTable].[Id]
	[rowNumber]         INT                 NULL,       -- API: cisloRiadku, Description: serial number of the line
	[designation]       VARCHAR(100)        NULL,       -- API: oznacenie, Description: typically special code of the line
	[textSk]            VARCHAR(MAX)        NULL,       -- API: text, Description: description of the line
	[textEn]            VARCHAR(MAX)        NULL,       -- API: text, Description: description of the line
    [SysStartTime]    DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateRows] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TemplateRows_TemplateTables] FOREIGN KEY ([TemplateTableId]) REFERENCES [templates].[TemplateTables] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateRowsHistory], DATA_CONSISTENCY_CHECK=ON));
