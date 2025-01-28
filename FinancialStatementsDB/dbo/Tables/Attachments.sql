CREATE TABLE [dbo].[Attachments] (
    [Id]                INT                                         NOT NULL,
    [ErpId]             INT                                         NOT NULL,
    [FinancialReportId] INT                                         NULL,
    [name]              VARCHAR (100)                               NULL,
    [mimeType]          VARCHAR (80)                                NULL,
    [size]              BIGINT                                      NULL,
    [pageCount]         INT                                         NULL,
    [digest]            VARCHAR (64)                                NULL,
    [language]          VARCHAR (3)                                 NULL,
    [SysStartTime]      DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]        DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_Attachments] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FinancialReportId]) REFERENCES [dbo].[FinancialReports] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[AttachmentsHistory], DATA_CONSISTENCY_CHECK=ON));

