
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_PUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_PUESTO()
        {
            this.FAR_EMP_SUC = new HashSet<FAR_EMP_SUC>();
        }

        [Display(Name = "CODIGO PUESTO")]
        public decimal ID_PUESTO { get; set; }
        [Display(Name = "PUESTO")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_PUESTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> SUELDO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_EMP_SUC> FAR_EMP_SUC { get; set; }
    }
}
