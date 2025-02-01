CREATE TABLE [staging].[Locations] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,  -- Technical ID as there is duplicate ("kod": "SKZZZ") returned from API for kraje & okresy and "kod": "SKZZZZ" for okresy and sidla
    [Code]           VARCHAR (100)  NOT NULL,       -- Public ID from API, can't be used as unique primary key due to (see above)
    [TitleEng]       NVARCHAR (250) NULL,           -- Title in English
    [TitleSk]        NVARCHAR (250) NULL,           -- Title in Slovakian
    [ParentLocation] VARCHAR (100)  NULL,           -- Code of parent location
    CONSTRAINT [PK_LocationsStaging] PRIMARY KEY ([Id])
);