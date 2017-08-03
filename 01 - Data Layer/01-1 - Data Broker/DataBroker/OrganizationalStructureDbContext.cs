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
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["BankingAnalyticsModelContainer"].ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .ToTable("Organizations");

            modelBuilder.Entity<Unit>()
                .ToTable("Units");
        }
    }
}
