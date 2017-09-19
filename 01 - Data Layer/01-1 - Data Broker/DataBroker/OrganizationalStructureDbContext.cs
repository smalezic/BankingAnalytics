using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ADS.BankingAnalytics.DataEntities.ObjectModel;

namespace ADS.BankingAnalytics.DataEntities.DataBroker
{
    public class OrganizationalStructureDbContext : DbContext
    {
        public DbSet<ExpandableEntity> ExpandableEntities { get; set; }
        public DbSet<AdditionalFieldDefinition> AdditionalFieldDefinitions { get; set; }
        public DbSet<AdditionalField> AdditionalFields { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitCategory> UnitCategories { get; set; }
        public DbSet<ExpandableEntityType> ExpandableEntityTypes { get; set; }
        public DbSet<Workbook> Workbooks { get; set; }
        public DbSet<WorkbookTemplate> WorkbookTemplate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["BankingAnalyticsModelContainer"].ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Additional Fields Implementation

            modelBuilder.Entity<ExpandableEntity>()
                .ToTable("ExpandableEntities");

            modelBuilder.Entity<AdditionalFieldDefinition>()
                .ToTable("AdditionalFieldDefinitions");

            modelBuilder.Entity<AdditionalField>()
                .ToTable("AdditionalFields");

            #endregion Additional Fields Implementation

            modelBuilder.Entity<Organization>()
                .ToTable("Organizations");

            modelBuilder.Entity<Unit>()
                .ToTable("Units");

            modelBuilder.Entity<WorkbookTemplate>()
                .ToTable("WorkbookTemplates");

            modelBuilder.Entity<Workbook>()
                .ToTable("Workbooks");
        }
    }
}
