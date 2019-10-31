﻿using System;
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
    public partial class ControlEstado : MetroFramework.Forms.MetroForm
    {
        Inicio padre;
        DataTable datosCotizaciones, datosCotizacion, producciones;
        string fecha;
        int contador = 0, aux, auxY, locY, cotizacionActual;
        DateTime t;
        public ControlEstado(Inicio padre, DateTime t)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.padre = padre;
            this.t = t;
        }

        private void ControlEstado_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Black;
            CargarProducciones();
        }

        public void CargarProducciones() {
            //obtenerFecha();
            datosCotizaciones = BD.consultaMaxCotizacion();
            cotizacionActual = Convert.ToInt32(datosCotizaciones.Rows[0]["id_cotizacion"]);
            timer1.Enabled = true;
            int i = 0;
            producciones = BD.DatosCotizacionForPrioridad();
            foreach (DataRow row in producciones.Rows)
            {
                AgregarBoton(Convert.ToString(producciones.Rows[i]["id_cotizacion"]), Convert.ToString(producciones.Rows[i]["razon_social"]),
                    Convert.ToString(producciones.Rows[i]["Fecha"]), Convert.ToString(producciones.Rows[i]["NoCotizacionesCliente"]),
                    Convert.ToString(producciones.Rows[i]["estado"]), Convert.ToString(producciones.Rows[i]["Prioridad"]));
                i++;
            }
        }

        public void CargarProduccionesB()
        {

            aux = 0;
            auxY = 0;
            locY = 0;
            contador = 0;
            //obtenerFecha();
            //datosCotizaciones = BD.consultaMaxCotizacion();
            //cotizacionActual = Convert.ToInt32(datosCotizaciones.Rows[0]["id_cotizacion"]);
            //timer1.Enabled = true;
            int i = 0;
            producciones = null;
            producciones = BD.DatosCotizacionForPrioridad();
            foreach (DataRow row in producciones.Rows)
            {
                AgregarBoton(Convert.ToString(producciones.Rows[i]["id_cotizacion"]), Convert.ToString(producciones.Rows[i]["razon_social"]),
                    Convert.ToString(producciones.Rows[i]["Fecha"]), Convert.ToString(producciones.Rows[i]["NoCotizacionesCliente"]),
                    Convert.ToString(producciones.Rows[i]["estado"]), Convert.ToString(producciones.Rows[i]["Prioridad"]));
                i++;
            }
        }
        private void AgregarBoton(string idCotizacion,string cliente,string fecha,string NoPedido,string estado,string urgencia) {
            Button btn = new Button();
            Button btnAux = new Button();
            Panel panelN = new Panel();
            AgregarPropiedadesButtonAux(btnAux,urgencia);
            AgregarPropiedades(btn,idCotizacion,cliente,fecha,NoPedido,estado);
            if (contador == 0)
            {
                AgregarPanel(panelN,"nada");
            }
            else
            {
                AgregarPanel(panelN);
            }
            panelN.Controls.Add(btn);
            panelN.Controls.Add(btnAux);
            panel.Controls.Add(panelN);
        }

        public void limpiarPanel() {
            panel.Controls.Clear();
            CargarProduccionesB();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            timer1.Stop();
            this.Close();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MetroPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarPanel(Panel panel) {
            int loc = aux + 10;
            locY = auxY;
            if (aux >= 920)
            {
                loc = 1;
                auxY = auxY + 209;
                locY = auxY;
                panel.Location = new Point(loc, locY);
                aux = 220;
            }
            else {
                panel.Location = new Point(loc, locY);
                aux = aux + 220;
            }
            panel.Size = new Size(220,200);
            contador++;
        }
        private void AgregarPanel(Panel panel,String nada)
        {
            panel.Location = new Point(1, 1);
            panel.Size = new Size(220, 200);
            aux = 220;
            auxY = 1;
            contador++;
        }
        private void AgregarPropiedades(Button btn, string id, string razonsocial, string fecha, string pedido, string estado) {
            btn.Name = "btn" + fecha;
            //Color color = System.Drawing.ColorTranslator.FromHtml("#C2E8F0");
            Color color = Color.Black;
            btn.BackColor = color;
            btn.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Size = new Size(220, 150);
            btn.Location = new Point(1, 1);
            btn.Text = "Cotización " + id + "\n " + razonsocial + "\n " + fecha + " \n Pedido " + pedido + " \n " + estado;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Click += (s, e) => {
                
                string fechaM = "";
                int dia = Convert.ToInt32(t.Day);
                if (dia < 10 && Convert.ToInt32(t.Month)>=10) {
                    fechaM = t.Year + "-" + t.Month + "-" + "0" + t.Day;
                }
                if (t.Day < 10 && t.Month < 10) {
                    fechaM = t.Year + "-" + "0"+t.Month + "-" + "0" + t.Day;
                }
                if (t.Day >= 10 && t.Month < 10) {
                    fechaM = t.Year + "-" + "0"+t.Month + "-" + t.Day;
                }
                if (t.Day >= 10 && t.Month >= 10)
                {
                    fechaM = t.Year + "-" + t.Month + "-" + t.Day;
                }

                DetalleControl form = new DetalleControl(this,Convert.ToInt32(id),fechaM);
                form.Show();
                this.Enabled = false;
            };
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            datosCotizaciones = null;
            BD.conexion.Close();
            datosCotizaciones = BD.consultaMaxCotizacion();
            if (cotizacionActual < Convert.ToInt32(datosCotizaciones.Rows[0]["id_cotizacion"]))
            {
                AlertaControl form = new AlertaControl();
                form.Show();
                cotizacionActual = Convert.ToInt32(datosCotizaciones.Rows[0]["id_cotizacion"]);
                datosCotizacion = BD.DatosCotizacion(cotizacionActual);
                AgregarBoton(Convert.ToString(cotizacionActual),Convert.ToString(datosCotizacion.Rows[0]["razon_social"]),
                    Convert.ToString(datosCotizacion.Rows[0]["Fecha"]), Convert.ToString(datosCotizacion.Rows[0]["NoCotizacionesCliente"]),
                    Convert.ToString(datosCotizacion.Rows[0]["estado"]), Convert.ToString(datosCotizacion.Rows[0]["Prioridad"]));
            }
        }

        private void AgregarPropiedadesButtonAux(Button btn,string urgencia)
        {
            btn.Name = "btnAux" + fecha;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            btn.Size = new Size(220, 30);
            btn.Location = new Point(1, 151);
            if (urgencia.Equals("NORMAL"))
            {
                btn.BackColor = Color.Green;
            }
            else {
                btn.BackColor = Color.Red;
            }
            btn.Text = urgencia;
            btn.TextAlign = ContentAlignment.TopCenter;
        }

        private string obtenerFecha()
        {
            t = BD.ObtenerFecha();
            return fecha = Convert.ToString(t.Day + t.Month + t.Year + t.Hour + t.Minute + t.Second);
        }

    }
}
