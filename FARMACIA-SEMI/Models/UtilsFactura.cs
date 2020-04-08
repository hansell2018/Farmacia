using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public static class UtilsFactura
    {
        public static Factura LlenarItems( Factura v_detalleVenta)
        {
            for (int i = 0; i < v_detalleVenta.far_det_venta.Count; i++)
            {
                v_detalleVenta.far_det_venta[i].ITEM = i + 1;
            }
            return v_detalleVenta;
        }

        public static String getFactura(List<FAR_VENTA> vVentas)
        {
            return (vVentas.Count() + 1).ToString();
        }

        public static decimal getTotalFac(List<FAR_DETALLE_VENTA> v_detalleVenta)
        {
            decimal vTotal= 0;

            for (int i = 0; i < v_detalleVenta.Count; i++)
            {
                vTotal = vTotal + v_detalleVenta[i].SUBTOTAL;
            }
            return vTotal;
        }
    }
}