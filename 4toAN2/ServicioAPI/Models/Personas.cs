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
    
    public partial class Personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personas()
        {
            this.Discapacidades = new HashSet<Discapacidades>();
            this.Matriculas = new HashSet<Matriculas>();
        }
    
        public string veh_identificacion { get; set; }
        public string veh_tipoidentificacion { get; set; }
        public string veh_apellidos { get; set; }
        public string veh_nombres { get; set; }
        public System.DateTime veh_fechanacimiento { get; set; }
        public string veh_direccion { get; set; }
        public string veh_telefono { get; set; }
        public string veh_celular { get; set; }
        public string veh_tiposangre { get; set; }
        public string veh_correo { get; set; }
        public string veh_genero { get; set; }
        public string veh_status { get; set; }
        public System.DateTime veh_add { get; set; }
        public Nullable<System.DateTime> veh_update { get; set; }
        public Nullable<System.DateTime> veh_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discapacidades> Discapacidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matriculas> Matriculas { get; set; }
    }
}
