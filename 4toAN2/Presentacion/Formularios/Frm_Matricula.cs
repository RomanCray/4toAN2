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
    public partial class Frm_Matricula : Form
    {
        public Frm_Matricula()
        {
            InitializeComponent();
        }

        private void Frm_Matricula_Load(object sender, EventArgs e)
        {
            loadProvincias();
        }

        private void txt_buscarPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Personas persona = new Personas();

                string identificacion = txt_buscarPersona.Text.TrimEnd().TrimStart();
                if (!String.IsNullOrEmpty(identificacion))
                {
                    persona = Logica.Logica_Persona.getPersonaXIdentificacion(identificacion);
                    if (persona != null)
                    {
                        lbl_alertaPersona.ForeColor = Color.Green;
                        lbl_nombre.Visible = true;
                        lbl_alertaPersona.Text = "* Persona Encontrada!";
                        lbl_nombre.Text = $"{persona.veh_apellidos} {persona.veh_nombres}";
                    }
                    else
                    {
                        lbl_alertaPersona.ForeColor = Color.Red;
                        MessageBox.Show("Vehiculo NO Encontrada\nhaga Clic en 'Agregar Vehiculo' para añadir", "Sistema de Matriculacion vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lbl_idVehiculo.Text = "";

                        Frm_Persona per = new Frm_Persona();
                        Inicio ini = new Inicio();
                        
                        per.Show();
                    }
                }
            }
        }

        private void txt_buscarVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vehiculos vehiculo = new Vehiculos();

                string placa = txt_buscarVehiculo.Text.TrimEnd().TrimStart();
                if (!String.IsNullOrEmpty(placa))
                {
                    vehiculo = Logica.Logica_Vehiculo.getONEVehiculo(placa);
                    if (vehiculo != null)
                    {
                        lbl_alertaVehiculo.ForeColor = Color.Green;
                        lbl_idVehiculo.Visible = true;
                        lbl_alertaVehiculo.Text = "Vehiculo Encontrado";
                        lbl_idVehiculo.Text = $"{vehiculo.veh_id} {vehiculo.MODELos.mod_descripcion}";
                    }
                    else
                    {
                        lbl_alertaVehiculo.ForeColor = Color.Red;
                        lbl_alertaVehiculo.Text = "Vehiculo NO Encontrada haga Clic en 'Agregar Vehiculo' para añadir";
                        lbl_idVehiculo.Text = "";
                    }
                }
            }
        }

        private void loadProvincias()
        {
            try
            {
                List<Provincias> listaProvincias = new List<Provincias>();
                listaProvincias = Logica.Logica_ProCant.getAllProvincias();
                if (listaProvincias != null && listaProvincias.Count > 0)
                {
                    listaProvincias.Insert(0, new Provincias
                    {
                        pro_id = 0,
                        pro_nombre = "-SELECCIONE PROVINCIA-"
                    });
                    cbx_provincia.DataSource = listaProvincias;
                    cbx_provincia.DisplayMember = "pro_nombre";
                    cbx_provincia.ValueMember = "pro_id";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void loadDinamicCantones(int ide)
        {
            try
            {
                List<Cantones> listaCantones = new List<Cantones>();
                listaCantones = Logica.Logica_ProCant.getAllCantones(ide);
                if (listaCantones != null && listaCantones.Count > 0)
                {
                    listaCantones.Insert(0, new Cantones
                    {
                        can_id = 0,
                        can_nombre = "-SELECCIONE CANTONES-"
                    });
                    cbx_canton.DataSource = listaCantones;
                    cbx_canton.DisplayMember = "can_nombre";
                    cbx_canton.ValueMember = "can_id";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbx_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadDinamicCantones(cbx_provincia.SelectedIndex);
        }

        private void btn_BPersona_Click(object sender, EventArgs e)
        {
            Frm_Persona per = new Frm_Persona();

            Inicio ini = new Inicio();

            per.MdiParent = ini;
            per.Show();            
        }

        public void mensajePersona(String identificacion, String nombre) {
            if (!string.IsNullOrEmpty(identificacion) && !string.IsNullOrEmpty(nombre))
            {
                txt_buscarPersona.Text = identificacion;
                lbl_nombre.Text = nombre;

                lbl_alertaPersona.ForeColor = Color.Green;
                lbl_nombre.Visible = true;
                lbl_alertaPersona.Text = "* Persona Encontrada!";                
            }
            else
            {
                MessageBox.Show("Error al Obtener la Persona");
            }
        }
    }

}
