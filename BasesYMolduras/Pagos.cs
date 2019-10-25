using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        int bandera, tareaBandera, idCotizacion;
        double total, pagado;
        string tipo_usuario, id;
        DataTable datosPagos, datosCuenta;

        private void BtnControl_Click(object sender, EventArgs e)
        {
            double bass = Convert.ToDouble(txtTotal.Text);
            pagado = Convert.ToDouble(txtPagado.Text);
            if (pagado >= bass) {
                MetroFramework.MetroMessageBox.
                  Show(this, "El monto pagado es mayor al adeudo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            AgregarPago form = new AgregarPago(this, Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]), total, pagado);
            form.Show();
            this.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            VerPago verpago = new VerPago(this,Convert.ToString(datosPagos.Rows[lista.CurrentRow.Index]["URL_pago"]));
            verpago.Show();
            this.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (bandera == 0)
            {
                pad.Enabled = true;
                pad.FocusMe();
                this.Close();
            }
            else
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
            }
        }

        public Pagos(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCotizacion)
        {
            InitializeComponent();
            this.Padre = padre;
            this.bandera = bandera;
            this.tareaBandera = tareaBandera;
            this.tipo_usuario = tipo_usuario;
            this.id = id;
            this.idCotizacion = idCotizacion;
        }

        public Pagos(CotizacionesRealizadas padreN, int idCotizacion, int bandera)
        {
            this.pad = padreN;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            InitializeComponent();
            
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
        }

        public void CargarDatosHilo() {
            double pagado = 0;
            int i = 0;
            datosCuenta = BD.listarCuenta(idCotizacion);
            datosPagos = BD.listarPagos(Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]));
            lista.DataSource = datosPagos;
            try
            {
                foreach (DataGridViewRow row in lista.Rows)
                {
                    pagado = pagado + Convert.ToDouble(datosPagos.Rows[i]["monto_pagado"]);
                    i++;
                }
                txtPagado.Text = Convert.ToString(pagado) + ".00";
            }
            catch {
                txtPagado.Text = "00.00";
            }
            total = Convert.ToDouble(datosCuenta.Rows[0]["monto_total"]);
            txtTotal.Text = Convert.ToString(datosCuenta.Rows[0]["monto_total"]) + ".00";
        }

 
    }
}
