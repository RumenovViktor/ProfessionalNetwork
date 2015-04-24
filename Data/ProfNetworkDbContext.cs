namespace Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Common.Models;
    using Data.Interfaces;
    using Data.Migrations;

    public class ProfNetworkDbContext : IdentityDbContext<User>, IProfNetworkDbContext
    {
        private const string nameForConnectionString = "ProfessionalNetwork";

        public ProfNetworkDbContext()
            : base(nameForConnectionString, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProfNetworkDbContext, Configuration>());
        }

        public static ProfNetworkDbContext Create()
        {
            return new ProfNetworkDbContext();
        }

        public IDbSet<SkillTag> Skills { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
