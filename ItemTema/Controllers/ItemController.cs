using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ItemTema.Contexts;
using ItemTema.Models;

namespace ItemTema.Controllers
{
    public class ItemController : Controller
    {
        private EFContext context = new EFContext();
        // Listagem de itens
        public ActionResult Index()
        {
            return View(context.Items.OrderBy(i => i.Nome));
        }
        // GET: Criar itens
        public ActionResult Create()
        {
            return View();
        }
        // POST: Criar itens
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item i)
        {
            context.Items.Add(i);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Editar itens
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Editar itens
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item i)
        {
            if (ModelState.IsValid)
            {
                context.Entry(i).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(i);
        }
        // GET: Detalhar itens
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // GET: Deletar itens
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Deletar itens
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Item item = context.Items.Find(id);
            context.Items.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}