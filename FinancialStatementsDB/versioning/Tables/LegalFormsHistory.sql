CREATE TABLE [versioning].[LegalFormsHistory] (
    [Id]           INT            NOT NULL,
    [Code]         VARCHAR (100)  NOT NULL,
    [TitleEng]     NVARCHAR (250) NULL,
    [TitleSk]      NVARCHAR (250) NULL,
    [SysStartTime] DATETIME2 (7)  NOT NULL,
    [SysEndTime]   DATETIME2 (7)  NOT NULL
);

