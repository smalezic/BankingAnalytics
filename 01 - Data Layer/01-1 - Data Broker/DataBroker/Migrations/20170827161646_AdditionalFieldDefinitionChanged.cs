using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    public partial class AdditionalFieldDefinitionChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultValueRecipe",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "GroupUIModifier",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "ValidationRecipe",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.AddColumn<int>(
                name: "FieldValueType",
                table: "AdditionalFieldDefinitions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValueType",
                table: "AdditionalFieldDefinitions");

            migrationBuilder.AddColumn<string>(
                name: "DefaultValueRecipe",
                table: "AdditionalFieldDefinitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "AdditionalFieldDefinitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupUIModifier",
                table: "AdditionalFieldDefinitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "AdditionalFieldDefinitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValidationRecipe",
                table: "AdditionalFieldDefinitions",
                nullable: true);
        }
    }
}
