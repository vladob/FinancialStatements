CREATE TABLE [versioning].[TemplateHeadersHistory] (
    [Id]              INT           NOT NULL,
    [TemplateTableId] INT           NULL,
    [text]            VARCHAR (MAX) NULL,
    [rowPosition]     INT           NULL,
    [columnPosition]  INT           NULL,
    [columnSpan]      INT           NULL,
    [rowSpan]         INT           NULL,
    [SysStartTime]    DATETIME2 (7) NOT NULL,
    [SysEndTime]      DATETIME2 (7) NOT NULL
);

