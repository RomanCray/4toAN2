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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frm_Login login = new frm_Login();
            login.Show();
            this.Hide();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListar_Usuario listaUsuarios = new FrmListar_Usuario();

            listaUsuarios.MdiParent = this;
            listaUsuarios.Show();
            //pnl_encabezado.Hide();
            pnl_header.Hide();
            pnl_pie.Hide();
            lbl_bienvenida.Hide();
        }

        private void tmr_hora_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("hh:mm:ss");
        }  

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Matricula listaMatricula = new Frm_Matricula();

            listaMatricula.MdiParent = this;
            listaMatricula.Show();
            //pnl_encabezado.Hide();
            pnl_header.Hide();
            pnl_pie.Hide();
            lbl_bienvenida.Hide();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Persona persona = new Frm_Persona();

            persona.MdiParent = this;
            persona.Show();
            //pnl_encabezado.Hide();
            pnl_header.Hide();
            pnl_pie.Hide();
            lbl_bienvenida.Hide();
        }
    }
}
