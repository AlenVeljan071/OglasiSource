using Microsoft.EntityFrameworkCore;
using OglasiSource.Core.Entities;

namespace OglasiSource.Infrastructure.Data.Context
{
    public class DbWriteContext : OglasiSourceContext
    {
        public DbWriteContext(DbContextOptions<DbWriteContext> options) : base(options)
        {
       
        }
        public override int SaveChanges()
        {
            UpdateDateTime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            UpdateDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateDateTime()
        {
            var entries = ChangeTracker
                 .Entries()
                 .Where(e => e.Entity is ITrackable && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((ITrackable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((ITrackable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }
            
        }
    }
}
