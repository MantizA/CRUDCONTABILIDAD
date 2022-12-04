using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDCONTABILIDAD;

namespace CRUDCONTABILIDAD.Controllers
{
    public class SISTEMASAUXesController : Controller
    {
        private CONTABILIDADDBEntities db = new CONTABILIDADDBEntities();

        // GET: SISTEMASAUXes
        public ActionResult Index()
        {
            return View(db.SISTEMASAUX.ToList());
        }

        // GET: SISTEMASAUXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SISTEMASAUX sISTEMASAUX = db.SISTEMASAUX.Find(id);
            if (sISTEMASAUX == null)
            {
                return HttpNotFound();
            }
            return View(sISTEMASAUX);
        }

        // GET: SISTEMASAUXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SISTEMASAUXes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,ESTADO")] SISTEMASAUX sISTEMASAUX)
        {
            if (ModelState.IsValid)
            {
                db.SISTEMASAUX.Add(sISTEMASAUX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sISTEMASAUX);
        }

        // GET: SISTEMASAUXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SISTEMASAUX sISTEMASAUX = db.SISTEMASAUX.Find(id);
            if (sISTEMASAUX == null)
            {
                return HttpNotFound();
            }
            return View(sISTEMASAUX);
        }

        // POST: SISTEMASAUXes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,ESTADO")] SISTEMASAUX sISTEMASAUX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sISTEMASAUX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sISTEMASAUX);
        }

        // GET: SISTEMASAUXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SISTEMASAUX sISTEMASAUX = db.SISTEMASAUX.Find(id);
            if (sISTEMASAUX == null)
            {
                return HttpNotFound();
            }
            return View(sISTEMASAUX);
        }

        // POST: SISTEMASAUXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SISTEMASAUX sISTEMASAUX = db.SISTEMASAUX.Find(id);
            db.SISTEMASAUX.Remove(sISTEMASAUX);
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
