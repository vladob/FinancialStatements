CREATE TABLE [staging].[TemplateHeaders] (
    [Id]                            INT IDENTITY(1,1)   NOT NULL,   -- Local identifier
    [TemplateTableId]  INT          NOT NULL,   -- Description: Reference to  [staging].[TemplateTables].[Id]
    [rowPosition]     INT           NULL,       -- API: riadok, position in the header, integer
    [columnPosition]  INT           NULL,       -- API: stlpec, position in the header, integer
    [rowSpan]         INT           NULL,       -- API: vyskaRiadku - number of rows, number
    [columnSpan]      INT           NULL,       -- API: sirkaStlpca - number of columns, number
    [textEn]          VARCHAR (MAX) NULL,       -- API: (english) description of the column, the object where key is the localization and the value is a string
    [textSk]          VARCHAR (MAX) NULL,       -- API: (slovak) description of the column, the object where key is the localization and the value is a string
    CONSTRAINT [PK_TemplateHeaders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TemplateHeaders_TemplateTables] FOREIGN KEY ([TemplateTableId]) REFERENCES [staging].[TemplateTables] (Id),
);