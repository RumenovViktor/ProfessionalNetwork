namespace Data.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;

    using Data.Interfaces;
    using System.Data.Entity.Infrastructure;

    public class ProfessionalNetworkRepository<T> : IProfessionalNetworkRepository<T> where T : class
    {
        public ProfessionalNetworkRepository(IProfNetworkDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public IProfNetworkDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(T id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public virtual int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
