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
    public class ENTRADACONTABLEsController : Controller
    {
        private CONTABILIDADDBEntities db = new CONTABILIDADDBEntities();

        // GET: ENTRADACONTABLEs
        public ActionResult Index()
        {
            return View(db.ENTRADACONTABLE.ToList());
        }

        // GET: ENTRADACONTABLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTRADACONTABLE eNTRADACONTABLE = db.ENTRADACONTABLE.Find(id);
            if (eNTRADACONTABLE == null)
            {
                return HttpNotFound();
            }
            return View(eNTRADACONTABLE);
        }

        // GET: ENTRADACONTABLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ENTRADACONTABLEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ASIENTO,DESCRIPCION,IDENTIFICADOR_AUX,CUENTA,TIPOMOV,FECHAASIENTO,MONTOASIENTO,ESTADO")] ENTRADACONTABLE eNTRADACONTABLE)
        {
            if (ModelState.IsValid)
            {
                db.ENTRADACONTABLE.Add(eNTRADACONTABLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eNTRADACONTABLE);
        }

        // GET: ENTRADACONTABLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTRADACONTABLE eNTRADACONTABLE = db.ENTRADACONTABLE.Find(id);
            if (eNTRADACONTABLE == null)
            {
                return HttpNotFound();
            }
            return View(eNTRADACONTABLE);
        }

        // POST: ENTRADACONTABLEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ASIENTO,DESCRIPCION,IDENTIFICADOR_AUX,CUENTA,TIPOMOV,FECHAASIENTO,MONTOASIENTO,ESTADO")] ENTRADACONTABLE eNTRADACONTABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNTRADACONTABLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eNTRADACONTABLE);
        }

        // GET: ENTRADACONTABLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTRADACONTABLE eNTRADACONTABLE = db.ENTRADACONTABLE.Find(id);
            if (eNTRADACONTABLE == null)
            {
                return HttpNotFound();
            }
            return View(eNTRADACONTABLE);
        }

        // POST: ENTRADACONTABLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENTRADACONTABLE eNTRADACONTABLE = db.ENTRADACONTABLE.Find(id);
            db.ENTRADACONTABLE.Remove(eNTRADACONTABLE);
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
