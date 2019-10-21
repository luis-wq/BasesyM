namespace BasesYMolduras
{
    partial class Cajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cajas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCierra = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.Label();
            this.txtPesoTotal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(23, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 379);
            this.panel1.TabIndex = 20;
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
            this.btnCierra.Location = new System.Drawing.Point(597, 365);
            this.btnCierra.Margin = new System.Windows.Forms.Padding(0);
            this.btnCierra.Name = "btnCierra";
            this.btnCierra.Size = new System.Drawing.Size(183, 65);
            this.btnCierra.TabIndex = 40;
            this.btnCierra.Text = "Agregar";
            this.btnCierra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCierra.UseCompatibleTextRendering = true;
            this.btnCierra.UseVisualStyleBackColor = false;
            this.btnCierra.Click += new System.EventHandler(this.BtnCierra_Click);
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
            this.button1.Location = new System.Drawing.Point(384, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 65);
            this.button1.TabIndex = 41;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.AutoSize = true;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Green;
            this.txtNombre.Location = new System.Drawing.Point(592, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 26);
            this.txtNombre.TabIndex = 42;
            this.txtNombre.Text = "Peso Total:";
            // 
            // txtPesoTotal
            // 
            this.txtPesoTotal.AutoSize = true;
            this.txtPesoTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoTotal.ForeColor = System.Drawing.Color.Teal;
            this.txtPesoTotal.Location = new System.Drawing.Point(612, 102);
            this.txtPesoTotal.Name = "txtPesoTotal";
            this.txtPesoTotal.Size = new System.Drawing.Size(97, 30);
            this.txtPesoTotal.TabIndex = 43;
            this.txtPesoTotal.Text = "00.00 Kg.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(278, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 71);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // Cajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPesoTotal);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCierra);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Cajas";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.Cajas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCierra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label txtPesoTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}