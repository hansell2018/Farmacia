using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class validaciones
    {
        public static Boolean ExisteEnPlanilla( decimal pEmp, decimal planilla)
        {
            Boolean resp = true;
            FARMACIAEntities db = new FARMACIAEntities();

            int coincidencias = db.FAR_PAGO_PLANILLA.Where(s => s.CODIGO_EMP == pEmp && s.ID_PLANILLA == planilla).Count();

            if (coincidencias==1)
            {
                resp = false;
            }

            return resp;
        }


        public static Boolean ExisteCliente(string pNit)
        {
            Boolean resp = true;
            FARMACIAEntities db = new FARMACIAEntities();

            int coincidencias = db.FAR_CLIENTE.Where(s => s.NIT == pNit).Count();

            if (coincidencias == 1)
            {
                resp = false;
            }

            return resp;
        }



        public static Boolean ExisteProveedor(string pNit)
        {
            Boolean resp = true;
            FARMACIAEntities db = new FARMACIAEntities();

            int coincidencias = db.FAR_PROVEEDOR.Where(s => s.NIT == pNit).Count();

            if (coincidencias == 1)
            {
                resp = false;
            }
            return resp;
        }

        public static Boolean ExisteUsuario(string pUsuario)
        {
            Boolean resp = true;
            FARMACIAEntities db = new FARMACIAEntities();

            int coincidencias = db.FAR_USUARIO.Where(s => s.ID_USUARIO == pUsuario).Count();

            if (coincidencias == 1)
            {
                resp = false;
            }
            return resp;
        }

    }
}