using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class UtilsCompra
    {
        public static Compra LlenarItems(Compra v_detalleCompra)
        {
            for (int i = 0; i < v_detalleCompra.far_det_compra.Count; i++)
            {
                v_detalleCompra.far_det_compra[i].ITEM = i + 1;
            }
            return v_detalleCompra;
        }

        public static String getFactura(List<FAR_COMPRA> vCompras)
        {
            return (vCompras.Count() + 1).ToString();
        }

        public static decimal getTotalFac(List<FAR_DETALLE_COMPRA> v_detalleCompra)
        {
            decimal vTotal = 0;

            for (int i = 0; i < v_detalleCompra.Count; i++)
            {
                vTotal = vTotal + v_detalleCompra[i].SUBTOTAL;
            }
            return vTotal;
        }
    }
}