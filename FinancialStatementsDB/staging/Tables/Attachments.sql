﻿CREATE TABLE [staging].[Attachments] (
    [Id]                INT           NOT NULL,
    [ErpId]             INT           NOT NULL,
    [FinancialReportId] INT           NULL,
    [name]              VARCHAR (100) NULL,
    [mimeType]          VARCHAR (80)  NULL,
    [size]              BIGINT        NULL,
    [pageCount]         INT           NULL,
    [digest]            VARCHAR (64)  NULL,
    [language]          VARCHAR (3)   NULL,
    CONSTRAINT [PK_staging_Attachments] PRIMARY KEY CLUSTERED ([Id] ASC)
);

