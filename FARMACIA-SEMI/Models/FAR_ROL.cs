
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_ROL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_ROL()
        {
            this.FAR_USUARIO = new HashSet<FAR_USUARIO>();
        }

        [Display(Name = "CODIGO ROL")]
        public decimal ID_ROL { get; set; }
        [Display(Name = "ROL")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_ROL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_USUARIO> FAR_USUARIO { get; set; }
    }
}
