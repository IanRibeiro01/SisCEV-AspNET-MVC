using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisCEV_Persistencia.DAL.Cadastros;
using SisCEV_Modelo.Cadastros;

namespace SisCEV_Servico.Cadastros
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable<Produto> ObterTodosProdutosPorNome()
        {
            return produtoDAL.ObterTodosProdutosPorNome();
        }

        public Produto ObterProdutoPorId (int id)
        {
            return produtoDAL.ObterProdutoPorId(id);
        }

        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }

        public Produto DeletarProduto(int id)
        {
            return produtoDAL.DeletarProduto(id);
        }
    }
}
