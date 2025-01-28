CREATE TABLE [staging].[FinancialStatements] (
    [Id]                            INT           NOT NULL,
    [ErpId]                         INT           NOT NULL,
    [AccountingEntityId]            INT           NULL,
    [periodFrom]                    VARCHAR (7)   NULL,
    [periodTo]                      VARCHAR (7)   NULL,
    [submissionDate]                DATE          NULL,
    [preparationDate]               DATE          NULL,
    [approvalDate]                  DATE          NULL,
    [assemblyDate]                  DATE          NULL,
    [auditorReportAttachmentDate]   DATE          NULL,
    [fundName]                      VARCHAR (500) NULL,
    [leiCode]                       VARCHAR (20)  NULL,
    [consolidated]                  BIT           NULL,
    [consolidatedCentralGovernment] BIT           NULL,
    [summaryPublicAdministration]   BIT           NULL,
    [type]                          VARCHAR (50)  NULL,
    [lastModification]              DATE          NULL,
    [dataSource]                    VARCHAR (30)  NULL,
    CONSTRAINT [PK_staging_FinancialStatements] PRIMARY KEY CLUSTERED ([Id] ASC)
);

