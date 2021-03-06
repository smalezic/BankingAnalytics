﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ADS.BankingAnalytics.DataEntities.DataBroker;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    [DbContext(typeof(OrganizationalStructureDbContext))]
    [Migration("20170823210113_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdditionalFieldDefinitionId");

                    b.Property<bool?>("BooleanValue");

                    b.Property<DateTime?>("DateTimeValue");

                    b.Property<decimal?>("DecimalValue");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("ExpandableEntityId");

                    b.Property<int?>("IntValue");

                    b.Property<string>("StringValue");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalFieldDefinitionId");

                    b.HasIndex("ExpandableEntityId");

                    b.ToTable("AdditionalFields");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessMeaning");

                    b.Property<string>("ChoiceItems");

                    b.Property<string>("DefaultValueRecipe");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int>("ExpandableEntityId");

                    b.Property<string>("Group");

                    b.Property<string>("GroupUIModifier");

                    b.Property<bool>("IsMandatory");

                    b.Property<string>("Name");

                    b.Property<int?>("Order");

                    b.Property<string>("Page");

                    b.Property<string>("ValidationRecipe");

                    b.HasKey("Id");

                    b.HasIndex("ExpandableEntityId");

                    b.ToTable("AdditionalFieldDefinitions");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MetaEntityId");

                    b.Property<string>("MetaEntityType");

                    b.HasKey("Id");

                    b.ToTable("ExpandableEntities");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrganizationId");

                    b.Property<int?>("ParentUnitId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentUnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalField", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", "AdditionalFieldDefinition")
                        .WithMany("AdditionalFields")
                        .HasForeignKey("AdditionalFieldDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", "ExpandableEntity")
                        .WithMany("AdditionalFields")
                        .HasForeignKey("ExpandableEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", "ExpandableEntity")
                        .WithMany("AdditionalFieldDefinitions")
                        .HasForeignKey("ExpandableEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Organization", "Organization")
                        .WithMany("Units")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", "ParentUnit")
                        .WithMany("ChildUnits")
                        .HasForeignKey("ParentUnitId");
                });
        }
    }
}
