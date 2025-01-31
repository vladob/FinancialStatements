CREATE TABLE [versioning].[AnnualReportAttachmentsHistory] (
	[Id] 				INT NOT NULL,
	[ErpId] 			INT NOT NULL,
	[AnnualReportId]	INT,
	[name] 				VARCHAR(100),
	[mimeType] 			VARCHAR(80),
	[size] 				BIGINT,
	[digest] 			VARCHAR(64),
	[SysStartTime] 		DATETIME2(7) NOT NULL,
	[SysEndTime] 		DATETIME2(7) NOT NULL
);