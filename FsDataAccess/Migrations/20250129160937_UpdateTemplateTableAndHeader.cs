using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FsDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTemplateTableAndHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_classifications_SkNace",
                schema: "Classifications",
                table: "SkNace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classifications_OwnershipTypes",
                schema: "Classifications",
                table: "OwnershipTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classifications_OrganizationSizes",
                schema: "Classifications",
                table: "OrganizationSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classifications_LegalForms",
                schema: "Classifications",
                table: "LegalForms");

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "Classifications",
                table: "SkNace")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "Classifications",
                table: "SkNace")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "Classifications",
                table: "OwnershipTypes")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "Classifications",
                table: "OwnershipTypes")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "Classifications",
                table: "OrganizationSizes")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "Classifications",
                table: "OrganizationSizes")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "Classifications",
                table: "Locations")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "Classifications",
                table: "Locations")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "Classifications",
                table: "LegalForms")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "Classifications",
                table: "LegalForms")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.RenameTable(
                name: "SkNace",
                schema: "Classifications",
                newName: "SkNace",
                newSchema: "staging")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SkNaceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.RenameTable(
                name: "OwnershipTypes",
                schema: "Classifications",
                newName: "OwnershipTypes",
                newSchema: "staging")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OwnershipTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.RenameTable(
                name: "OrganizationSizes",
                schema: "Classifications",
                newName: "OrganizationSizes",
                newSchema: "staging")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OrganizationSizesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "Classifications",
                newName: "Locations",
                newSchema: "staging")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LocationsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.RenameTable(
                name: "LegalForms",
                schema: "Classifications",
                newName: "LegalForms",
                newSchema: "staging")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LegalFormsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.RenameTable(
                name: "AccountingEntities_FinancialStatements",
                schema: "indexing",
                newName: "AccountingEntities_FinancialStatements",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "AccountingEntities_AnnualReports",
                schema: "indexing",
                newName: "AccountingEntities_AnnualReports",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "TemplateTables",
                schema: "staging",
                newName: "TemplateTable");

            migrationBuilder.RenameTable(
                name: "TemplateRows",
                schema: "staging",
                newName: "TemplateRow");

            migrationBuilder.RenameTable(
                name: "TemplateHeaders",
                schema: "staging",
                newName: "TemplateHeader");

            migrationBuilder.RenameTable(
                name: "ReportTables",
                schema: "staging",
                newName: "ReportTable");

            migrationBuilder.RenameTable(
                name: "ReportContents",
                schema: "staging",
                newName: "ReportContent");

            migrationBuilder.RenameTable(
                name: "FinancialStatements",
                schema: "staging",
                newName: "FinancialStatement");

            migrationBuilder.RenameTable(
                name: "FinancialReportTemplates",
                schema: "staging",
                newName: "FinancialReportTemplate");

            migrationBuilder.RenameTable(
                name: "FinancialReports",
                schema: "staging",
                newName: "FinancialReport");

            migrationBuilder.RenameTable(
                name: "Attachments",
                schema: "staging",
                newName: "Attachment");

            migrationBuilder.RenameTable(
                name: "AnnualReports",
                schema: "staging",
                newName: "AnnualReport");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TemplateTable",
                newName: "nameSk");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateTables_FinancialReportTemplateId",
                table: "TemplateTable",
                newName: "IX_TemplateTable_FinancialReportTemplateId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TemplateRow",
                newName: "descriptionSk");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateRows_TemplateTableId",
                table: "TemplateRow",
                newName: "IX_TemplateRow_TemplateTableId");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "TemplateHeader",
                newName: "textSk");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateHeaders_TemplateTableId",
                table: "TemplateHeader",
                newName: "IX_TemplateHeader_TemplateTableId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTables_FinancialReportId",
                table: "ReportTable",
                newName: "IX_ReportTable_FinancialReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportContents_FinancialReportId",
                table: "ReportContent",
                newName: "IX_ReportContent_FinancialReportId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialStatements_AccountingEntityId",
                table: "FinancialStatement",
                newName: "IX_FinancialStatement_AccountingEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialReports_FinancialStatementId",
                table: "FinancialReport",
                newName: "IX_FinancialReport_FinancialStatementId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialReports_AnnualReportId",
                table: "FinancialReport",
                newName: "IX_FinancialReport_AnnualReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_FinancialReportId",
                table: "Attachment",
                newName: "IX_Attachment_FinancialReportId");

            migrationBuilder.AlterTable(
                name: "SkNace",
                schema: "staging")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "SkNaceHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "OwnershipTypes",
                schema: "staging")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "OwnershipTypesHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "OrganizationSizes",
                schema: "staging")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "OrganizationSizesHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "Locations",
                schema: "staging")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "LocationsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "LegalForms",
                schema: "staging")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "LegalFormsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfColumns",
                table: "TemplateTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDataColumns",
                table: "TemplateTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nameEn",
                table: "TemplateTable",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descriptionEn",
                table: "TemplateRow",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "textEn",
                table: "TemplateHeader",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_staging_SkNace",
                schema: "staging",
                table: "SkNace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staging_OwnershipTypes",
                schema: "staging",
                table: "OwnershipTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staging_OrganizationSizes",
                schema: "staging",
                table: "OrganizationSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staging_LegalForms",
                schema: "staging",
                table: "LegalForms",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_staging_SkNace",
                schema: "staging",
                table: "SkNace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staging_OwnershipTypes",
                schema: "staging",
                table: "OwnershipTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staging_OrganizationSizes",
                schema: "staging",
                table: "OrganizationSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staging_LegalForms",
                schema: "staging",
                table: "LegalForms");

            migrationBuilder.DropColumn(
                name: "NumberOfColumns",
                table: "TemplateTable");

            migrationBuilder.DropColumn(
                name: "NumberOfDataColumns",
                table: "TemplateTable");

            migrationBuilder.DropColumn(
                name: "nameEn",
                table: "TemplateTable");

            migrationBuilder.DropColumn(
                name: "descriptionEn",
                table: "TemplateRow");

            migrationBuilder.DropColumn(
                name: "textEn",
                table: "TemplateHeader");

            migrationBuilder.EnsureSchema(
                name: "indexing");

            migrationBuilder.EnsureSchema(
                name: "Classifications");

            migrationBuilder.RenameTable(
                name: "SkNace",
                schema: "staging",
                newName: "SkNace",
                newSchema: "Classifications");

            migrationBuilder.RenameTable(
                name: "OwnershipTypes",
                schema: "staging",
                newName: "OwnershipTypes",
                newSchema: "Classifications");

            migrationBuilder.RenameTable(
                name: "OrganizationSizes",
                schema: "staging",
                newName: "OrganizationSizes",
                newSchema: "Classifications");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "staging",
                newName: "Locations",
                newSchema: "Classifications");

            migrationBuilder.RenameTable(
                name: "LegalForms",
                schema: "staging",
                newName: "LegalForms",
                newSchema: "Classifications");

            migrationBuilder.RenameTable(
                name: "AccountingEntities_FinancialStatements",
                schema: "staging",
                newName: "AccountingEntities_FinancialStatements",
                newSchema: "indexing");

            migrationBuilder.RenameTable(
                name: "AccountingEntities_AnnualReports",
                schema: "staging",
                newName: "AccountingEntities_AnnualReports",
                newSchema: "indexing");

            migrationBuilder.RenameTable(
                name: "TemplateTable",
                newName: "TemplateTables",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "TemplateRow",
                newName: "TemplateRows",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "TemplateHeader",
                newName: "TemplateHeaders",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "ReportTable",
                newName: "ReportTables",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "ReportContent",
                newName: "ReportContents",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "FinancialStatement",
                newName: "FinancialStatements",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "FinancialReportTemplate",
                newName: "FinancialReportTemplates",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "FinancialReport",
                newName: "FinancialReports",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments",
                newSchema: "staging");

            migrationBuilder.RenameTable(
                name: "AnnualReport",
                newName: "AnnualReports",
                newSchema: "staging");

            migrationBuilder.RenameColumn(
                name: "nameSk",
                schema: "staging",
                table: "TemplateTables",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateTable_FinancialReportTemplateId",
                schema: "staging",
                table: "TemplateTables",
                newName: "IX_TemplateTables_FinancialReportTemplateId");

            migrationBuilder.RenameColumn(
                name: "descriptionSk",
                schema: "staging",
                table: "TemplateRows",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateRow_TemplateTableId",
                schema: "staging",
                table: "TemplateRows",
                newName: "IX_TemplateRows_TemplateTableId");

            migrationBuilder.RenameColumn(
                name: "textSk",
                schema: "staging",
                table: "TemplateHeaders",
                newName: "text");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateHeader_TemplateTableId",
                schema: "staging",
                table: "TemplateHeaders",
                newName: "IX_TemplateHeaders_TemplateTableId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportTable_FinancialReportId",
                schema: "staging",
                table: "ReportTables",
                newName: "IX_ReportTables_FinancialReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportContent_FinancialReportId",
                schema: "staging",
                table: "ReportContents",
                newName: "IX_ReportContents_FinancialReportId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialStatement_AccountingEntityId",
                schema: "staging",
                table: "FinancialStatements",
                newName: "IX_FinancialStatements_AccountingEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialReport_FinancialStatementId",
                schema: "staging",
                table: "FinancialReports",
                newName: "IX_FinancialReports_FinancialStatementId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialReport_AnnualReportId",
                schema: "staging",
                table: "FinancialReports",
                newName: "IX_FinancialReports_AnnualReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_FinancialReportId",
                schema: "staging",
                table: "Attachments",
                newName: "IX_Attachments_FinancialReportId");

            migrationBuilder.AlterTable(
                name: "SkNace",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "SkNaceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "OwnershipTypes",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OwnershipTypesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "OrganizationSizes",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "OrganizationSizesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "Locations",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LocationsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "LegalForms",
                schema: "Classifications")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "LegalFormsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "Classifications")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "Classifications",
                table: "SkNace",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "Classifications",
                table: "SkNace",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "Classifications",
                table: "OwnershipTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "Classifications",
                table: "OwnershipTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "Classifications",
                table: "OrganizationSizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "Classifications",
                table: "OrganizationSizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "Classifications",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "Classifications",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "Classifications",
                table: "LegalForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "Classifications",
                table: "LegalForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_classifications_SkNace",
                schema: "Classifications",
                table: "SkNace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classifications_OwnershipTypes",
                schema: "Classifications",
                table: "OwnershipTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classifications_OrganizationSizes",
                schema: "Classifications",
                table: "OrganizationSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classifications_LegalForms",
                schema: "Classifications",
                table: "LegalForms",
                column: "Id");
        }
    }
}
