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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.txtContrasena = new PlaceholderTextBox.PlaceholderTextBox();
            this.txtUsuario = new PlaceholderTextBox.PlaceholderTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labeliniciarSesion = new System.Windows.Forms.Label();
            this.ButtonIngresar = new MetroFramework.Controls.MetroButton();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            this.panelLogin.Controls.Add(this.ButtonIngresar);
            this.panelLogin.Controls.Add(this.txtContrasena);
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Controls.Add(this.pictureBox2);
            this.panelLogin.Location = new System.Drawing.Point(823, 30);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(488, 666);
            this.panelLogin.TabIndex = 1;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLogin_Paint);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(100, 428);
            this.txtContrasena.MaxLength = 20;
            this.txtContrasena.MinimumSize = new System.Drawing.Size(312, 31);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.PlaceholderText = "CONTRASEÑA";
            this.txtContrasena.Size = new System.Drawing.Size(312, 31);
            this.txtContrasena.TabIndex = 2;
            this.txtContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtContrasena_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(100, 370);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.MinimumSize = new System.Drawing.Size(312, 31);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PlaceholderText = "USUARIO";
            this.txtUsuario.Size = new System.Drawing.Size(312, 31);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BasesYMolduras.Properties.Resources.usuario;
            this.pictureBox2.Location = new System.Drawing.Point(142, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 231);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BasesYMolduras.Properties.Resources.LOGO_BYM;
            this.pictureBox1.Location = new System.Drawing.Point(62, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(681, 448);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labeliniciarSesion
            // 
            this.labeliniciarSesion.AutoSize = true;
            this.labeliniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeliniciarSesion.Location = new System.Drawing.Point(252, 60);
            this.labeliniciarSesion.Name = "labeliniciarSesion";
            this.labeliniciarSesion.Size = new System.Drawing.Size(325, 55);
            this.labeliniciarSesion.TabIndex = 3;
            this.labeliniciarSesion.Text = "Iniciar Sesión";
            // 
            // ButtonIngresar
            // 
            this.ButtonIngresar.BackColor = System.Drawing.Color.White;
            this.ButtonIngresar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.ButtonIngresar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ButtonIngresar.Location = new System.Drawing.Point(100, 492);
            this.ButtonIngresar.Name = "ButtonIngresar";
            this.ButtonIngresar.Size = new System.Drawing.Size(312, 62);
            this.ButtonIngresar.Style = MetroFramework.MetroColorStyle.Silver;
            this.ButtonIngresar.TabIndex = 4;
            this.ButtonIngresar.Text = "INGRESAR";
            this.ButtonIngresar.UseCustomBackColor = true;
            this.ButtonIngresar.UseCustomForeColor = true;
            this.ButtonIngresar.UseSelectable = true;
            this.ButtonIngresar.UseStyleColors = true;
            this.ButtonIngresar.Click += new System.EventHandler(this.MetroButton1_Click_1);
            // 
            // Login
            // 
            this.AcceptButton = this.ButtonIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 693);
            this.Controls.Add(this.labeliniciarSesion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labeliniciarSesion;
        private PlaceholderTextBox.PlaceholderTextBox txtContrasena;
        private MetroFramework.Controls.MetroButton ButtonIngresar;
        internal PlaceholderTextBox.PlaceholderTextBox txtUsuario;
    }
}

