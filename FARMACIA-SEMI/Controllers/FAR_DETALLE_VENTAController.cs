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
    public class FAR_DETALLE_VENTAController : Controller
    {
        private FARMACIAEntities db = new FARMACIAEntities();

        // GET: FAR_DETALLE_VENTA
        public ActionResult Index()
        {
            var fAR_DETALLE_VENTA = db.FAR_DETALLE_VENTA.Include(f => f.FAR_ARTICULO).Include(f => f.FAR_VENTA);
            return View(fAR_DETALLE_VENTA.ToList());
        }

        // GET: FAR_DETALLE_VENTA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_VENTA fAR_DETALLE_VENTA = db.FAR_DETALLE_VENTA.Find(id);
            if (fAR_DETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DETALLE_VENTA);
        }

        // GET: FAR_DETALLE_VENTA/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_VENTA, "ID_SUCURSAL", "FACTURA");
            return View();
        }

        // POST: FAR_DETALLE_VENTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,FACTURA,ITEM,ID_ARTICULO,CANTIDAD,COSTO_U")] FAR_DETALLE_VENTA fAR_DETALLE_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_DETALLE_VENTA.Add(fAR_DETALLE_VENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_VENTA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_VENTA, "ID_SUCURSAL", "FACTURA");
            return View(fAR_DETALLE_VENTA);
        }

        // GET: FAR_DETALLE_VENTA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_VENTA fAR_DETALLE_VENTA = db.FAR_DETALLE_VENTA.Find(id);
            if (fAR_DETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_VENTA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_VENTA, "ID_SUCURSAL", "FACTURA");
            return View(fAR_DETALLE_VENTA);
        }

        // POST: FAR_DETALLE_VENTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,FACTURA,ITEM,ID_ARTICULO,CANTIDAD,COSTO_U")] FAR_DETALLE_VENTA fAR_DETALLE_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_DETALLE_VENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DETALLE_VENTA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_VENTA, "ID_SUCURSAL", "FACTURA");
            return View(fAR_DETALLE_VENTA);
        }

        // GET: FAR_DETALLE_VENTA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DETALLE_VENTA fAR_DETALLE_VENTA = db.FAR_DETALLE_VENTA.Find(id);
            if (fAR_DETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DETALLE_VENTA);
        }

        // POST: FAR_DETALLE_VENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_DETALLE_VENTA fAR_DETALLE_VENTA = db.FAR_DETALLE_VENTA.Find(id);
            db.FAR_DETALLE_VENTA.Remove(fAR_DETALLE_VENTA);
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
