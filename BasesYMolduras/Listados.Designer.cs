namespace BasesYMolduras
{
    partial class Listados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCRUD = new System.Windows.Forms.Panel();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataSet1 = new BasesYMolduras.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lista = new MetroFramework.Controls.MetroGrid();
            this.comboBoxBuscar = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panelBusqueda = new MetroFramework.Controls.MetroPanel();
            this.txtBuscar = new MetroFramework.Controls.MetroTextBox();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.btnGenerarReporte = new MetroFramework.Controls.MetroButton();
            this.panelCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCRUD
            // 
            this.panelCRUD.Controls.Add(this.btnPagos);
            this.panelCRUD.Controls.Add(this.btnDetalles);
            this.panelCRUD.Controls.Add(this.btnAprobar);
            this.panelCRUD.Controls.Add(this.btnControl);
            this.panelCRUD.Controls.Add(this.btnSalir);
            this.panelCRUD.Controls.Add(this.btnModificar);
            this.panelCRUD.Controls.Add(this.btnEliminar);
            this.panelCRUD.Location = new System.Drawing.Point(23, 72);
            this.panelCRUD.Name = "panelCRUD";
            this.panelCRUD.Size = new System.Drawing.Size(200, 564);
            this.panelCRUD.TabIndex = 16;
            // 
            // btnPagos
            // 
            this.btnPagos.BackColor = System.Drawing.Color.Teal;
            this.btnPagos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPagos.FlatAppearance.BorderSize = 0;
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.ForeColor = System.Drawing.Color.White;
            this.btnPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnPagos.Image")));
            this.btnPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagos.Location = new System.Drawing.Point(0, 12);
            this.btnPagos.Margin = new System.Windows.Forms.Padding(0);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(200, 70);
            this.btnPagos.TabIndex = 16;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagos.UseCompatibleTextRendering = true;
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.BtnPagos_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnDetalles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetalles.FlatAppearance.BorderSize = 0;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.ForeColor = System.Drawing.Color.White;
            this.btnDetalles.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalles.Image")));
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalles.Location = new System.Drawing.Point(0, 93);
            this.btnDetalles.Margin = new System.Windows.Forms.Padding(0);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(200, 70);
            this.btnDetalles.TabIndex = 9;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetalles.UseCompatibleTextRendering = true;
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(0)))), ((int)(((byte)(115)))));
            this.btnAprobar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAprobar.FlatAppearance.BorderSize = 0;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Image = ((System.Drawing.Image)(resources.GetObject("btnAprobar.Image")));
            this.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAprobar.Location = new System.Drawing.Point(0, 494);
            this.btnAprobar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(200, 70);
            this.btnAprobar.TabIndex = 15;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAprobar.UseCompatibleTextRendering = true;
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.BtnAprobar_Click);
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.btnControl.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.ForeColor = System.Drawing.Color.White;
            this.btnControl.Image = ((System.Drawing.Image)(resources.GetObject("btnControl.Image")));
            this.btnControl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControl.Location = new System.Drawing.Point(0, 173);
            this.btnControl.Margin = new System.Windows.Forms.Padding(0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(200, 70);
            this.btnControl.TabIndex = 10;
            this.btnControl.Text = " Agregar";
            this.btnControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControl.UseCompatibleTextRendering = true;
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.BtnControl_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(96)))), ((int)(((byte)(138)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 414);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(200, 70);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseCompatibleTextRendering = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(0, 254);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(0);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(200, 70);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseCompatibleTextRendering = true;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEliminar.Location = new System.Drawing.Point(0, 334);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(200, 70);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseCompatibleTextRendering = true;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // lista
            // 
            this.lista.AllowUserToAddRows = false;
            this.lista.AllowUserToDeleteRows = false;
            this.lista.AllowUserToOrderColumns = true;
            this.lista.AllowUserToResizeColumns = false;
            this.lista.AllowUserToResizeRows = false;
            this.lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.lista.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.lista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista.DefaultCellStyle = dataGridViewCellStyle8;
            this.lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lista.EnableHeadersVisualStyles = false;
            this.lista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lista.GridColor = System.Drawing.Color.White;
            this.lista.Location = new System.Drawing.Point(275, 72);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.lista.RowHeadersVisible = false;
            this.lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lista.Size = new System.Drawing.Size(852, 559);
            this.lista.TabIndex = 18;
            this.lista.UseCustomBackColor = true;
            this.lista.UseCustomForeColor = true;
            this.lista.UseStyleColors = true;
            this.lista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Lista_CellContentClick);
            // 
            // comboBoxBuscar
            // 
            this.comboBoxBuscar.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxBuscar.FormattingEnabled = true;
            this.comboBoxBuscar.ItemHeight = 19;
            this.comboBoxBuscar.Location = new System.Drawing.Point(102, 16);
            this.comboBoxBuscar.Name = "comboBoxBuscar";
            this.comboBoxBuscar.Size = new System.Drawing.Size(237, 25);
            this.comboBoxBuscar.TabIndex = 22;
            this.comboBoxBuscar.UseSelectable = true;
            this.comboBoxBuscar.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBuscar_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(-2, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 25);
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Buscar por:";
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.comboBoxBuscar);
            this.panelBusqueda.Controls.Add(this.metroLabel1);
            this.panelBusqueda.HorizontalScrollbarBarColor = true;
            this.panelBusqueda.HorizontalScrollbarHighlightOnWheel = false;
            this.panelBusqueda.HorizontalScrollbarSize = 10;
            this.panelBusqueda.Location = new System.Drawing.Point(275, 13);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(855, 54);
            this.panelBusqueda.TabIndex = 28;
            this.panelBusqueda.VerticalScrollbarBarColor = true;
            this.panelBusqueda.VerticalScrollbarHighlightOnWheel = false;
            this.panelBusqueda.VerticalScrollbarSize = 10;
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtBuscar.CustomButton.Image = null;
            this.txtBuscar.CustomButton.Location = new System.Drawing.Point(478, 1);
            this.txtBuscar.CustomButton.Name = "";
            this.txtBuscar.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtBuscar.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBuscar.CustomButton.TabIndex = 1;
            this.txtBuscar.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBuscar.CustomButton.UseSelectable = true;
            this.txtBuscar.CustomButton.Visible = false;
            this.txtBuscar.DisplayIcon = true;
            this.txtBuscar.Icon = ((System.Drawing.Image)(resources.GetObject("txtBuscar.Icon")));
            this.txtBuscar.Lines = new string[0];
            this.txtBuscar.Location = new System.Drawing.Point(350, 16);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.ShortcutsEnabled = true;
            this.txtBuscar.Size = new System.Drawing.Size(502, 25);
            this.txtBuscar.TabIndex = 25;
            this.txtBuscar.UseSelectable = true;
            this.txtBuscar.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBuscar.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(25, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(210, 25);
            this.lblTitulo.TabIndex = 29;
            this.lblTitulo.Text = "Listado Usuarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.UseCustomBackColor = true;
            this.lblTitulo.UseCustomForeColor = true;
            this.lblTitulo.UseStyleColors = true;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.Brown;
            this.btnGenerarReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGenerarReporte.Location = new System.Drawing.Point(202, 16);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(44, 38);
            this.btnGenerarReporte.TabIndex = 30;
            this.btnGenerarReporte.UseCustomBackColor = true;
            this.btnGenerarReporte.UseCustomForeColor = true;
            this.btnGenerarReporte.UseMnemonic = false;
            this.btnGenerarReporte.UseSelectable = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.BtnGenerarReporte_Click);
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.ControlBox = false;
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.panelCRUD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Listados";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "7";
            this.Load += new System.EventHandler(this.Listados_Load);
            this.panelCRUD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Panel panelCRUD;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private MetroFramework.Controls.MetroGrid lista;
        private MetroFramework.Controls.MetroComboBox comboBoxBuscar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtBuscar;
        private MetroFramework.Controls.MetroPanel panelBusqueda;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private System.Windows.Forms.Button btnPagos;
        private MetroFramework.Controls.MetroButton btnGenerarReporte;
    }
}