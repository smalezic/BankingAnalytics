using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class RemovedReferenceAFDandExpandableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntities_ExpandableEntityId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "ExpandableEntityId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityTypeId",
                principalTable: "ExpandableEntityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntityType_ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.AlterColumn<int>(
                name: "ExpandableEntityTypeId",
                table: "AdditionalFieldDefinitions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ExpandableEntityId",
                table: "AdditionalFieldDefinitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalFieldDefinitions_ExpandableEntityId",
                table: "AdditionalFieldDefinitions",
                column: "ExpandableEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalFieldDefinitions_ExpandableEntities_ExpandableEntityId",
                table: "AdditionalFieldDefinitions",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
