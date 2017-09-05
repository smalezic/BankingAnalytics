using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ADS.BankingAnalytics.DataEntities.DataBroker;
using ADS.BankingAnalytics.DataEntities.Enumerations;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    [DbContext(typeof(OrganizationalStructureDbContext))]
    [Migration("20170905183140_MinorChanges")]
    partial class MinorChanges
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

                    b.Property<int>("ExpansionId");

                    b.Property<int?>("IntValue");

                    b.Property<string>("StringValue");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalFieldDefinitionId");

                    b.HasIndex("ExpandableEntityId");

                    b.HasIndex("ExpansionId");

                    b.ToTable("AdditionalFields");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessMeaning");

                    b.Property<string>("ChoiceItems");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int>("ExpandableEntityTypeId");

                    b.Property<int>("ExpansionId");

                    b.Property<int>("FieldValueType");

                    b.Property<bool>("IsMandatory");

                    b.Property<string>("Name");

                    b.Property<int?>("Order");

                    b.HasKey("Id");

                    b.HasIndex("ExpandableEntityTypeId");

                    b.HasIndex("ExpansionId");

                    b.ToTable("AdditionalFieldDefinitions");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("MetaEntityId");

                    b.Property<string>("MetaEntityType");

                    b.HasKey("Id");

                    b.ToTable("Expandable");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Expandable");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExpansionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ExpansionId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExpansionId");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizationId");

                    b.Property<int?>("ParentUnitId");

                    b.Property<int?>("UnitCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ExpansionId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentUnitId");

                    b.HasIndex("UnitCategoryId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.UnitCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExpansionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ExpansionId");

                    b.ToTable("UnitCategory");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", b =>
                {
                    b.HasBaseType("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable");


                    b.ToTable("ExpandableEntities");

                    b.HasDiscriminator().HasValue("ExpandableEntity");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType", b =>
                {
                    b.HasBaseType("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable");


                    b.ToTable("ExpandableEntityType");

                    b.HasDiscriminator().HasValue("ExpandableEntityType");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalField", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", "AdditionalFieldDefinition")
                        .WithMany("AdditionalFields")
                        .HasForeignKey("AdditionalFieldDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity")
                        .WithMany("AdditionalFields")
                        .HasForeignKey("ExpandableEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.AdditionalFieldDefinition", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType", "ExpandableEntityType")
                        .WithMany("AdditionalFieldDefinitions")
                        .HasForeignKey("ExpandableEntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Organization", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Organization", "Organization")
                        .WithMany("Units")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Unit", "ParentUnit")
                        .WithMany("ChildUnits")
                        .HasForeignKey("ParentUnitId");

                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.UnitCategory", "UnitCategory")
                        .WithMany("Units")
                        .HasForeignKey("UnitCategoryId");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.UnitCategory", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.Expandable", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
