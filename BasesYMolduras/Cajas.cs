using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class Cajas : MetroFramework.Forms.MetroForm
    {
        DetalleControl padre;
        int contCajas = 0, contDetalleC = 0;
        int auxY = 1, idCotizacion;
        DataTable cajas, detalleCaja, detalleCotizacion;
        double pesoTotal = 0, auxPeso = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }

        public Cajas(DetalleControl padre, int idCotizacion)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            detalleCotizacion = BD.ConsultaCotizacionById(this.idCotizacion);
        }

        private void Cajas_Load(object sender, EventArgs e)
        {
            cajas = BD.consultaCajas(idCotizacion);
            cargarDatos();
        }

        public void Refrescar() {
            panel1.Controls.Clear();
            contCajas = 0;
            contDetalleC = 0;
            auxY = 1;
            pesoTotal = 0;
            auxPeso = 0;
            cajas = BD.consultaCajas(idCotizacion);
            cargarDatos();
        }
        public void cargarDatos() {
            foreach (DataRow row in cajas.Rows)
            {
                detalleCaja = BD.consultaDetalleCajas(Convert.ToInt32(cajas.Rows[contCajas]["id_caja"]));
                foreach (DataRow detalle in detalleCaja.Rows) {
                    pesoTotal = pesoTotal + Convert.ToDouble(detalleCaja.Rows[contDetalleC]["peso"]);
                    contDetalleC++;
                }
                Button btn = new Button();
                AgregarPropiedades(btn,Convert.ToInt32(cajas.Rows[contCajas]["id_caja"]),pesoTotal);
                panel1.Controls.Add(btn);
                contCajas++;
                pesoTotal = 0;
            }
            txtPesoTotal.Text = Convert.ToString(detalleCotizacion.Rows[0]["pesoTotal"]);
        }
        private void BtnCierra_Click(object sender, EventArgs e)
        {
            int numero_caja = Convert.ToInt32(cajas.Rows[contCajas-1]["numero_cajas"]) + 1;
            BD.insertarCaja(numero_caja, idCotizacion,"0.00");
            Refrescar();
        }

        private void AgregarPropiedades(Button btn, int IdCaja,double pesoTotal)
        {
            //btn.Name = Convert.ToString(cajas.Rows[contador]["id_caja"]);
            btn.Name = Convert.ToString(IdCaja);
            Color color = Color.DarkViolet;
            btn.BackColor = color;
            btn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Size = new Size(232, 90); 
            btn.Location = new Point(1, auxY);
            btn.Text = "Caja " + pesoTotal + " /30Kg.";
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Click += (s, e) => {
                DetalleCaja form = new DetalleCaja(this,idCotizacion,Convert.ToInt32(btn.Name));
                this.Enabled = false;
                form.Show();
            };
            auxY = auxY + 92;
        } 

    }
}
