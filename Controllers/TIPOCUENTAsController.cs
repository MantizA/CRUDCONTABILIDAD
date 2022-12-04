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
    public class TIPOCUENTAsController : Controller
    {
        private CONTABILIDADDBEntities db = new CONTABILIDADDBEntities();

        // GET: TIPOCUENTAs
        public ActionResult Index()
        {
            return View(db.TIPOCUENTA.ToList());
        }

        // GET: TIPOCUENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCUENTA tIPOCUENTA = db.TIPOCUENTA.Find(id);
            if (tIPOCUENTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCUENTA);
        }

        // GET: TIPOCUENTAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOCUENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,ORIGEN,ESTADO")] TIPOCUENTA tIPOCUENTA)
        {
            if (ModelState.IsValid)
            {
                db.TIPOCUENTA.Add(tIPOCUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOCUENTA);
        }

        // GET: TIPOCUENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCUENTA tIPOCUENTA = db.TIPOCUENTA.Find(id);
            if (tIPOCUENTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCUENTA);
        }

        // POST: TIPOCUENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,ORIGEN,ESTADO")] TIPOCUENTA tIPOCUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOCUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOCUENTA);
        }

        // GET: TIPOCUENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCUENTA tIPOCUENTA = db.TIPOCUENTA.Find(id);
            if (tIPOCUENTA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCUENTA);
        }

        // POST: TIPOCUENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOCUENTA tIPOCUENTA = db.TIPOCUENTA.Find(id);
            db.TIPOCUENTA.Remove(tIPOCUENTA);
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
