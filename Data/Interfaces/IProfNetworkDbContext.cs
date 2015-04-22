namespace Data.Interfaces
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IProfNetworkDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<SkillTag> Skills { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry Entry(object entity);

        void Dispose();

        int SaveChanges();
    }
}
