
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_PAGO_PLANILLA
    {
        public decimal ID_PLANILLA { get; set; }
        [Display(Name = "EMPLEADO")]
        public decimal CODIGO_EMP { get; set; }
        [Display(Name = "SUCURSAL")]
        public Nullable<decimal> ID_SUCURSAL { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<decimal> DIAS_LAB { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> SUELDO_NETO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> BONIFICACION { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> IGSS { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> DESCUENTOS { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> LIQUIDO { get; set; }
        public string USR_MOD { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_MOD { get; set; }
    
        public virtual FAR_EMPLEADO FAR_EMPLEADO { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
        public virtual FAR_PLANILLA FAR_PLANILLA { get; set; }
    }
}
