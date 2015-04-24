namespace Data
{
    using System;

    using Data.Interfaces;

    public class ProfessionalNetworkData
    {
        private IProfNetworkDbContext context;

        // Poor man's dependancy inversion. TODO: To fix it with Ninject.
        public ProfessionalNetworkData()
            : this(new ProfNetworkDbContext())
        {

        }

        public ProfessionalNetworkData(IProfNetworkDbContext context)
        {
            this.context = context;
        }
    }
}
