using System;
using System.Threading;
using System.Threading.Tasks;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Base.Extensions;

namespace prboard.api.data.Base
{
    public abstract class BaseDataContext : DbContext, IWorkUnit
    {
        protected BaseDataContext(DbContextOptions options) : base(options)
        {
        }
        
        public abstract void Seed();

        public override int SaveChanges()
        {
            if (!ChangeTracker.HasChanges()) 
                return base.SaveChanges();
            
            AuditEntity();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (!ChangeTracker.HasChanges()) 
                return base.SaveChangesAsync(cancellationToken);
            
            AuditEntity();
            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            modelBuilder.AddEntityMappingConfgurations(assemblies, typeof(IEntityTypeConfiguration<>));

            modelBuilder.RemoveEntitySuffixFromTableNames();

            base.OnModelCreating(modelBuilder);
        }

        void IWorkUnit.Commit()
        {
            SaveChanges();
        }
        
        async Task IWorkUnit.CommitAsync()
        {
            await SaveChangesAsync();
        }

        private void AuditEntity()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var now = DateTime.Now;

                if (entry.Entity is ICrudDates timeEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            timeEntity.CreatedAt = now;
                            timeEntity.UpdatedAt = now;
                            break;
                        case EntityState.Modified:
                            timeEntity.UpdatedAt = now;
                            break;
                    }
                }

                if (entry.Entity is IUuid guidEntity)
                {
                    if (guidEntity.Uuid == Guid.Empty)
                        guidEntity.Uuid = Guid.NewGuid();
                }
            }
        }
    }
}