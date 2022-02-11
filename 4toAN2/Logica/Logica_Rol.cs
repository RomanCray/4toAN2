using _4toAN2;
using Logica.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Rol
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        // **************** Traer varios Rols ************
        public static List<Rol> getAllrRol()
        {
            try
            {
                var resultRol = dc.Rol.Where(rol => rol.rol_estatus == 'A').OrderBy(data => data.rol_id);

                return resultRol.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // **************** Para realizar una insercion ************
        public static bool saveRol(Rol dataRol)
        {
            try
            {
                bool resul = false;

                dataRol.rol_estatus = 'A';
                dataRol.rol_add = DateTime.Now;                

                dc.Rol.InsertOnSubmit(dataRol);
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

        // **************** Para realizar una actualizacion ************
        public static bool updaUser(Rol dataRol)
        {
            try
            {
                bool resul = false;

                dataRol.rol_update = DateTime.Now;                

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


        // **************** Para realizar una eliminado logico ************
        public static bool EliminarUsu(Rol dataRol)
        {
            try
            {
                bool resul = false;

                dataRol.rol_estatus = 'I';
                dataRol.rol_delete = DateTime.Now;

                // eliminar de manera permanente => dc.Rol.Reverse
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
