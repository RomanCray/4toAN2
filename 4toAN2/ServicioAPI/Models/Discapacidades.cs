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
    
    public partial class Discapacidades
    {
        public int dis_id { get; set; }
        public byte dis_porcentaje { get; set; }
        public System.DateTime dis_fechacarnet { get; set; }
        public string dis_observaciones { get; set; }
        public string dis_status { get; set; }
        public System.DateTime dis_add { get; set; }
        public Nullable<System.DateTime> dis_update { get; set; }
        public Nullable<System.DateTime> dis_delete { get; set; }
        public string veh_identificacion { get; set; }
        public Nullable<byte> tdi_id { get; set; }
    
        public virtual Personas Personas { get; set; }
        public virtual Tipo_Discapacidades Tipo_Discapacidades { get; set; }
    }
}
