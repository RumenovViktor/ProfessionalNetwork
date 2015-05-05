namespace Data.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface IProfessionalNetworkData
    {
        IDeletableEntityRepository<Skill> Skills { get; }

        IDeletableEntityRepository<User> Users { get; }

        void SaveChanges();
    }
}
