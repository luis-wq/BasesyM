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
        CotizacionesRealizadas padreN;
        int contCajas = 0, contDetalleC = 0;
        int auxY = 1, idCotizacion;
        int bandera = 1;
        DataTable cajas, detalleCaja, detalleCotizacion;
        double pesoTotal = 0, auxPeso = 0;
        Dictionary<String, int> ids = new Dictionary<string, int>();

        private void Button1_Click(object sender, EventArgs e)
        {
            if (bandera == 0)
            {
                padreN.Enabled = true;
                padreN.FocusMe();
                this.Close();
            }
            else
            {
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
            }
        }

        public Cajas(DetalleControl padre, int idCotizacion)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            detalleCotizacion = BD.ConsultaCotizacionById(this.idCotizacion);
        }

        public Cajas(CotizacionesRealizadas padre, int idCotizacion, int bandera)
        {
            InitializeComponent();
            this.padreN = padre;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            detalleCotizacion = BD.ConsultaCotizacionById(this.idCotizacion);
        }

        private void Cajas_Load(object sender, EventArgs e)
        {
            if (bandera == 0) {
                txtSoloLectura.Visible = true;
                btnCierra.Enabled = false;
                button3.Enabled = false;
            }
            cajas = BD.consultaCajas(idCotizacion);
            cargarDatos();
        }

        public void Refrescar() {
            ids.Clear();
            contCajas = 0;
            contDetalleC = 0;
            auxY = 1;
            pesoTotal = 0;
            auxPeso = 0;
            cajas = BD.consultaCajas(idCotizacion);
            cargarDatos();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bandera == 0)
                {
                    DetalleCaja form = new DetalleCaja(this, idCotizacion, Convert.ToInt32(lista.CurrentRow.Cells["id_caja"].Value), 0);
                    this.Enabled = false;
                    form.Show();
                }
                else
                {
                    DetalleCaja form = new DetalleCaja(this, idCotizacion, Convert.ToInt32(lista.CurrentRow.Cells["id_caja"].Value));
                    this.Enabled = false;
                    form.Show();
                }
            }
            catch {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Debes seleccionar una caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir.", "¿Estas seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes) {
                if (bandera == 0)
                {
                    padreN.Enabled = true;
                    padreN.FocusMe();
                    this.Close();
                }
                else
                {
                    padre.Enabled = true;
                    padre.FocusMe();
                    padre.AgregarEstado(6);
                    this.Close();
                }
            }
        }

        public void cargarDatos() {
            foreach (DataRow row in cajas.Rows)
            {
                /*detalleCaja = BD.consultaDetalleCajas(Convert.ToInt32(cajas.Rows[contCajas]["id_caja"]));
                foreach (DataRow detalle in detalleCaja.Rows) {
                    pesoTotal = pesoTotal + Convert.ToDouble(detalleCaja.Rows[contDetalleC]["peso"]);
                    contDetalleC++;
                }*/
                contCajas++;
/*                Button btn = new Button();
                AgregarPropiedades(btn,Convert.ToInt32(cajas.Rows[contCajas]["id_caja"]),"Caja " + Convert.ToString(cajas.Rows[contCajas]["numero_cajas"]) + " " +Convert.ToString(cajas.Rows[contCajas]["titulo"]));
                panel1.Controls.Add(btn);
                contCajas++;
                pesoTotal = 0;*/
            }
            lista.DataSource = null;
            lista.DataSource = cajas;
            lista.Columns[lista.Columns["id_caja"].Index].Visible = false;
            lista.Columns[lista.Columns["id_cotizacion"].Index].Visible = false;
            lista.Columns[lista.Columns["peso_total"].Index].Visible = false;
            txtPesoTotal.Text = Convert.ToString(detalleCotizacion.Rows[0]["pesoTotal"]);
        }
        private void BtnCierra_Click(object sender, EventArgs e)
        {
            int numero_caja = Convert.ToInt32(cajas.Rows[cajas.Rows.Count-1]["#"]) + 1;
            BD.insertarCaja(numero_caja, idCotizacion,"0.00","Sin titulo");
            /*DataTable temporalIdCaja = BD.ObtenerUltimaCaja(idCotizacion);
            BD.insertarDetalleCaja(idCotizacion, Convert.ToInt32(temporalIdCaja.Rows[0]["id_caja"]));*/
            Refrescar();
        }

        private void AgregarPropiedades(Button btn, int IdCaja,string titulo)
        {
            //btn.Name = Convert.ToString(cajas.Rows[contador]["id_caja"]);
            btn.Name = Convert.ToString(IdCaja);
            agregarIdCaja(Convert.ToString(IdCaja), IdCaja);
            Color color = Color.DarkViolet;
            btn.BackColor = color;
            btn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Size = new Size(232, 90); 
            btn.Location = new Point(1, auxY);
            btn.Text = titulo;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Click += (s, e) => {
                if (bandera == 0)
                {
                    DetalleCaja form = new DetalleCaja(this, idCotizacion, obtenerIdCaja(btn.Name), 0);
                    this.Enabled = false;
                    form.Show();
                }
                else
                {
                    DetalleCaja form = new DetalleCaja(this, idCotizacion, obtenerIdCaja(btn.Name));
                    this.Enabled = false;
                    form.Show();
                }
            };
            auxY = auxY + 92;
        }

        private void agregarIdCaja(String nombreControl, int idCaja) {
            ids.Add(nombreControl, idCaja);
        }
        private int obtenerIdCaja(String nombrecontrol) {
            int id = ids[nombrecontrol];
            return id;
        }

    }
}
