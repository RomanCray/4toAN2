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
    public partial class FrmListar_Usuario : Form
    {
        public FrmListar_Usuario()
        {
            InitializeComponent();
        }

        private void FrmListar_Usuario_Load(object sender, EventArgs e)
        {
            List<USUARIO> listaUsuario = Logica.LogicaUSUARIO.getAllUser();
            loadUsar(listaUsuario);
            LoadRol();
            usuarioNuevo();
        }
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarVal();
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_id.Text))
            {
                guardarUser();
            }
            else
            {
                UploadUser();
            }
        }

        private void txt_confirmarContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_nombre.Focus();
            }
        }
        private void txt_contraActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                USUARIO dataUsuario = new USUARIO();

                int ide = Convert.ToInt32(lbl_id.Text);

                String verify = Logica.Validacion.EncrytarSha1.encriptar(txt_contraActual.Text);
                dataUsuario = Logica.LogicaUSUARIO.getONEUser(ide);

                if (dataUsuario != null)
                {
                    if (dataUsuario.us_password.Equals(verify))
                    {
                        txt_NuevaContra.Visible = true;
                        lbl_nuevaContra.Visible = true;
                        lbl_contrasenaActual.Visible = true;
                        txt_confirmarContra.Visible = true;
                        lbl_confirmarContra.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                    saltoLinea(txt_correo);
                }
                else
                {
                    saltoLinea(txt_contraActual);
                }
            }
        }
        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            solotexto(e);
        }
        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            solotexto(e);
        }


        private void loadUsar(List<USUARIO> listaUsuario)
        {
            try
            {                               
                if (listaUsuario != null && listaUsuario.Count > 0)
                {
                    dgv_usuarios.DataSource = listaUsuario.Select(data => new
                    {
                        Codigo = data.us_id,
                        Nombre = data.us_nombres,
                        Apellido = data.us_apellido,
                        Correo = data.us_correo,
                        Rol = data.Rol.rol_descripcion
                    }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void LimpiarVal()
        {
            if (string.IsNullOrEmpty(lbl_id.Text))
            {
                lbl_id.Text = "";
                txt_apellido.Clear();
                txt_contraActual.Clear();
                txt_NuevaContra.Clear();
                txt_confirmarContra.Clear();
                txt_correo.Clear();
                txt_nombre.Clear();
                cbx_listarRol.SelectedIndex = 0;
                chkb_mostrarContra.Checked = false;
            }
            else
            {
                lbl_id.Text = "";
                txt_apellido.Clear();
                txt_contraActual.Clear();
                txt_NuevaContra.Clear();
                txt_confirmarContra.Clear();
                txt_correo.Clear();
                txt_nombre.Clear();
                cbx_listarRol.SelectedIndex = 0;
                chkb_mostrarContra.Checked = false;
                usuarioNuevo();
            }
        }
        private void LoadRol()
        {
            try
            {
                List<Rol> listarRoles = new List<Rol>();
                listarRoles = Logica.Logica_Rol.getAllrRol();
                if (listarRoles != null && listarRoles.Count > 0)
                {
                    listarRoles.Insert(0, new Rol
                    {
                        rol_id = 0,
                        rol_descripcion = "-SELECCIONE ROL-"
                    });
                    cbx_listarRol.DataSource = listarRoles;
                    cbx_listarRol.DisplayMember = "rol_descripcion";
                    cbx_listarRol.ValueMember = "rol_id";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void UploadUser()
        {
            try
            {
                if (txt_NuevaContra.Text != null && txt_NuevaContra.Text != "")
                {
                    if (txt_confirmarContra.Text != null && txt_confirmarContra.Text != "")
                    {
                        if (validaciones() == true)
                        {
                            bool resp = false;
                            int ide = Convert.ToInt32(lbl_id.Text);
                            USUARIO usuario = new USUARIO();

                            usuario = Logica.LogicaUSUARIO.getONEUser(ide);                            
                            usuario.us_apellido = txt_apellido.Text.ToUpper();
                            usuario.us_nombres = txt_nombre.Text.ToUpper();
                            usuario.us_correo = txt_correo.Text;
                            usuario.rol_id = cbx_listarRol.SelectedIndex;
                            usuario.us_password = Logica.Validacion.EncrytarSha1.encriptar(txt_NuevaContra.Text);
                            resp = Logica.LogicaUSUARIO.updaUser(usuario);
                            if (resp == true)
                            {
                                LimpiarVal();
                                MessageBox.Show("Actualizado Correctamente", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("ERROR al Actualizar ", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        var sms = MessageBox.Show("Esta seguro que No desea cambiar su contraseña!", "Sistema de Matriculacion Vehicular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sms.ToString().Equals("YES") || sms.ToString().Equals("yes"))
                        {
                            txt_NuevaContra.Text = "contra";
                            txt_confirmarContra.Text = "contra";
                            if (validaciones() == true)
                            {
                                bool resp = false;
                                int ide = Convert.ToInt32(lbl_id.Text);
                                USUARIO usuario = new USUARIO();

                                usuario = Logica.LogicaUSUARIO.getONEUser(ide);                                
                                usuario.us_apellido = txt_apellido.Text.ToUpper();
                                usuario.us_nombres = txt_nombre.Text.ToUpper();
                                usuario.us_correo = txt_correo.Text;
                                usuario.rol_id = cbx_listarRol.SelectedIndex;
                                resp = Logica.LogicaUSUARIO.updaUser(usuario);
                                if (resp == true)
                                {
                                    LimpiarVal();
                                    MessageBox.Show("Actualizado Correctamente", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("ERROR al Actualizar ", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleciono NO ", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    var sms = MessageBox.Show("Esta seguro que No desea cambiar su contraseña!", "Sistema de Matriculacion Vehicular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sms.ToString().Equals("YES") || sms.ToString().Equals("yes") || sms.ToString().Equals("Yes"))
                    {
                        txt_NuevaContra.Text = "contra";
                        txt_confirmarContra.Text = "contra";
                        if (validaciones() == true)
                        {
                            bool resp = false;
                            int ide = Convert.ToInt32(lbl_id.Text);
                            USUARIO usuario = new USUARIO();

                            usuario = Logica.LogicaUSUARIO.getONEUser(ide);
                            usuario.us_apellido = txt_apellido.Text.ToUpper();
                            usuario.us_nombres = txt_nombre.Text.ToUpper();
                            usuario.us_correo = txt_correo.Text;
                            usuario.rol_id = cbx_listarRol.SelectedIndex;
                            resp = Logica.LogicaUSUARIO.updaUser(usuario);
                            if (resp == true)
                            {
                                LimpiarVal();
                                MessageBox.Show("Actualizado Correctamente", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("ERROR al Actualizar ", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(sms.ToString(), "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                List<USUARIO> listaUsuario = Logica.LogicaUSUARIO.getAllUser();
                loadUsar(listaUsuario);
                usuarioNuevo();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void guardarUser()
        {
            try
            {
                if (validaciones() == true)
                {
                    bool resp = false;
                    USUARIO usuario = new USUARIO();
                    usuario.us_apellido = txt_apellido.Text.ToUpper();
                    usuario.us_nombres = txt_nombre.Text.ToUpper();
                    usuario.us_correo = txt_correo.Text;
                    usuario.rol_id = cbx_listarRol.SelectedIndex;
                    usuario.us_password = Logica.Validacion.EncrytarSha1.encriptar(txt_NuevaContra.Text);
                    resp = Logica.LogicaUSUARIO.saveUser(usuario);
                    if (resp == true)
                    {
                        LimpiarVal();
                        MessageBox.Show("Guardado Correctamente", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("ERROR al Guardar ", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                List<USUARIO> listaUsuario = Logica.LogicaUSUARIO.getAllUser();
                loadUsar(listaUsuario);
                usuarioNuevo();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private bool validaciones()
        {

            bool resp = false;
            String mensaje = "";
            if (txt_correo == null || txt_correo.Text == "")
            {
                mensaje += "\nCampo CORREO esta bacio";
            }

            if (txt_NuevaContra.Text == null || txt_NuevaContra.Text == "")
            {
                mensaje += "\nCampo Nueva Contraseña esta vacio!";
            }

            if (txt_confirmarContra.Text == null || txt_confirmarContra.Text == "")
            {
                mensaje += "\nCampo Confirmar Contraseña esta vacio!";
            }

            if (txt_NuevaContra.Text.Equals(txt_confirmarContra.Text))
            { }
            else
            {
                mensaje += "\nLas Contraseñas no Coinciden";
            }

            if (txt_nombre.Text == null || txt_nombre.Text == "")
            {
                mensaje += "\nEl campo de Nombre esta vacio";
            }

            if (txt_apellido.Text == null || txt_apellido.Text == "")
            {
                mensaje += "\nEl campo Apellido esta vacio";
            }

            if (cbx_listarRol.SelectedIndex == 0 || cbx_listarRol.Text.Equals("-SELECCIONE ROL-"))
            {
                mensaje += "\nNo se ha Selecionado ningun elemento en Rol";
            }

            if (mensaje.Equals(""))
            {
                resp = true;
            }
            else
            {
                MessageBox.Show(mensaje, "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resp;
        }
        private void saltoLinea(TextBox text)
        {
            text.Focus();
        }
        private void solotexto(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(e.KeyChar > 64 && e.KeyChar < 91))
            {
                if (!(e.KeyChar > 96 && e.KeyChar < 123))
                {
                    if (e.KeyChar != 32)
                    {
                        if (e.KeyChar != 8)
                        {
                            if (e.KeyChar != 13)
                            {
                                MessageBox.Show("Solo Letras", "Sistema Vahicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
        private void solonumeros(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(e.KeyChar > 47 && e.KeyChar < 58))
            {
                if (e.KeyChar != 8)
                {
                    if (e.KeyChar != 13)
                    {
                        MessageBox.Show("Solo Numeros", "Sistema Vahicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void usuarioNuevo()
        {
            txt_contraActual.Visible = false;
            lbl_contrasenaActual.Visible = false;
            txt_contraActual.Text = "";

            txt_NuevaContra.Visible = true;
            lbl_nuevaContra.Visible = true;
            txt_NuevaContra.Text = "";

            txt_confirmarContra.Visible = true;
            lbl_confirmarContra.Visible = true;
            txt_confirmarContra.Text = "";

            chkb_mostrarContra.Text = "";
            chkb_mostrarContra.Visible = false;
            lbl_contraPregunta.Text = "";
        }
        private void dgv_usuarios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rolUser = dgv_usuarios.Rows[e.RowIndex].Cells["Rol"].Value;
            var correoUser = dgv_usuarios.Rows[e.RowIndex].Cells["Correo"].Value;
            var apellidoUser = dgv_usuarios.Rows[e.RowIndex].Cells["Apellido"].Value;
            var nombreUser = dgv_usuarios.Rows[e.RowIndex].Cells["Nombre"].Value;
            var idUser = dgv_usuarios.Rows[e.RowIndex].Cells["Codigo"].Value;

            if (!string.IsNullOrEmpty(idUser.ToString()))
            {
                lbl_id.Text = idUser.ToString();
                txt_apellido.Text = apellidoUser.ToString();
                txt_correo.Text = correoUser.ToString();
                txt_nombre.Text = nombreUser.ToString();
                cbx_listarRol.SelectedIndex = cbx_listarRol.FindString(rolUser.ToString()); // busca en cbx el nombre y lo selecciona
            }
        }
        private void chkb_mostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_mostrarContra.Checked == true)
            {
                txt_contraActual.Visible = true;
                lbl_contrasenaActual.Visible = true;

                chkb_mostrarContra.Text = "Ingresa tu contraseña Actual para verificar tu identidad\n y preciona ENTER";
            }
            else
            {
                txt_NuevaContra.Visible = false;
                lbl_nuevaContra.Visible = false;
                txt_contraActual.Visible = false;
                txt_confirmarContra.Visible = false;
                lbl_confirmarContra.Visible = false;
                lbl_contrasenaActual.Visible = false;
                txt_contraActual.Text = "";
                txt_confirmarContra.Text = "";
                txt_NuevaContra.Text = "";

                chkb_mostrarContra.Text = "";
            }

        }
        private void lbl_id_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(e.ToString()))
            {
                usuarioNuevo();
            }
            else
            {
                txt_contraActual.Visible = false;
                lbl_contrasenaActual.Visible = false;
                txt_contraActual.Text = "";

                txt_NuevaContra.Visible = false;
                lbl_nuevaContra.Visible = false;
                txt_NuevaContra.Text = "";

                txt_confirmarContra.Visible = false;
                lbl_confirmarContra.Visible = false;
                txt_confirmarContra.Text = "";

                chkb_mostrarContra.Text = "";
                chkb_mostrarContra.Visible = true;
                lbl_contraPregunta.Text = "Actualizar Contraseña";

                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            eliminarUser();
        }

        private void eliminarUser() {
            try
            {
                if (!string.IsNullOrEmpty(lbl_id.Text) || !lbl_id.Text.Equals(""))
                {
                    int ide = Convert.ToInt32(lbl_id.Text);
                    USUARIO usuario = new USUARIO();

                    usuario = Logica.LogicaUSUARIO.getONEUser(ide);

                    if (Logica.LogicaUSUARIO.EliminarUsu(usuario))
                    {
                        MessageBox.Show("Eliminado Correctamente","Sistema de Matriculacion Vehicular",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR al Eliminar", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                List<USUARIO> listaUsuario = Logica.LogicaUSUARIO.getAllUser();
                loadUsar(listaUsuario);
                usuarioNuevo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void searchUser(String op) 
        {
            if (!string.IsNullOrEmpty(op) || !op.Equals(""))
            {
                List<USUARIO> listaUsuario = new List<USUARIO>();

                String datoBuscar = txt_search.Text ;

                switch (op)
                {
                    case "Todos":
                        listaUsuario = Logica.LogicaUSUARIO.getAllUser();
                        loadUsar(listaUsuario);
                        break;

                    case "Apellido":
                        listaUsuario = Logica.LogicaUSUARIO.getUserxApellido(datoBuscar);
                        loadUsar(listaUsuario);
                        break;

                    case "Correo":
                        listaUsuario = Logica.LogicaUSUARIO.getUserxCorreo(datoBuscar);
                        loadUsar(listaUsuario);
                        break;

                    case "Nombre":
                        listaUsuario = Logica.LogicaUSUARIO.getUserxNombre(datoBuscar);
                        loadUsar(listaUsuario);
                        break;

                    case "Rol":
                        listaUsuario = Logica.LogicaUSUARIO.getUserxRol(datoBuscar);
                        loadUsar(listaUsuario);
                        break;
                    
                }
            }
            else
            {
                List<USUARIO> listaUsuario = Logica.LogicaUSUARIO.getAllUser();                
                loadUsar(listaUsuario);
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cbx_search.Text.Equals(""))
            {
                searchUser(cbx_search.Text); 
            }
        }
    }
}
