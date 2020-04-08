
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_EMP_SUC
    {
        public decimal ID_MOV { get; set; }
        [Display(Name = "EMPLEADO")]
        public decimal CODIGO_EMP { get; set; }
        [Display(Name = "SUCURSAL")]
        public decimal ID_SUCURSAL { get; set; }
        [Display(Name = "PUESTO")]
        public Nullable<decimal> ID_PUESTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_ALTA { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_BAJA { get; set; }
    
        public virtual FAR_EMPLEADO FAR_EMPLEADO { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
        public virtual FAR_PUESTO FAR_PUESTO { get; set; }
    }
}
