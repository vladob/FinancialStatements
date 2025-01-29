CREATE TABLE [staging].[OrganizationSizes] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Code]     VARCHAR (100)  NOT NULL,
    [TitleEng] NVARCHAR (250) NULL,
    [TitleSk]  NVARCHAR (250) NULL,
    CONSTRAINT [PK_staging_OrganizationSizes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

