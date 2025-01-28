CREATE TABLE [dbo].[AnnualReportAttachments] (
    [Id]             INT                                         NOT NULL,
    [ErpId]          INT                                         NOT NULL,
    [AnnualReportId] INT                                         NULL,
    [name]           VARCHAR (100)                               NULL,
    [mimeType]       VARCHAR (80)                                NULL,
    [size]           BIGINT                                      NULL,
    [digest]         VARCHAR (64)                                NULL,
    [SysStartTime]   DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]     DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_AnnualReportAttachments] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AnnualReportId]) REFERENCES [dbo].[AnnualReports] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[AnnualReportAttachmentsHistory], DATA_CONSISTENCY_CHECK=ON));

