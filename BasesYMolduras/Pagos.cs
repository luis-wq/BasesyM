using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class Pagos : MetroFramework.Forms.MetroForm
    {
        Listados Padre;
        CotizacionesRealizadas pad;
        Produccion pod;
        int bandera, tareaBandera, idCotizacion;
        double total, pagado;
        string tipo_usuario, id;
        DataTable datosPagos, datosCuenta;
        DateTime t;

        private void BtnControl_Click(object sender, EventArgs e)
        {
                double bass = Convert.ToDouble(total);
                pagado = Convert.ToDouble(pagado);
                if (pagado >= bass)
                {
                    MetroFramework.MetroMessageBox.
                      Show(this, "El monto pagado es mayor al adeudo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                AgregarPago form = new AgregarPago(this, Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]), total, pagado,t);
                form.Show();
                this.Enabled = false;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] b = (byte[])datosPagos.Rows[lista.CurrentRow.Index]["Imagen"];
                VerPago verpago = new VerPago(this, Convert.ToString(datosPagos.Rows[lista.CurrentRow.Index]["URL_pago"]), b);

                verpago.Show();
                this.Enabled = false;
            }
            catch {
                MetroFramework.MetroMessageBox.
                  Show(this, "No has seleccionado un pago o no se encuentra ningún pago registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (bandera == 0)
            {
                pad.Enabled = true;
                pad.FocusMe();
                this.Close();
            }
            else if(bandera == 6)
            {
                pod.Enabled = true;
                pod.FocusMe();
                this.Close();
            }
            else
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
                Padre.CargarDatos();

            }
        }

        public Pagos(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCotizacion, DateTime t)
        {
            InitializeComponent();
            this.Padre = padre;
            this.bandera = bandera;
            this.tareaBandera = tareaBandera;
            this.tipo_usuario = tipo_usuario;
            this.id = id;
            this.idCotizacion = idCotizacion;
            this.t = t;
        }

        public Pagos(CotizacionesRealizadas padreN, int idCotizacion, int bandera,DateTime t)
        {
            InitializeComponent();
            this.pad = padreN;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            this.t = t;
            
        }
        public Pagos(Produccion padreP, int idCotizacion, int bandera,DateTime t)
        {

            InitializeComponent();
            this.pod = padreP;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            this.t = t;

        }



        private void Pagos_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
        }

        public void CargarDatosHilo() {
            pagado = 0;
            int i = 0;
            datosCuenta = BD.listarCuenta(idCotizacion);
            datosPagos = BD.listarPagos(Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]));
            lista.DataSource = datosPagos;
            lista.Columns["monto_pagado"].DefaultCellStyle.Format = "C2";
            lista.Columns["Imagen"].Visible = false;
            try
            {
                foreach (DataGridViewRow row in lista.Rows)
                {
                    pagado = pagado + Convert.ToDouble(datosPagos.Rows[i]["monto_pagado"]);
                    i++;
                }
                txtPagado.Text = string.Format("{0:c2}", pagado); 
            }
            catch {
                txtPagado.Text = "$"+"00.00";
            }
            total = Convert.ToDouble(datosCuenta.Rows[0]["monto_total"]);
            txtTotal.Text = string.Format("{0:c2}", total); 
            Double restante = total - pagado;
            txtResta.Text = string.Format("{0:c2}", restante);
        }

 
    }
}
