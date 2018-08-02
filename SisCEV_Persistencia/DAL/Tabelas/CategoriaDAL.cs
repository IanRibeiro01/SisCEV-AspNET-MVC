using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisCEV_Persistencia.Contexts;
using SisCEV_Modelo.Tabelas;
using System.Data.Entity;

namespace SisCEV_Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterTodasCategoriasPorNome()
        {
            return context.Categorias.OrderBy(c => c.Nome);
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            return context.Categorias.Find(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            if(categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria DeletarCategoria(int id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }

    }
}
