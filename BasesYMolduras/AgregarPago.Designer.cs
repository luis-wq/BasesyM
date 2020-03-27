namespace BasesYMolduras
{
    partial class AgregarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarPago));
            this.btnControl = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.txtMontoPagado = new MetroFramework.Controls.MetroTextBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.checkEfec = new MetroFramework.Controls.MetroCheckBox();
            this.checkDep = new MetroFramework.Controls.MetroCheckBox();
            this.checkTrans = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtConcepto = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel4.SuspendLayout();
            this.SuspendLayout();
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
            this.btnControl.Location = new System.Drawing.Point(210, 24);
            this.btnControl.Margin = new System.Windows.Forms.Padding(0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(170, 76);
            this.btnControl.TabIndex = 16;
            this.btnControl.Text = " Agregar";
            this.btnControl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControl.UseCompatibleTextRendering = true;
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.BtnControl_Click);
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
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(20, 24);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(170, 76);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Salir";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseCompatibleTextRendering = true;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel1.Controls.Add(this.btnEliminar);
            this.metroPanel1.Controls.Add(this.btnControl);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(381, 616);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(396, 128);
            this.metroPanel1.TabIndex = 18;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel2.Controls.Add(this.txtMontoPagado);
            this.metroPanel2.Controls.Add(this.txtTotal);
            this.metroPanel2.Controls.Add(this.label14);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(381, 109);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(396, 90);
            this.metroPanel2.TabIndex = 19;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtMontoPagado.CustomButton.Image = null;
            this.txtMontoPagado.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.txtMontoPagado.CustomButton.Name = "";
            this.txtMontoPagado.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtMontoPagado.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMontoPagado.CustomButton.TabIndex = 1;
            this.txtMontoPagado.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMontoPagado.CustomButton.UseSelectable = true;
            this.txtMontoPagado.CustomButton.Visible = false;
            this.txtMontoPagado.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMontoPagado.Lines = new string[] {
        "$0.00"};
            this.txtMontoPagado.Location = new System.Drawing.Point(102, 46);
            this.txtMontoPagado.MaxLength = 40;
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.PasswordChar = '\0';
            this.txtMontoPagado.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMontoPagado.SelectedText = "";
            this.txtMontoPagado.SelectionLength = 0;
            this.txtMontoPagado.SelectionStart = 0;
            this.txtMontoPagado.ShortcutsEnabled = true;
            this.txtMontoPagado.Size = new System.Drawing.Size(127, 29);
            this.txtMontoPagado.TabIndex = 22;
            this.txtMontoPagado.Text = "$0.00";
            this.txtMontoPagado.UseSelectable = true;
            this.txtMontoPagado.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMontoPagado.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRazonSocial_KeyPress);
            this.txtMontoPagado.Leave += new System.EventHandler(this.TxtMontoPagado_Leave);
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(234, 51);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(45, 24);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.Text = "00.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(130, 9);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 24);
            this.label14.TabIndex = 20;
            this.label14.Text = "Ingresar Monto";
            // 
            // metroPanel3
            // 
            this.metroPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel3.Controls.Add(this.button1);
            this.metroPanel3.Controls.Add(this.pictureBox1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(381, 245);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(396, 183);
            this.metroPanel3.TabIndex = 20;
            this.metroPanel3.UseCustomBackColor = true;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(249, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 76);
            this.button1.TabIndex = 18;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(23, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel4.Controls.Add(this.metroPanel2);
            this.metroPanel4.Controls.Add(this.checkEfec);
            this.metroPanel4.Controls.Add(this.checkDep);
            this.metroPanel4.Controls.Add(this.checkTrans);
            this.metroPanel4.Controls.Add(this.metroLabel4);
            this.metroPanel4.Controls.Add(this.metroPanel3);
            this.metroPanel4.Controls.Add(this.txtConcepto);
            this.metroPanel4.Controls.Add(this.metroPanel1);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(-378, -46);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(1157, 778);
            this.metroPanel4.TabIndex = 31;
            this.metroPanel4.UseCustomBackColor = true;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // checkEfec
            // 
            this.checkEfec.AutoEllipsis = true;
            this.checkEfec.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkEfec.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.checkEfec.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.checkEfec.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkEfec.Location = new System.Drawing.Point(650, 450);
            this.checkEfec.Name = "checkEfec";
            this.checkEfec.Size = new System.Drawing.Size(111, 44);
            this.checkEfec.TabIndex = 59;
            this.checkEfec.Text = "Efectivo";
            this.checkEfec.UseCustomBackColor = true;
            this.checkEfec.UseCustomForeColor = true;
            this.checkEfec.UseSelectable = true;
            this.checkEfec.CheckedChanged += new System.EventHandler(this.CheckEfec_CheckedChanged);
            // 
            // checkDep
            // 
            this.checkDep.AutoEllipsis = true;
            this.checkDep.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkDep.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.checkDep.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.checkDep.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkDep.Location = new System.Drawing.Point(526, 450);
            this.checkDep.Name = "checkDep";
            this.checkDep.Size = new System.Drawing.Size(110, 44);
            this.checkDep.TabIndex = 58;
            this.checkDep.Text = "Deposito";
            this.checkDep.UseCustomBackColor = true;
            this.checkDep.UseCustomForeColor = true;
            this.checkDep.UseSelectable = true;
            this.checkDep.CheckedChanged += new System.EventHandler(this.CheckDep_CheckedChanged);
            // 
            // checkTrans
            // 
            this.checkTrans.AutoEllipsis = true;
            this.checkTrans.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkTrans.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.checkTrans.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.checkTrans.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.checkTrans.Location = new System.Drawing.Point(381, 450);
            this.checkTrans.Name = "checkTrans";
            this.checkTrans.Size = new System.Drawing.Size(139, 44);
            this.checkTrans.TabIndex = 57;
            this.checkTrans.Text = "Transferencia";
            this.checkTrans.UseCustomBackColor = true;
            this.checkTrans.UseCustomForeColor = true;
            this.checkTrans.UseSelectable = true;
            this.checkTrans.CheckedChanged += new System.EventHandler(this.CheckTrans_CheckedChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.BackColor = System.Drawing.Color.OrangeRed;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.ForeColor = System.Drawing.Color.White;
            this.metroLabel4.Location = new System.Drawing.Point(401, 516);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(360, 28);
            this.metroLabel4.TabIndex = 50;
            this.metroLabel4.Text = "Concepto de:";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // txtConcepto
            // 
            this.txtConcepto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtConcepto.CustomButton.Image = null;
            this.txtConcepto.CustomButton.Location = new System.Drawing.Point(308, 2);
            this.txtConcepto.CustomButton.Name = "";
            this.txtConcepto.CustomButton.Size = new System.Drawing.Size(49, 49);
            this.txtConcepto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConcepto.CustomButton.TabIndex = 1;
            this.txtConcepto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConcepto.CustomButton.UseSelectable = true;
            this.txtConcepto.CustomButton.Visible = false;
            this.txtConcepto.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtConcepto.Lines = new string[0];
            this.txtConcepto.Location = new System.Drawing.Point(401, 544);
            this.txtConcepto.MaxLength = 200;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.PasswordChar = '\0';
            this.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConcepto.SelectedText = "";
            this.txtConcepto.SelectionLength = 0;
            this.txtConcepto.SelectionStart = 0;
            this.txtConcepto.ShortcutsEnabled = true;
            this.txtConcepto.Size = new System.Drawing.Size(360, 54);
            this.txtConcepto.TabIndex = 49;
            this.txtConcepto.UseCustomBackColor = true;
            this.txtConcepto.UseSelectable = true;
            this.txtConcepto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConcepto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AgregarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 698);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "AgregarPago";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "PAGO NUEVO";
            this.Load += new System.EventHandler(this.AgregarPago_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnEliminar;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label14;
        private MetroFramework.Controls.MetroTextBox txtMontoPagado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtConcepto;
        private MetroFramework.Controls.MetroCheckBox checkEfec;
        private MetroFramework.Controls.MetroCheckBox checkDep;
        private MetroFramework.Controls.MetroCheckBox checkTrans;
    }
}