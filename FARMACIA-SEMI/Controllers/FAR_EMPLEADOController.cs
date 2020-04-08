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
    public class FAR_EMPLEADOController : Controller
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
        // GET: FAR_EMPLEADO
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            return View(db.FAR_EMPLEADO.ToList());
        }

        // GET: FAR_EMPLEADO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EMPLEADO fAR_EMPLEADO = db.FAR_EMPLEADO.Find(id);
            if (fAR_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_EMPLEADO);
        }

        // GET: FAR_EMPLEADO/Create
        public ActionResult Create()
        {
            @ViewBag.Title = "AGREGANDO EMPLEADO";
            return View();
        }

        // POST: FAR_EMPLEADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO_EMP,NOMBRES,APELLIDOS,FECHA_NAC,DPI,DIRECCION")] FAR_EMPLEADO fAR_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.FAR_EMPLEADO.Add(fAR_EMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAR_EMPLEADO);
        }

        // GET: FAR_EMPLEADO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EMPLEADO fAR_EMPLEADO = db.FAR_EMPLEADO.Find(id);
            if (fAR_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            @ViewBag.Title = "ACTUALIZACION DATOS DE EMPLEADO";
            return View(fAR_EMPLEADO);
        }

        // POST: FAR_EMPLEADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO_EMP,NOMBRES,APELLIDOS,FECHA_NAC,DPI,DIRECCION")] FAR_EMPLEADO fAR_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_EMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAR_EMPLEADO);
        }

        // GET: FAR_EMPLEADO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_EMPLEADO fAR_EMPLEADO = db.FAR_EMPLEADO.Find(id);
            if (fAR_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_EMPLEADO);
        }

        // POST: FAR_EMPLEADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_EMPLEADO fAR_EMPLEADO = db.FAR_EMPLEADO.Find(id);
            db.FAR_EMPLEADO.Remove(fAR_EMPLEADO);
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
