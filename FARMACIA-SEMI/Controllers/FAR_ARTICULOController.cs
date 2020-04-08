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
    public class FAR_ARTICULOController : Controller
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
        
        // GET: FAR_ARTICULO
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_ARTICULO = db.FAR_ARTICULO.Include(f => f.FAR_CAT_ARTICULO).Include(f => f.FAR_MARCA).Include(f => f.FAR_UNIDAD_MED);
            return View(fAR_ARTICULO.ToList());
        }

        // GET: FAR_ARTICULO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_ARTICULO fAR_ARTICULO = db.FAR_ARTICULO.Find(id);
            if (fAR_ARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_ARTICULO);
        }

        // GET: FAR_ARTICULO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CAT = new SelectList(db.FAR_CAT_ARTICULO, "ID_CAT", "DESC_CAT");
            ViewBag.ID_MARCA = new SelectList(db.FAR_MARCA, "ID_MARCA", "DESC_MARCA");
            ViewBag.ID_MEDIDA = new SelectList(db.FAR_UNIDAD_MED, "ID_MEDIDA", "DESC_MEDIDA");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,ID_MARCA,ID_CAT,ID_MEDIDA,DESC_ARTICULO")] FAR_ARTICULO fAR_ARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.FAR_ARTICULO.Add(fAR_ARTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CAT = new SelectList(db.FAR_CAT_ARTICULO, "ID_CAT", "DESC_CAT", fAR_ARTICULO.ID_CAT);
            ViewBag.ID_MARCA = new SelectList(db.FAR_MARCA, "ID_MARCA", "DESC_MARCA", fAR_ARTICULO.ID_MARCA);
            ViewBag.ID_MEDIDA = new SelectList(db.FAR_UNIDAD_MED, "ID_MEDIDA", "DESC_MEDIDA", fAR_ARTICULO.ID_MEDIDA);
            return View(fAR_ARTICULO);
        }

        // GET: FAR_ARTICULO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_ARTICULO fAR_ARTICULO = db.FAR_ARTICULO.Find(id);
            if (fAR_ARTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CAT = new SelectList(db.FAR_CAT_ARTICULO, "ID_CAT", "DESC_CAT", fAR_ARTICULO.ID_CAT);
            ViewBag.ID_MARCA = new SelectList(db.FAR_MARCA, "ID_MARCA", "DESC_MARCA", fAR_ARTICULO.ID_MARCA);
            ViewBag.ID_MEDIDA = new SelectList(db.FAR_UNIDAD_MED, "ID_MEDIDA", "DESC_MEDIDA", fAR_ARTICULO.ID_MEDIDA);
            return View(fAR_ARTICULO);
        }

        // POST: FAR_ARTICULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,ID_MARCA,ID_CAT,ID_MEDIDA,DESC_ARTICULO")] FAR_ARTICULO fAR_ARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_ARTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CAT = new SelectList(db.FAR_CAT_ARTICULO, "ID_CAT", "DESC_CAT", fAR_ARTICULO.ID_CAT);
            ViewBag.ID_MARCA = new SelectList(db.FAR_MARCA, "ID_MARCA", "DESC_MARCA", fAR_ARTICULO.ID_MARCA);
            ViewBag.ID_MEDIDA = new SelectList(db.FAR_UNIDAD_MED, "ID_MEDIDA", "DESC_MEDIDA", fAR_ARTICULO.ID_MEDIDA);
            return View(fAR_ARTICULO);
        }

        // GET: FAR_ARTICULO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_ARTICULO fAR_ARTICULO = db.FAR_ARTICULO.Find(id);
            if (fAR_ARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_ARTICULO);
        }

        // POST: FAR_ARTICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_ARTICULO fAR_ARTICULO = db.FAR_ARTICULO.Find(id);
            db.FAR_ARTICULO.Remove(fAR_ARTICULO);
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
