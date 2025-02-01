CREATE TABLE [dbo].[AccountingEntities] (
    [Id]                  INT                                         IDENTITY (1, 1) NOT NULL,
    [ErpId]               VARCHAR (10)                                NOT NULL,
    [cin]                 VARCHAR (20)                                NULL,
    [tin]                 VARCHAR (20)                                NULL,
    [sid]                 VARCHAR (20)                                NULL,
    [titleAE]             NVARCHAR (500)                              NULL,
    [city]                NVARCHAR (200)                              NULL,
    [street]              NVARCHAR (200)                              NULL,
    [zip]                 VARCHAR (10)                                NULL,
    [established]         DATE                                        NULL,
    [cancellation]        DATE                                        NULL,
    [legalFormId]         INT                               NULL,
    [skNaceId]            INT                               NULL,
    [organizationSizeId]  INT                               NULL,
    [ownershipTypeId]     INT                               NULL,
    [regionId]            INT                               NULL,
    [districtId]          INT                               NULL,
    [registerredOfficeId] INT                               NULL,
    [consolidated]        BIT                                         NULL,
    [dataSource]          VARCHAR (30)                                NULL,
    [lastModification]    DATE                                        NULL,
    [SysStartTime]        DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]          DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_dbo_AccountingEntities] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[AccountingEntitiesHistory], DATA_CONSISTENCY_CHECK=ON));

