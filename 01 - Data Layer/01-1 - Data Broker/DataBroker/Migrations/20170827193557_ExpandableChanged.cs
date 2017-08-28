using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class ExpandableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ExpandableEntities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpandableEntityTypeId",
                table: "ExpandableEntities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExpandableEntities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "ExpandableEntities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentUnitId",
                table: "ExpandableEntities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpandableEntityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandableEntityType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpandableEntities_ExpandableEntityTypeId",
                table: "ExpandableEntities",
                column: "ExpandableEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpandableEntities_OrganizationId",
                table: "ExpandableEntities",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpandableEntities_ParentUnitId",
                table: "ExpandableEntities",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId",
                principalTable: "ExpandableEntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpandableEntities_ExpandableEntityType_ExpandableEntityTypeId",
                table: "ExpandableEntities",
                column: "ExpandableEntityTypeId",
                principalTable: "ExpandableEntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpandableEntities_Organizations_OrganizationId",
                table: "ExpandableEntities",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpandableEntities_ExpandableEntities_ParentUnitId",
                table: "ExpandableEntities",
                column: "ParentUnitId",
                principalTable: "ExpandableEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpandableEntities_ExpandableEntityType_ExpandableEntityTypeId",
                table: "ExpandableEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpandableEntities_Organizations_OrganizationId",
                table: "ExpandableEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpandableEntities_ExpandableEntities_ParentUnitId",
                table: "ExpandableEntities");

            migrationBuilder.DropTable(
                name: "ExpandableEntityType");

            migrationBuilder.DropIndex(
                name: "IX_ExpandableEntities_ExpandableEntityTypeId",
                table: "ExpandableEntities");

            migrationBuilder.DropIndex(
                name: "IX_ExpandableEntities_OrganizationId",
                table: "ExpandableEntities");

            migrationBuilder.DropIndex(
                name: "IX_ExpandableEntities_ParentUnitId",
                table: "ExpandableEntities");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ExpandableEntities");

            migrationBuilder.DropColumn(
                name: "ExpandableEntityTypeId",
                table: "ExpandableEntities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExpandableEntities");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "ExpandableEntities");

            migrationBuilder.DropColumn(
                name: "ParentUnitId",
                table: "ExpandableEntities");

            migrationBuilder.DropColumn(
                name: "ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ParentUnitId = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_OrganizationId",
                table: "Units",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");
        }
    }
}
