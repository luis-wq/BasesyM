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
        DataTable datosCotizacion, datosCotizacionInCaja, listadoEnCotizacion, listadoEnCaja, caja, CajaInCaja, cajaActual;
        double pesoencaja = 0.00;
        int bandera = 1;
        private void BtnCierra_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Estas seguro?.", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes) {
                int inCaja = 0, i = 0;
                this.Enabled = false;
                foreach (DataRow row in listadoEnCaja.Rows)
                {
                    CajaInCaja = BD.consultaDetalleCotizacionCajasInCaja(Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]));
                    DataTable consultaExistencia = BD.consultarExistenciaEnCaja(Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]), idCaja);
                    
                    int actual = 0;
                    foreach (DataGridViewRow rowN in listaCaja.Rows) {
                        int idInLista = Convert.ToInt32(listaCaja.Rows[actual].Cells[0].Value);
                        int idInDB = Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]);
                        if (idInLista == idInDB)
                        {
                            actual++;
                        }
                    }
                    if (consultaExistencia.Rows.Count == 0)
                    {
                        BD.insertarInCaja(actual, Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]), idCaja);
                    }
                    else
                    {
                        BD.modificarInCaja(actual, Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]), idCaja);
                    }
                    i++;
                }
                BD.modificarCaja(Convert.ToString(pesoencaja), txtTitulo.Text, idCaja);
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
                padre.Refrescar();
            }
        }

        private void DetalleCaja_Load(object sender, EventArgs e)
        {
            if (bandera == 0) {
                txtSoloLectura.Visible = true;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                btnCierra.Enabled = false;
            }
            caja = BD.consultaCaja(idCotizacion);
            cajaActual = BD.consultaCajaActual(idCaja);
            datosCotizacionInCaja = BD.consultaDetalleCotizacionInCajas(idCotizacion,idCaja);
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
                    newrow["Color"] = datosCotizacionInCaja.Rows[contN]["Color"];
                    double pesoAux = Convert.ToDouble(datosCotizacionInCaja.Rows[contN]["peso"]);
                    pesoencaja = pesoencaja + pesoAux;
                    listadoEnCaja.Rows.Add(newrow);
                }
                contN++;
            }
            datosCotizacion = BD.consultaDetalleCotizacionCajas(idCotizacion);
            DataTable can;
            foreach (DataRow row in datosCotizacion.Rows)
            {
                int cantidadInCaja = 0, contadorCantidad = 0;
                can = BD.consultaCantidadInCaja(Convert.ToInt32(datosCotizacion.Rows[cont]["id_detalle_cotizacion"]));
                
                foreach (DataRow rowN in can.Rows)
                {
                    cantidadInCaja = cantidadInCaja + Convert.ToInt32(can.Rows[contadorCantidad]["inCaja"]);
                    contadorCantidad++;
                }
                int cantidad = Convert.ToInt32(datosCotizacion.Rows[cont]["cantidad"]) - cantidadInCaja;
                for (int i = 0; i < cantidad; i++)
                {
                    DataRow newrow = listadoEnCotizacion.NewRow();
                    newrow["ID"] = datosCotizacion.Rows[cont]["id_detalle_cotizacion"];
                    newrow["Nombre"] = datosCotizacion.Rows[cont]["modelo"];
                    newrow["Material"] = datosCotizacion.Rows[cont]["nombre"];
                    newrow["Tamaño"] = datosCotizacion.Rows[cont]["tamano"];
                    newrow["Peso"] = datosCotizacion.Rows[cont]["peso"];
                    newrow["Color"] = datosCotizacion.Rows[cont]["Color"];
                    listadoEnCotizacion.Rows.Add(newrow);
                }
                cont++;
            }
            lista.DataSource = listadoEnCotizacion;
            listaCaja.DataSource = listadoEnCaja;
            lista.Columns[1].Width = 150;
            listaCaja.Columns[1].Width = 150;
            lista.Columns[0].Width = 70;
            listaCaja.Columns[0].Width = 70;
            cantidadCaja.Text = Convert.ToString(listaCaja.Rows.Count) + " Piezas";
            cantidadCotizacion.Text = Convert.ToString(lista.Rows.Count) + " Piezas";
            string valorFormateado = string.Format("{0:n2}", (Math.Truncate(pesoencaja * 100) / 100));
            txtNoPedido.Text = valorFormateado + " / " + "30KG.";
            txtTitulo.Text = Convert.ToString(cajaActual.Rows[0]["titulo"]);

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
            listadoEnCotizacion.Columns.Add("Color");

            listadoEnCaja.Columns.Add("ID");
            listadoEnCaja.Columns.Add("Nombre");
            listadoEnCaja.Columns.Add("Material");
            listadoEnCaja.Columns.Add("Tamaño");
            listadoEnCaja.Columns.Add("Peso");
            listadoEnCaja.Columns.Add("Color");

        }
        public DetalleCaja(Cajas padre, int idCotizacion, int idCaja,int bandera)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            this.idCaja = idCaja;
            this.bandera = bandera;
            listadoEnCotizacion = new DataTable();
            listadoEnCaja = new DataTable();
            listadoEnCotizacion.Columns.Add("ID");
            listadoEnCotizacion.Columns.Add("Nombre");
            listadoEnCotizacion.Columns.Add("Material");
            listadoEnCotizacion.Columns.Add("Tamaño");
            listadoEnCotizacion.Columns.Add("Peso");
            listadoEnCotizacion.Columns.Add("Color");

            listadoEnCaja.Columns.Add("ID");
            listadoEnCaja.Columns.Add("Nombre");
            listadoEnCaja.Columns.Add("Material");
            listadoEnCaja.Columns.Add("Tamaño");
            listadoEnCaja.Columns.Add("Peso");
            listadoEnCaja.Columns.Add("Color");
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
