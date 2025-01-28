CREATE TABLE [versioning].[AnnualReportAttachmentsHistory] (
    [Id]             INT           NOT NULL,
    [ErpId]          INT           NOT NULL,
    [AnnualReportId] INT           NULL,
    [name]           VARCHAR (100) NULL,
    [mimeType]       VARCHAR (80)  NULL,
    [size]           BIGINT        NULL,
    [digest]         VARCHAR (64)  NULL,
    [SysStartTime]   DATETIME2 (7) NOT NULL,
    [SysEndTime]     DATETIME2 (7) NOT NULL
);

