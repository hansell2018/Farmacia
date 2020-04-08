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
    public class FAR_DET_TRASLADOController : Controller
    {
        private FARMACIAEntities db = new FARMACIAEntities();

        // GET: FAR_DET_TRASLADO
        public ActionResult Index()
        {
            var fAR_DET_TRASLADO = db.FAR_DET_TRASLADO.Include(f => f.FAR_ARTICULO).Include(f => f.FAR_TRASLADO);
            return View(fAR_DET_TRASLADO.ToList());
        }

        // GET: FAR_DET_TRASLADO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DET_TRASLADO fAR_DET_TRASLADO = db.FAR_DET_TRASLADO.Find(id);
            if (fAR_DET_TRASLADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DET_TRASLADO);
        }

        // GET: FAR_DET_TRASLADO/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.ID_TRASLADO = new SelectList(db.FAR_TRASLADO, "ID_TRASLADO", "ID_TRASLADO");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRASLADO,ITEM,ID_ARTICULO,CANTIDAD")] FAR_DET_TRASLADO fAR_DET_TRASLADO)
        {
            if (ModelState.IsValid)
            {
                db.FAR_DET_TRASLADO.Add(fAR_DET_TRASLADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DET_TRASLADO.ID_ARTICULO);
            ViewBag.ID_TRASLADO = new SelectList(db.FAR_TRASLADO, "ID_TRASLADO", "ID_TRASLADO", fAR_DET_TRASLADO.ID_TRASLADO);
            return View(fAR_DET_TRASLADO);
        }

        // GET: FAR_DET_TRASLADO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DET_TRASLADO fAR_DET_TRASLADO = db.FAR_DET_TRASLADO.Find(id);
            if (fAR_DET_TRASLADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DET_TRASLADO.ID_ARTICULO);
            ViewBag.ID_TRASLADO = new SelectList(db.FAR_TRASLADO, "ID_TRASLADO", "ID_TRASLADO", fAR_DET_TRASLADO.ID_TRASLADO);
            return View(fAR_DET_TRASLADO);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRASLADO,ITEM,ID_ARTICULO,CANTIDAD")] FAR_DET_TRASLADO fAR_DET_TRASLADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_DET_TRASLADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_DET_TRASLADO.ID_ARTICULO);
            ViewBag.ID_TRASLADO = new SelectList(db.FAR_TRASLADO, "ID_TRASLADO", "ID_TRASLADO", fAR_DET_TRASLADO.ID_TRASLADO);
            return View(fAR_DET_TRASLADO);
        }

        // GET: FAR_DET_TRASLADO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_DET_TRASLADO fAR_DET_TRASLADO = db.FAR_DET_TRASLADO.Find(id);
            if (fAR_DET_TRASLADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_DET_TRASLADO);
        }

        // POST: FAR_DET_TRASLADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_DET_TRASLADO fAR_DET_TRASLADO = db.FAR_DET_TRASLADO.Find(id);
            db.FAR_DET_TRASLADO.Remove(fAR_DET_TRASLADO);
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
