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


        public IDbSet<SkillsTag> Skills { get; set; }
    }
}
