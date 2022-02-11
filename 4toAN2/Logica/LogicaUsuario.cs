using _4toAN2;
using Logica.Validacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaUSUARIO
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        // **************** Traer varios USUARIOs ************
        public static List<USUARIO> getAllUser()
        {
            try
            {
                var resultUSUARIO = dc.USUARIO.Where(user => user.us_estatus == 'A').OrderBy(data => data.us_id);

                return resultUSUARIO.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // **************** Traer un USUARIO ************
        public static USUARIO getONEUser(int ide)
        {
            try
            {
                var resultUsuario = dc.USUARIO.FirstOrDefault(user => user.us_estatus == 'A'
                                                    && user.us_id == ide);    

                    return resultUsuario;
                }
                catch (Exception)
                {

                    throw new Exception("Error al obtener el usuario");
                }
            }

        // **************** Para realizar una insercion ************
        public static bool saveUser(USUARIO dataUSUARIO)
        {
            try
            {
                bool resul = false;

                dataUSUARIO.us_estatus = 'A';
                dataUSUARIO.us_add = DateTime.Now;
                //dataUSUARIO.us_password = EncrytarSha1.encriptar(dataUSUARIO.us_password);

                dc.USUARIO.InsertOnSubmit(dataUSUARIO);
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
        public static bool updaUser(USUARIO dataUSUARIO)
        {
            try
            {
                bool resul = false;
                
                dataUSUARIO.us_update = DateTime.Now;                

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
        public static bool EliminarUsu(USUARIO dataUSUARIO)
        {
            try
            {
                bool resul = false;

                dataUSUARIO.us_estatus = 'I';
                dataUSUARIO.us_delete = DateTime.Now;

                // eliminar de manera permanente => dc.USUARIO.Reverse
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

        // **************** METODOS **********************
        public static bool RegistroErroryBloqueo(String dataUsuario, int contador)
        {
            try
            {
                var resultUsuario1 = dc.USUARIO.FirstOrDefault(user => user.us_correo.Equals(dataUsuario));
                bool resul = false;

                if (contador == 3)
                {
                    resultUsuario1.us_estatus = 'B';
                }

                resultUsuario1.us_intentos = Convert.ToInt32(contador);
                resultUsuario1.us_fechaInten = DateTime.Now;

                dc.SubmitChanges();

                resul = true;

                return resul;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static String StatusCorreo(String correo)
        {
            try
            {
                var resultUsuario1 = dc.USUARIO.FirstOrDefault(user => user.us_correo.Equals(correo));

                if (resultUsuario1 != null)
                {
                    String resultUsuario2 = resultUsuario1.us_estatus.ToString();

                    if (resultUsuario2 == "A")
                    {
                        return resultUsuario2;
                    }
                    if (resultUsuario2 == "B")
                    {
                        return resultUsuario2;
                    }
                    if (resultUsuario2 == "I")
                    {
                        return resultUsuario2;
                    }
                }
                String falso = "";
                return falso;

            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }
        // **************** Traer un login en especifico ***********                       
        public static USUARIO getUserxlog(String correo, String clave)
        {
            try
            {
                var resultUsuario = dc.USUARIO.FirstOrDefault(user => user.us_estatus == 'A'
                                                        && user.us_correo.Equals(correo)
                                                        && user.us_password.Equals(clave));              

                return resultUsuario;
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }

        public static List<USUARIO> getUserxCorreo(String correo)
        {
            try
            {
                var resultUsuario = dc.USUARIO.Where(user => user.us_estatus == 'A'
                                                    && user.us_correo.StartsWith(correo))
                                                    .OrderBy(ord=>ord.us_id);

                return resultUsuario.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }

        public static List<USUARIO> getUserxNombre(String nombre)
        {
            try
            {
                var resultUsuario = dc.USUARIO.Where(user => user.us_estatus == 'A'
                                                     && user.us_nombres.StartsWith(nombre))
                                                    .OrderBy(ord=> ord.us_id);

                return resultUsuario.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }        
            public static List<USUARIO> getUserxApellido(String apellido)
        {
            try
            {
                var resultUsuario = dc.USUARIO.Where(user => user.us_estatus == 'A'
                                                    && user.us_apellido.StartsWith(apellido))
                                                    .OrderBy(ord=>ord.rol_id);

                return resultUsuario.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }

        public static List<USUARIO> getUserxRol(String rol)
        {
            try
            {
                var resultUsuario = dc.USUARIO.Where(user => user.us_estatus == 'A'
                                                        && user.Rol.rol_descripcion.StartsWith(rol)
                                                        ).OrderBy(ord => ord.rol_id);

                return resultUsuario.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el usuario");
            }
        }     
    }
}
