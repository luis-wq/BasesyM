namespace BasesYMolduras
{
    partial class Produccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion));
            this.lista = new MetroFramework.Controls.MetroGrid();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.lblNumPedidos = new MetroFramework.Controls.MetroLabel();
            this.btnPagos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.metroPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista.DefaultCellStyle = dataGridViewCellStyle2;
            this.lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lista.EnableHeadersVisualStyles = false;
            this.lista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lista.GridColor = System.Drawing.Color.White;
            this.lista.Location = new System.Drawing.Point(28, 60);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.lista.RowHeadersVisible = false;
            this.lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lista.Size = new System.Drawing.Size(1159, 492);
            this.lista.TabIndex = 19;
            this.lista.UseCustomBackColor = true;
            this.lista.UseCustomForeColor = true;
            this.lista.UseStyleColors = true;
            this.lista.DataSourceChanged += new System.EventHandler(this.Lista_DataSourceChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(23, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(247, 25);
            this.lblTitulo.TabIndex = 30;
            this.lblTitulo.Text = "PEDIDOS EN PRODUCCIÓN:";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitulo.UseCustomBackColor = true;
            this.lblTitulo.UseCustomForeColor = true;
            this.lblTitulo.UseStyleColors = true;
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
            this.btnDetalles.Location = new System.Drawing.Point(212, 573);
            this.btnDetalles.Margin = new System.Windows.Forms.Padding(0);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(172, 81);
            this.btnDetalles.TabIndex = 31;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetalles.UseCompatibleTextRendering = true;
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.BtnDetalles_Click);
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
            this.btnSalir.Location = new System.Drawing.Point(28, 573);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(172, 81);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseCompatibleTextRendering = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // metroPanel4
            // 
            this.metroPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel4.Controls.Add(this.pictureBox1);
            this.metroPanel4.Controls.Add(this.btnDetalles);
            this.metroPanel4.Controls.Add(this.btnSalir);
            this.metroPanel4.Controls.Add(this.lblNumPedidos);
            this.metroPanel4.Controls.Add(this.btnPagos);
            this.metroPanel4.Controls.Add(this.lista);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(-5, 3);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(1238, 698);
            this.metroPanel4.TabIndex = 40;
            this.metroPanel4.UseCustomBackColor = true;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // lblNumPedidos
            // 
            this.lblNumPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.lblNumPedidos.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNumPedidos.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNumPedidos.ForeColor = System.Drawing.Color.Crimson;
            this.lblNumPedidos.Location = new System.Drawing.Point(269, 18);
            this.lblNumPedidos.Name = "lblNumPedidos";
            this.lblNumPedidos.Size = new System.Drawing.Size(142, 25);
            this.lblNumPedidos.TabIndex = 41;
            this.lblNumPedidos.Text = "0";
            this.lblNumPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNumPedidos.UseCustomBackColor = true;
            this.lblNumPedidos.UseCustomForeColor = true;
            this.lblNumPedidos.UseStyleColors = true;
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
            this.btnPagos.Location = new System.Drawing.Point(396, 573);
            this.btnPagos.Margin = new System.Windows.Forms.Padding(0);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(172, 81);
            this.btnPagos.TabIndex = 37;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagos.UseCompatibleTextRendering = true;
            this.btnPagos.UseVisualStyleBackColor = false;
            this.btnPagos.Click += new System.EventHandler(this.BtnPagos_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(983, 558);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // Produccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1205, 677);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.metroPanel4);
            this.Movable = false;
            this.Name = "Produccion";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "7";
            this.Load += new System.EventHandler(this.Produccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.metroPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid lista;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnSalir;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private System.Windows.Forms.Button btnPagos;
        private MetroFramework.Controls.MetroLabel lblNumPedidos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}