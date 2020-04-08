using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FARMACIA_SEMI.Models;

namespace FARMACIA_SEMI.Controllers
{
    public class FAR_DETALLE_COMPRAController : Controller
    {
        private FARMACIAEntities db = new FARMACIAEntities();

        // GET: FAR_DETALLE_COMPRA
        public ActionResult Index()
        {
            var fAR_DETALLE_COMPRA = db.FAR_DETALLE_COMPRA.Include(f => f.FAR_ARTICULO).Include(f => f.FAR_COMPRA);
            return View(fAR_DETALLE_COMPRA.ToList());
        }

        // GET: FAR_DETALLE_COMPRA/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA = db.FAR_DETALLE_COMPRA.Find(id);
            if (fAR_DETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DETALLE_COMPRA);
        }

        // GET: FAR_DETALLE_COMPRA/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.FACTURA = new SelectList(db.FAR_COMPRA, "FACTURA", "FACTURA");
            return View();
        }

        // POST: FAR_DETALLE_COMPRA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FACTURA,ITEM,ID_ARTICULO,CANTIDAD,COSTO_U")] FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_DETALLE_COMPRA.Add(fAR_DETALLE_COMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_COMPRA.ID_ARTICULO);
            ViewBag.FACTURA = new SelectList(db.FAR_COMPRA, "FACTURA", "FACTURA", fAR_DETALLE_COMPRA.FACTURA);
            return View(fAR_DETALLE_COMPRA);
        }

        // GET: FAR_DETALLE_COMPRA/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA = db.FAR_DETALLE_COMPRA.Find(id);
            if (fAR_DETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_COMPRA.ID_ARTICULO);
            ViewBag.FACTURA = new SelectList(db.FAR_COMPRA, "FACTURA", "FACTURA", fAR_DETALLE_COMPRA.FACTURA);
            return View(fAR_DETALLE_COMPRA);
        }

        // POST: FAR_DETALLE_COMPRA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FACTURA,ITEM,ID_ARTICULO,CANTIDAD,COSTO_U")] FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_DETALLE_COMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_COMPRA.ID_ARTICULO);
            ViewBag.FACTURA = new SelectList(db.FAR_COMPRA, "FACTURA", "FACTURA", fAR_DETALLE_COMPRA.FACTURA);
            return View(fAR_DETALLE_COMPRA);
        }

        // GET: FAR_DETALLE_COMPRA/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA = db.FAR_DETALLE_COMPRA.Find(id);
            if (fAR_DETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DETALLE_COMPRA);
        }

        // POST: FAR_DETALLE_COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FAR_DETALLE_COMPRA fAR_DETALLE_COMPRA = db.FAR_DETALLE_COMPRA.Find(id);
            db.FAR_DETALLE_COMPRA.Remove(fAR_DETALLE_COMPRA);
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
