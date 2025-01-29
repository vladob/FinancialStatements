﻿CREATE TABLE [classifications].[OrganizationSizes] (
    [Id]           INT                                         IDENTITY (1, 1) NOT NULL,
    [Code]         VARCHAR (100)                               NOT NULL,
    [TitleEng]     NVARCHAR (250)                              NULL,
    [TitleSk]      NVARCHAR (250)                              NULL,
    [SysStartTime] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]   DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_classifications_OrganizationSizes] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[OrganizationSizesHistory], DATA_CONSISTENCY_CHECK=ON));

