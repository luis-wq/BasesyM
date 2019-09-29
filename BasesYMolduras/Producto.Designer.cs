namespace BasesYMolduras
{
    partial class Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Producto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelArriba = new MetroFramework.Controls.MetroPanel();
            this.txtBusqueda = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxMaterial = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxCategoria = new MetroFramework.Controls.MetroComboBox();
            this.panelAbajo = new MetroFramework.Controls.MetroPanel();
            this.lblProductos = new MetroFramework.Controls.MetroLabel();
            this.lblPrueba = new MetroFramework.Controls.MetroLabel();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnModificarProducto = new MetroFramework.Controls.MetroButton();
            this.btnSalirProducto = new MetroFramework.Controls.MetroButton();
            this.tablaProductos = new MetroFramework.Controls.MetroGrid();
            this.btnCargar = new MetroFramework.Controls.MetroButton();
            this.panelArriba.SuspendLayout();
            this.panelAbajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelArriba
            // 
            this.panelArriba.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelArriba.Controls.Add(this.txtBusqueda);
            this.panelArriba.Controls.Add(this.metroLabel3);
            this.panelArriba.Controls.Add(this.comboBoxMaterial);
            this.panelArriba.Controls.Add(this.metroLabel2);
            this.panelArriba.Controls.Add(this.comboBoxCategoria);
            this.panelArriba.HorizontalScrollbarBarColor = true;
            this.panelArriba.HorizontalScrollbarHighlightOnWheel = false;
            this.panelArriba.HorizontalScrollbarSize = 10;
            this.panelArriba.Location = new System.Drawing.Point(0, -1);
            this.panelArriba.Name = "panelArriba";
            this.panelArriba.Size = new System.Drawing.Size(1401, 103);
            this.panelArriba.TabIndex = 28;
            this.panelArriba.UseCustomBackColor = true;
            this.panelArriba.UseCustomForeColor = true;
            this.panelArriba.UseStyleColors = true;
            this.panelArriba.VerticalScrollbarBarColor = true;
            this.panelArriba.VerticalScrollbarHighlightOnWheel = false;
            this.panelArriba.VerticalScrollbarSize = 10;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtBusqueda.CustomButton.Image = null;
            this.txtBusqueda.CustomButton.Location = new System.Drawing.Point(574, 1);
            this.txtBusqueda.CustomButton.Name = "";
            this.txtBusqueda.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtBusqueda.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBusqueda.CustomButton.TabIndex = 1;
            this.txtBusqueda.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBusqueda.CustomButton.UseSelectable = true;
            this.txtBusqueda.CustomButton.Visible = false;
            this.txtBusqueda.DisplayIcon = true;
            this.txtBusqueda.Icon = ((System.Drawing.Image)(resources.GetObject("txtBusqueda.Icon")));
            this.txtBusqueda.Lines = new string[0];
            this.txtBusqueda.Location = new System.Drawing.Point(763, 39);
            this.txtBusqueda.MaxLength = 32767;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PasswordChar = '\0';
            this.txtBusqueda.PromptText = "INGRESE UN MODELO";
            this.txtBusqueda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBusqueda.SelectedText = "";
            this.txtBusqueda.SelectionLength = 0;
            this.txtBusqueda.SelectionStart = 0;
            this.txtBusqueda.ShortcutsEnabled = true;
            this.txtBusqueda.Size = new System.Drawing.Size(598, 25);
            this.txtBusqueda.TabIndex = 28;
            this.txtBusqueda.UseSelectable = true;
            this.txtBusqueda.WaterMark = "INGRESE UN MODELO";
            this.txtBusqueda.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBusqueda.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBusqueda.TextChanged += new System.EventHandler(this.MetroTextBox1_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(391, 39);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 25);
            this.metroLabel3.TabIndex = 29;
            this.metroLabel3.Text = "Material:";
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.ItemHeight = 19;
            this.comboBoxMaterial.Location = new System.Drawing.Point(486, 39);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.PromptText = "Seleccione un material";
            this.comboBoxMaterial.Size = new System.Drawing.Size(237, 25);
            this.comboBoxMaterial.TabIndex = 30;
            this.comboBoxMaterial.UseSelectable = true;
            this.comboBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMaterial_SelectedIndexChanged);
            this.comboBoxMaterial.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxMaterial_SelectionChangeCommitted);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(39, 39);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 25);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "Categoria:";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.ItemHeight = 19;
            this.comboBoxCategoria.Location = new System.Drawing.Point(134, 39);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.PromptText = "Seleccione una categoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(237, 25);
            this.comboBoxCategoria.TabIndex = 28;
            this.comboBoxCategoria.UseSelectable = true;
            this.comboBoxCategoria.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCategoria_SelectionChangeCommitted);
            // 
            // panelAbajo
            // 
            this.panelAbajo.BackColor = System.Drawing.SystemColors.Control;
            this.panelAbajo.Controls.Add(this.btnCargar);
            this.panelAbajo.Controls.Add(this.lblProductos);
            this.panelAbajo.Controls.Add(this.lblPrueba);
            this.panelAbajo.Controls.Add(this.txtCantidad);
            this.panelAbajo.Controls.Add(this.metroLabel4);
            this.panelAbajo.Controls.Add(this.btnModificarProducto);
            this.panelAbajo.Controls.Add(this.btnSalirProducto);
            this.panelAbajo.HorizontalScrollbarBarColor = true;
            this.panelAbajo.HorizontalScrollbarHighlightOnWheel = false;
            this.panelAbajo.HorizontalScrollbarSize = 10;
            this.panelAbajo.Location = new System.Drawing.Point(0, 691);
            this.panelAbajo.Name = "panelAbajo";
            this.panelAbajo.Size = new System.Drawing.Size(1401, 92);
            this.panelAbajo.TabIndex = 29;
            this.panelAbajo.UseCustomBackColor = true;
            this.panelAbajo.UseCustomForeColor = true;
            this.panelAbajo.UseStyleColors = true;
            this.panelAbajo.VerticalScrollbarBarColor = true;
            this.panelAbajo.VerticalScrollbarHighlightOnWheel = false;
            this.panelAbajo.VerticalScrollbarSize = 10;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblProductos.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblProductos.Location = new System.Drawing.Point(513, 30);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(205, 25);
            this.lblProductos.TabIndex = 33;
            this.lblProductos.Text = "Productos Encontrados: 0";
            this.lblProductos.UseCustomBackColor = true;
            this.lblProductos.UseCustomForeColor = true;
            // 
            // lblPrueba
            // 
            this.lblPrueba.AutoSize = true;
            this.lblPrueba.Location = new System.Drawing.Point(535, 33);
            this.lblPrueba.Name = "lblPrueba";
            this.lblPrueba.Size = new System.Drawing.Size(0, 0);
            this.lblPrueba.TabIndex = 32;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtCantidad.Location = new System.Drawing.Point(1078, 30);
            this.txtCantidad.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(77, 20);
            this.txtCantidad.TabIndex = 30;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(998, 27);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(84, 25);
            this.metroLabel4.TabIndex = 31;
            this.metroLabel4.Text = "Cantidad:";
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Location = new System.Drawing.Point(1161, 22);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(199, 36);
            this.btnModificarProducto.TabIndex = 3;
            this.btnModificarProducto.Text = "MODIFICAR";
            this.btnModificarProducto.UseSelectable = true;
            this.btnModificarProducto.Click += new System.EventHandler(this.BtnModificarProducto_Click);
            // 
            // btnSalirProducto
            // 
            this.btnSalirProducto.Location = new System.Drawing.Point(39, 22);
            this.btnSalirProducto.Name = "btnSalirProducto";
            this.btnSalirProducto.Size = new System.Drawing.Size(181, 39);
            this.btnSalirProducto.TabIndex = 2;
            this.btnSalirProducto.Text = "SALIR";
            this.btnSalirProducto.UseSelectable = true;
            this.btnSalirProducto.Click += new System.EventHandler(this.BtnSalirProducto_Click);
            // 
            // tablaProductos
            // 
            this.tablaProductos.AllowUserToAddRows = false;
            this.tablaProductos.AllowUserToDeleteRows = false;
            this.tablaProductos.AllowUserToOrderColumns = true;
            this.tablaProductos.AllowUserToResizeColumns = false;
            this.tablaProductos.AllowUserToResizeRows = false;
            this.tablaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaProductos.BackgroundColor = System.Drawing.Color.Green;
            this.tablaProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tablaProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablaProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaProductos.EnableHeadersVisualStyles = false;
            this.tablaProductos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tablaProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tablaProductos.Location = new System.Drawing.Point(39, 121);
            this.tablaProductos.Name = "tablaProductos";
            this.tablaProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablaProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaProductos.Size = new System.Drawing.Size(1321, 550);
            this.tablaProductos.TabIndex = 30;
            this.tablaProductos.UseCustomBackColor = true;
            this.tablaProductos.UseCustomForeColor = true;
            this.tablaProductos.UseStyleColors = true;
            this.tablaProductos.DataSourceChanged += new System.EventHandler(this.TablaProductos_DataSourceChanged);
            this.tablaProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaProductos_CellClick);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(243, 22);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(246, 39);
            this.btnCargar.TabIndex = 34;
            this.btnCargar.Text = "CARGAR TODOS LOS PRODUCTOS";
            this.btnCargar.UseSelectable = true;
            this.btnCargar.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1400, 781);
            this.ControlBox = false;
            this.Controls.Add(this.tablaProductos);
            this.Controls.Add(this.panelAbajo);
            this.Controls.Add(this.panelArriba);
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Producto";
            this.Resizable = false;
            this.Text = "d1c";
            this.Load += new System.EventHandler(this.Producto_Load);
            this.panelArriba.ResumeLayout(false);
            this.panelArriba.PerformLayout();
            this.panelAbajo.ResumeLayout(false);
            this.panelAbajo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelArriba;
        private MetroFramework.Controls.MetroTextBox txtBusqueda;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBoxMaterial;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox comboBoxCategoria;
        private MetroFramework.Controls.MetroPanel panelAbajo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton btnModificarProducto;
        private MetroFramework.Controls.MetroButton btnSalirProducto;
        private System.Windows.Forms.NumericUpDown txtCantidad;
        private MetroFramework.Controls.MetroGrid tablaProductos;
        private MetroFramework.Controls.MetroLabel lblPrueba;
        private MetroFramework.Controls.MetroLabel lblProductos;
        private MetroFramework.Controls.MetroButton btnCargar;
    }
}