CREATE TABLE [dbo].[AnnualReports] (
    [Id]                 INT                                         NOT NULL,
    [ErpId]              INT                                         NOT NULL,
    [titleAE]            VARCHAR (500)                               NULL,
    [type]               VARCHAR (100)                               NULL,
    [fundName]           VARCHAR (500)                               NULL,
    [leiCode]            VARCHAR (20)                                NULL,
    [periodFrom]         VARCHAR (7)                                 NULL,
    [periodTo]           VARCHAR (7)                                 NULL,
    [submissionDate]     DATE                                        NULL,
    [assemblyDate]       DATE                                        NULL,
    [dataAvailability]   VARCHAR (30)                                NULL,
    [accountingEntityId] INT                                         NULL,
    [lastModification]   DATE                                        NULL,
    [dataSource]         VARCHAR (30)                                NULL,
    [SysStartTime]       DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]         DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_AnnualReports] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[AnnualReportsHistory], DATA_CONSISTENCY_CHECK=ON));

