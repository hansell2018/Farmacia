
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_ZONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_ZONA()
        {
            this.FAR_RUTA = new HashSet<FAR_RUTA>();
        }

        [Display(Name = "CODIGO ZONA")]
        public decimal ID_ZONA { get; set; }
        [Display(Name = "ZONA")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_ZONA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_RUTA> FAR_RUTA { get; set; }
    }
}
