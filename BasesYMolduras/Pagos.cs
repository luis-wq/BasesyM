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
                pod.listarTabla();
            }
            else
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
                Padre.CargarDatos();

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch



            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

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
