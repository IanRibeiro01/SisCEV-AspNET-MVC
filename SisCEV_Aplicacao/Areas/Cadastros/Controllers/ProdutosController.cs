using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisCEV_Modelo.Cadastros;
using System.Data.Entity;
using SisCEV_Servico.Cadastros;
using SisCEV_Servico.Tabelas;

namespace SisCEV_Aplicacao.Areas.Cadastros.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private CategoriaServico categoriaServico = new CategoriaServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(produtoServico.ObterTodosProdutosPorNome());
        }

        //GET: Obter Visão do Produto
        public ActionResult ObterVisaoProdutoPorId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = produtoServico.ObterProdutoPorId((int)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //Popular ViewBag com DropDownList de associações Fabricante/Categoria 
        private void PopularViewBag(Produto produto = null)
        {
            if(produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterTodasCategoriasPorNome(),
                    "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterTodosFabricantesPorNome(),
                    "FabricanteId", "Nome");
            }
            else
            {
                //Ultimo parâmetro identifica qual estará selecionado através do ID
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterTodasCategoriasPorNome(),
                    "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterTodosFabricantesPorNome(),
                    "FabricanteId", "Nome", produto.FabricanteId);
            }
        }

        //Criar e Editar Produto
        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Details
        public ActionResult Details(int? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((int)id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                produtoServico.DeletarProduto(id);
                //TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi deletado";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
