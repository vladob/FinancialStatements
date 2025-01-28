CREATE TABLE [staging].[Locations] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Code]           VARCHAR (100)  NULL,
    [TitleEng]       NVARCHAR (250) NULL,
    [TitleSk]        NVARCHAR (250) NULL,
    [ParentLocation] VARCHAR (100)  NULL,
    CONSTRAINT [PK_staging_Locations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

