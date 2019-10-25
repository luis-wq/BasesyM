namespace BasesYMolduras
{
    partial class Seguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seguridad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelarC = new MetroFramework.Controls.MetroButton();
            this.btnContra = new MetroFramework.Controls.MetroButton();
            this.txtContra = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 54);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 36);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña de seguridad";
            this.label2.UseWaitCursor = true;
            // 
            // btnCancelarC
            // 
            this.btnCancelarC.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelarC.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCancelarC.ForeColor = System.Drawing.Color.White;
            this.btnCancelarC.Location = new System.Drawing.Point(179, 199);
            this.btnCancelarC.Name = "btnCancelarC";
            this.btnCancelarC.Size = new System.Drawing.Size(155, 44);
            this.btnCancelarC.TabIndex = 8;
            this.btnCancelarC.Text = "CANCELAR";
            this.btnCancelarC.UseCustomBackColor = true;
            this.btnCancelarC.UseCustomForeColor = true;
            this.btnCancelarC.UseSelectable = true;
            this.btnCancelarC.Click += new System.EventHandler(this.BtnCancelarC_Click);
            // 
            // btnContra
            // 
            this.btnContra.BackColor = System.Drawing.Color.DarkGreen;
            this.btnContra.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnContra.ForeColor = System.Drawing.Color.White;
            this.btnContra.Location = new System.Drawing.Point(344, 199);
            this.btnContra.Name = "btnContra";
            this.btnContra.Size = new System.Drawing.Size(155, 44);
            this.btnContra.TabIndex = 7;
            this.btnContra.Text = "CONTINUAR";
            this.btnContra.UseCustomBackColor = true;
            this.btnContra.UseCustomForeColor = true;
            this.btnContra.UseSelectable = true;
            this.btnContra.Click += new System.EventHandler(this.BtnContra_Click);
            // 
            // txtContra
            // 
            // 
            // 
            // 
            this.txtContra.CustomButton.Image = null;
            this.txtContra.CustomButton.Location = new System.Drawing.Point(286, 1);
            this.txtContra.CustomButton.Name = "";
            this.txtContra.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtContra.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContra.CustomButton.TabIndex = 1;
            this.txtContra.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContra.CustomButton.UseSelectable = true;
            this.txtContra.CustomButton.Visible = false;
            this.txtContra.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtContra.Lines = new string[0];
            this.txtContra.Location = new System.Drawing.Point(179, 149);
            this.txtContra.MaxLength = 5;
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '*';
            this.txtContra.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContra.SelectedText = "";
            this.txtContra.SelectionLength = 0;
            this.txtContra.SelectionStart = 0;
            this.txtContra.ShortcutsEnabled = true;
            this.txtContra.Size = new System.Drawing.Size(320, 35);
            this.txtContra.TabIndex = 6;
            this.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContra.UseSelectable = true;
            this.txtContra.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContra.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(163, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Introduzca contraseña para continuar:\r\n";
            this.label1.UseWaitCursor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(-242, -200);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1157, 693);
            this.metroPanel1.TabIndex = 31;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // Seguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(672, 293);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarC);
            this.Controls.Add(this.btnContra);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Seguridad";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.Seguridad_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton btnCancelarC;
        private MetroFramework.Controls.MetroButton btnContra;
        private MetroFramework.Controls.MetroTextBox txtContra;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
    }
}