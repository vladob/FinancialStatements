CREATE TABLE [staging].[SkNace] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Code]     VARCHAR (100)  NULL,
    [TitleEng] NVARCHAR (250) NULL,
    [TitleSk]  NVARCHAR (250) NULL,
    CONSTRAINT [PK_staging_SkNace] PRIMARY KEY CLUSTERED ([Id] ASC)
);

