using _4toAN2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class Frm_Persona : Form
    {
        public Frm_Persona()
        {
            InitializeComponent();
        }

        //-------------------- KeyPress ------------------

        private void txt_identificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(e,sender);
        }
        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLetras(sender,e);
        }
        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLetras(sender, e);
        }
        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(e, sender);
        }

        //----------------- KeyDown --------------------------

        private void cbx_tipoDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_identificacion.Focus();
            }
        }

        private void txt_identificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_apellido.Focus();
            }
        }

        private void txt_apellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Nombre.Focus();
            }
        }

        private void txt_Nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_correo.Focus();
            }
        }

        private void txt_correo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String correo = txt_correo.Text;
                bool validar = (correo.Contains('@') && correo.Contains(".com"));

                if (validar != true)
                {
                    MessageBox.Show("Email/Correo invalio debe contener '@' y terminar en '.com'", "Sistema Vahicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_telefono.Focus();
                }
                else
                {
                    txt_correo.Text = "";
                }
            }
        }

        private void txt_telefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_tipoSangre.Focus();
            }
        }

        private void cbx_tipoSangre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbx_genero.Focus();
            }
        }

        private void cbx_genero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_direccion.Focus();
            }
        }

        private void txt_direccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_guardar.Focus();
            }
        }
        //----------------- Fin KeyDown



        //-------------------- Mis Funciones
        public void validarLetras(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;

            }
        }

        private void solonumeros(System.Windows.Forms.KeyPressEventArgs e, object sender)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Frm_Matricula matricula = new Frm_Matricula();
            matricula.Show();

            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validacion()==true)
            {
                Personas personas = new Personas();

                personas.veh_tipoidentificacion = cbx_tipoDNI.Text == "CEDULA" ? 'C':'R';
                personas.veh_identificacion = txt_identificacion.Text;
                personas.veh_apellidos = txt_apellido.Text;
                personas.veh_nombres = txt_Nombre.Text;
                personas.veh_correo = txt_correo.Text;
                personas.veh_celular = txt_telefono.Text;
                personas.veh_tiposangre = cbx_tipoSangre.Text;
                personas.veh_genero = cbx_genero.Text == "MASCULINO" ? 'M' :
                                      cbx_genero.Text == "FEMENINO" ? 'F': 'O';
                personas.veh_direccion = txt_direccion.Text;
                personas.veh_fechanacimiento = mc_fecha.SelectionStart;

                var resp = Logica.Logica_Persona.savePersona(personas);

                Frm_Matricula matricula = new Frm_Matricula();
                var indetificacion = txt_identificacion.Text;
                var nombre = $"{txt_apellido.Text} {txt_Nombre.Text}";
                matricula.mensajePersona(indetificacion, nombre);

                Inicio ini = new Inicio();

                matricula.MdiParent = ini;
                matricula.Show();                
            }           
        }

        private bool validacion() {

            String sms = "";

            bool resp = false;

            if (cbx_tipoDNI.SelectedIndex == 0 )
            {
                sms += "\nDebe selecionar un Tipo DNI";
            }

            if (string.IsNullOrEmpty(txt_identificacion.Text))
            {
                sms += "\nCampo Identificacion Obligatorio";
            }

            if (string.IsNullOrEmpty(txt_apellido.Text))
            {
                sms += "\nCampo Apellido Obligatorio";
            }

            if (string.IsNullOrEmpty(txt_Nombre.Text))
            {
                sms += "\nCampo Nombre Obligatorio";
            }

            if (string.IsNullOrEmpty(txt_correo.Text))
            {
                if (txt_correo.TextLength > 4)
                {
                    sms += "\nCampo Correo Electronico Obligatorio"; 
                }
            }

            if (string.IsNullOrEmpty(txt_telefono.Text))
            {
                sms += "\nCampo Telefono Obligatorio";
            }

            if (cbx_tipoSangre.SelectedIndex == 0)
            {
                sms += "\nDebe selecionar un Tipo de SAngre";
            }

            if (cbx_genero.SelectedIndex == 0)
            {
                sms += "\nDebe selecionar un Genero";
            }

            if (string.IsNullOrEmpty(txt_direccion.Text))
            {
                sms += "\nCampo Direccion es Obligatorio";
            }

            DateTime ac = DateTime.Today;

            var fecha = ac.Year - mc_fecha.SelectionStart.Year;

            if (fecha < 18)
            {
                sms += "\n Es menor de Edad ";
            }

            if (String.IsNullOrEmpty(sms))
            {
                resp = true;
            }
            else
            {
                MessageBox.Show(sms,"Sistema de Matriculacion Vehicular",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return resp;
        }
    }
}
