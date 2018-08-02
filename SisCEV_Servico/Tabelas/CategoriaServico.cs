using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisCEV_Modelo.Tabelas;
using SisCEV_Persistencia.DAL.Tabelas;
namespace SisCEV_Servico.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable<Categoria> ObterTodasCategoriasPorNome()
        {
            return categoriaDAL.ObterTodasCategoriasPorNome();
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            return categoriaDAL.ObterCategoriaPorId(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria DeletarCategoria(int id)
        {
            return categoriaDAL.DeletarCategoria(id);
        }

    }
}
