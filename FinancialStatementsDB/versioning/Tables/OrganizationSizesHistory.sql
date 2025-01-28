CREATE TABLE [versioning].[OrganizationSizesHistory] (
    [Id]           INT            NOT NULL,
    [Code]         VARCHAR (100)  NULL,
    [TitleEng]     NVARCHAR (250) NULL,
    [TitleSk]      NVARCHAR (250) NULL,
    [SysStartTime] DATETIME2 (7)  NOT NULL,
    [SysEndTime]   DATETIME2 (7)  NOT NULL
);

