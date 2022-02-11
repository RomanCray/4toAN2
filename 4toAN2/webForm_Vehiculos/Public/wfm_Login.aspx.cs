using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace webForm_Vehiculos.Public
{
    public partial class wfm_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            ingresar(sender, e);
        }
        private void ingresar(object sender, EventArgs e)
        {

            var username = txt_correo.Text.TrimStart().TrimEnd(); // los trim me ayudan cuando el usuario escribe espacio al inicio o al final            
            String password = txt_pass.Text;

            if ((!string.IsNullOrEmpty(username)) || (username != ""))
            {
                var valUsuario = LogicaUSUARIO.StatusCorreo(username);

                if (valUsuario == "A")
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        try
                        {


                            var password1 = Logica.Validacion.EncrytarSha1.encriptar(password);
                            var dataUsuario = LogicaUSUARIO.getUserxlog(username, password1);
                            if (dataUsuario != null)
                            {
                                var alerta = dataUsuario.us_nombres + ' ' + dataUsuario.us_apellido + '-' + dataUsuario.Rol.rol_descripcion;
                                Response.Write("<script>alert(Bien benid@ al sistema" + alerta + ");</script>");

                                Response.Redirect("/Default.aspx");
                            }
                        }

                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('ERROR al comunicarse con el servidor:'" + ex + ");</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('La Clave es Campo  obligatorio');</script>");

                    }
                }
                else if (valUsuario == "B")
                {
                    Response.Write("<script>alert('El Usuario se encutra Bloqueado');</script>");
                }
                else if (valUsuario == "I")
                {
                    Response.Write("<script>alert('El Usuario se encutra Inactivo');</script>");
                }
                else
                {
                    Response.Write("<script>alert('No existe en el Registro');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('El Correo es Campo  obligatorio');</script>");
            }

        }
    }
}