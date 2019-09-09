namespace BasesYMolduras
{
    partial class AgregarUsuario
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
            this.ComboBoxTipo = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.txtAP = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAM = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPIN = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModificar = new MetroFramework.Controls.MetroButton();
            this.btnSalir = new MetroFramework.Controls.MetroButton();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBoxTipo
            // 
            this.ComboBoxTipo.FormattingEnabled = true;
            this.ComboBoxTipo.ItemHeight = 23;
            this.ComboBoxTipo.Location = new System.Drawing.Point(84, 172);
            this.ComboBoxTipo.Name = "ComboBoxTipo";
            this.ComboBoxTipo.Size = new System.Drawing.Size(369, 29);
            this.ComboBoxTipo.TabIndex = 2;
            this.ComboBoxTipo.UseSelectable = true;
            this.ComboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre(s)";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtNombre.CustomButton.Image = null;
            this.txtNombre.CustomButton.Location = new System.Drawing.Point(341, 1);
            this.txtNombre.CustomButton.Name = "";
            this.txtNombre.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombre.CustomButton.TabIndex = 1;
            this.txtNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombre.CustomButton.UseSelectable = true;
            this.txtNombre.CustomButton.Visible = false;
            this.txtNombre.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombre.Lines = new string[0];
            this.txtNombre.Location = new System.Drawing.Point(84, 278);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(369, 29);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.UseSelectable = true;
            this.txtNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtAP
            // 
            this.txtAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtAP.CustomButton.Image = null;
            this.txtAP.CustomButton.Location = new System.Drawing.Point(341, 1);
            this.txtAP.CustomButton.Name = "";
            this.txtAP.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAP.CustomButton.TabIndex = 1;
            this.txtAP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAP.CustomButton.UseSelectable = true;
            this.txtAP.CustomButton.Visible = false;
            this.txtAP.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtAP.Lines = new string[0];
            this.txtAP.Location = new System.Drawing.Point(84, 366);
            this.txtAP.MaxLength = 55;
            this.txtAP.Name = "txtAP";
            this.txtAP.PasswordChar = '\0';
            this.txtAP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAP.SelectedText = "";
            this.txtAP.SelectionLength = 0;
            this.txtAP.SelectionStart = 0;
            this.txtAP.ShortcutsEnabled = true;
            this.txtAP.Size = new System.Drawing.Size(369, 29);
            this.txtAP.TabIndex = 7;
            this.txtAP.UseSelectable = true;
            this.txtAP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido Paterno";
            // 
            // txtAM
            // 
            this.txtAM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtAM.CustomButton.Image = null;
            this.txtAM.CustomButton.Location = new System.Drawing.Point(341, 1);
            this.txtAM.CustomButton.Name = "";
            this.txtAM.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAM.CustomButton.TabIndex = 1;
            this.txtAM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAM.CustomButton.UseSelectable = true;
            this.txtAM.CustomButton.Visible = false;
            this.txtAM.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtAM.Lines = new string[0];
            this.txtAM.Location = new System.Drawing.Point(84, 469);
            this.txtAM.MaxLength = 55;
            this.txtAM.Name = "txtAM";
            this.txtAM.PasswordChar = '\0';
            this.txtAM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAM.SelectedText = "";
            this.txtAM.SelectionLength = 0;
            this.txtAM.SelectionStart = 0;
            this.txtAM.ShortcutsEnabled = true;
            this.txtAM.Size = new System.Drawing.Size(369, 29);
            this.txtAM.TabIndex = 9;
            this.txtAM.UseSelectable = true;
            this.txtAM.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAM.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Apellido Materno";
            // 
            // txtUser
            // 
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtUser.CustomButton.Image = null;
            this.txtUser.CustomButton.Location = new System.Drawing.Point(341, 1);
            this.txtUser.CustomButton.Name = "";
            this.txtUser.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUser.CustomButton.TabIndex = 1;
            this.txtUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUser.CustomButton.UseSelectable = true;
            this.txtUser.CustomButton.Visible = false;
            this.txtUser.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(559, 172);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.ShortcutsEnabled = true;
            this.txtUser.Size = new System.Drawing.Size(369, 29);
            this.txtUser.TabIndex = 11;
            this.txtUser.UseSelectable = true;
            this.txtUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(555, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre de usuario";
            // 
            // txtPIN
            // 
            this.txtPIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtPIN.CustomButton.Image = null;
            this.txtPIN.CustomButton.Location = new System.Drawing.Point(341, 1);
            this.txtPIN.CustomButton.Name = "";
            this.txtPIN.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtPIN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPIN.CustomButton.TabIndex = 1;
            this.txtPIN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPIN.CustomButton.UseSelectable = true;
            this.txtPIN.CustomButton.Visible = false;
            this.txtPIN.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPIN.Lines = new string[0];
            this.txtPIN.Location = new System.Drawing.Point(559, 269);
            this.txtPIN.MaxLength = 5;
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.PasswordChar = '\0';
            this.txtPIN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPIN.SelectedText = "";
            this.txtPIN.SelectionLength = 0;
            this.txtPIN.SelectionStart = 0;
            this.txtPIN.ShortcutsEnabled = true;
            this.txtPIN.Size = new System.Drawing.Size(369, 29);
            this.txtPIN.TabIndex = 13;
            this.txtPIN.UseSelectable = true;
            this.txtPIN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPIN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(555, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "PIN (Contraseña)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(994, 19);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 64);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseCustomBackColor = true;
            this.btnGuardar.UseCustomForeColor = true;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.UseStyleColors = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.MetroButton2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancelar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(845, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 64);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseCustomBackColor = true;
            this.btnCancelar.UseCustomForeColor = true;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Location = new System.Drawing.Point(0, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 96);
            this.panel1.TabIndex = 17;
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModificar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnModificar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(994, 19);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(133, 64);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseCustomBackColor = true;
            this.btnModificar.UseCustomForeColor = true;
            this.btnModificar.UseSelectable = true;
            this.btnModificar.UseStyleColors = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSalir.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(994, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(133, 64);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseCustomBackColor = true;
            this.btnSalir.UseCustomForeColor = true;
            this.btnSalir.UseSelectable = true;
            this.btnSalir.UseStyleColors = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(84, 48);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 25);
            this.lblTitulo.TabIndex = 18;
            this.lblTitulo.Text = "AGREGAR USUARIO";
            // 
            // AgregarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxTipo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "AgregarUsuario";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Load += new System.EventHandler(this.AgregarUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox ComboBoxTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroTextBox txtAP;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txtAM;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txtUser;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox txtPIN;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnSalir;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroButton btnModificar;
    }
}