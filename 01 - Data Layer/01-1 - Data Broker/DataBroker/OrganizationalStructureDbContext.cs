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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //_logger.Debug("On configuring");
            String connectionString = ConfigurationManager.ConnectionStrings["BankingAnalyticsModelContainer"].ToString();
            //_logger.DebugFormat("Connection string - {0}", connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            //_logger.Debug("On configuring is done");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //_logger.Debug("Fluent API");

            modelBuilder.Entity<Organization>()
                .ToTable("Organizations");

            //_logger.Debug("Fluent API is done");
        }
    }
}
