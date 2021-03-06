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

    public partial class FAR_TRASLADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_TRASLADO()
        {
            this.FAR_DET_TRASLADO = new HashSet<FAR_DET_TRASLADO>();
        }
        

        public decimal ID_TRASLADO { get; set; }
        [Display(Name = "ORIGEN")]
        public Nullable<decimal> ID_ORIGEN { get; set; }
        [Display(Name = "DESTINO")]
        public Nullable<decimal> ID_DESTINO { get; set; }
        [Display(Name = "EMPLEADO")]
        public Nullable<decimal> CODIGO_EMP { get; set; }
        [Display(Name = "ESTATUS")]
        public Nullable<decimal> ID_ESTATUS { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_DET_TRASLADO> FAR_DET_TRASLADO { get; set; }
        public virtual FAR_EMPLEADO FAR_EMPLEADO { get; set; }
        public virtual FAR_ESTATUS FAR_ESTATUS { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL1 { get; set; }
    }
}
