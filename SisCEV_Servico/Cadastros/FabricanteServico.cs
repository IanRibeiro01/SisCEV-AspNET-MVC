using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisCEV_Persistencia.DAL.Cadastros;
using SisCEV_Modelo.Cadastros;

namespace SisCEV_Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterTodosFabricantesPorNome()
        {
            return fabricanteDAL.OberTodosFabricantesPorNome();
        }

        public Fabricante ObterFabricantePorId(int id)
        {
            return fabricanteDAL.ObterFabricantePorId(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante DeletarFabricante(int id)
        {
            return fabricanteDAL.DeletarFabricante(id);
        }

    }
}
