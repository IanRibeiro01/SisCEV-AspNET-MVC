namespace SisCEV_Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisCEV_Persistencia.Contexts.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Atribuir true quando modificar modelo, ap�s execu��o atribuir false  
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SisCEV_Persistencia.Contexts.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
