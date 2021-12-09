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
    public partial class Produccion : MetroFramework.Forms.MetroForm
    {
        Inicio Padre = null;
        string tipo_usuario;
        int idProduccion;
        DateTime t;
        public Produccion(Inicio padre, string tipo_usuario, DateTime t)
        {
            Padre = padre;
            this.tipo_usuario = tipo_usuario;
            this.t = t;
            InitializeComponent();

            if (tipo_usuario.Equals("ADMINISTRADOR")) {
                btnReporteador.Visible = true;
                btnDesaprobar.Visible = true;
            }
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                int idProduccion = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                generarPDF(tipo_usuario, idProduccion);

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void generarPDF(string tipo, int idProduccion)
        {
            GenerarPDF form = new GenerarPDF(this,tipo,idProduccion);
            form.Show();
            this.Enabled = false; //Productos
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        public void listarTabla() {
            String tipo = Login.tipo;
            int id_usuario = Login.idUsuario;
            DataTable dt = BD.listarProducciones(lista,tipo,id_usuario);

            try
            {
                lista.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                lista.Columns["PAGADO"].DefaultCellStyle.Format = "C2";
                lista.Columns["RESTA"].DefaultCellStyle.Format = "C2";

                Double total_total = 0;
                Double total_pagado = 0;
                Double total_resta = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total_total += Convert.ToDouble(dt.Rows[i]["TOTAL"]);
                    total_pagado += Convert.ToDouble(dt.Rows[i]["PAGADO"]);
                    total_resta += Convert.ToDouble(dt.Rows[i]["RESTA"]);
                }
                txtTotalCartera.Text = string.Format("{0:c2}", total_total);
                txtTotalPagado.Text = string.Format("{0:c2}", total_pagado);
                txtTotalResta.Text = string.Format("{0:c2}", total_resta);

            }
            catch
            {
            }

        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            if (tipo_usuario.Equals("PRODUCCION"))
            {
                btnPagos.Visible = false;
            }
            listarTabla();
        }

        private void BtnPagos_Click(object sender, EventArgs e)
        {

        }

        private void BtnPagos_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idProduccion = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                Pagos form = new Pagos(this, idProduccion, 6, t);
                form.Show();
                this.Enabled = false;

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Lista_DataSourceChanged(object sender, EventArgs e)
        {
            lblNumPedidos.Text = lista.RowCount.ToString();
        }

        private void BtnReporteador_Click(object sender, EventArgs e)
        {
            Reporteador form = new Reporteador(this);
            form.Show();
            form.FocusMe();
            this.Enabled = false;
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "Desea desaprobar esta cotización", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                int id_cotizacion = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());

                Boolean elim_cotizacion = BD.desaprobarCotizacion(id_cotizacion);
                if (elim_cotizacion)
                {
                    Boolean eliminar_control = BD.eliminarControlCotizacion(id_cotizacion);
                    Boolean eliminar_caja = BD.eliminarCajaCotizacion(id_cotizacion);

                    if (eliminar_control && eliminar_caja)
                    {
                        listarTabla();
                        DialogResult resp;
                        resp = MetroFramework.MetroMessageBox.Show(this, "Cotización desaprobada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        DialogResult resp;
                        resp = MetroFramework.MetroMessageBox.Show(this, "Error al desaprobar la cotizacion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult resp;
                    resp = MetroFramework.MetroMessageBox.Show(this, "Error al desaprobar la cotizacion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
