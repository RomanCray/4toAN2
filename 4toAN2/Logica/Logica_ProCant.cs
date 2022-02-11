using _4toAN2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_ProCant
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();
        public static List<Provincias> getAllProvincias()
        {
            try
            {
                var result = dc.Provincias.Where(prov => prov.pro_status == 'A').OrderBy(data => data.pro_id);

                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Cantones> getAllCantones(int ide)
        {
            try
            {
                var result = dc.Cantones.Where(cant => cant.can_status == 'A'
                                               && cant.pro_id == ide).OrderBy(data => data.can_id);

                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
