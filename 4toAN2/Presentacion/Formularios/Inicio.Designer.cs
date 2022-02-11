
namespace Presentacion.Formularios
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lbl_bienvenida = new System.Windows.Forms.Label();
            this.pnl_pie = new System.Windows.Forms.Panel();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.pbx_pie = new System.Windows.Forms.PictureBox();
            this.pnl_encabezado = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matriculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tmr_hora = new System.Windows.Forms.Timer(this.components);
            this.pnl_header = new System.Windows.Forms.Panel();
            this.pbx_encabezado = new System.Windows.Forms.PictureBox();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_pie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_pie)).BeginInit();
            this.pnl_encabezado.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_encabezado)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_bienvenida
            // 
            this.lbl_bienvenida.BackColor = System.Drawing.Color.White;
            this.lbl_bienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_bienvenida.Font = new System.Drawing.Font("Segoe UI Emoji", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_bienvenida.Location = new System.Drawing.Point(0, 0);
            this.lbl_bienvenida.Name = "lbl_bienvenida";
            this.lbl_bienvenida.Size = new System.Drawing.Size(641, 602);
            this.lbl_bienvenida.TabIndex = 0;
            this.lbl_bienvenida.Text = "Bienvenido";
            this.lbl_bienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_pie
            // 
            this.pnl_pie.Controls.Add(this.lbl_hora);
            this.pnl_pie.Controls.Add(this.pbx_pie);
            this.pnl_pie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_pie.Location = new System.Drawing.Point(0, 525);
            this.pnl_pie.Name = "pnl_pie";
            this.pnl_pie.Size = new System.Drawing.Size(641, 77);
            this.pnl_pie.TabIndex = 11;
            // 
            // lbl_hora
            // 
            this.lbl_hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.BackColor = System.Drawing.Color.White;
            this.lbl_hora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_hora.Location = new System.Drawing.Point(526, 0);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(115, 29);
            this.lbl_hora.TabIndex = 18;
            this.lbl_hora.Text = "hh:mm:ss";
            // 
            // pbx_pie
            // 
            this.pbx_pie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbx_pie.Image = ((System.Drawing.Image)(resources.GetObject("pbx_pie.Image")));
            this.pbx_pie.Location = new System.Drawing.Point(3, 0);
            this.pbx_pie.Name = "pbx_pie";
            this.pbx_pie.Size = new System.Drawing.Size(641, 77);
            this.pbx_pie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_pie.TabIndex = 19;
            this.pbx_pie.TabStop = false;
            // 
            // pnl_encabezado
            // 
            this.pnl_encabezado.Controls.Add(this.menuStrip1);
            this.pnl_encabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_encabezado.Location = new System.Drawing.Point(0, 0);
            this.pnl_encabezado.Name = "pnl_encabezado";
            this.pnl_encabezado.Size = new System.Drawing.Size(641, 25);
            this.pnl_encabezado.TabIndex = 16;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.formularioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // formularioToolStripMenuItem
            // 
            this.formularioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.matriculaToolStripMenuItem,
            this.registrarToolStripMenuItem});
            this.formularioToolStripMenuItem.Name = "formularioToolStripMenuItem";
            this.formularioToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.formularioToolStripMenuItem.Text = "Formulario";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.listarToolStripMenuItem.Text = "Listar";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // matriculaToolStripMenuItem
            // 
            this.matriculaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarToolStripMenuItem1});
            this.matriculaToolStripMenuItem.Name = "matriculaToolStripMenuItem";
            this.matriculaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.matriculaToolStripMenuItem.Text = "Matricula";
            // 
            // listarToolStripMenuItem1
            // 
            this.listarToolStripMenuItem1.Name = "listarToolStripMenuItem1";
            this.listarToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.listarToolStripMenuItem1.Text = "Listar";
            this.listarToolStripMenuItem1.Click += new System.EventHandler(this.listarToolStripMenuItem1_Click);
            // 
            // tmr_hora
            // 
            this.tmr_hora.Enabled = true;
            this.tmr_hora.Tick += new System.EventHandler(this.tmr_hora_Tick);
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.pbx_encabezado);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 25);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(641, 38);
            this.pnl_header.TabIndex = 18;
            // 
            // pbx_encabezado
            // 
            this.pbx_encabezado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbx_encabezado.Image = ((System.Drawing.Image)(resources.GetObject("pbx_encabezado.Image")));
            this.pbx_encabezado.Location = new System.Drawing.Point(0, 1);
            this.pbx_encabezado.Name = "pbx_encabezado";
            this.pbx_encabezado.Size = new System.Drawing.Size(641, 37);
            this.pbx_encabezado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_encabezado.TabIndex = 17;
            this.pbx_encabezado.TabStop = false;
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personasToolStripMenuItem});
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarToolStripMenuItem.Text = "Registrar";
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.personasToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 602);
            this.Controls.Add(this.pnl_header);
            this.Controls.Add(this.pnl_encabezado);
            this.Controls.Add(this.pnl_pie);
            this.Controls.Add(this.lbl_bienvenida);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.pnl_pie.ResumeLayout(false);
            this.pnl_pie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_pie)).EndInit();
            this.pnl_encabezado.ResumeLayout(false);
            this.pnl_encabezado.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_encabezado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_bienvenida;
        private System.Windows.Forms.Panel pnl_pie;
        private System.Windows.Forms.Panel pnl_encabezado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formularioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Timer tmr_hora;
        private System.Windows.Forms.PictureBox pbx_pie;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.PictureBox pbx_encabezado;
        private System.Windows.Forms.ToolStripMenuItem matriculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
    }
}