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
    public class TIPOMONEDAsController : Controller
    {
        private CONTABILIDADDBEntities db = new CONTABILIDADDBEntities();

        // GET: TIPOMONEDAs
        public ActionResult Index()
        {
            return View(db.TIPOMONEDA.ToList());
        }

        // GET: TIPOMONEDAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOMONEDA tIPOMONEDA = db.TIPOMONEDA.Find(id);
            if (tIPOMONEDA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOMONEDA);
        }

        // GET: TIPOMONEDAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOMONEDAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODIGO,DESCRIPCION,TASACAMBIO,ESTADO")] TIPOMONEDA tIPOMONEDA)
        {
            if (ModelState.IsValid)
            {
                db.TIPOMONEDA.Add(tIPOMONEDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOMONEDA);
        }

        // GET: TIPOMONEDAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOMONEDA tIPOMONEDA = db.TIPOMONEDA.Find(id);
            if (tIPOMONEDA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOMONEDA);
        }

        // POST: TIPOMONEDAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODIGO,DESCRIPCION,TASACAMBIO,ESTADO")] TIPOMONEDA tIPOMONEDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOMONEDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOMONEDA);
        }

        // GET: TIPOMONEDAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOMONEDA tIPOMONEDA = db.TIPOMONEDA.Find(id);
            if (tIPOMONEDA == null)
            {
                return HttpNotFound();
            }
            return View(tIPOMONEDA);
        }

        // POST: TIPOMONEDAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOMONEDA tIPOMONEDA = db.TIPOMONEDA.Find(id);
            db.TIPOMONEDA.Remove(tIPOMONEDA);
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
