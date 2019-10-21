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
    public partial class DetalleCaja : MetroFramework.Forms.MetroForm
    {
        int idCotizacion, idCaja, cont = 0, contN = 0;
        Cajas padre;
        DataTable datosCotizacion, datosCotizacionInCaja, listadoEnCotizacion, listadoEnCaja, caja, CajaInCaja;
        double pesoencaja = 0.00;
        private void BtnCierra_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Estas seguro?.", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes) {
                int inCaja = 0, i = 0;
                foreach (DataRow row in listadoEnCaja.Rows)
                {
                    CajaInCaja = BD.consultaDetalleCotizacionCajasInCaja(idCotizacion, Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]));
                    int actual = Convert.ToInt32(CajaInCaja.Rows[0]["inCaja"]);
                    int nuevo = actual + 1;
                    BD.modificarInCaja(nuevo, Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]));
                    i++;
                }
                BD.modificarCaja(Convert.ToString(pesoencaja), txtTitulo.Text, Convert.ToInt32(caja.Rows[0]["id_caja"]));
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
                padre.Refrescar();
            }
        }

        private void DetalleCaja_Load(object sender, EventArgs e)
        {
            caja = BD.consultaCaja(idCotizacion);
            datosCotizacionInCaja = BD.consultaDetalleCotizacionInCajas(idCotizacion);
            foreach (DataRow row in datosCotizacionInCaja.Rows)
            {
                int cantidad = Convert.ToInt32(datosCotizacionInCaja.Rows[contN]["inCaja"]);
                for (int i = 0; i < cantidad; i++)
                {
                    DataRow newrow = listadoEnCaja.NewRow();
                    newrow["ID"] = datosCotizacionInCaja.Rows[contN]["id_detalle_cotizacion"];
                    newrow["Nombre"] = datosCotizacionInCaja.Rows[contN]["modelo"];
                    newrow["Material"] = datosCotizacionInCaja.Rows[contN]["nombre"];
                    newrow["Tamaño"] = datosCotizacionInCaja.Rows[contN]["tamano"];
                    newrow["Peso"] = datosCotizacionInCaja.Rows[contN]["peso"];
                    double pesoAux = Convert.ToDouble(datosCotizacionInCaja.Rows[contN]["peso"]);
                    pesoencaja = pesoencaja + pesoAux;
                    listadoEnCaja.Rows.Add(newrow);
                }
                contN++;
            }
            datosCotizacion = BD.consultaDetalleCotizacionCajas(idCotizacion);
            foreach (DataRow row in datosCotizacion.Rows)
            {
                int cantidad = Convert.ToInt32(datosCotizacion.Rows[cont]["cantidad"]) - Convert.ToInt32(datosCotizacion.Rows[cont]["inCaja"]);
                for (int i = 0; i < cantidad; i++)
                {
                    DataRow newrow = listadoEnCotizacion.NewRow();
                    newrow["ID"] = datosCotizacion.Rows[cont]["id_detalle_cotizacion"];
                    newrow["Nombre"] = datosCotizacion.Rows[cont]["modelo"];
                    newrow["Material"] = datosCotizacion.Rows[cont]["nombre"];
                    newrow["Tamaño"] = datosCotizacion.Rows[cont]["tamano"];
                    newrow["Peso"] = datosCotizacion.Rows[cont]["peso"];
                    listadoEnCotizacion.Rows.Add(newrow);
                }
                cont++;
            }
            lista.DataSource = listadoEnCotizacion;
            listaCaja.DataSource = listadoEnCaja;
            string valorFormateado = string.Format("{0:n2}", (Math.Truncate(pesoencaja * 100) / 100));
            txtNoPedido.Text = valorFormateado + " / " + "30KG.";
            txtTitulo.Text = Convert.ToString(caja.Rows[0]["titulo"]);
        }

        public DetalleCaja(Cajas padre,int idCotizacion,int idCaja)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            this.idCaja = idCaja;
            listadoEnCotizacion = new DataTable();
            listadoEnCaja = new DataTable();
            listadoEnCotizacion.Columns.Add("ID");
            listadoEnCotizacion.Columns.Add("Nombre");
            listadoEnCotizacion.Columns.Add("Material");
            listadoEnCotizacion.Columns.Add("Tamaño");
            listadoEnCotizacion.Columns.Add("Peso");

            listadoEnCaja.Columns.Add("ID");
            listadoEnCaja.Columns.Add("Nombre");
            listadoEnCaja.Columns.Add("Material");
            listadoEnCaja.Columns.Add("Tamaño");
            listadoEnCaja.Columns.Add("Peso");

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
            padre.Refrescar();
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                double pesoItem = Convert.ToDouble(listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Peso"]);
                double pesoencajaaux = pesoencaja + pesoItem;
                if (pesoencajaaux < 30.00)
                {
                    DataRow newrow = listadoEnCaja.NewRow();
                    newrow["ID"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["ID"];
                    newrow["Nombre"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Nombre"];
                    newrow["Material"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Material"];
                    newrow["Tamaño"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Tamaño"];
                    newrow["Peso"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["peso"];
                    listadoEnCaja.Rows.Add(newrow);
                    listaCaja.DataSource = listadoEnCaja;
                    listadoEnCotizacion.Rows.RemoveAt(lista.CurrentRow.Index);
                    lista.DataSource = null;
                    lista.DataSource = listadoEnCotizacion;
                    pesoencaja = pesoencaja + pesoItem;
                    txtNoPedido.Text = Convert.ToString(pesoencaja) + " / " + "30KG.";
                }
                else
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "La caja ya se encuentra llena.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No se ha seleccionado ningún elemento.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                double pesoItem = Convert.ToDouble(listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Peso"]);
                pesoencaja = pesoencaja - pesoItem;
                DataRow newrow = listadoEnCotizacion.NewRow();
                newrow["ID"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["ID"];
                newrow["Nombre"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Nombre"];
                newrow["Material"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Material"];
                newrow["Tamaño"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Tamaño"];
                newrow["Peso"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["peso"];
                listadoEnCaja.Rows.RemoveAt(listaCaja.CurrentRow.Index);
                listadoEnCotizacion.Rows.Add(newrow);
                lista.DataSource = null;
                lista.DataSource = listadoEnCotizacion;
                listaCaja.DataSource = null;
                listaCaja.DataSource = listadoEnCaja;
                if (listadoEnCaja.Rows.Count == 0) {
                    pesoencaja = 0.00;
                }
                txtNoPedido.Text = Convert.ToString(pesoencaja) + " / " + "30KG.";
            }
            catch {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No se ha seleccionado ningún elemento o la caja no contiene objetos.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
