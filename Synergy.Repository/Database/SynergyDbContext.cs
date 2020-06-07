using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using Synergy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Synergy.Repository.Database
{
  public  class SynergyDbContext : DbContext, IDbContext
    {
        public static Logger dbSqllog = LogManager.GetLogger("databaseSqlLogger");
        public SynergyDbContext(DbContextOptions<SynergyDbContext> options) : base(options)
        {
            //Database.Migrate();
        }

        public SynergyDbContext()
        {

        }
        void LogSql(string log)
        {
            dbSqllog.Info(log);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SynergyDbConnection"));


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeRigister = Assembly.Load("Synergy.Repository").GetTypes()
                .Where(t => t.GetInterfaces()
                .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();


            foreach (var type in typeRigister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        private IEnumerable<DbParameter> ToParameter(params object[] commandParameters)
        {
            if (commandParameters == null || commandParameters.Length == 0)
                return Enumerable.Empty<DbParameter>();

            return commandParameters.Cast<DbParameter>();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();
    }
}
