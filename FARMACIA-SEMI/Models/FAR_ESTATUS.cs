
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_ESTATUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_ESTATUS()
        {
            this.FAR_COMPRA = new HashSet<FAR_COMPRA>();
            this.FAR_MOV_CAJA = new HashSet<FAR_MOV_CAJA>();
            this.FAR_TRASLADO = new HashSet<FAR_TRASLADO>();
            this.FAR_USUARIO = new HashSet<FAR_USUARIO>();
            this.FAR_VENTA = new HashSet<FAR_VENTA>();
        }

        [Display(Name = "CODIGO ESTATUS")]
        public decimal ID_ESTATUS { get; set; }
        [Display(Name = "ESTATUS")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_ESTATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_COMPRA> FAR_COMPRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_MOV_CAJA> FAR_MOV_CAJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_TRASLADO> FAR_TRASLADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_USUARIO> FAR_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_VENTA> FAR_VENTA { get; set; }
    }
}
