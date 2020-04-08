
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_PROVEEDOR()
        {
            this.FAR_COMPRA = new HashSet<FAR_COMPRA>();
        }

        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string NIT { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        [Display(Name = "PROVEEDOR")]
        public string DESC_NIT { get; set; }
        [Display(Name = "CONTACTO")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string NOM_CONTACTO { get; set; }
        [Display(Name = "TELEFONO 1")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<decimal> TEL_CONTACTO { get; set; }
        [Display(Name = "TELEFONO 2")]
        public Nullable<decimal> TEL_PROVEEDOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_COMPRA> FAR_COMPRA { get; set; }
    }
}
