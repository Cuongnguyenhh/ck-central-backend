using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.DataObjects.Entity;

namespace CK.Central.Core.Helpers
{
    public class DateInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
        {
            var context = eventData.Context;

            if (context is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var entries = context.ChangeTracker.Entries<BaseEntity>()
                .Where(entry => entry.State is EntityState.Added or EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Modified)
                {
                    entry.Property(auditable => auditable.UpdatedDatetime).CurrentValue = DateTime.UtcNow;
                }

                if (entry.State is EntityState.Added)
                {
                    entry.Property(auditable => auditable.CreatedDatetime).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
