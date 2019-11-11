namespace BasesYMolduras
{
    partial class AlertaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertaControl));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.Label();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(444, 474);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 52);
            this.button1.TabIndex = 47;
            this.button1.Text = "SALIR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(332, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 39);
            this.label1.TabIndex = 48;
            this.label1.Text = "ALERTA DE PEDIDO NUEVO";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(356, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 119);
            this.label2.TabIndex = 49;
            this.label2.Text = "Se ha generado una nueva orden de producción, con los siguientes datos:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.metroPanel1.Controls.Add(this.button1);
            this.metroPanel1.Controls.Add(this.label4);
            this.metroPanel1.Controls.Add(this.txtCliente);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.txtPedido);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(-178, -121);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1157, 693);
            this.metroPanel1.TabIndex = 50;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label4.Location = new System.Drawing.Point(291, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 45);
            this.label4.TabIndex = 54;
            this.label4.Text = "No. de pedido:";
            // 
            // txtCliente
            // 
            this.txtCliente.AutoSize = true;
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Red;
            this.txtCliente.Location = new System.Drawing.Point(532, 352);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(106, 31);
            this.txtCliente.TabIndex = 53;
            this.txtCliente.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(400, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(435, 45);
            this.label3.TabIndex = 52;
            this.label3.Text = "Cliente:";
            // 
            // txtPedido
            // 
            this.txtPedido.AutoSize = true;
            this.txtPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.ForeColor = System.Drawing.Color.Red;
            this.txtPedido.Location = new System.Drawing.Point(532, 406);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(30, 31);
            this.txtPedido.TabIndex = 51;
            this.txtPedido.Text = "0";
            // 
            // AlertaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertaControl";
            this.Resizable = false;
            this.Text = "ALERTA";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AlertaControl_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label txtPedido;
        private System.Windows.Forms.Label txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}