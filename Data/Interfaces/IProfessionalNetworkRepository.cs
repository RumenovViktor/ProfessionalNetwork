namespace Data.Interfaces
{
    using System;
    using System.Linq;

    interface IProfessionalNetworkRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T GetById(T id);

        void Update(T entity);

        T Delete(T entity);

        T DeleteById(T id);

        void Detach(T entity);

        int SaveChanges();
    }
}
