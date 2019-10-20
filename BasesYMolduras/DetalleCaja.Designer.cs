namespace BasesYMolduras
{
    partial class DetalleCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleCaja));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lista = new MetroFramework.Controls.MetroGrid();
            this.listaCaja = new MetroFramework.Controls.MetroGrid();
            this.txtNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCierra = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoPedido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.Location = new System.Drawing.Point(403, 203);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(86, 84);
            this.btnAgregar.TabIndex = 32;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregar.UseCompatibleTextRendering = true;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Red;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitar.Location = new System.Drawing.Point(403, 305);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(86, 84);
            this.btnQuitar.TabIndex = 33;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQuitar.UseCompatibleTextRendering = true;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // lista
            // 
            this.lista.AllowUserToAddRows = false;
            this.lista.AllowUserToDeleteRows = false;
            this.lista.AllowUserToOrderColumns = true;
            this.lista.AllowUserToResizeColumns = false;
            this.lista.AllowUserToResizeRows = false;
            this.lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.lista.BackgroundColor = System.Drawing.Color.Green;
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.lista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista.DefaultCellStyle = dataGridViewCellStyle14;
            this.lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lista.EnableHeadersVisualStyles = false;
            this.lista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lista.Location = new System.Drawing.Point(11, 98);
            this.lista.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lista.Name = "lista";
            this.lista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lista.Size = new System.Drawing.Size(362, 407);
            this.lista.TabIndex = 34;
            this.lista.UseCustomBackColor = true;
            this.lista.UseCustomForeColor = true;
            this.lista.UseStyleColors = true;
            // 
            // listaCaja
            // 
            this.listaCaja.AllowUserToAddRows = false;
            this.listaCaja.AllowUserToDeleteRows = false;
            this.listaCaja.AllowUserToOrderColumns = true;
            this.listaCaja.AllowUserToResizeColumns = false;
            this.listaCaja.AllowUserToResizeRows = false;
            this.listaCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.listaCaja.BackgroundColor = System.Drawing.Color.Green;
            this.listaCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaCaja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.listaCaja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaCaja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.listaCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaCaja.DefaultCellStyle = dataGridViewCellStyle17;
            this.listaCaja.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listaCaja.EnableHeadersVisualStyles = false;
            this.listaCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listaCaja.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.listaCaja.Location = new System.Drawing.Point(516, 98);
            this.listaCaja.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listaCaja.Name = "listaCaja";
            this.listaCaja.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaCaja.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.listaCaja.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listaCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaCaja.Size = new System.Drawing.Size(364, 407);
            this.listaCaja.TabIndex = 35;
            this.listaCaja.UseCustomBackColor = true;
            this.listaCaja.UseCustomForeColor = true;
            this.listaCaja.UseStyleColors = true;
            // 
            // txtNombre
            // 
            this.txtNombre.AutoSize = true;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtNombre.Location = new System.Drawing.Point(6, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(251, 26);
            this.txtNombre.TabIndex = 43;
            this.txtNombre.Text = "Detalles de Cotización";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(511, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 26);
            this.label1.TabIndex = 44;
            this.label1.Text = "Detalles en Caja";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 535);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 65);
            this.button1.TabIndex = 46;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnCierra
            // 
            this.btnCierra.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCierra.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCierra.FlatAppearance.BorderSize = 0;
            this.btnCierra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierra.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierra.ForeColor = System.Drawing.Color.White;
            this.btnCierra.Image = ((System.Drawing.Image)(resources.GetObject("btnCierra.Image")));
            this.btnCierra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCierra.Location = new System.Drawing.Point(208, 535);
            this.btnCierra.Margin = new System.Windows.Forms.Padding(0);
            this.btnCierra.Name = "btnCierra";
            this.btnCierra.Size = new System.Drawing.Size(183, 65);
            this.btnCierra.TabIndex = 45;
            this.btnCierra.Text = "Aceptar";
            this.btnCierra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCierra.UseCompatibleTextRendering = true;
            this.btnCierra.UseVisualStyleBackColor = false;
            this.btnCierra.Click += new System.EventHandler(this.BtnCierra_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(424, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 26);
            this.label2.TabIndex = 47;
            this.label2.Text = "Título personalizado";
            // 
            // txtTitulo
            // 
            this.txtTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtTitulo.CustomButton.Image = null;
            this.txtTitulo.CustomButton.Location = new System.Drawing.Point(237, 1);
            this.txtTitulo.CustomButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTitulo.CustomButton.Name = "";
            this.txtTitulo.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtTitulo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTitulo.CustomButton.TabIndex = 1;
            this.txtTitulo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTitulo.CustomButton.UseSelectable = true;
            this.txtTitulo.CustomButton.Visible = false;
            this.txtTitulo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTitulo.Lines = new string[0];
            this.txtTitulo.Location = new System.Drawing.Point(402, 568);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTitulo.MaxLength = 100;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.PasswordChar = '\0';
            this.txtTitulo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTitulo.SelectedText = "";
            this.txtTitulo.SelectionLength = 0;
            this.txtTitulo.SelectionStart = 0;
            this.txtTitulo.ShortcutsEnabled = true;
            this.txtTitulo.Size = new System.Drawing.Size(265, 29);
            this.txtTitulo.TabIndex = 48;
            this.txtTitulo.UseSelectable = true;
            this.txtTitulo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTitulo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(695, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 26);
            this.label3.TabIndex = 49;
            this.label3.Text = "Peso";
            // 
            // txtNoPedido
            // 
            this.txtNoPedido.AutoSize = true;
            this.txtNoPedido.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPedido.ForeColor = System.Drawing.Color.Teal;
            this.txtNoPedido.Location = new System.Drawing.Point(695, 568);
            this.txtNoPedido.Name = "txtNoPedido";
            this.txtNoPedido.Size = new System.Drawing.Size(147, 25);
            this.txtNoPedido.TabIndex = 50;
            this.txtNoPedido.Text = "00.00 / 00.00 KG.";
            // 
            // DetalleCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.txtNoPedido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCierra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.listaCaja);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Name = "DetalleCaja";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "DetalleCaja";
            this.Load += new System.EventHandler(this.DetalleCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private MetroFramework.Controls.MetroGrid lista;
        private MetroFramework.Controls.MetroGrid listaCaja;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCierra;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox txtTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtNoPedido;
    }
}