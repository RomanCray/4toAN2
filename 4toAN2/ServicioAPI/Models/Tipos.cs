//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipos()
        {
            this.Vehiculos = new HashSet<Vehiculos>();
        }
    
        public int tip_id { get; set; }
        public string tip_descripcion { get; set; }
        public string tip_status { get; set; }
        public System.DateTime tip_add { get; set; }
        public Nullable<System.DateTime> tip_update { get; set; }
        public Nullable<System.DateTime> tip_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}