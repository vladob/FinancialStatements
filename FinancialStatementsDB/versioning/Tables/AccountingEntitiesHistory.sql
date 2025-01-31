﻿CREATE TABLE [versioning].[AccountingEntitiesHistory] (
	[Id] INT NOT NULL,
	[ErpId] VARCHAR(10) NOT NULL,
	[cin] VARCHAR(20) NULL,
	[tin] VARCHAR(20) NULL,
	[sid] VARCHAR(20) NULL,
	[titleAE] NVARCHAR(500) NOT NULL,
	[city] NVARCHAR(200) NULL,
	[street] NVARCHAR(200) NULL,
	[zip] VARCHAR(10) NULL,
	[established] DATE NULL,
	[cancellation] DATE NULL,
	[legalFormId] int NULL,
	[skNaceId] int NULL,
	[organizationSizeId] int NULL,
	[ownershipTypeId] int NULL,
	[regionId] int NULL,
	[districtId] int NULL,
	[registerredOfficeId] int NULL,
	[consolidated] BIT NULL,
	[dataSource] VARCHAR(30) NULL,
	[lastModification] DATE NULL,
	[SysStartTime] DATETIME2(7) NOT NULL,	-- System versioning start time
	[SysEndTime] DATETIME2(7) NOT NULL		-- System versioning end time
);