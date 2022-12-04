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
    public class CUENTASCONTsController : Controller
    {
        private CONTABILIDADDBEntities db = new CONTABILIDADDBEntities();

        // GET: CUENTASCONTs
        public ActionResult Index()
        {
            return View(db.CUENTASCONT.ToList());
        }

        // GET: CUENTASCONTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTASCONT cUENTASCONT = db.CUENTASCONT.Find(id);
            if (cUENTASCONT == null)
            {
                return HttpNotFound();
            }
            return View(cUENTASCONT);
        }

        // GET: CUENTASCONTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUENTASCONTs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,PERMITEMOV,TIPO,NIVEL,BALANCE,CUENTA_MAYOR,ESTADO")] CUENTASCONT cUENTASCONT)
        {
            if (ModelState.IsValid)
            {
                db.CUENTASCONT.Add(cUENTASCONT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTASCONT);
        }

        // GET: CUENTASCONTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTASCONT cUENTASCONT = db.CUENTASCONT.Find(id);
            if (cUENTASCONT == null)
            {
                return HttpNotFound();
            }
            return View(cUENTASCONT);
        }

        // POST: CUENTASCONTs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,PERMITEMOV,TIPO,NIVEL,BALANCE,CUENTA_MAYOR,ESTADO")] CUENTASCONT cUENTASCONT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTASCONT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUENTASCONT);
        }

        // GET: CUENTASCONTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTASCONT cUENTASCONT = db.CUENTASCONT.Find(id);
            if (cUENTASCONT == null)
            {
                return HttpNotFound();
            }
            return View(cUENTASCONT);
        }

        // POST: CUENTASCONTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUENTASCONT cUENTASCONT = db.CUENTASCONT.Find(id);
            db.CUENTASCONT.Remove(cUENTASCONT);
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
