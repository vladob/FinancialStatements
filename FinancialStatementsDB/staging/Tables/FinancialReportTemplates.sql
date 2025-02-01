﻿CREATE TABLE [staging].[FinancialReportTemplates] (
    [ErpId]            INT           NOT NULL,  -- API: id, Description: identifier of the financial report template, maximum ten digits integer
    [name]             VARCHAR (100) NULL,      -- API: nazov, Description: name of the template
    [mfSpecification]  VARCHAR (100) NULL,      -- API: nariadenieMF, Description: specification of the Ministry of Finance regulation
    [validFrom]        DATE          NULL,      -- API: platneOd, Description: validity of the template from the date
    [validTo]          DATE          NULL,      -- API: platneDo, Description: validity of the template until the date
    CONSTRAINT [PK_FinancialReportTemplatesStaging] PRIMARY KEY ([ErpId])
);