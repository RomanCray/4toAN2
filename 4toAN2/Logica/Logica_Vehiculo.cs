using _4toAN2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Vehiculo
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();
        public static Vehiculos getONEVehiculo(String placa)
        {
            try
            {
                var resultUsuario = dc.Vehiculos.FirstOrDefault(vehi => vehi.veh_status == 'A'
                                                    && vehi.veh_placaactual == placa);

                return resultUsuario;
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }
    }
}
