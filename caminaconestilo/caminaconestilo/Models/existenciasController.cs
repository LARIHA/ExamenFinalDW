using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace caminaconestilo.Models
{
    public class existenciasController : Controller
    {
        private camina_con_estiloEntities db = new camina_con_estiloEntities();

        // GET: existencias
        public ActionResult Index()
        {
            var existencia = db.existencia.Include(e => e.producto);
            return View(existencia.ToList());
        }

        // GET: existencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            existencia existencia = db.existencia.Find(id);
            if (existencia == null)
            {
                return HttpNotFound();
            }
            return View(existencia);
        }

        // GET: existencias/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre");
            return View();
        }

        // POST: existencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_existencia,descripcion,id_producto,id_proveedor,cantidad")] existencia existencia)
        {
            if (ModelState.IsValid)
            {
                db.existencia.Add(existencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", existencia.id_producto);
            return View(existencia);
        }

        // GET: existencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            existencia existencia = db.existencia.Find(id);
            if (existencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", existencia.id_producto);
            return View(existencia);
        }

        // POST: existencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_existencia,descripcion,id_producto,id_proveedor,cantidad")] existencia existencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(existencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.producto, "id_producto", "nombre", existencia.id_producto);
            return View(existencia);
        }

        // GET: existencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            existencia existencia = db.existencia.Find(id);
            if (existencia == null)
            {
                return HttpNotFound();
            }
            return View(existencia);
        }

        // POST: existencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            existencia existencia = db.existencia.Find(id);
            db.existencia.Remove(existencia);
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
