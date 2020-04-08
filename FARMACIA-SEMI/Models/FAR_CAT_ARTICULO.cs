
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_CAT_ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_CAT_ARTICULO()
        {
            this.FAR_ARTICULO = new HashSet<FAR_ARTICULO>();
        }
        
        [Display(Name = "CODIGO CATEGORIA")]
        public decimal ID_CAT { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        [Display(Name = "CATEGORIA")]
        public string DESC_CAT { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_ALTA { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_BAJA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_ARTICULO> FAR_ARTICULO { get; set; }
    }
}
