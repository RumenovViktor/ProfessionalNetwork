namespace Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Data.Interfaces;
    using Data.Repository;

    public class ProfessionalNetworkData : IProfessionalNetworkData
    {
        private IProfNetworkDbContext context;
        private IDictionary<Type, object> repositories;

        // Poor man's dependancy inversion. TODO: To fix it with Ninject.
        public ProfessionalNetworkData()
            : this(new ProfNetworkDbContext())
        {
        }

        public ProfessionalNetworkData(IProfNetworkDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public IDeletableEntityRepository<SkillTag> Skills
        {
            get
            {
                return GetRepository<SkillTag>();
            }
        }

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return GetRepository<User>();
            }
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(IDeletableEntityRepository<T>);

                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfModel];
        }
    }
}
