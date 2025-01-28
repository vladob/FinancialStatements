CREATE TABLE [dbo].[TemplateRows] (
    [Id]              INT                                         NOT NULL,
    [TemplateTableId] INT                                         NULL,
    [code]            VARCHAR (100)                               NULL,
    [rowNumber]       INT                                         NULL,
    [description]     VARCHAR (MAX)                               NULL,
    [SysStartTime]    DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateRows] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TemplateTableId]) REFERENCES [dbo].[TemplateTables] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateRowsHistory], DATA_CONSISTENCY_CHECK=ON));

