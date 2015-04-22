namespace Data
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Data.Interfaces;
    using Data.Migrations;

    public class ProfNetworkDbContext : IdentityDbContext<User>, IProfNetworkDbContext
    {
        public ProfNetworkDbContext()
            : base("ProfessionalNetwork", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProfNetworkDbContext, Configuration>());
        }

        public static ProfNetworkDbContext Create()
        {
            return new ProfNetworkDbContext();
        }
    }
}
