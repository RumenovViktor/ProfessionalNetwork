namespace Data
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Data.Interfaces;

    public class ProfNetworkDbContext : IdentityDbContext<User>, IProfNetworkDbContext
    {
        public ProfNetworkDbContext()
            : base("ProfessionalNetwork", throwIfV1Schema: false)
        {

        }

        public static ProfNetworkDbContext Create()
        {
            return new ProfNetworkDbContext();
        }
    }
}
