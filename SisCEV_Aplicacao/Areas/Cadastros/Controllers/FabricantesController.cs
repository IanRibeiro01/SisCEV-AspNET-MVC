using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisCEV_Modelo.Cadastros;
using SisCEV_Servico.Cadastros;

namespace SisCEV_Aplicacao.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // Listar
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterTodosFabricantesPorNome());
        }

        //Obter Visão do Fabricante
        private ActionResult ObterVisaoFabricantePorId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).
            // Include("Produtos.Categoria").First();
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((int)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        //Criar e Editar Fabricante
        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
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
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }


        //Editar
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);

        }


        //Detalhes
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        //Deletar
        public ActionResult Delete(int? id)
        {
            
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                fabricanteServico.DeletarFabricante(id);
                //TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " Foi Removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }


    }
}