namespace IntegradoraPOO
{
    partial class FormularioPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelBarraLateral = new System.Windows.Forms.Panel();
            this.botonSalir = new System.Windows.Forms.Button();
            this.contenedorMenu = new System.Windows.Forms.Panel();
            this.botonSubMenuDos = new System.Windows.Forms.Button();
            this.botonSubMenuUno = new System.Windows.Forms.Button();
            this.botonMenuPrincipal = new System.Windows.Forms.Button();
            this.botonConfiguracion = new System.Windows.Forms.Button();
            this.botonInformacion = new System.Windows.Forms.Button();
            this.botonTablero = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.botonMenu = new System.Windows.Forms.Button();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.transicionBarra = new System.Windows.Forms.Timer(this.components);
            this.transicionMenu = new System.Windows.Forms.Timer(this.components);
            this.panelBarraLateral.SuspendLayout();
            this.contenedorMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarraLateral
            // 
            this.panelBarraLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.panelBarraLateral.Controls.Add(this.botonSalir);
            this.panelBarraLateral.Controls.Add(this.contenedorMenu);
            this.panelBarraLateral.Controls.Add(this.botonConfiguracion);
            this.panelBarraLateral.Controls.Add(this.botonInformacion);
            this.panelBarraLateral.Controls.Add(this.botonTablero);
            this.panelBarraLateral.Controls.Add(this.panelLogo);
            this.panelBarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBarraLateral.Location = new System.Drawing.Point(0, 0);
            this.panelBarraLateral.Margin = new System.Windows.Forms.Padding(0);
            this.panelBarraLateral.Name = "panelBarraLateral";
            this.panelBarraLateral.Size = new System.Drawing.Size(158, 488);
            this.panelBarraLateral.TabIndex = 0;
            // 
            // botonSalir
            // 
            this.botonSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.botonSalir.FlatAppearance.BorderSize = 0;
            this.botonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSalir.ForeColor = System.Drawing.Color.White;
            this.botonSalir.Location = new System.Drawing.Point(0, 447);
            this.botonSalir.Margin = new System.Windows.Forms.Padding(2);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.botonSalir.Size = new System.Drawing.Size(158, 41);
            this.botonSalir.TabIndex = 5;
            this.botonSalir.Text = "Salir";
            this.botonSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.BotonSalir_Click);
            // 
            // contenedorMenu
            // 
            this.contenedorMenu.Controls.Add(this.botonSubMenuDos);
            this.contenedorMenu.Controls.Add(this.botonSubMenuUno);
            this.contenedorMenu.Controls.Add(this.botonMenuPrincipal);
            this.contenedorMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.contenedorMenu.Location = new System.Drawing.Point(0, 164);
            this.contenedorMenu.Margin = new System.Windows.Forms.Padding(2);
            this.contenedorMenu.Name = "contenedorMenu";
            this.contenedorMenu.Size = new System.Drawing.Size(158, 122);
            this.contenedorMenu.TabIndex = 4;
            // 
            // botonSubMenuDos
            // 
            this.botonSubMenuDos.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonSubMenuDos.FlatAppearance.BorderSize = 0;
            this.botonSubMenuDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSubMenuDos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSubMenuDos.ForeColor = System.Drawing.Color.White;
            this.botonSubMenuDos.Location = new System.Drawing.Point(0, 82);
            this.botonSubMenuDos.Margin = new System.Windows.Forms.Padding(2);
            this.botonSubMenuDos.Name = "botonSubMenuDos";
            this.botonSubMenuDos.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.botonSubMenuDos.Size = new System.Drawing.Size(158, 41);
            this.botonSubMenuDos.TabIndex = 2;
            this.botonSubMenuDos.Text = "Submenú 2";
            this.botonSubMenuDos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonSubMenuDos.UseVisualStyleBackColor = true;
            this.botonSubMenuDos.Click += new System.EventHandler(this.BotonSubMenuDos_Click);
            // 
            // botonSubMenuUno
            // 
            this.botonSubMenuUno.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonSubMenuUno.FlatAppearance.BorderSize = 0;
            this.botonSubMenuUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSubMenuUno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSubMenuUno.ForeColor = System.Drawing.Color.White;
            this.botonSubMenuUno.Location = new System.Drawing.Point(0, 41);
            this.botonSubMenuUno.Margin = new System.Windows.Forms.Padding(2);
            this.botonSubMenuUno.Name = "botonSubMenuUno";
            this.botonSubMenuUno.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.botonSubMenuUno.Size = new System.Drawing.Size(158, 41);
            this.botonSubMenuUno.TabIndex = 1;
            this.botonSubMenuUno.Text = "Submenú 1";
            this.botonSubMenuUno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonSubMenuUno.UseVisualStyleBackColor = true;
            this.botonSubMenuUno.Click += new System.EventHandler(this.BotonSubMenuUno_Click);
            // 
            // botonMenuPrincipal
            // 
            this.botonMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonMenuPrincipal.FlatAppearance.BorderSize = 0;
            this.botonMenuPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonMenuPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonMenuPrincipal.ForeColor = System.Drawing.Color.White;
            this.botonMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.botonMenuPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.botonMenuPrincipal.Name = "botonMenuPrincipal";
            this.botonMenuPrincipal.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.botonMenuPrincipal.Size = new System.Drawing.Size(158, 41);
            this.botonMenuPrincipal.TabIndex = 0;
            this.botonMenuPrincipal.Text = "Menú principal";
            this.botonMenuPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonMenuPrincipal.UseVisualStyleBackColor = true;
            this.botonMenuPrincipal.Click += new System.EventHandler(this.BotonMenuPrincipal_Click);
            // 
            // botonConfiguracion
            // 
            this.botonConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonConfiguracion.FlatAppearance.BorderSize = 0;
            this.botonConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonConfiguracion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConfiguracion.ForeColor = System.Drawing.Color.White;
            this.botonConfiguracion.Location = new System.Drawing.Point(0, 123);
            this.botonConfiguracion.Margin = new System.Windows.Forms.Padding(2);
            this.botonConfiguracion.Name = "botonConfiguracion";
            this.botonConfiguracion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.botonConfiguracion.Size = new System.Drawing.Size(158, 41);
            this.botonConfiguracion.TabIndex = 3;
            this.botonConfiguracion.Text = "Configuración";
            this.botonConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonConfiguracion.UseVisualStyleBackColor = true;
            this.botonConfiguracion.Click += new System.EventHandler(this.BotonConfiguracion_Click);
            // 
            // botonInformacion
            // 
            this.botonInformacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonInformacion.FlatAppearance.BorderSize = 0;
            this.botonInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonInformacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonInformacion.ForeColor = System.Drawing.Color.White;
            this.botonInformacion.Location = new System.Drawing.Point(0, 82);
            this.botonInformacion.Margin = new System.Windows.Forms.Padding(2);
            this.botonInformacion.Name = "botonInformacion";
            this.botonInformacion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.botonInformacion.Size = new System.Drawing.Size(158, 41);
            this.botonInformacion.TabIndex = 2;
            this.botonInformacion.Text = "Crear Publicacion";
            this.botonInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonInformacion.UseVisualStyleBackColor = true;
            this.botonInformacion.Click += new System.EventHandler(this.BotonInformacion_Click);
            // 
            // botonTablero
            // 
            this.botonTablero.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonTablero.FlatAppearance.BorderSize = 0;
            this.botonTablero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonTablero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonTablero.ForeColor = System.Drawing.Color.White;
            this.botonTablero.Location = new System.Drawing.Point(0, 41);
            this.botonTablero.Margin = new System.Windows.Forms.Padding(2);
            this.botonTablero.Name = "botonTablero";
            this.botonTablero.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.botonTablero.Size = new System.Drawing.Size(158, 41);
            this.botonTablero.TabIndex = 1;
            this.botonTablero.Text = "Tablero";
            this.botonTablero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonTablero.UseVisualStyleBackColor = true;
            this.botonTablero.Click += new System.EventHandler(this.BotonTablero_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.botonMenu);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(158, 41);
            this.panelLogo.TabIndex = 0;
            // 
            // botonMenu
            // 
            this.botonMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.botonMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.botonMenu.FlatAppearance.BorderSize = 0;
            this.botonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonMenu.Location = new System.Drawing.Point(0, 0);
            this.botonMenu.Margin = new System.Windows.Forms.Padding(2);
            this.botonMenu.Name = "botonMenu";
            this.botonMenu.Size = new System.Drawing.Size(38, 41);
            this.botonMenu.TabIndex = 0;
            this.botonMenu.UseVisualStyleBackColor = false;
            this.botonMenu.Click += new System.EventHandler(this.BotonMenu_Click);
            this.botonMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.BotonMenu_Paint);
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.panelEncabezado.Controls.Add(this.botonCerrar);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(158, 0);
            this.panelEncabezado.Margin = new System.Windows.Forms.Padding(2);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(592, 41);
            this.panelEncabezado.TabIndex = 1;
            this.panelEncabezado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelEncabezado_MouseDown);
            // 
            // botonCerrar
            // 
            this.botonCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.botonCerrar.FlatAppearance.BorderSize = 0;
            this.botonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCerrar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCerrar.ForeColor = System.Drawing.Color.White;
            this.botonCerrar.Location = new System.Drawing.Point(554, 0);
            this.botonCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(38, 41);
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.Text = "X";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(158, 41);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(592, 447);
            this.panelPrincipal.TabIndex = 2;
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPrincipal_Paint);
            // 
            // transicionBarra
            // 
            this.transicionBarra.Interval = 10;
            this.transicionBarra.Tick += new System.EventHandler(this.TransicionBarra_Tick);
            // 
            // transicionMenu
            // 
            this.transicionMenu.Interval = 10;
            this.transicionMenu.Tick += new System.EventHandler(this.TransicionMenu_Tick);
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 488);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.panelBarraLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicación con Barra Lateral";
            this.panelBarraLateral.ResumeLayout(false);
            this.contenedorMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarraLateral;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button botonMenu;
        private System.Windows.Forms.Button botonTablero;
        private System.Windows.Forms.Button botonInformacion;
        private System.Windows.Forms.Button botonConfiguracion;
        private System.Windows.Forms.Panel contenedorMenu;
        private System.Windows.Forms.Button botonSubMenuDos;
        private System.Windows.Forms.Button botonSubMenuUno;
        private System.Windows.Forms.Button botonMenuPrincipal;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Button botonCerrar;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Timer transicionBarra;
        private System.Windows.Forms.Timer transicionMenu;
    }
}

