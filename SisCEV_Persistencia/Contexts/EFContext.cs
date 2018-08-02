using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SisCEV_Modelo.Cadastros;
using SisCEV_Modelo.Tabelas;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SisCEV_Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(): base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>
                (new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        //Sobrescrever método para regularizar problema de pluralização (ex: Produto = Produtoes)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}