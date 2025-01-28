CREATE TABLE [versioning].[TemplateRowsHistory] (
    [Id]              INT           NOT NULL,
    [TemplateTableId] INT           NULL,
    [code]            VARCHAR (100) NULL,
    [rowNumber]       INT           NULL,
    [description]     VARCHAR (MAX) NULL,
    [SysStartTime]    DATETIME2 (7) NOT NULL,
    [SysEndTime]      DATETIME2 (7) NOT NULL
);

