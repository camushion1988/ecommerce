//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce.WebASP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_IMPUESTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_IMPUESTOS()
        {
            this.TBL_DETALLEIMPUESTO = new HashSet<TBL_DETALLEIMPUESTO>();
        }
    
        public int IMP_ID { get; set; }
        public string IMP_CODIGOSRI { get; set; }
        public string IMP_DESCRIPCION { get; set; }
        public decimal IMP_PORCENTAJE { get; set; }
        public string IMP_STATUS { get; set; }
        public System.DateTime IMP_FECHACREACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DETALLEIMPUESTO> TBL_DETALLEIMPUESTO { get; set; }
    }
}