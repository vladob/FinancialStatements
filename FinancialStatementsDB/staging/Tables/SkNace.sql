CREATE TABLE [staging].[SkNace] (
    [Code]     VARCHAR (100)  NOT NULL,
    [TitleEng] NVARCHAR (250) NULL,
    [TitleSk]  NVARCHAR (250) NULL, 
    CONSTRAINT [PK_SkNaceStaging] PRIMARY KEY ([Code])
);