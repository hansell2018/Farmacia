using FARMACIA_SEMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARMACIA_SEMI.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}