CREATE TABLE [versioning].[AnnualReportsHistory] (
	[Id]					INT NOT NULL,
	[ErpId]					INT NOT NULL,
	[titleAE]				VARCHAR(500),
	[type]					VARCHAR(100),
	[fundName]				VARCHAR(500),
	[leiCode]				VARCHAR(20),
	[periodFrom]			VARCHAR(7),
	[periodTo]				VARCHAR(7),
	[submissionDate]		DATE,
	[assemblyDate]			DATE,
	[dataAvailability]		VARCHAR(30),
	[accountingEntityId]	INT,
	[lastModification]		DATE,
	[dataSource]			VARCHAR(30),
	[SysStartTime]			DATETIME2(7) NOT NULL,
	[SysEndTime]			DATETIME2(7) NOT NULL
);