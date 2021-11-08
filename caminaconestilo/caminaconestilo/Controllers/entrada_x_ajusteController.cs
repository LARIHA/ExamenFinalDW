using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using caminaconestilo.Models;

namespace caminaconestilo.Controllers
{
    public class entrada_x_ajusteController : Controller
    {
        private camina_con_estiloEntities db = new camina_con_estiloEntities();

        // GET: entrada_x_ajuste
        public ActionResult Index()
        {
            var entrada_x_ajuste = db.entrada_x_ajuste.Include(e => e.producto);
            return View(entrada_x_ajuste.ToList());
        }

        // GET: entrada_x_ajuste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_x_ajuste entrada_x_ajuste = db.entrada_x_ajuste.Find(id);
            if (entrada_x_ajuste == null)
            {
                return HttpNotFound();
            }
            return View(entrada_x_ajuste);
        }

        // GET: entrada_x_ajuste/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre");
            return View();
        }

        // POST: entrada_x_ajuste/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_entrada_x_ajuste,descripcion,id_producto")] entrada_x_ajuste entrada_x_ajuste)
        {
            if (ModelState.IsValid)
            {
                db.entrada_x_ajuste.Add(entrada_x_ajuste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", entrada_x_ajuste.id_producto);
            return View(entrada_x_ajuste);
        }

        // GET: entrada_x_ajuste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_x_ajuste entrada_x_ajuste = db.entrada_x_ajuste.Find(id);
            if (entrada_x_ajuste == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", entrada_x_ajuste.id_producto);
            return View(entrada_x_ajuste);
        }

        // POST: entrada_x_ajuste/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_entrada_x_ajuste,descripcion,id_producto")] entrada_x_ajuste entrada_x_ajuste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada_x_ajuste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", entrada_x_ajuste.id_producto);
            return View(entrada_x_ajuste);
        }

        // GET: entrada_x_ajuste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entrada_x_ajuste entrada_x_ajuste = db.entrada_x_ajuste.Find(id);
            if (entrada_x_ajuste == null)
            {
                return HttpNotFound();
            }
            return View(entrada_x_ajuste);
        }

        // POST: entrada_x_ajuste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entrada_x_ajuste entrada_x_ajuste = db.entrada_x_ajuste.Find(id);
            db.entrada_x_ajuste.Remove(entrada_x_ajuste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
