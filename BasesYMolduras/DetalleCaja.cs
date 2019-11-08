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
    public partial class DetalleCaja : MetroFramework.Forms.MetroForm
    {
        int idCotizacion, idCaja, cont = 0, contN = 0;
        Cajas padre;
        DataTable datosCotizacion, datosCotizacionInCaja, listadoEnCotizacion, listadoEnCaja, caja, CajaInCaja, cajaActual;

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                double pesoItem = Convert.ToDouble(listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Peso"]);
                pesoencaja = pesoencaja - pesoItem;
                DataRow newrow = listadoEnCotizacion.NewRow();
                newrow["ID"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["ID"];
                newrow["Modelo"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Modelo"];
                newrow["Material"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Material"];
                newrow["Tamaño"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Tamaño"];
                newrow["Peso"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["peso"];
                newrow["Color"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Color"];
                newrow["Descripcion"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Descripcion"];
                newrow["Tipo"] = listadoEnCaja.Rows[listaCaja.CurrentRow.Index]["Tipo"];
                listadoEnCaja.Rows.RemoveAt(listaCaja.CurrentRow.Index);
                listadoEnCotizacion.Rows.Add(newrow);
                lista.DataSource = null;
                lista.DataSource = listadoEnCotizacion;
                listaCaja.DataSource = null;
                listaCaja.DataSource = listadoEnCaja;
                lista.Columns[0].Width = 50;
                lista.Columns[1].Width = 130;
                lista.Columns[2].Width = 110;
                lista.Columns[3].Width = 130;
                lista.Columns[4].Width = 200;
                lista.Columns[5].Width = 100;
                lista.Columns[6].Width = 50;
                lista.Columns[7].Width = 80;
                listaCaja.Columns[0].Width = 50;
                listaCaja.Columns[1].Width = 130;
                listaCaja.Columns[2].Width = 110;
                listaCaja.Columns[3].Width = 130;
                listaCaja.Columns[4].Width = 200;
                listaCaja.Columns[5].Width = 100;
                listaCaja.Columns[6].Width = 50;
                listaCaja.Columns[7].Width = 80;
                if (listadoEnCaja.Rows.Count == 0)
                {
                    pesoencaja = 0.00;
                }
                txtNoPedido.Text = Convert.ToString(pesoencaja) + " / " + "30KG.";
                cantidadCaja.Text = Convert.ToString(listaCaja.Rows.Count) + " Piezas";
                cantidadCotizacion.Text = Convert.ToString(lista.Rows.Count) + " Piezas";
            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No se ha seleccionado ningún elemento o la caja no contiene objetos.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                double pesoItem = Convert.ToDouble(listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Peso"]);
                double pesoencajaaux = pesoencaja + pesoItem;
                if (pesoencajaaux < 50.00)
                {
                    DataRow newrow = listadoEnCaja.NewRow();
                    newrow["ID"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["ID"];
                    newrow["Modelo"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Modelo"];
                    newrow["Material"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Material"];
                    newrow["Tamaño"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Tamaño"];
                    newrow["Peso"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["peso"];
                    newrow["Color"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Color"];
                    newrow["Descripcion"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Descripcion"];
                    newrow["Tipo"] = listadoEnCotizacion.Rows[lista.CurrentRow.Index]["Tipo"];
                    listadoEnCaja.Rows.Add(newrow);
                    listaCaja.DataSource = listadoEnCaja;
                    listadoEnCotizacion.Rows.RemoveAt(lista.CurrentRow.Index);
                    lista.DataSource = null;
                    lista.DataSource = listadoEnCotizacion;
                    lista.Columns[0].Width = 50;
                    lista.Columns[1].Width = 130;
                    lista.Columns[2].Width = 110;
                    lista.Columns[3].Width = 130;
                    lista.Columns[4].Width = 200;
                    lista.Columns[5].Width = 100;
                    lista.Columns[6].Width = 50;
                    lista.Columns[7].Width = 80;
                    listaCaja.Columns[0].Width = 50;
                    listaCaja.Columns[1].Width = 130;
                    listaCaja.Columns[2].Width = 110;
                    listaCaja.Columns[3].Width = 130;
                    listaCaja.Columns[4].Width = 200;
                    listaCaja.Columns[5].Width = 100;
                    listaCaja.Columns[6].Width = 50;
                    listaCaja.Columns[7].Width = 80;
                    pesoencaja = pesoencaja + pesoItem;
                    txtNoPedido.Text = Convert.ToString(pesoencaja) + " / " + "50KG.";
                    cantidadCaja.Text = Convert.ToString(listaCaja.Rows.Count) + " Piezas";
                    cantidadCotizacion.Text = Convert.ToString(lista.Rows.Count) + " Piezas";
                }
                else
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "La caja ya se encuentra llena.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No se ha seleccionado ningún elemento.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        double pesoencaja = 0.00;
        int bandera = 1;
        private void BtnCierra_Click(object sender, EventArgs e)
        {
            if (contN > 0)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha sellado esta caja.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Estas seguro?.", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (pregunta == DialogResult.Yes)
                {
                    Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.GuardarCaja));
                    hiloPesosYPrecios.Start();
                }
            }
        }

        private void GuardarCaja()
        {
            int inCaja = 0, i = 0;
            this.Enabled = false;
            foreach (DataRow row in listadoEnCaja.Rows)
            {
                CajaInCaja = BD.consultaDetalleCotizacionCajasInCaja(Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]));
                DataTable consultaExistencia = BD.consultarExistenciaEnCaja(Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]), idCaja);

                DataTable df = (from item in listadoEnCaja.Rows.Cast<DataRow>()
                                let codigo = Convert.ToString(item[0] == null ? string.Empty : item[0].ToString())
                                where codigo.Contains(Convert.ToString(listadoEnCaja.Rows[i]["ID"]))
                                select item).CopyToDataTable();

                int actual = df.Rows.Count;
                /*foreach (DataGridViewRow rowN in listaCaja.Rows)
                {
                    int idInLista = Convert.ToInt32(listaCaja.Rows[actual].Cells[0].Value);
                    int idInDB = Convert.ToInt32(listadoEnCaja.Rows[i]["ID"]);
                    if (idInLista == idInDB)
                    {
                        actual++;
                    }
                }*/
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
        private void CargarCajas()
        {
            UseWaitCursor = true;
            this.Enabled = false;
            if (bandera == 0)
            {
                txtSoloLectura.Visible = true;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                btnCierra.Enabled = false;
            }
            caja = BD.consultaCaja(idCotizacion);
            cajaActual = BD.consultaCajaActual(idCaja);
            datosCotizacionInCaja = BD.consultaDetalleCotizacionInCajas(idCotizacion, idCaja);
            foreach (DataRow row in datosCotizacionInCaja.Rows)
            {
                int cantidad = Convert.ToInt32(datosCotizacionInCaja.Rows[contN]["inCaja"]);
                for (int i = 0; i < cantidad; i++)
                {
                    DataRow newrow = listadoEnCaja.NewRow();
                    newrow["ID"] = datosCotizacionInCaja.Rows[contN]["id_detalle_cotizacion"];
                    newrow["Modelo"] = datosCotizacionInCaja.Rows[contN]["modelo"];
                    newrow["Color"] = datosCotizacionInCaja.Rows[contN]["Color"];
                    newrow["Tamaño"] = datosCotizacionInCaja.Rows[contN]["tamano"];
                    newrow["Descripcion"] = datosCotizacionInCaja.Rows[contN]["descripcion"];
                    newrow["Material"] = datosCotizacionInCaja.Rows[contN]["nombre"];
                    newrow["Peso"] = datosCotizacionInCaja.Rows[contN]["peso"];
                    newrow["Tipo"] = datosCotizacionInCaja.Rows[contN]["Tipo"];
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
                    newrow["Modelo"] = datosCotizacion.Rows[cont]["modelo"];
                    newrow["Color"] = datosCotizacion.Rows[cont]["Color"];
                    newrow["Tamaño"] = datosCotizacion.Rows[cont]["tamano"];
                    newrow["Descripcion"] = datosCotizacion.Rows[cont]["descripcion"];
                    newrow["Material"] = datosCotizacion.Rows[cont]["nombre"];
                    newrow["Peso"] = datosCotizacion.Rows[cont]["peso"];
                    newrow["Tipo"] = datosCotizacion.Rows[cont]["Tipo"];
                    listadoEnCotizacion.Rows.Add(newrow);
                }
                cont++;
            }
            lista.DataSource = listadoEnCotizacion;
            listaCaja.DataSource = listadoEnCaja;
            lista.Columns[0].Width = 50;
            lista.Columns[1].Width = 130;
            lista.Columns[2].Width = 110;
            lista.Columns[3].Width = 130;
            lista.Columns[4].Width = 200;
            lista.Columns[5].Width = 100;
            lista.Columns[6].Width = 50;
            lista.Columns[7].Width = 80;


            listaCaja.Columns[0].Width = 50;
            listaCaja.Columns[1].Width = 130;
            listaCaja.Columns[2].Width = 110;
            listaCaja.Columns[3].Width = 130;
            listaCaja.Columns[4].Width = 200;
            listaCaja.Columns[5].Width = 100;
            listaCaja.Columns[6].Width = 50;
            listaCaja.Columns[7].Width = 80;

            cantidadCaja.Text = Convert.ToString(listaCaja.Rows.Count) + " Piezas";
            cantidadCotizacion.Text = Convert.ToString(lista.Rows.Count) + " Piezas";
            string valorFormateado = string.Format("{0:n2}", (Math.Truncate(pesoencaja * 100) / 100));
            txtNoPedido.Text = valorFormateado + " / " + "30KG.";
            txtTitulo.Text = Convert.ToString(cajaActual.Rows[0]["titulo"]);
            this.Enabled = true;
            UseWaitCursor = false;
        }
        private void DetalleCaja_Load(object sender, EventArgs e)
        {
            Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarCajas));
            hiloPesosYPrecios.Start();
        }

        public DetalleCaja(Cajas padre,int idCotizacion,int idCaja)
        {

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            this.idCaja = idCaja;
            listadoEnCotizacion = new DataTable();
            listadoEnCaja = new DataTable();
            listadoEnCotizacion.Columns.Add("ID");
            listadoEnCotizacion.Columns.Add("Modelo");
            listadoEnCotizacion.Columns.Add("Color");
            listadoEnCotizacion.Columns.Add("Tamaño");
            listadoEnCotizacion.Columns.Add("Descripcion");
            listadoEnCotizacion.Columns.Add("Material");
            listadoEnCotizacion.Columns.Add("Peso");
            listadoEnCotizacion.Columns.Add("Tipo");

            listadoEnCaja.Columns.Add("ID");
            listadoEnCaja.Columns.Add("Modelo");
            listadoEnCaja.Columns.Add("Color");
            listadoEnCaja.Columns.Add("Tamaño");
            listadoEnCaja.Columns.Add("Descripcion");
            listadoEnCaja.Columns.Add("Material");
            listadoEnCaja.Columns.Add("Peso");
            listadoEnCaja.Columns.Add("Tipo");

        }
        public DetalleCaja(Cajas padre, int idCotizacion, int idCaja,int bandera)
        {

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            this.idCaja = idCaja;
            this.bandera = bandera;
            listadoEnCotizacion = new DataTable();
            listadoEnCaja = new DataTable();
            listadoEnCotizacion.Columns.Add("ID");
            listadoEnCotizacion.Columns.Add("Modelo");
            listadoEnCotizacion.Columns.Add("Color");
            listadoEnCotizacion.Columns.Add("Tamaño");
            listadoEnCotizacion.Columns.Add("Descripcion");
            listadoEnCotizacion.Columns.Add("Material");
            listadoEnCotizacion.Columns.Add("Peso");
            listadoEnCotizacion.Columns.Add("Tipo");

            listadoEnCaja.Columns.Add("ID");
            listadoEnCaja.Columns.Add("Modelo");
            listadoEnCaja.Columns.Add("Color");
            listadoEnCaja.Columns.Add("Tamaño");
            listadoEnCaja.Columns.Add("Descripcion");
            listadoEnCaja.Columns.Add("Material");
            listadoEnCaja.Columns.Add("Peso");
            listadoEnCaja.Columns.Add("Tipo");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
            padre.Refrescar();
            
        }



    }
}
