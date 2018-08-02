using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisCEV_Persistencia.Contexts;
using SisCEV_Modelo.Cadastros;
using System.Data.Entity;

namespace SisCEV_Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> OberTodosFabricantesPorNome()
        {
            return context.Fabricantes.OrderBy(f => f.Nome);
        }

        public Fabricante ObterFabricantePorId(int id)
        {
            //return context.Fabricantes.Where(f => f.FabricanteId == id).First();
            return context.Fabricantes.Find(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if(fabricante.FabricanteId == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante DeletarFabricante(int id)
        {
            Fabricante fabricante = ObterFabricantePorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }


    }
}
