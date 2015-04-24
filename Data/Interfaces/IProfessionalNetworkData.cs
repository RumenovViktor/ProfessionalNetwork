namespace Data.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface IProfessionalNetworkData
    {
        IProfessionalNetworkRepository<SkillTag> Skills { get; }

        IProfessionalNetworkRepository<User> Users { get; }

        void SaveChanges();
    }
}
