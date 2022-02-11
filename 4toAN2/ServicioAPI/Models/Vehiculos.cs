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
    
    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            this.Matriculas = new HashSet<Matriculas>();
        }
    
        public int veh_id { get; set; }
        public string veh_placaanterior { get; set; }
        public string veh_placaactual { get; set; }
        public string veh_chasis { get; set; }
        public string veh_motor { get; set; }
        public System.DateTime veh_fechacompra { get; set; }
        public byte veh_pasajeros { get; set; }
        public decimal veh_tonelaje { get; set; }
        public string veh_combustible { get; set; }
        public string veh_observacion { get; set; }
        public short veh_anio { get; set; }
        public short veh_cilindraje { get; set; }
        public string veh_status { get; set; }
        public System.DateTime veh_add { get; set; }
        public Nullable<System.DateTime> veh_update { get; set; }
        public Nullable<System.DateTime> veh_delete { get; set; }
        public string veh_carroceria { get; set; }
        public Nullable<int> mod_id { get; set; }
        public Nullable<int> cla_id { get; set; }
        public Nullable<int> tip_id { get; set; }
        public Nullable<int> col_id { get; set; }
        public Nullable<int> pai_id { get; set; }
    
        public virtual ClLASes ClLASes { get; set; }
        public virtual Colores Colores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matriculas> Matriculas { get; set; }
        public virtual MODELos MODELos { get; set; }
        public virtual Paises Paises { get; set; }
        public virtual Tipos Tipos { get; set; }
    }
}
