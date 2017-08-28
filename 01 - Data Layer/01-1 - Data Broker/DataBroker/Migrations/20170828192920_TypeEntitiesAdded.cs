using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class TypeEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitCategoryId",
                table: "Units",
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
                    MetaEntityId = table.Column<int>(nullable: false),
                    MetaEntityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandableEntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitCategoryId",
                table: "Units",
                column: "UnitCategoryId");

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
                name: "FK_Units_UnitCategory_UnitCategoryId",
                table: "Units",
                column: "UnitCategoryId",
                principalTable: "UnitCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitCategory_UnitCategoryId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "ExpandableEntityType");

            migrationBuilder.DropTable(
                name: "UnitCategory");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitCategoryId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "UnitCategoryId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");
        }
    }
}
