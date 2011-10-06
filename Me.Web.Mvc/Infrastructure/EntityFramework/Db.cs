namespace Me.Web.Mvc.Infrastructure.EntityFramework
{
    #region using directives

    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Models.DomainModel;

    #endregion

    public class Db : DbContext
    {
        public Db()
        {
            Database.SetInitializer(new Seeder());
        }

        public override int SaveChanges()
        {
            var entriesToAudit = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified)
                    && typeof(IEntityWithAudit).IsAssignableFrom(x.Entity.GetType()));

            foreach (var entry in entriesToAudit)
            {
                var entity = entry.Entity as IEntityWithAudit;
                if (entity != null && entry.State == EntityState.Added)
                {
                    entity.Created = DateTimeOffset.Now;
                    entity.Modified = DateTimeOffset.Now;
                }
                else if (entity != null && entry.State == EntityState.Modified)
                {
                    entity.Modified = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}