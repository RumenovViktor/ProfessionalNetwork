namespace Data.Interfaces
{
    using System;
    using System.Data.Entity;

    using Models;

    public interface IProfNetworkDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<SkillsTag> Skills { get; set; }
    }
}
