using _4toAN2;
using Logica;
using Presentacion.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frm_Login : Form
    {

        USUARIO dataUsuario = new USUARIO();
        String valUsuario = "";
        String username = "";
        String comprovarUsuatio = "";
        int contador = 1;

        public frm_Login()
        {
            InitializeComponent();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ingresar(sender,e);
        }

        //--------------FUNCIONES------------ 
        private void ingresar(object sender, EventArgs e)
        {

            username = txt_correo.Text.TrimStart().TrimEnd(); // los trim me ayudan cuando el usuario escribe espacio al inicio o al final            
            String password = txt_pass.Text;

            if ((!string.IsNullOrEmpty(username)) || ( username!="" ))
            {
                valUsuario = LogicaUSUARIO.StatusCorreo(username);                               

                if (valUsuario == "A")
                {                    
                    if (!string.IsNullOrEmpty(password))
                    {
                        try
                        {
                            if (comprovarUsuatio.Equals(username))
                            {
                                contador++;
                                if (contador > 3)
                                {
                                    contador = 1;
                                }
                            }
                            else
                            {
                                contador = 0;
                            }

                            var password1 = Logica.Validacion.EncrytarSha1.encriptar(password);
                            dataUsuario = LogicaUSUARIO.getUserxlog(username, password1);
                            if (dataUsuario != null)
                            {
                                MessageBox.Show("Bien benid@ al sistema " + dataUsuario.us_nombres + " "
                                    + dataUsuario.us_apellido + " - "
                                    + dataUsuario.Rol.rol_descripcion);

                                Inicio frminicio = new Inicio();
                                frminicio.Show();
                                this.Hide();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Correo O Clave INCORRECTA");
                                Conta(contador, username);
                                limpiar();
                            }                            
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR al comunicarse con el servidor: " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Clave es Campo  obligatorio");

                    }
                }
                else if (valUsuario == "B")
                {
                    MessageBox.Show("El Usuario se encutra Bloqueado");
                    limpiar();
                    return;
                }
                else if (valUsuario == "I")
                {
                    MessageBox.Show("El Usuario se encutra Inactivo");
                    limpiar();
                    return;
                }
                else
                {
                    MessageBox.Show("No existe en el Registro");
                    limpiar();
                    return;
                }
            }
            else
            {
                MessageBox.Show("El Correo es Campo  obligatorio");
            }

            comprovarUsuatio = username;
        }              
        private void limpiar()
        {
            txt_correo.Text = "";
            txt_pass.Text = "";
        }
        private void Conta(int contador, String correoUsu)
        {
            MessageBox.Show("clave Incorrecta tiene " + (3 - contador) + " Intentos");
            LogicaUSUARIO.RegistroErroryBloqueo(correoUsu, contador);

            if (contador == 3)
                MessageBox.Show("Usuario Bloqueado");
        }
    }
}
