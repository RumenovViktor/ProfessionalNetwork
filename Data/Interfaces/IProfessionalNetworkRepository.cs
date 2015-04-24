namespace Data.Interfaces
{
    using System;
    using System.Linq;

    public interface IProfessionalNetworkRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T GetById(T id);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
