using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_ExpandableEntities_ExpandableEntityId",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropTable(
                name: "ExpandableEntities");

            migrationBuilder.DropTable(
                name: "ExpandableEntityType");

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "UnitCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "Organizations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "AdditionalFieldDefinitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpansionId",
                table: "AdditionalFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Expandable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expandable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitCategory_ExpansionId",
                table: "UnitCategory",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ExpansionId",
                table: "Units",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ExpansionId",
                table: "Organizations",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldDefinitions_ExpansionId",
                table: "AdditionalFieldDefinitions",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFields_ExpansionId",
                table: "AdditionalFields",
                column: "ExpansionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_Expandable_ExpandableEntityId",
                table: "AdditionalFields",
                column: "ExpandableEntityId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_Expandable_ExpansionId",
                table: "AdditionalFields",
                column: "ExpansionId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_Expandable_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_Expandable_ExpansionId",
                table: "AdditionalFieldDefinitions",
                column: "ExpansionId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Expandable_ExpansionId",
                table: "Organizations",
                column: "ExpansionId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Expandable_ExpansionId",
                table: "Units",
                column: "ExpansionId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitCategory_Expandable_ExpansionId",
                table: "UnitCategory",
                column: "ExpansionId",
                principalTable: "Expandable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_Expandable_ExpandableEntityId",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFields_Expandable_ExpansionId",
                table: "AdditionalFields");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_Expandable_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_Expandable_ExpansionId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Expandable_ExpansionId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Expandable_ExpansionId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitCategory_Expandable_ExpansionId",
                table: "UnitCategory");

            migrationBuilder.DropTable(
                name: "Expandable");

            migrationBuilder.DropIndex(
                name: "IX_UnitCategory_ExpansionId",
                table: "UnitCategory");

            migrationBuilder.DropIndex(
                name: "IX_Units_ExpansionId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_ExpansionId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFieldDefinitions_ExpansionId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFields_ExpansionId",
                table: "AdditionalFields");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "UnitCategory");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "ExpansionId",
                table: "AdditionalFields");

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
                name: "ExpandableEntityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandableEntityType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFields_ExpandableEntities_ExpandableEntityId",
                table: "AdditionalFields",
                column: "ExpandableEntityId",
                principalTable: "ExpandableEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId",
                principalTable: "ExpandableEntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
