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

    public partial class FAR_TTRANSACCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_TTRANSACCION()
        {
            this.FAR_MOV_CAJA = new HashSet<FAR_MOV_CAJA>();
        }


        [Display(Name = "CODIGO TRANSACCION")]
        public decimal ID_TRANSACCION { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        [Display(Name = "TRANSACCION")]
        public string DESC_TANSACCION { get; set; }
        public Nullable<decimal> FACTOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_MOV_CAJA> FAR_MOV_CAJA { get; set; }
    }
}
