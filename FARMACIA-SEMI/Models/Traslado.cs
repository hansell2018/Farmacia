using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class Traslado
    {
        public FAR_TRASLADO far_traslado { get; set; }
        public List<FAR_DET_TRASLADO> far_det_traslado { get; set; }
        public List<FAR_SUCURSAL> far_sucursal { get; set; }
        public List<FAR_ARTICULO> far_articulo { get; set; }
        public List<FAR_EMPLEADO> far_empleado { get; set; }
    }
}