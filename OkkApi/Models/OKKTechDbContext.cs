using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkApi.Models
{
    public class OKKTechDbContext:DbContext
    {
        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State ==EntityState.Added))
            {
                string EntryName = (entry.Entity != null) ? entry.Entity.GetType().Name : "";
                if (entry.Property("CreatedOn").CurrentValue == null)
                    entry.Property("CreatedOn").CurrentValue = saveTime;
                
            }
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                string EntryName = entry.GetType().Name;

                if (entry.Property("ModifiedOn") != null)
                    entry.Property("ModifiedOn").CurrentValue = saveTime;
            }

            return base.SaveChanges();
        }

        public OKKTechDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
