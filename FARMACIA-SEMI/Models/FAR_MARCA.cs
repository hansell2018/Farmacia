
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_MARCA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_MARCA()
        {
            this.FAR_ARTICULO = new HashSet<FAR_ARTICULO>();
        }
        
        [Display(Name = "CODIGO MARCA")]
        public decimal ID_MARCA { get; set; }
        [Display(Name = "MARCA")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_MARCA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_ARTICULO> FAR_ARTICULO { get; set; }
    }
}