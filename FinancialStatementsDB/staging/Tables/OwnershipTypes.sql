CREATE TABLE [staging].[OwnershipTypes] (
    [Code]     VARCHAR (100)  NOT NULL,
    [TitleEng] NVARCHAR (250) NULL,
    [TitleSk]  NVARCHAR (250) NULL, 
    CONSTRAINT [PK_OwnershipTypesStaging] PRIMARY KEY ([Code])
);