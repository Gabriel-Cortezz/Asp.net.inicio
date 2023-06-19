using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Home
        public ActionResult Index()
        {
            Home h = new Home();

            h.fabricantes = context.Fabricantes.OrderBy(c => c.Nome);
            h.categorias = context.Categorias.OrderBy(c => c.Nome);



            return View(h);
        }
        public ActionResult IndexComProdutosdoFabricante(long? id, bool tipo)
        {
            Home h = new Home();
            h.categorias = context.Categorias.OrderBy(c => c.Nome);
            h.fabricantes = context.Fabricantes.OrderBy(c => c.Nome);
            if (id != null)
            {
                if (tipo)
                {
                    h.produtos = context.Produtos.Where(p => p.FabricanteId == id);
                }
                else
                {
                    h.produtos = context.Produtos.Where(p => p.CategoriaId == id);
                }
            }
            else
            {
                h.produtos = context.Produtos.OrderBy(p => p.Nome);
            }
            return View(h);
        }
    }
}