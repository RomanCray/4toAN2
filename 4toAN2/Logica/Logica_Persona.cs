using _4toAN2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Persona
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();
        public static Personas getPersonaXIdentificacion(String identificacion)
        {
            try
            {
                var resultUsuario = dc.Personas.FirstOrDefault(per => per.veh_status == 'A'
                                                    && per.veh_identificacion == identificacion);

                return resultUsuario;
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener la Persona");
            }
        }
        public static bool savePersona(Personas persona)
        {
            try
            {
                bool resul = false;

                persona.veh_status = 'A';
                persona.veh_add = DateTime.Now;
                //dataUSUARIO.us_password = EncrytarSha1.encriptar(dataUSUARIO.us_password);

                dc.Personas.InsertOnSubmit(persona);
                //comit : SubmitChanges() =realiza un refresh del contexto de datos
                dc.SubmitChanges();
                resul = true;

                return resul;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
