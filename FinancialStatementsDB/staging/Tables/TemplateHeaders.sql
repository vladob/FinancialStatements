CREATE TABLE [staging].[TemplateHeaders] (
    [Id]              INT           NOT NULL,
    [TemplateTableId] INT           NULL,
    [text]            VARCHAR (MAX) NULL,
    [rowPosition]     INT           NULL,
    [columnPosition]  INT           NULL,
    [columnSpan]      INT           NULL,
    [rowSpan]         INT           NULL,
    CONSTRAINT [PK_staging_TemplateHeaders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

