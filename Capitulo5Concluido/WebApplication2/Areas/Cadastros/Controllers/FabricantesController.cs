using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Servico.Cadastros;

namespace WebApplication2.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        private FabricanteServico fabricanteServico = new FabricanteServico();
        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }
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
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    // GET: Fabricantes
    // public ActionResult Index()
    // {
    //     return View(context.Fabricantes.OrderBy(c => c.Nome));
    // }

    // GET: Create
    // public ActionResult Create()
    // {
    //     return View();
    // }
    // POST: Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    // public ActionResult Create(Fabricante fabricante)
    // {
    //     context.Fabricantes.Add(fabricante);
    //     context.SaveChanges();
    //     TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi adicionado";
    //     return RedirectToAction("Index");
    // }

    // GET: Fabricantes/Edit/5
    // public ActionResult Edit(long? id)
    // {
    //     if (id == null)
    //     {
    //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //     }
    //     Fabricante fabricante = context.Fabricantes.Find(id);
    //     if (fabricante == null)
    //     {
    //         return HttpNotFound();
    //     }
    //     return View(fabricante);
    // }
    // POST: Fabricantes/Edit/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Edit(Fabricante fabricante)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         context.Entry(fabricante).State = EntityState.Modified;
    //         context.SaveChanges();
    //         return RedirectToAction("Index");
    //     }
    //     return View(fabricante);
    // }


    // GET: Fabricantes/Details/5
    // public ActionResult Details(long? id)
    // {
    //     if (id == null)
    //     {
    //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //     }
    //     Fabricante fabricante = context.Fabricantes.Find(id); antigo
    //     Fabricante fabricante = context.Fabricantes.Where(f => f.FabricanteId == id).Include("Produtos.Categoria").First();
    //     if (fabricante == null)
    //     {
    //         return HttpNotFound();
    //     }
    //     return View(fabricante);
    // }
    // GET: Fabricantes/Delete/5
    // public ActionResult Delete(long? id)
    // {
    //     if (id == null)
    //     {
    //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //     }
    //     Fabricante fabricante = context.Fabricantes.Find(id);
    //     if (fabricante == null)
    //     {
    //         return HttpNotFound();
    //     }
    //     return View(fabricante);
    // }
    // POST: Fabricantes/Delete/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Delete(long id)
    // {
    //     Fabricante fabricante = context.Fabricantes.Find(id);
    //     context.Fabricantes.Remove(fabricante);
    //     context.SaveChanges();
    //     TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
    //     return RedirectToAction("Index");
    // }
}

