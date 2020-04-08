//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_USUARIO
    {
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        [Display(Name = "USUARIO")]
        public string ID_USUARIO { get; set; }
        [Display(Name = "SUCURSAL")]
        public Nullable<decimal> ID_SUCURSAL { get; set; }
        [Display(Name = "ROL")]
        public Nullable<decimal> ID_ROL { get; set; }
        [Display(Name = "ESTATUS")]
        public Nullable<decimal> ID_ESTATUS { get; set; }
        [Display(Name = "EMPLEADO")]
        public Nullable<decimal> CODIGO_EMP { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string CONTRASENIA { get; set; }
    
        public virtual FAR_EMPLEADO FAR_EMPLEADO { get; set; }
        public virtual FAR_ESTATUS FAR_ESTATUS { get; set; }
        public virtual FAR_ROL FAR_ROL { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
    }
}
