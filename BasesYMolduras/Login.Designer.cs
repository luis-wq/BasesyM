namespace BasesYMolduras
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labeliniciarSesion = new System.Windows.Forms.Label();
            this.txtContrasena = new MetroFramework.Controls.MetroTextBox();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.spinnerLogin = new MetroFramework.Controls.MetroProgressSpinner();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.btnIngresar = new MetroFramework.Controls.MetroButton();
            this.btnMini = new MetroFramework.Controls.MetroButton();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            this.panelLogin.Controls.Add(this.btnMini);
            this.panelLogin.Controls.Add(this.btnIngresar);
            this.panelLogin.Controls.Add(this.btnCerrar);
            this.panelLogin.Controls.Add(this.labeliniciarSesion);
            this.panelLogin.Controls.Add(this.txtContrasena);
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Controls.Add(this.pictureBox2);
            this.panelLogin.Controls.Add(this.spinnerLogin);
            this.panelLogin.Location = new System.Drawing.Point(823, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(488, 696);
            this.panelLogin.TabIndex = 1;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLogin_Paint);
            // 
            // labeliniciarSesion
            // 
            this.labeliniciarSesion.AutoSize = true;
            this.labeliniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeliniciarSesion.ForeColor = System.Drawing.Color.White;
            this.labeliniciarSesion.Location = new System.Drawing.Point(104, 69);
            this.labeliniciarSesion.Name = "labeliniciarSesion";
            this.labeliniciarSesion.Size = new System.Drawing.Size(325, 55);
            this.labeliniciarSesion.TabIndex = 3;
            this.labeliniciarSesion.Text = "Iniciar Sesión";
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtContrasena.CustomButton.Image = null;
            this.txtContrasena.CustomButton.Location = new System.Drawing.Point(284, 2);
            this.txtContrasena.CustomButton.Name = "";
            this.txtContrasena.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtContrasena.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContrasena.CustomButton.TabIndex = 1;
            this.txtContrasena.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContrasena.CustomButton.UseSelectable = true;
            this.txtContrasena.CustomButton.Visible = false;
            this.txtContrasena.DisplayIcon = true;
            this.txtContrasena.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtContrasena.ForeColor = System.Drawing.Color.Black;
            this.txtContrasena.Icon = ((System.Drawing.Image)(resources.GetObject("txtContrasena.Icon")));
            this.txtContrasena.Lines = new string[0];
            this.txtContrasena.Location = new System.Drawing.Point(104, 477);
            this.txtContrasena.MaxLength = 5;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '●';
            this.txtContrasena.PromptText = "INGRESE CONTRASEÑA";
            this.txtContrasena.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContrasena.SelectedText = "";
            this.txtContrasena.SelectionLength = 0;
            this.txtContrasena.SelectionStart = 0;
            this.txtContrasena.ShortcutsEnabled = true;
            this.txtContrasena.Size = new System.Drawing.Size(312, 30);
            this.txtContrasena.TabIndex = 6;
            this.txtContrasena.UseCustomBackColor = true;
            this.txtContrasena.UseCustomForeColor = true;
            this.txtContrasena.UseSelectable = true;
            this.txtContrasena.UseStyleColors = true;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.WaterMark = "INGRESE CONTRASEÑA";
            this.txtContrasena.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContrasena.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContrasena_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(284, 2);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.DisplayIcon = true;
            this.txtUsuario.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.Icon = ((System.Drawing.Image)(resources.GetObject("txtUsuario.Icon")));
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(104, 432);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.PromptText = "INGRESE USUARIO";
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(312, 30);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.UseCustomBackColor = true;
            this.txtUsuario.UseCustomForeColor = true;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.UseStyleColors = true;
            this.txtUsuario.WaterMark = "INGRESE USUARIO";
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BasesYMolduras.Properties.Resources.usuario;
            this.pictureBox2.Location = new System.Drawing.Point(146, 159);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 231);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // spinnerLogin
            // 
            this.spinnerLogin.Location = new System.Drawing.Point(207, 542);
            this.spinnerLogin.Maximum = 100;
            this.spinnerLogin.Name = "spinnerLogin";
            this.spinnerLogin.Size = new System.Drawing.Size(101, 101);
            this.spinnerLogin.Speed = 2F;
            this.spinnerLogin.TabIndex = 7;
            this.spinnerLogin.UseCustomBackColor = true;
            this.spinnerLogin.UseCustomForeColor = true;
            this.spinnerLogin.UseSelectable = true;
            this.spinnerLogin.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BasesYMolduras.Properties.Resources.LOGO_BYM;
            this.pictureBox1.Location = new System.Drawing.Point(39, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(745, 456);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(828, 693);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCerrar.Location = new System.Drawing.Point(454, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.UseCustomBackColor = true;
            this.btnCerrar.UseSelectable = true;
            this.btnCerrar.UseStyleColors = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.White;
            this.btnIngresar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(193)))));
            this.btnIngresar.Location = new System.Drawing.Point(104, 522);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(312, 49);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseCustomBackColor = true;
            this.btnIngresar.UseCustomForeColor = true;
            this.btnIngresar.UseSelectable = true;
            this.btnIngresar.UseStyleColors = true;
            this.btnIngresar.Click += new System.EventHandler(this.MetroButton1_Click_1);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.Transparent;
            this.btnMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMini.BackgroundImage")));
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMini.Location = new System.Drawing.Point(423, 8);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(25, 25);
            this.btnMini.TabIndex = 9;
            this.btnMini.UseCustomBackColor = true;
            this.btnMini.UseSelectable = true;
            this.btnMini.UseStyleColors = true;
            this.btnMini.Click += new System.EventHandler(this.BtnMini_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 693);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.panelLogin);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "Login";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labeliniciarSesion;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private MetroFramework.Controls.MetroTextBox txtContrasena;
        private MetroFramework.Controls.MetroProgressSpinner spinnerLogin;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnCerrar;
        private MetroFramework.Controls.MetroButton btnIngresar;
        private MetroFramework.Controls.MetroButton btnMini;
    }
}

