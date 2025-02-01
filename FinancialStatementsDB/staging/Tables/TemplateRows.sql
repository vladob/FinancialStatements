CREATE TABLE [staging].[TemplateRows] (
    [Id]                INT IDENTITY(1,1)   NOT NULL,   -- Local identifier
    [TemplateTableId]   INT                 NOT NULL,   -- Description: Reference to  [staging].[TemplateTables].[Id]
    [rowNumber]         INT                 NOT NULL,   -- API: cisloRiadku, serial number of the line
    [text_sk]           VARCHAR (MAX)       NULL,       -- API: text.sk, (slovak) a description of the line, the object where key is the localization and the value is a string
    [text_en]           VARCHAR (MAX)       NULL,       -- API: text.en, (english) a description of the line, the object where key is the localization and the value is a string
    [designation]       NVARCHAR(100)       NULL        -- API: oznacenie, typically special code of the line
);