using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ADS.BankingAnalytics.DataEntities.DataBroker;

namespace ADS.BankingAnalytics.DataEntities.DataBroker.Migrations
{
    [DbContext(typeof(OrganizationalStructureDbContext))]
    [Migration("20170802141907_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
