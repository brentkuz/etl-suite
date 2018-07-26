using ETLSuite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETLSuite.Data
{
    public class ETLDataContext : DbContext
    {
        public ETLDataContext(DbContextOptions<ETLDataContext> options) : base(options)
        {
        }

        public DbSet<LogEntry> LogEntries { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        } 

        private void AddTimestamps()
        {
            //TODO: implement for .NET Core

            //var entities = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            //var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
            //   ? HttpContext.Current.User.Identity.Name
            //   : USER;

            //foreach (var entity in entities)
            //{
            //    if (entity.State == EntityState.Added)
            //    {
            //        ((EntityBase)entity.Entity).Created = DateTime.UtcNow;
            //        ((EntityBase)entity.Entity).CreatedBy = currentUsername;
            //    }

            //    ((EntityBase)entity.Entity).Modified = DateTime.UtcNow;
            //    ((EntityBase)entity.Entity).ModifiedBy = currentUsername;
            //}
        }
    }
}
