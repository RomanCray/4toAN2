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
    
    public partial class Matriculas
    {
        public long mat_id { get; set; }
        public Nullable<System.DateTime> mat_fechaemision { get; set; }
        public Nullable<System.DateTime> mat_fechacaducidad { get; set; }
        public string mat_numeroespecie { get; set; }
        public Nullable<decimal> valor_maticula { get; set; }
        public Nullable<int> veh_id { get; set; }
        public Nullable<int> can_id { get; set; }
        public string veh_identificacion { get; set; }
    
        public virtual Cantones Cantones { get; set; }
        public virtual Personas Personas { get; set; }
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
