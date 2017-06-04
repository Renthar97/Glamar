using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;

namespace Glamar.mvc.Controllers
{
    public class DOCUMENTOesController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: DOCUMENTOes
        public ActionResult Index()
        {
            var documentos = db.Documentos.Include(d => d.CLIENTE).Include(d => d.VENTA);
            return View(documentos.ToList());
        }

        // GET: DOCUMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.Documentos.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente");
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: DOCUMENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentoId,VentaId,ClienteId,tipo")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(dOCUMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", dOCUMENTO.ClienteId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", dOCUMENTO.VentaId);
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.Documentos.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", dOCUMENTO.ClienteId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", dOCUMENTO.VentaId);
            return View(dOCUMENTO);
        }

        // POST: DOCUMENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentoId,VentaId,ClienteId,tipo")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", dOCUMENTO.ClienteId);
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", dOCUMENTO.VentaId);
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.Documentos.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // POST: DOCUMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENTO dOCUMENTO = db.Documentos.Find(id);
            db.Documentos.Remove(dOCUMENTO);
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
