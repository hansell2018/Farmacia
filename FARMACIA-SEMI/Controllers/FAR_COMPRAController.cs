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
    public class FAR_COMPRAController : Controller
    {
        private FARMACIAEntities db = new FARMACIAEntities();
            public Boolean validarSesion()
            {
                FAR_USUARIO usuario = new FAR_USUARIO();
                usuario = Session["usuario"] as FAR_USUARIO;
                Boolean estadoSesion = true;

                if (usuario == null)
                {
                    estadoSesion = false;
                }

                return estadoSesion;
            }
        // GET: FAR_COMPRA
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_COMPRA = db.FAR_COMPRA.Include(f => f.FAR_SUCURSAL).Include(f => f.FAR_PROVEEDOR).Include(f => f.FAR_TIPO_PAGO).Include(f => f.FAR_DETALLE_COMPRA);
            return View(fAR_COMPRA.ToList());
        }

        // GET: FAR_COMPRA/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_COMPRA fAR_COMPRA = db.FAR_COMPRA.Find(id);
            if (fAR_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_COMPRA);
        }

        // GET: FAR_COMPRA/Create
        public ActionResult Create()
        {
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.NIT = new SelectList(db.FAR_PROVEEDOR, "NIT", "DESC_NIT");
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO");
            ViewBag.FACTURA = new SelectList(db.FAR_DETALLE_COMPRA, "FACTURA", "FACTURA");
            return View();
        }

        // POST: FAR_COMPRA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FACTURA,ID_SUCURSAL,NIT,ID_TPAGO,FECHA")] FAR_COMPRA fAR_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_COMPRA.Add(fAR_COMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_COMPRA.ID_SUCURSAL);
            ViewBag.NIT = new SelectList(db.FAR_PROVEEDOR, "NIT", "DESC_NIT", fAR_COMPRA.NIT);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_COMPRA.ID_TPAGO);
            ViewBag.FACTURA = new SelectList(db.FAR_DETALLE_COMPRA, "FACTURA", "FACTURA", fAR_COMPRA.FACTURA);
            return View(fAR_COMPRA);
        }

        // GET: FAR_COMPRA/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_COMPRA fAR_COMPRA = db.FAR_COMPRA.Find(id);
            if (fAR_COMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_COMPRA.ID_SUCURSAL);
            ViewBag.NIT = new SelectList(db.FAR_PROVEEDOR, "NIT", "DESC_NIT", fAR_COMPRA.NIT);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_COMPRA.ID_TPAGO);
            ViewBag.FACTURA = new SelectList(db.FAR_DETALLE_COMPRA, "FACTURA", "FACTURA", fAR_COMPRA.FACTURA);
            return View(fAR_COMPRA);
        }

        // POST: FAR_COMPRA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FACTURA,ID_SUCURSAL,NIT,ID_TPAGO,FECHA")] FAR_COMPRA fAR_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_COMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_COMPRA.ID_SUCURSAL);
            ViewBag.NIT = new SelectList(db.FAR_PROVEEDOR, "NIT", "DESC_NIT", fAR_COMPRA.NIT);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_COMPRA.ID_TPAGO);
            ViewBag.FACTURA = new SelectList(db.FAR_DETALLE_COMPRA, "FACTURA", "FACTURA", fAR_COMPRA.FACTURA);
            return View(fAR_COMPRA);
        }

        // GET: FAR_COMPRA/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_COMPRA fAR_COMPRA = db.FAR_COMPRA.Find(id);
            if (fAR_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_COMPRA);
        }

        // POST: FAR_COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FAR_COMPRA fAR_COMPRA = db.FAR_COMPRA.Find(id);
            db.FAR_COMPRA.Remove(fAR_COMPRA);
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
