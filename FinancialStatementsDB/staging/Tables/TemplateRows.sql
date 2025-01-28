CREATE TABLE [staging].[TemplateRows] (
    [Id]              INT           NOT NULL,
    [TemplateTableId] INT           NULL,
    [code]            VARCHAR (100) NULL,
    [rowNumber]       INT           NULL,
    [description]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_staging_TemplateRows] PRIMARY KEY CLUSTERED ([Id] ASC)
);

