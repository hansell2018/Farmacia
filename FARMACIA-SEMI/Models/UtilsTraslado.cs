using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class UtilsTraslado
    {
        public static Traslado LlenarItems(Traslado v_detalleTraslado)
        {
            for (int i = 0; i < v_detalleTraslado.far_det_traslado.Count; i++)
            {
                v_detalleTraslado.far_det_traslado[i].ITEM = i + 1;
            }
            return v_detalleTraslado;
        }

        public static int getTraslado(List<FAR_TRASLADO> vTraslados)
        {
            return (vTraslados.Count() + 1);
        }
    }
}
