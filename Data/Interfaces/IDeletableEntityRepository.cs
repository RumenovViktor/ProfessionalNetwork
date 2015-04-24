namespace Data.Interfaces
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface IDeletableEntityRepository<T> : IProfessionalNetworkRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}
