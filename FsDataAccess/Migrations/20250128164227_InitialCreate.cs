using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "staging");

            migrationBuilder.EnsureSchema(
                name: "indexing");

            migrationBuilder.EnsureSchema(
                name: "Classifications");

            migrationBuilder.CreateTable(
                name: "AccountingEntities",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    cin = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    tin = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    sid = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    titleAE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    zip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    established = table.Column<DateOnly>(type: "date", nullable: true),
                    cancellation = table.Column<DateOnly>(type: "date", nullable: true),
                    legalFormId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    skNaceId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    organizationSizeId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ownershipTypeId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    regionId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    districtId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    registerredOfficeId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    consolidated = table.Column<bool>(type: "bit", nullable: true),
                    dataSource = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    lastModification = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_AccountingEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnualReports",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    titleAE = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fundName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    leiCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    periodFrom = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    periodTo = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    submissionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    assemblyDate = table.Column<DateOnly>(type: "date", nullable: true),
                    dataAvailability = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    accountingEntityId = table.Column<int>(type: "int", nullable: true),
                    lastModification = table.Column<DateOnly>(type: "date", nullable: true),
                    dataSource = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_AnnualReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialReportTemplates",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    mfSpecification = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    validFrom = table.Column<DateOnly>(type: "date", nullable: true),
                    validTo = table.Column<DateOnly>(type: "date", nullable: true),
                    lastModification = table.Column<DateOnly>(type: "date", nullable: true),
                    dataSource = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_FinancialReportTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalForms",
                schema: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TitleSk = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_LegalForms", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LegalFormsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TitleSk = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParentLocation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_Locations", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LocationsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "OrganizationSizes",
                schema: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TitleSk = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_OrganizationSizes", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OrganizationSizesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "OwnershipTypes",
                schema: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TitleSk = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_OwnershipTypes", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OwnershipTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "SkNace",
                schema: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TitleSk = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_SkNace", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SkNaceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    AccountingEntityId = table.Column<int>(type: "int", nullable: true),
                    periodFrom = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    periodTo = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    submissionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    preparationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    approvalDate = table.Column<DateOnly>(type: "date", nullable: true),
                    assemblyDate = table.Column<DateOnly>(type: "date", nullable: true),
                    auditorReportAttachmentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    fundName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    leiCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    consolidated = table.Column<bool>(type: "bit", nullable: true),
                    consolidatedCentralGovernment = table.Column<bool>(type: "bit", nullable: true),
                    summaryPublicAdministration = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lastModification = table.Column<DateOnly>(type: "date", nullable: true),
                    dataSource = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_FinancialStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Financial__Accou__37C5420D",
                        column: x => x.AccountingEntityId,
                        principalSchema: "staging",
                        principalTable: "AccountingEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountingEntities_AnnualReports",
                schema: "indexing",
                columns: table => new
                {
                    AccountingEntityId = table.Column<int>(type: "int", nullable: false),
                    AnnualReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounti__72B514D14DD17587", x => new { x.AccountingEntityId, x.AnnualReportId });
                    table.ForeignKey(
                        name: "FK__Accountin__Accou__5A1A5A11",
                        column: x => x.AccountingEntityId,
                        principalSchema: "staging",
                        principalTable: "AccountingEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Accountin__Annua__5B0E7E4A",
                        column: x => x.AnnualReportId,
                        principalSchema: "staging",
                        principalTable: "AnnualReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnnualReportAttachments",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    AnnualReportId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    mimeType = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    size = table.Column<long>(type: "bigint", nullable: true),
                    digest = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_AnnualReportAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK__AnnualRep__Annua__48EFCE0F",
                        column: x => x.AnnualReportId,
                        principalSchema: "staging",
                        principalTable: "AnnualReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTables",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialReportTemplateId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_TemplateTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TemplateT__Finan__4DB4832C",
                        column: x => x.FinancialReportTemplateId,
                        principalSchema: "staging",
                        principalTable: "FinancialReportTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountingEntities_FinancialStatements",
                schema: "indexing",
                columns: table => new
                {
                    AccountingEntityId = table.Column<int>(type: "int", nullable: false),
                    FinancialStatementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounti__54B346F8C6389670", x => new { x.AccountingEntityId, x.FinancialStatementId });
                    table.ForeignKey(
                        name: "FK__Accountin__Accou__5649C92D",
                        column: x => x.AccountingEntityId,
                        principalSchema: "staging",
                        principalTable: "AccountingEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Accountin__Finan__573DED66",
                        column: x => x.FinancialStatementId,
                        principalSchema: "staging",
                        principalTable: "FinancialStatements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialReports",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    FinancialStatementId = table.Column<int>(type: "int", nullable: true),
                    AnnualReportId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    currency = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    taxOfficeCode = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    dataAvailability = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    lastModification = table.Column<DateOnly>(type: "date", nullable: true),
                    dataSource = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_FinancialReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Financial__Annua__3D7E1B63",
                        column: x => x.AnnualReportId,
                        principalSchema: "staging",
                        principalTable: "AnnualReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Financial__Finan__3C89F72A",
                        column: x => x.FinancialStatementId,
                        principalSchema: "staging",
                        principalTable: "FinancialStatements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateHeaders",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTableId = table.Column<int>(type: "int", nullable: true),
                    text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    rowPosition = table.Column<int>(type: "int", nullable: true),
                    columnPosition = table.Column<int>(type: "int", nullable: true),
                    columnSpan = table.Column<int>(type: "int", nullable: true),
                    rowSpan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_TemplateHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TemplateH__Templ__5090EFD7",
                        column: x => x.TemplateTableId,
                        principalSchema: "staging",
                        principalTable: "TemplateTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateRows",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateTableId = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    rowNumber = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_TemplateRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TemplateR__Templ__536D5C82",
                        column: x => x.TemplateTableId,
                        principalSchema: "staging",
                        principalTable: "TemplateTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpId = table.Column<int>(type: "int", nullable: false),
                    FinancialReportId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    mimeType = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    size = table.Column<long>(type: "bigint", nullable: true),
                    pageCount = table.Column<int>(type: "int", nullable: true),
                    digest = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    language = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Attachmen__Finan__405A880E",
                        column: x => x.FinancialReportId,
                        principalSchema: "staging",
                        principalTable: "FinancialReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportContents",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialReportId = table.Column<int>(type: "int", nullable: true),
                    coverPageTitle = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    coverPageIco = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    coverPageDic = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    coverPageSid = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    coverPageAddress = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    coverPageLegalFormId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    coverPageSkNaceId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    coverPageType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    coverPageConsolidated = table.Column<bool>(type: "bit", nullable: true),
                    coverPageConsolidatedCG = table.Column<bool>(type: "bit", nullable: true),
                    coverPageSummaryPA = table.Column<bool>(type: "bit", nullable: true),
                    coverPageTypeUnit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    commercialRegister = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fundName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    leiCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    periodFrom = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    periodTo = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    previousPeriodFrom = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    previousPeriodTo = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    completionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    approvalDate = table.Column<DateOnly>(type: "date", nullable: true),
                    preparationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    assemblyDate = table.Column<DateOnly>(type: "date", nullable: true),
                    auditorReportAttachmentDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_ReportContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ReportCon__Finan__4336F4B9",
                        column: x => x.FinancialReportId,
                        principalSchema: "staging",
                        principalTable: "FinancialReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportTables",
                schema: "staging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialReportId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    data = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_ReportTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ReportTab__Finan__46136164",
                        column: x => x.FinancialReportId,
                        principalSchema: "staging",
                        principalTable: "FinancialReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntities_AnnualReports_AnnualReportId",
                schema: "indexing",
                table: "AccountingEntities_AnnualReports",
                column: "AnnualReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntities_FinancialStatements_FinancialStatementId",
                schema: "indexing",
                table: "AccountingEntities_FinancialStatements",
                column: "FinancialStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualReportAttachments_AnnualReportId",
                schema: "staging",
                table: "AnnualReportAttachments",
                column: "AnnualReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FinancialReportId",
                schema: "staging",
                table: "Attachments",
                column: "FinancialReportId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReports_AnnualReportId",
                schema: "staging",
                table: "FinancialReports",
                column: "AnnualReportId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReports_FinancialStatementId",
                schema: "staging",
                table: "FinancialReports",
                column: "FinancialStatementId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_AccountingEntityId",
                schema: "staging",
                table: "FinancialStatements",
                column: "AccountingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportContents_FinancialReportId",
                schema: "staging",
                table: "ReportContents",
                column: "FinancialReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTables_FinancialReportId",
                schema: "staging",
                table: "ReportTables",
                column: "FinancialReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateHeaders_TemplateTableId",
                schema: "staging",
                table: "TemplateHeaders",
                column: "TemplateTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateRows_TemplateTableId",
                schema: "staging",
                table: "TemplateRows",
                column: "TemplateTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTables_FinancialReportTemplateId",
                schema: "staging",
                table: "TemplateTables",
                column: "FinancialReportTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingEntities_AnnualReports",
                schema: "indexing");

            migrationBuilder.DropTable(
                name: "AccountingEntities_FinancialStatements",
                schema: "indexing");

            migrationBuilder.DropTable(
                name: "AnnualReportAttachments",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "LegalForms",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LegalFormsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LocationsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "OrganizationSizes",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OrganizationSizesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "OwnershipTypes",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OwnershipTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "ReportContents",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "ReportTables",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "SkNace",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SkNaceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "TemplateHeaders",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "TemplateRows",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "FinancialReports",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "TemplateTables",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "AnnualReports",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "FinancialStatements",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "FinancialReportTemplates",
                schema: "staging");

            migrationBuilder.DropTable(
                name: "AccountingEntities",
                schema: "staging");
        }
    }
}
