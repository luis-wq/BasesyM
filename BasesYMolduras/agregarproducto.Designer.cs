namespace BasesYMolduras
{
    partial class agregarproducto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarProducto = new MetroFramework.Controls.MetroButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPeso = new MetroFramework.Controls.MetroTextBox();
            this.txtPorcentaje = new MetroFramework.Controls.MetroTextBox();
            this.txtPrecioM = new MetroFramework.Controls.MetroTextBox();
            this.txtPrecioF = new MetroFramework.Controls.MetroTextBox();
            this.txtPrecioP = new MetroFramework.Controls.MetroTextBox();
            this.txtDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.txtTamano = new MetroFramework.Controls.MetroTextBox();
            this.txtModelo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.cbTipo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.checkTamanoE = new System.Windows.Forms.CheckBox();
            this.checkTamanoN = new System.Windows.Forms.CheckBox();
            this.checkModeloE = new System.Windows.Forms.CheckBox();
            this.checkModeloN = new System.Windows.Forms.CheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbTamano = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cbModelo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbMaterial = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbCategoria = new MetroFramework.Controls.MetroComboBox();
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnModificarProducto);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 527);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(398, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nuevo producto";
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.BackColor = System.Drawing.Color.Crimson;
            this.btnModificarProducto.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnModificarProducto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificarProducto.Highlight = true;
            this.btnModificarProducto.Location = new System.Drawing.Point(17, 466);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(163, 43);
            this.btnModificarProducto.TabIndex = 4;
            this.btnModificarProducto.Text = "SALIR";
            this.btnModificarProducto.UseCustomBackColor = true;
            this.btnModificarProducto.UseCustomForeColor = true;
            this.btnModificarProducto.UseSelectable = true;
            this.btnModificarProducto.Click += new System.EventHandler(this.BtnModificarProducto_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtPeso);
            this.panel3.Controls.Add(this.txtPorcentaje);
            this.panel3.Controls.Add(this.txtPrecioM);
            this.panel3.Controls.Add(this.txtPrecioF);
            this.panel3.Controls.Add(this.txtPrecioP);
            this.panel3.Controls.Add(this.txtDescripcion);
            this.panel3.Controls.Add(this.txtTamano);
            this.panel3.Controls.Add(this.txtModelo);
            this.panel3.Controls.Add(this.metroLabel7);
            this.panel3.Controls.Add(this.metroLabel13);
            this.panel3.Controls.Add(this.cbTipo);
            this.panel3.Controls.Add(this.metroLabel12);
            this.panel3.Controls.Add(this.metroLabel11);
            this.panel3.Controls.Add(this.metroLabel10);
            this.panel3.Controls.Add(this.metroLabel9);
            this.panel3.Controls.Add(this.metroLabel8);
            this.panel3.Controls.Add(this.checkTamanoE);
            this.panel3.Controls.Add(this.checkTamanoN);
            this.panel3.Controls.Add(this.checkModeloE);
            this.panel3.Controls.Add(this.checkModeloN);
            this.panel3.Controls.Add(this.metroLabel5);
            this.panel3.Controls.Add(this.cbTamano);
            this.panel3.Controls.Add(this.metroLabel6);
            this.panel3.Controls.Add(this.metroLabel4);
            this.panel3.Controls.Add(this.cbModelo);
            this.panel3.Controls.Add(this.metroLabel1);
            this.panel3.Controls.Add(this.metroLabel3);
            this.panel3.Controls.Add(this.cbMaterial);
            this.panel3.Controls.Add(this.metroLabel2);
            this.panel3.Controls.Add(this.cbCategoria);
            this.panel3.Location = new System.Drawing.Point(17, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(895, 396);
            this.panel3.TabIndex = 6;
            // 
            // txtPeso
            // 
            // 
            // 
            // 
            this.txtPeso.CustomButton.Image = null;
            this.txtPeso.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtPeso.CustomButton.Name = "";
            this.txtPeso.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPeso.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPeso.CustomButton.TabIndex = 1;
            this.txtPeso.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPeso.CustomButton.UseSelectable = true;
            this.txtPeso.CustomButton.Visible = false;
            this.txtPeso.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPeso.Lines = new string[0];
            this.txtPeso.Location = new System.Drawing.Point(634, 194);
            this.txtPeso.MaxLength = 32767;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.PasswordChar = '\0';
            this.txtPeso.PromptText = "00.00";
            this.txtPeso.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPeso.SelectedText = "";
            this.txtPeso.SelectionLength = 0;
            this.txtPeso.SelectionStart = 0;
            this.txtPeso.ShortcutsEnabled = true;
            this.txtPeso.Size = new System.Drawing.Size(237, 28);
            this.txtPeso.TabIndex = 69;
            this.txtPeso.UseSelectable = true;
            this.txtPeso.WaterMark = "00.00";
            this.txtPeso.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPeso.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPeso_KeyPress_1);
            // 
            // txtPorcentaje
            // 
            // 
            // 
            // 
            this.txtPorcentaje.CustomButton.Image = null;
            this.txtPorcentaje.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtPorcentaje.CustomButton.Name = "";
            this.txtPorcentaje.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPorcentaje.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPorcentaje.CustomButton.TabIndex = 1;
            this.txtPorcentaje.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPorcentaje.CustomButton.UseSelectable = true;
            this.txtPorcentaje.CustomButton.Visible = false;
            this.txtPorcentaje.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPorcentaje.Lines = new string[0];
            this.txtPorcentaje.Location = new System.Drawing.Point(634, 153);
            this.txtPorcentaje.MaxLength = 32767;
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.PasswordChar = '\0';
            this.txtPorcentaje.PromptText = "00.00";
            this.txtPorcentaje.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPorcentaje.SelectedText = "";
            this.txtPorcentaje.SelectionLength = 0;
            this.txtPorcentaje.SelectionStart = 0;
            this.txtPorcentaje.ShortcutsEnabled = true;
            this.txtPorcentaje.Size = new System.Drawing.Size(237, 28);
            this.txtPorcentaje.TabIndex = 68;
            this.txtPorcentaje.UseSelectable = true;
            this.txtPorcentaje.WaterMark = "00.00";
            this.txtPorcentaje.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPorcentaje.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPorcentaje_KeyPress);
            // 
            // txtPrecioM
            // 
            // 
            // 
            // 
            this.txtPrecioM.CustomButton.Image = null;
            this.txtPrecioM.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtPrecioM.CustomButton.Name = "";
            this.txtPrecioM.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPrecioM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecioM.CustomButton.TabIndex = 1;
            this.txtPrecioM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecioM.CustomButton.UseSelectable = true;
            this.txtPrecioM.CustomButton.Visible = false;
            this.txtPrecioM.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecioM.Lines = new string[0];
            this.txtPrecioM.Location = new System.Drawing.Point(634, 110);
            this.txtPrecioM.MaxLength = 32767;
            this.txtPrecioM.Name = "txtPrecioM";
            this.txtPrecioM.PasswordChar = '\0';
            this.txtPrecioM.PromptText = "$00.00";
            this.txtPrecioM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecioM.SelectedText = "";
            this.txtPrecioM.SelectionLength = 0;
            this.txtPrecioM.SelectionStart = 0;
            this.txtPrecioM.ShortcutsEnabled = true;
            this.txtPrecioM.Size = new System.Drawing.Size(237, 28);
            this.txtPrecioM.TabIndex = 67;
            this.txtPrecioM.UseSelectable = true;
            this.txtPrecioM.WaterMark = "$00.00";
            this.txtPrecioM.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecioM.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrecioM.Leave += new System.EventHandler(this.TxtPrecioM_Leave);
            // 
            // txtPrecioF
            // 
            // 
            // 
            // 
            this.txtPrecioF.CustomButton.Image = null;
            this.txtPrecioF.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtPrecioF.CustomButton.Name = "";
            this.txtPrecioF.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPrecioF.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecioF.CustomButton.TabIndex = 1;
            this.txtPrecioF.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecioF.CustomButton.UseSelectable = true;
            this.txtPrecioF.CustomButton.Visible = false;
            this.txtPrecioF.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecioF.Lines = new string[0];
            this.txtPrecioF.Location = new System.Drawing.Point(634, 69);
            this.txtPrecioF.MaxLength = 32767;
            this.txtPrecioF.Name = "txtPrecioF";
            this.txtPrecioF.PasswordChar = '\0';
            this.txtPrecioF.PromptText = "$00.00";
            this.txtPrecioF.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecioF.SelectedText = "";
            this.txtPrecioF.SelectionLength = 0;
            this.txtPrecioF.SelectionStart = 0;
            this.txtPrecioF.ShortcutsEnabled = true;
            this.txtPrecioF.Size = new System.Drawing.Size(237, 28);
            this.txtPrecioF.TabIndex = 66;
            this.txtPrecioF.UseSelectable = true;
            this.txtPrecioF.WaterMark = "$00.00";
            this.txtPrecioF.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecioF.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrecioF.Leave += new System.EventHandler(this.TxtPrecioF_Leave);
            // 
            // txtPrecioP
            // 
            // 
            // 
            // 
            this.txtPrecioP.CustomButton.Image = null;
            this.txtPrecioP.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtPrecioP.CustomButton.Name = "";
            this.txtPrecioP.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPrecioP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecioP.CustomButton.TabIndex = 1;
            this.txtPrecioP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecioP.CustomButton.UseSelectable = true;
            this.txtPrecioP.CustomButton.Visible = false;
            this.txtPrecioP.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecioP.Lines = new string[0];
            this.txtPrecioP.Location = new System.Drawing.Point(634, 28);
            this.txtPrecioP.MaxLength = 32767;
            this.txtPrecioP.Name = "txtPrecioP";
            this.txtPrecioP.PasswordChar = '\0';
            this.txtPrecioP.PromptText = "$00.00";
            this.txtPrecioP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecioP.SelectedText = "";
            this.txtPrecioP.SelectionLength = 0;
            this.txtPrecioP.SelectionStart = 0;
            this.txtPrecioP.ShortcutsEnabled = true;
            this.txtPrecioP.Size = new System.Drawing.Size(237, 28);
            this.txtPrecioP.TabIndex = 65;
            this.txtPrecioP.UseSelectable = true;
            this.txtPrecioP.WaterMark = "$00.00";
            this.txtPrecioP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecioP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrecioP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioP_KeyPress);
            this.txtPrecioP.Leave += new System.EventHandler(this.TxtPrecioP_Leave);
            // 
            // txtDescripcion
            // 
            // 
            // 
            // 
            this.txtDescripcion.CustomButton.Image = null;
            this.txtDescripcion.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtDescripcion.CustomButton.Name = "";
            this.txtDescripcion.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtDescripcion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescripcion.CustomButton.TabIndex = 1;
            this.txtDescripcion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescripcion.CustomButton.UseSelectable = true;
            this.txtDescripcion.CustomButton.Visible = false;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtDescripcion.Lines = new string[0];
            this.txtDescripcion.Location = new System.Drawing.Point(188, 339);
            this.txtDescripcion.MaxLength = 32767;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.SelectionLength = 0;
            this.txtDescripcion.SelectionStart = 0;
            this.txtDescripcion.ShortcutsEnabled = true;
            this.txtDescripcion.Size = new System.Drawing.Size(237, 28);
            this.txtDescripcion.TabIndex = 64;
            this.txtDescripcion.UseSelectable = true;
            this.txtDescripcion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescripcion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTamano
            // 
            // 
            // 
            // 
            this.txtTamano.CustomButton.Image = null;
            this.txtTamano.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtTamano.CustomButton.Name = "";
            this.txtTamano.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTamano.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTamano.CustomButton.TabIndex = 1;
            this.txtTamano.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTamano.CustomButton.UseSelectable = true;
            this.txtTamano.CustomButton.Visible = false;
            this.txtTamano.Enabled = false;
            this.txtTamano.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTamano.Lines = new string[0];
            this.txtTamano.Location = new System.Drawing.Point(188, 242);
            this.txtTamano.MaxLength = 32767;
            this.txtTamano.Name = "txtTamano";
            this.txtTamano.PasswordChar = '\0';
            this.txtTamano.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTamano.SelectedText = "";
            this.txtTamano.SelectionLength = 0;
            this.txtTamano.SelectionStart = 0;
            this.txtTamano.ShortcutsEnabled = true;
            this.txtTamano.Size = new System.Drawing.Size(237, 28);
            this.txtTamano.TabIndex = 63;
            this.txtTamano.UseSelectable = true;
            this.txtTamano.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTamano.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtModelo
            // 
            // 
            // 
            // 
            this.txtModelo.CustomButton.Image = null;
            this.txtModelo.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.txtModelo.CustomButton.Name = "";
            this.txtModelo.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtModelo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtModelo.CustomButton.TabIndex = 1;
            this.txtModelo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtModelo.CustomButton.UseSelectable = true;
            this.txtModelo.CustomButton.Visible = false;
            this.txtModelo.Enabled = false;
            this.txtModelo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtModelo.Lines = new string[0];
            this.txtModelo.Location = new System.Drawing.Point(188, 110);
            this.txtModelo.MaxLength = 32767;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.PasswordChar = '\0';
            this.txtModelo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtModelo.SelectedText = "";
            this.txtModelo.SelectionLength = 0;
            this.txtModelo.SelectionStart = 0;
            this.txtModelo.ShortcutsEnabled = true;
            this.txtModelo.Size = new System.Drawing.Size(237, 28);
            this.txtModelo.TabIndex = 62;
            this.txtModelo.UseSelectable = true;
            this.txtModelo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtModelo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(8, 342);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(167, 25);
            this.metroLabel7.TabIndex = 61;
            this.metroLabel7.Text = "Descripción tamaño:";
            this.metroLabel7.UseCustomBackColor = true;
            this.metroLabel7.UseCustomForeColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel13.Location = new System.Drawing.Point(126, 197);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(49, 25);
            this.metroLabel13.TabIndex = 59;
            this.metroLabel13.Text = "Tipo:";
            this.metroLabel13.UseCustomBackColor = true;
            this.metroLabel13.UseCustomForeColor = true;
            // 
            // cbTipo
            // 
            this.cbTipo.Enabled = false;
            this.cbTipo.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.ItemHeight = 19;
            this.cbTipo.Location = new System.Drawing.Point(188, 197);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.PromptText = "Seleccione un tipo";
            this.cbTipo.Size = new System.Drawing.Size(237, 25);
            this.cbTipo.TabIndex = 58;
            this.cbTipo.UseSelectable = true;
            this.cbTipo.SelectionChangeCommitted += new System.EventHandler(this.CbTipo_SelectionChangeCommitted);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel12.Location = new System.Drawing.Point(570, 197);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(51, 25);
            this.metroLabel12.TabIndex = 57;
            this.metroLabel12.Text = "Peso:";
            this.metroLabel12.UseCustomBackColor = true;
            this.metroLabel12.UseCustomForeColor = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel11.Location = new System.Drawing.Point(526, 156);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(95, 25);
            this.metroLabel11.TabIndex = 55;
            this.metroLabel11.Text = "Porcentaje:";
            this.metroLabel11.UseCustomBackColor = true;
            this.metroLabel11.UseCustomForeColor = true;
            this.metroLabel11.Click += new System.EventHandler(this.MetroLabel11_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.Location = new System.Drawing.Point(480, 113);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(141, 25);
            this.metroLabel10.TabIndex = 53;
            this.metroLabel10.Text = "Precio mayorista:";
            this.metroLabel10.UseCustomBackColor = true;
            this.metroLabel10.UseCustomForeColor = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(482, 72);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(139, 25);
            this.metroLabel9.TabIndex = 51;
            this.metroLabel9.Text = "Precio frecuente:";
            this.metroLabel9.UseCustomBackColor = true;
            this.metroLabel9.UseCustomForeColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(497, 31);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(124, 25);
            this.metroLabel8.TabIndex = 49;
            this.metroLabel8.Text = "Precio publico:";
            this.metroLabel8.UseCustomBackColor = true;
            this.metroLabel8.UseCustomForeColor = true;
            // 
            // checkTamanoE
            // 
            this.checkTamanoE.AutoSize = true;
            this.checkTamanoE.Enabled = false;
            this.checkTamanoE.Location = new System.Drawing.Point(439, 295);
            this.checkTamanoE.Name = "checkTamanoE";
            this.checkTamanoE.Size = new System.Drawing.Size(15, 14);
            this.checkTamanoE.TabIndex = 45;
            this.checkTamanoE.UseVisualStyleBackColor = true;
            this.checkTamanoE.CheckedChanged += new System.EventHandler(this.CheckTamanoE_CheckedChanged);
            // 
            // checkTamanoN
            // 
            this.checkTamanoN.AutoSize = true;
            this.checkTamanoN.Enabled = false;
            this.checkTamanoN.Location = new System.Drawing.Point(439, 248);
            this.checkTamanoN.Name = "checkTamanoN";
            this.checkTamanoN.Size = new System.Drawing.Size(15, 14);
            this.checkTamanoN.TabIndex = 44;
            this.checkTamanoN.UseVisualStyleBackColor = true;
            this.checkTamanoN.CheckedChanged += new System.EventHandler(this.CheckTamanoN_CheckedChanged);
            // 
            // checkModeloE
            // 
            this.checkModeloE.AutoSize = true;
            this.checkModeloE.Enabled = false;
            this.checkModeloE.Location = new System.Drawing.Point(439, 159);
            this.checkModeloE.Name = "checkModeloE";
            this.checkModeloE.Size = new System.Drawing.Size(15, 14);
            this.checkModeloE.TabIndex = 43;
            this.checkModeloE.UseVisualStyleBackColor = true;
            this.checkModeloE.CheckedChanged += new System.EventHandler(this.CheckModeloE_CheckedChanged);
            // 
            // checkModeloN
            // 
            this.checkModeloN.AutoSize = true;
            this.checkModeloN.Enabled = false;
            this.checkModeloN.Location = new System.Drawing.Point(439, 116);
            this.checkModeloN.Name = "checkModeloN";
            this.checkModeloN.Size = new System.Drawing.Size(15, 14);
            this.checkModeloN.TabIndex = 42;
            this.checkModeloN.UseVisualStyleBackColor = true;
            this.checkModeloN.CheckedChanged += new System.EventHandler(this.CheckModeloN_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(29, 289);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(146, 25);
            this.metroLabel5.TabIndex = 41;
            this.metroLabel5.Text = "Tamaño existente:";
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            // 
            // cbTamano
            // 
            this.cbTamano.Enabled = false;
            this.cbTamano.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbTamano.FormattingEnabled = true;
            this.cbTamano.ItemHeight = 19;
            this.cbTamano.Location = new System.Drawing.Point(188, 289);
            this.cbTamano.Name = "cbTamano";
            this.cbTamano.PromptText = "Seleccione un tamaño";
            this.cbTamano.Size = new System.Drawing.Size(237, 25);
            this.cbTamano.TabIndex = 40;
            this.cbTamano.UseSelectable = true;
            this.cbTamano.SelectionChangeCommitted += new System.EventHandler(this.CbTamano_SelectionChangeCommitted);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(46, 245);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(129, 25);
            this.metroLabel6.TabIndex = 39;
            this.metroLabel6.Text = "Nuevo tamaño:";
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(25, 156);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(145, 25);
            this.metroLabel4.TabIndex = 37;
            this.metroLabel4.Text = "Modelo existente:";
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            this.metroLabel4.Click += new System.EventHandler(this.MetroLabel4_Click);
            // 
            // cbModelo
            // 
            this.cbModelo.Enabled = false;
            this.cbModelo.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbModelo.FormattingEnabled = true;
            this.cbModelo.ItemHeight = 19;
            this.cbModelo.Location = new System.Drawing.Point(188, 153);
            this.cbModelo.Name = "cbModelo";
            this.cbModelo.PromptText = "Seleccione un modelo";
            this.cbModelo.Size = new System.Drawing.Size(237, 25);
            this.cbModelo.TabIndex = 36;
            this.cbModelo.UseSelectable = true;
            this.cbModelo.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox3_SelectedIndexChanged);
            this.cbModelo.SelectionChangeCommitted += new System.EventHandler(this.CbModelo_SelectionChangeCommitted);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(46, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(129, 25);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "Nuevo modelo:";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.Click += new System.EventHandler(this.MetroLabel1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(98, 67);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 25);
            this.metroLabel3.TabIndex = 33;
            this.metroLabel3.Text = "Material:";
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // cbMaterial
            // 
            this.cbMaterial.Enabled = false;
            this.cbMaterial.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.ItemHeight = 19;
            this.cbMaterial.Location = new System.Drawing.Point(188, 67);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.PromptText = "Seleccione un material";
            this.cbMaterial.Size = new System.Drawing.Size(237, 25);
            this.cbMaterial.TabIndex = 34;
            this.cbMaterial.UseSelectable = true;
            this.cbMaterial.SelectionChangeCommitted += new System.EventHandler(this.CbMaterial_SelectionChangeCommitted);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(86, 25);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 25);
            this.metroLabel2.TabIndex = 31;
            this.metroLabel2.Text = "Categoria:";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.Click += new System.EventHandler(this.MetroLabel2_Click);
            // 
            // cbCategoria
            // 
            this.cbCategoria.Enabled = false;
            this.cbCategoria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.ItemHeight = 19;
            this.cbCategoria.Location = new System.Drawing.Point(188, 26);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.PromptText = "Seleccione una categoria";
            this.cbCategoria.Size = new System.Drawing.Size(237, 25);
            this.cbCategoria.TabIndex = 32;
            this.cbCategoria.UseSelectable = true;
            this.cbCategoria.SelectionChangeCommitted += new System.EventHandler(this.CbCategoria_SelectionChangeCommitted);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAgregar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Highlight = true;
            this.btnAgregar.Location = new System.Drawing.Point(749, 466);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(163, 43);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseCustomBackColor = true;
            this.btnAgregar.UseCustomForeColor = true;
            this.btnAgregar.UseSelectable = true;
            this.btnAgregar.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // agregarproducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(931, 526);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "agregarproducto";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.agregarproducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btnModificarProducto;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbMaterial;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbCategoria;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cbModelo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbTamano;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.CheckBox checkTamanoE;
        private System.Windows.Forms.CheckBox checkTamanoN;
        private System.Windows.Forms.CheckBox checkModeloE;
        private System.Windows.Forms.CheckBox checkModeloN;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroComboBox cbTipo;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtModelo;
        private MetroFramework.Controls.MetroTextBox txtPorcentaje;
        private MetroFramework.Controls.MetroTextBox txtPrecioM;
        private MetroFramework.Controls.MetroTextBox txtPrecioF;
        private MetroFramework.Controls.MetroTextBox txtDescripcion;
        private MetroFramework.Controls.MetroTextBox txtTamano;
        private MetroFramework.Controls.MetroTextBox txtPrecioP;
        private MetroFramework.Controls.MetroTextBox txtPeso;
    }
}