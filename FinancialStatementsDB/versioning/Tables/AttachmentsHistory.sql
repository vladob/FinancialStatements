CREATE TABLE [versioning].[AttachmentsHistory] (
	[Id]				INT NOT NULL,
	[ErpId]				INT NOT NULL,
	[FinancialReportId]	INT NOT NULL,
	[name]				VARCHAR(100) NULL,
	[mimeType]			VARCHAR(80) NULL,
	[size]				BIGINT NULL,
	[pageCount]			INT NULL,
	[digest]			VARCHAR(64) NULL,
	[language]			VARCHAR(3) NULL,
	[SysStartTime] 		DATETIME2(7) NOT NULL,
	[SysEndTime]		DATETIME2(7) NOT NULL
);