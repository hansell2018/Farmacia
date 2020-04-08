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
    public class FAR_EXISTENCIAController : Controller
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

        // GET: FAR_EXISTENCIA
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_EXISTENCIA = db.FAR_EXISTENCIA.Include(f => f.FAR_ARTICULO).Include(f => f.FAR_SUCURSAL).Where(s=> s.FAR_ARTICULO.ID_CAT != 1);
            return View(fAR_EXISTENCIA.ToList());
        }

        // GET: FAR_EXISTENCIA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EXISTENCIA fAR_EXISTENCIA = db.FAR_EXISTENCIA.Find(id);
            if (fAR_EXISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_EXISTENCIA);
        }

        // GET: FAR_EXISTENCIA/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            return View();
        }

        // POST: FAR_EXISTENCIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,ID_ARTICULO,EXISTENCIA,COSTO_MEDIO,USR_MOD,FECHA_MOD")] FAR_EXISTENCIA fAR_EXISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_EXISTENCIA.Add(fAR_EXISTENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_EXISTENCIA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_EXISTENCIA.ID_SUCURSAL);
            return View(fAR_EXISTENCIA);
        }

        // GET: FAR_EXISTENCIA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EXISTENCIA fAR_EXISTENCIA = db.FAR_EXISTENCIA.Find(id);
            if (fAR_EXISTENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_EXISTENCIA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_EXISTENCIA.ID_SUCURSAL);
            return View(fAR_EXISTENCIA);
        }

        // POST: FAR_EXISTENCIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,ID_ARTICULO,EXISTENCIA,COSTO_MEDIO,USR_MOD,FECHA_MOD")] FAR_EXISTENCIA fAR_EXISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_EXISTENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_EXISTENCIA.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_EXISTENCIA.ID_SUCURSAL);
            return View(fAR_EXISTENCIA);
        }

        // GET: FAR_EXISTENCIA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EXISTENCIA fAR_EXISTENCIA = db.FAR_EXISTENCIA.Find(id);
            if (fAR_EXISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_EXISTENCIA);
        }

        // POST: FAR_EXISTENCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_EXISTENCIA fAR_EXISTENCIA = db.FAR_EXISTENCIA.Find(id);
            db.FAR_EXISTENCIA.Remove(fAR_EXISTENCIA);
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
