using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisCEV_Modelo.Tabelas;
using SisCEV_Servico.Tabelas;

namespace SisCEV_Aplicacao.Controllers
{
    public class CategoriasController : Controller
    {

        private CategoriaServico categoriaServico = new CategoriaServico();

        // Listar
        public ActionResult Index()
        {
            return View(categoriaServico.ObterTodasCategoriasPorNome());
        }

        //Obter Visão do Categoria
        private ActionResult ObterVisaoCategoriaPorId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((int)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //Criar e Editar Fabricante
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        //Criar
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        //Editar
        public ActionResult Edit(int? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        //Detalhes
        public ActionResult Details(int? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        //Deletar
        public ActionResult Delete (int? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                categoriaServico.DeletarCategoria(id);
                //TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " Foi Removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

    }
}