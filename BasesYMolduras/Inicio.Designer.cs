﻿namespace BasesYMolduras
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnCotRe = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnProducciones = new System.Windows.Forms.Button();
            this.btnCotizaciones = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.Label();
            this.txtTipoUser = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.spinnerLogin = new MetroFramework.Controls.MetroProgressSpinner();
            this.imageLogo = new System.Windows.Forms.PictureBox();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.White;
            this.metroPanel2.Controls.Add(this.panelPrincipal);
            this.metroPanel2.Controls.Add(this.metroPanel1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 5);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1362, 763);
            this.metroPanel2.TabIndex = 7;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroPanel1.Controls.Add(this.btnCerrarSesion);
            this.metroPanel1.Controls.Add(this.btnProductos);
            this.metroPanel1.Controls.Add(this.btnCotRe);
            this.metroPanel1.Controls.Add(this.btnControl);
            this.metroPanel1.Controls.Add(this.btnProducciones);
            this.metroPanel1.Controls.Add(this.btnCotizaciones);
            this.metroPanel1.Controls.Add(this.btnUsuarios);
            this.metroPanel1.Controls.Add(this.btnClientes);
            this.metroPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroPanel1.ForeColor = System.Drawing.Color.White;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 119);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1359, 641);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.UseStyleColors = true;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            this.metroPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MetroPanel1_Paint);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Red;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(969, 538);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(359, 65);
            this.btnCerrarSesion.TabIndex = 12;
            this.btnCerrarSesion.Text = "SALIR";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarSesion.UseCompatibleTextRendering = true;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(119)))), ((int)(((byte)(14)))));
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(496, 48);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(420, 162);
            this.btnProductos.TabIndex = 8;
            this.btnProductos.Text = "PRODUCTOS";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseCompatibleTextRendering = true;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            this.btnProductos.MouseEnter += new System.EventHandler(this.BtnProductos_MouseEnter);
            this.btnProductos.MouseLeave += new System.EventHandler(this.BtnProductos_MouseLeave);
            // 
            // btnCotRe
            // 
            this.btnCotRe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(48)))), ((int)(((byte)(44)))));
            this.btnCotRe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCotRe.FlatAppearance.BorderSize = 0;
            this.btnCotRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotRe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCotRe.ForeColor = System.Drawing.Color.White;
            this.btnCotRe.Image = ((System.Drawing.Image)(resources.GetObject("btnCotRe.Image")));
            this.btnCotRe.Location = new System.Drawing.Point(969, 48);
            this.btnCotRe.Margin = new System.Windows.Forms.Padding(0);
            this.btnCotRe.Name = "btnCotRe";
            this.btnCotRe.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.btnCotRe.Size = new System.Drawing.Size(359, 490);
            this.btnCotRe.TabIndex = 7;
            this.btnCotRe.Text = "PEDIDOS FINALIZADOS";
            this.btnCotRe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCotRe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCotRe.UseCompatibleTextRendering = true;
            this.btnCotRe.UseVisualStyleBackColor = false;
            this.btnCotRe.Click += new System.EventHandler(this.BtnCotRe_Click);
            this.btnCotRe.MouseEnter += new System.EventHandler(this.BtnCotRe_MouseEnter);
            this.btnCotRe.MouseLeave += new System.EventHandler(this.BtnCotRe_MouseLeave);
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(122)))), ((int)(((byte)(101)))));
            this.btnControl.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.ForeColor = System.Drawing.Color.White;
            this.btnControl.Image = ((System.Drawing.Image)(resources.GetObject("btnControl.Image")));
            this.btnControl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControl.Location = new System.Drawing.Point(496, 441);
            this.btnControl.Margin = new System.Windows.Forms.Padding(0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(420, 162);
            this.btnControl.TabIndex = 6;
            this.btnControl.Text = "CONTROL Y ESTATUS DE PRODUCCIÓN";
            this.btnControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControl.UseCompatibleTextRendering = true;
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.BtnControl_Click);
            this.btnControl.MouseEnter += new System.EventHandler(this.BtnControl_MouseEnter);
            this.btnControl.MouseLeave += new System.EventHandler(this.BtnControl_MouseLeave);
            // 
            // btnProducciones
            // 
            this.btnProducciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.btnProducciones.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProducciones.FlatAppearance.BorderSize = 0;
            this.btnProducciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducciones.ForeColor = System.Drawing.Color.White;
            this.btnProducciones.Image = ((System.Drawing.Image)(resources.GetObject("btnProducciones.Image")));
            this.btnProducciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducciones.Location = new System.Drawing.Point(28, 441);
            this.btnProducciones.Margin = new System.Windows.Forms.Padding(0);
            this.btnProducciones.Name = "btnProducciones";
            this.btnProducciones.Size = new System.Drawing.Size(420, 162);
            this.btnProducciones.TabIndex = 5;
            this.btnProducciones.Text = "ORDENES DE PRODUCCIÓN ";
            this.btnProducciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducciones.UseCompatibleTextRendering = true;
            this.btnProducciones.UseVisualStyleBackColor = false;
            this.btnProducciones.Click += new System.EventHandler(this.BtnProducciones_Click);
            this.btnProducciones.MouseEnter += new System.EventHandler(this.BtnProducciones_MouseEnter);
            this.btnProducciones.MouseLeave += new System.EventHandler(this.BtnProducciones_MouseLeave);
            // 
            // btnCotizaciones
            // 
            this.btnCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnCotizaciones.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCotizaciones.FlatAppearance.BorderSize = 0;
            this.btnCotizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCotizaciones.ForeColor = System.Drawing.Color.White;
            this.btnCotizaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnCotizaciones.Image")));
            this.btnCotizaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCotizaciones.Location = new System.Drawing.Point(28, 245);
            this.btnCotizaciones.Margin = new System.Windows.Forms.Padding(0);
            this.btnCotizaciones.Name = "btnCotizaciones";
            this.btnCotizaciones.Size = new System.Drawing.Size(420, 162);
            this.btnCotizaciones.TabIndex = 4;
            this.btnCotizaciones.Text = "COTIZACIONES";
            this.btnCotizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCotizaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCotizaciones.UseCompatibleTextRendering = true;
            this.btnCotizaciones.UseVisualStyleBackColor = false;
            this.btnCotizaciones.Click += new System.EventHandler(this.BtnCotizaciones_Click);
            this.btnCotizaciones.MouseEnter += new System.EventHandler(this.BtnCotizaciones_MouseEnter);
            this.btnCotizaciones.MouseLeave += new System.EventHandler(this.BtnCotizaciones_MouseLeave);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(51)))));
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(28, 48);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(420, 162);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseCompatibleTextRendering = true;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);
            this.btnUsuarios.MouseEnter += new System.EventHandler(this.BtnUsuarios_MouseEnter);
            this.btnUsuarios.MouseLeave += new System.EventHandler(this.BtnUsuarios_MouseLeave);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(496, 245);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(420, 162);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseCompatibleTextRendering = true;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.Button1_Click);
            this.btnClientes.MouseEnter += new System.EventHandler(this.BtnClientes_MouseEnter);
            this.btnClientes.MouseLeave += new System.EventHandler(this.BtnClientes_MouseLeave);
            // 
            // txtNombre
            // 
            this.txtNombre.AutoSize = true;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Green;
            this.txtNombre.Location = new System.Drawing.Point(197, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(0, 26);
            this.txtNombre.TabIndex = 3;
            // 
            // txtTipoUser
            // 
            this.txtTipoUser.AutoSize = true;
            this.txtTipoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoUser.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.txtTipoUser.Location = new System.Drawing.Point(198, 57);
            this.txtTipoUser.Name = "txtTipoUser";
            this.txtTipoUser.Size = new System.Drawing.Size(0, 20);
            this.txtTipoUser.TabIndex = 4;
            // 
            // txtHora
            // 
            this.txtHora.AutoSize = true;
            this.txtHora.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.ForeColor = System.Drawing.Color.Teal;
            this.txtHora.Location = new System.Drawing.Point(1104, 37);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(89, 45);
            this.txtHora.TabIndex = 7;
            this.txtHora.Text = "Hora";
            // 
            // txtFecha
            // 
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.Teal;
            this.txtFecha.Location = new System.Drawing.Point(851, 37);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(102, 45);
            this.txtFecha.TabIndex = 5;
            this.txtFecha.Text = "Fecha";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.Window;
            this.panelPrincipal.Controls.Add(this.imageLogo);
            this.panelPrincipal.Controls.Add(this.lblCargando);
            this.panelPrincipal.Controls.Add(this.spinnerLogin);
            this.panelPrincipal.Controls.Add(this.txtFecha);
            this.panelPrincipal.Controls.Add(this.txtHora);
            this.panelPrincipal.Controls.Add(this.txtTipoUser);
            this.panelPrincipal.Controls.Add(this.txtNombre);
            this.panelPrincipal.Location = new System.Drawing.Point(2, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1360, 113);
            this.panelPrincipal.TabIndex = 6;
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPrincipal_Paint);
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.ForeColor = System.Drawing.Color.Teal;
            this.lblCargando.Location = new System.Drawing.Point(568, 47);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(143, 30);
            this.lblCargando.TabIndex = 9;
            this.lblCargando.Text = "CARGANDO...";
            this.lblCargando.Visible = false;
            // 
            // spinnerLogin
            // 
            this.spinnerLogin.Location = new System.Drawing.Point(459, 15);
            this.spinnerLogin.Maximum = 100;
            this.spinnerLogin.Name = "spinnerLogin";
            this.spinnerLogin.Size = new System.Drawing.Size(103, 82);
            this.spinnerLogin.Speed = 2F;
            this.spinnerLogin.TabIndex = 8;
            this.spinnerLogin.UseCustomBackColor = true;
            this.spinnerLogin.UseCustomForeColor = true;
            this.spinnerLogin.UseSelectable = true;
            this.spinnerLogin.Visible = false;
            // 
            // imageLogo
            // 
            this.imageLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.imageLogo.Image = global::BasesYMolduras.Properties.Resources.LOGO_BYM;
            this.imageLogo.Location = new System.Drawing.Point(21, 15);
            this.imageLogo.Name = "imageLogo";
            this.imageLogo.Size = new System.Drawing.Size(168, 82);
            this.imageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageLogo.TabIndex = 49;
            this.imageLogo.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Movable = false;
            this.Name = "Inicio";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "INICIO";
            this.Activated += new System.EventHandler(this.Inicio_Activated);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.VisibleChanged += new System.EventHandler(this.Inicio_VisibleChanged);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label txtTipoUser;
        private System.Windows.Forms.Label txtHora;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.Panel panelPrincipal;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnCotRe;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnProducciones;
        private System.Windows.Forms.Button btnCotizaciones;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnClientes;
        private MetroFramework.Controls.MetroProgressSpinner spinnerLogin;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.PictureBox imageLogo;
    }
}