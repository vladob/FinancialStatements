CREATE TABLE [dbo].[FinancialStatements] (
    [Id]                            INT                                         NOT NULL,
    [ErpId]                         INT                                         NOT NULL,
    [AccountingEntityId]            INT                                         NULL,
    [periodFrom]                    VARCHAR (7)                                 NULL,
    [periodTo]                      VARCHAR (7)                                 NULL,
    [submissionDate]                DATE                                        NULL,
    [preparationDate]               DATE                                        NULL,
    [approvalDate]                  DATE                                        NULL,
    [assemblyDate]                  DATE                                        NULL,
    [auditorReportAttachmentDate]   DATE                                        NULL,
    [fundName]                      VARCHAR (500)                               NULL,
    [leiCode]                       VARCHAR (20)                                NULL,
    [consolidated]                  BIT                                         NULL,
    [consolidatedCentralGovernment] BIT                                         NULL,
    [summaryPublicAdministration]   BIT                                         NULL,
    [type]                          VARCHAR (50)                                NULL,
    [lastModification]              DATE                                        NULL,
    [dataSource]                    VARCHAR (30)                                NULL,
    [SysStartTime]                  DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]                    DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_FinancialStatements] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AccountingEntityId]) REFERENCES [dbo].[AccountingEntities] ([Id]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[FinancialStatementsHistory], DATA_CONSISTENCY_CHECK=ON));

