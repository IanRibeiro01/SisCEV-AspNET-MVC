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
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        //Obter Lista de Produtos Ordenados por nome
        public IQueryable<Produto> ObterTodosProdutosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).
                Include(f => f.Fabricante).OrderBy(p => p.Nome);
        }

        //Obter Produto através do ID
        public Produto ObterProdutoPorId(int id)
        {
            return context.Produtos.Where(p => p.ProdutoID == id).
                Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        //Salvar um novo Produto ou editar existente
        public void GravarProduto(Produto produto)
        {
            if(produto.ProdutoID == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State =
                    EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Editar um Produto
        public Produto DeletarProduto(int id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }

    }
}
