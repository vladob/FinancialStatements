CREATE TABLE [dbo].[TemplateHeaders] (
    [Id]              INT                                         NOT NULL,
    [TemplateTableId] INT                                         NULL,
    [text]            VARCHAR (MAX)                               NULL,
    [rowPosition]     INT                                         NULL,
    [columnPosition]  INT                                         NULL,
    [columnSpan]      INT                                         NULL,
    [rowSpan]         INT                                         NULL,
    [SysStartTime]    DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_TemplateHeaders] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TemplateTableId]) REFERENCES [dbo].[TemplateTables] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[TemplateHeadersHistory], DATA_CONSISTENCY_CHECK=ON));

