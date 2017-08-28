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
    [Migration("20170827202431_ExpandableChanged-2")]
    partial class ExpandableChanged2
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

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int>("ExpandableEntityTypeId");

                    b.Property<int>("FieldValueType");

                    b.Property<bool>("IsMandatory");

                    b.Property<string>("Name");

                    b.Property<int?>("Order");

                    b.HasKey("Id");

                    b.HasIndex("ExpandableEntityTypeId");

                    b.ToTable("AdditionalFieldDefinitions");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("ExpandableEntityTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ExpandableEntityTypeId");

                    b.ToTable("ExpandableEntities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ExpandableEntity");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExpandableEntityType");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ExpandableEntityType");
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
                    b.HasBaseType("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizationId");

                    b.Property<int?>("ParentUnitId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentUnitId");

                    b.ToTable("Units");

                    b.HasDiscriminator().HasValue("Unit");
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.UnitType", b =>
                {
                    b.HasBaseType("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType");

                    b.Property<string>("Name");

                    b.ToTable("UnitTypes");

                    b.HasDiscriminator().HasValue("UnitType");
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
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType", "ExpandableEntityType")
                        .WithMany("AdditionalFieldDefinitions")
                        .HasForeignKey("ExpandableEntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntity", b =>
                {
                    b.HasOne("ADS.BankingAnalytics.DataEntities.ObjectModel.ExpandableEntityType", "ExpandableEntityType")
                        .WithMany("ExpandableEntities")
                        .HasForeignKey("ExpandableEntityTypeId");
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
