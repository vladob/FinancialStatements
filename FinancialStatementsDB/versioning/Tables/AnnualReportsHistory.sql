CREATE TABLE [versioning].[AnnualReportsHistory] (
    [Id]                 INT           NOT NULL,
    [ErpId]              INT           NOT NULL,
    [titleAE]            VARCHAR (500) NULL,
    [type]               VARCHAR (100) NULL,
    [fundName]           VARCHAR (500) NULL,
    [leiCode]            VARCHAR (20)  NULL,
    [periodFrom]         VARCHAR (7)   NULL,
    [periodTo]           VARCHAR (7)   NULL,
    [submissionDate]     DATE          NULL,
    [assemblyDate]       DATE          NULL,
    [dataAvailability]   VARCHAR (30)  NULL,
    [accountingEntityId] INT           NULL,
    [lastModification]   DATE          NULL,
    [dataSource]         VARCHAR (30)  NULL,
    [SysStartTime]       DATETIME2 (7) NOT NULL,
    [SysEndTime]         DATETIME2 (7) NOT NULL
);

