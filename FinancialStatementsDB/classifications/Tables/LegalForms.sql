CREATE TABLE [classifications].[LegalForms] (
    [Id]           INT                                         IDENTITY (1, 1) NOT NULL, -- Technical ID
    [Code]         VARCHAR (100)                               NOT NULL,    -- Public ID API: kod
    [TitleEng]     NVARCHAR (250)                              NULL,        -- Title in English
    [TitleSk]      NVARCHAR (250)                              NULL,        -- Title in Slovakian
    [SysStartTime] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [SysEndTime]   DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT [PK_classifications_LegalForms] PRIMARY KEY CLUSTERED ([Id] ASC),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[versioning].[LegalFormsHistory], DATA_CONSISTENCY_CHECK=ON));
