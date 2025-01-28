CREATE TABLE [staging].[AnnualReportAttachments] (
    [Id]             INT           NOT NULL,
    [ErpId]          INT           NOT NULL,
    [AnnualReportId] INT           NULL,
    [name]           VARCHAR (100) NULL,
    [mimeType]       VARCHAR (80)  NULL,
    [size]           BIGINT        NULL,
    [digest]         VARCHAR (64)  NULL,
    CONSTRAINT [PK_staging_AnnualReportAttachments] PRIMARY KEY CLUSTERED ([Id] ASC)
);

