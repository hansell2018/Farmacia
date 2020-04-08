
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_RUTA
    {
        public decimal ID_ZONA { get; set; }
        [Display(Name = "SUCURSAL")]
        public decimal ID_SUCURSAL { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<System.DateTime> FECHA_ALTA { get; set; }
        public Nullable<System.DateTime> FECHA_BAJA { get; set; }
    
        public virtual FAR_ZONA FAR_ZONA { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
    }
}
