using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpandableEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandableEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpandableEntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandableEntityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalFieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessMeaning = table.Column<string>(nullable: true),
                    ChoiceItems = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpandableEntityTypeId = table.Column<int>(nullable: false),
                    FieldValueType = table.Column<int>(nullable: false),
                    IsMandatory = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalFieldDefinitions_ExpandableEntityTypes_ExpandableEntityTypeId",
                        column: x => x.ExpandableEntityTypeId,
                        principalTable: "ExpandableEntityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitCategories_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkbookTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkbookTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkbookTemplates_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalFieldDefinitionId = table.Column<int>(nullable: false),
                    BooleanValue = table.Column<bool>(nullable: true),
                    DateTimeValue = table.Column<DateTime>(nullable: true),
                    DecimalValue = table.Column<decimal>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ExpandableEntityId = table.Column<int>(nullable: false),
                    IntValue = table.Column<int>(nullable: true),
                    StringValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalFields_AdditionalFieldDefinitions_AdditionalFieldDefinitionId",
                        column: x => x.AdditionalFieldDefinitionId,
                        principalTable: "AdditionalFieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalFields_ExpandableEntities_ExpandableEntityId",
                        column: x => x.ExpandableEntityId,
                        principalTable: "ExpandableEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ParentUnitId = table.Column<int>(nullable: true),
                    UnitCategoryId = table.Column<int>(nullable: true),
                    WorkbookTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_Units_ParentUnitId",
                        column: x => x.ParentUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_UnitCategories_UnitCategoryId",
                        column: x => x.UnitCategoryId,
                        principalTable: "UnitCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_WorkbookTemplates_WorkbookTemplateId",
                        column: x => x.WorkbookTemplateId,
                        principalTable: "WorkbookTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workbooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UnitId = table.Column<int>(nullable: false),
                    WorkbookTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workbooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workbooks_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workbooks_WorkbookTemplates_WorkbookTemplateId",
                        column: x => x.WorkbookTemplateId,
                        principalTable: "WorkbookTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFields_AdditionalFieldDefinitionId",
                table: "AdditionalFields",
                column: "AdditionalFieldDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFields_ExpandableEntityId",
                table: "AdditionalFields",
                column: "ExpandableEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_OrganizationId",
                table: "Units",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitCategoryId",
                table: "Units",
                column: "UnitCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_WorkbookTemplateId",
                table: "Units",
                column: "WorkbookTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitCategories_OrganizationId",
                table: "UnitCategories",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Workbooks_UnitId",
                table: "Workbooks",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Workbooks_WorkbookTemplateId",
                table: "Workbooks",
                column: "WorkbookTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkbookTemplates_OrganizationId",
                table: "WorkbookTemplates",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalFields");

            migrationBuilder.DropTable(
                name: "Workbooks");

            migrationBuilder.DropTable(
                name: "AdditionalFieldDefinitions");

            migrationBuilder.DropTable(
                name: "ExpandableEntities");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "ExpandableEntityTypes");

            migrationBuilder.DropTable(
                name: "UnitCategories");

            migrationBuilder.DropTable(
                name: "WorkbookTemplates");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
