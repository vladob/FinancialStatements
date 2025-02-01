CREATE TABLE [staging].[Locations] (
    [Code]           VARCHAR (100)  NOT NULL,
    [TitleEng]       NVARCHAR (250) NULL,
    [TitleSk]        NVARCHAR (250) NULL,
    [ParentLocation] VARCHAR (100)  NULL, 
    CONSTRAINT [PK_LocationsStaging] PRIMARY KEY ([Code])
);