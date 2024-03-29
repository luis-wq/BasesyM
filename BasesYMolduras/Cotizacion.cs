﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Cotizacion : MetroFramework.Forms.MetroForm
    {
        Listados padre;
        string txtFecha;
        Double auxtablasMDF, tablaMDF = 0, auxtablasMOLDURA, tablaMOLDURA = 0, auxtablasPINO, tablaPINO = 0,
            envio = 0, envio_cotizacion = 0, cargo_extra = 0, cargo_extra_cotizacion = 0, totalIVA = 0, totalIVA_cotizacion = 0,
            total = 0, pesoFinal = 0, subtotal = 0, total_cotizacion = 0, pesoFinal_cotizacion = 0;
        Double total_modificar = 0, pesoFinal_modificar = 0, subtotal_modificar = 0, totalIVA_modificar = 0;
        Double total_nuevo = 0, pesoFinal_nuevo = 0, subtotal_nuevo = 0, totalIVA_nuevo = 0;
        int idCategoria, idMaterial, idTamano, idTipo, idCliente, bandera, idCotizacion, idClienteModificar, cantidad_productos, cantidad_productos_modificar, cantidad_productos_nuevo, tipoEnvioCb = -1;
        String modelo, tipo_cliente, tipo_cliente_c, prioridad = "NORMAL", tipo_envio;
        Boolean factura = false, agregar = false, nuevo = false, modificar = false, check = false;
        ArrayList listaEliminados = new ArrayList();
        DataTable listaProductosCantidad = new DataTable();
        int idUsuario;
        string tipo_usuario;
        int valorXCaja = 125, valorXkilo = 7;
        MySqlDataReader datosCliente, datosPaqueteria;
        DataTable dataCantidad, dataProductosCotizacion, datosClientes, dataProductosModificar;

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            comboUrgencia.Items.Add("NORMAL");
            comboUrgencia.Items.Add("URGENTE");
            cargarPrecioPaqueteria();
            cargarCategoria();
            cargarClientes();
            cargarDatosTablaCotizacion();
            cargarBandera();
            listaProductosCantidad.Columns.Add("id_producto", typeof(int));
            listaProductosCantidad.Columns.Add("cantidad", typeof(int));

            for (int i = 1; i <= 6; i++)
            {
                limpiarTabla(i);
            }
        }

        public Cotizacion(Listados padre, int bandera, int idCotizacion, int idUsuario, string tipo_usuario)
        {
            this.padre = padre;
            this.bandera = bandera;
            this.idCotizacion = idCotizacion;
            this.idUsuario = idUsuario;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();
            

        }

        private void ComboBoxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCategoria = Convert.ToInt32(comboBoxCategoria.SelectedValue);
            for (int i = 2; i <= 6; i++) { limpiarTabla(i); }
            cargarMaterial();
        }
        private void ComboUrgencia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            prioridad = comboUrgencia.SelectedItem.ToString();
        }

        private void TablaMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 3; i <= 6; i++) { limpiarTabla(i); }
            idMaterial = Convert.ToInt32(tablaMaterial.SelectedRows[0].Cells["ID"].Value.ToString());
            cargarModelo();
        }

        private void cargarCategoria()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosCategorias = BD.listarCategoriasForCotizacion();
            comboBoxCategoria.DataSource = datosCategorias;
            comboBoxCategoria.ValueMember = "id_categoria";
            comboBoxCategoria.DisplayMember = "NOMBRE";
            Cursor.Current = Cursors.Default;
        }

        private void TablaModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            modelo = tablaModelo.SelectedRows[0].Cells["MODELO"].Value.ToString();
            for (int i = 4; i <= 6; i++) { limpiarTabla(i); }
            cargarTipo();
        }

        private void comboBoxClientes2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBoxClientes2_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void comboBoxClientes2_KeyDown(object sender, KeyEventArgs e)
        {

            comboBoxClientes2.DroppedDown = false;

            if (e.KeyCode == Keys.Enter)
            {
                seleccionarClientes();
            }



        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           



        }

        private void metroComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {


            tipo_envio = cbTipoEnvio.Text;
            tipoEnvioCb = cbTipoEnvio.SelectedIndex;
            generarEnvio(tipoEnvioCb);

        }

        private void generarEnvio(int tipo)
        {
            int tienda = 0;
            int otros = 100;
            switch (tipo)
            {
                case 0:
                    txtEnvio.Text = string.Format("{0:c2}", tienda);
                    txtEnvio.Enabled = false;
                    envio = Convert.ToDouble(tienda);
                    break;
                case 2:
                    txtEnvio.Enabled = true;
                    txtEnvio.Text = string.Format("{0:c2}", tienda);
                    envio = Convert.ToDouble(tienda);
                    break;
                case 3:
                    txtEnvio.Text = string.Format("{0:c2}", otros);
                    txtEnvio.Enabled = false;
                    envio = Convert.ToDouble(otros);
                    break;
                case 4:
                    txtEnvio.Text = string.Format("{0:c2}", tienda);
                    txtEnvio.Enabled = true;
                    envio = Convert.ToDouble(tienda);
                    break;

                default:

                    break;
            }
            envioCotizacion();
        }


        public void calcularpaqueteria() {


            //double cajasEn = pesoFinal / 25;
            //double cajasT = Math.Floor(cajasEn);
            //double TotalC = cajasT * valorXCaja;


            //double KilosR = pesoFinal % 25;

            //double KilosT = Math.Ceiling(KilosR);
            //double TotalK = KilosT * valorXkilo;

            //double TotalEnvioP = TotalC + TotalK;

            //txtEnvio.Text = string.Format("{0:c2}", TotalEnvioP);
            //txtEnvio.Enabled = false;

            //envio = TotalEnvioP;

            double cajasEn = pesoFinal / 25;
            double cajasT = Math.Ceiling(cajasEn);
            double TotalC = cajasT * valorXCaja;

            double kilosT = Math.Ceiling(pesoFinal);
            double TotalK = kilosT * valorXkilo;

            double TotalEnvioP = TotalC + TotalK;
            txtEnvio.Text = string.Format("{0:c2}", TotalEnvioP);
            txtEnvio.Enabled = false;

            envio = TotalEnvioP;
        }



        private void TablaTipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            idTipo = Convert.ToInt32(tablaTipo.SelectedRows[0].Cells["ID"].Value.ToString());
            cargarColores();
            cargarTamanos();

        }
        private void seleccionarClientes()
        {
            try
            {
                DialogResult pregunta;

                pregunta = MetroFramework.MetroMessageBox.Show(this, "\n ¿Desea seleccionar el Cliente: " + comboBoxClientes2.Text + " ?.\n No se podrá cambiar despues de seleccionarlo", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (pregunta == DialogResult.Yes)
                {
                    idCliente = Convert.ToInt32(comboBoxClientes2.SelectedValue);

                    BD metodos = new BD();
                    BD.ObtenerConexion();
                    datosCliente = metodos.consultarClienteTipo(idCliente);
                    tipo_cliente = datosCliente.GetString(0);
                    BD.CerrarConexion();
                    lblTipoC.Text = tipo_cliente;
                    comboBoxClientes2.Enabled = false;
                    comboBoxCategoria.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex);
            }
        }
        private void cargarMaterial()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarMaterialesForCategoriasCotizacion(tablaMaterial, idCategoria);
            tablaMaterial.Columns["ID"].Visible = false;
            tablaMaterial.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void TablaTamano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTamano = Convert.ToInt32(tablaTamano.SelectedRows[0].Cells["ID"].Value.ToString());
            cargarProducto(2);
        }

        private void TxtProductos_Click(object sender, EventArgs e)
        {

        }

        private void cargarModelo()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroMaterial(tablaModelo, idCategoria, idMaterial);
            tablaModelo.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void cargarClientes()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (tipo_usuario.Equals("ADMINISTRADOR"))
            {
                datosClientes = BD.listarClientesForCotizacionAdmin();
            }
            else {
                datosClientes = BD.listarClientesForCotizacion(idUsuario);
            }
            comboBoxClientes2.DataSource = datosClientes;
            comboBoxClientes2.ValueMember = "id_cliente";
            comboBoxClientes2.DisplayMember = "RAZONSOCIAL";

            Cursor.Current = Cursors.Default;
        }
        private void cargarPrecioPaqueteria()
        {
            Cursor.Current = Cursors.WaitCursor;

            BD metodos = new BD();
            BD.ObtenerConexion();
            datosPaqueteria = BD.precioPaqueteria();
            valorXCaja = datosPaqueteria.GetInt32(1);
            valorXkilo = datosPaqueteria.GetInt32(2);
            BD.CerrarConexion();
            Cursor.Current = Cursors.Default;
        }
        private void TablaColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProducto(1);

        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if(modificar == false)
            {
                try
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar este producto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (pregunta == DialogResult.Yes)
                    {
                        dataProductosCotizacion.Rows.RemoveAt(tablaCotizacion.CurrentRow.Index);
                        tablaCotizacion.DataSource = dataProductosCotizacion;
                        Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPrecios));
                        hiloPesosYPrecios.Start();
                    }

                }
                catch
                {
                    DialogResult pregunta;

                    pregunta = MetroFramework.MetroMessageBox.Show(this, "No hay productos agregados o no ha seleccionado alguno.", "Error al quitar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(modificar == true)
            {
                if (nuevo == false)
                {
                    try
                    {
                        DialogResult pregunta;

                        pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar este producto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (pregunta == DialogResult.Yes)
                        {
                            int id_detalle_tabla = Convert.ToInt32(tablaCotizacionModificar.SelectedRows[0].Cells["ID_DETALLE"].Value.ToString());
                            listaEliminados.Add(id_detalle_tabla);

                            dataProductosModificar.Rows.RemoveAt(tablaCotizacionModificar.CurrentRow.Index);
                            tablaCotizacionModificar.DataSource = dataProductosModificar;
                            tablaCotizacionModificar.Rows[0].Selected = false;


                            Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPreciosModificar));
                            hiloPesosYPrecios.Start();
                        }

                    }
                    catch
                    {
                        
                        pesoFinal_modificar = 0;
                        cantidad_productos_modificar = 0;
                        total_modificar = 0;
                        subtotal_modificar = 0;
                        cargarDatosPrecios();
                        DialogResult pregunta;
                        pregunta = MetroFramework.MetroMessageBox.Show(this, "No hay productos agregados o no ha seleccionado alguno.", "Error al quitar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else if(nuevo == true)
                {
                    try
                    {
                        DialogResult pregunta;

                        pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar este producto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (pregunta == DialogResult.Yes)
                        {
                            dataProductosCotizacion.Rows.RemoveAt(tablaCotizacion.CurrentRow.Index);
                            tablaCotizacion.DataSource = dataProductosCotizacion;

                            Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPreciosNuevo));
                            hiloPesosYPrecios.Start();
                        }

                    }
                    catch
                    {
                        pesoFinal_modificar = 0;
                        cantidad_productos_modificar = 0;
                        total_modificar = 0;
                        subtotal_modificar = 0;
                        cargarDatosPrecios();
                        DialogResult pregunta;

                        pregunta = MetroFramework.MetroMessageBox.Show(this, "No hay productos agregados o no ha seleccionado alguno.", "Error al quitar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void MetroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           

            if (modificar == false)
            {
                if (checkBox.Checked)
                {
                    factura = true;
                    CargarTextoPrecios();

                }
                else
                {
                    factura = false;
                    CargarTextoPrecios();
                }
            }
            else if (modificar == true)
            {
                if(check == true)
                {
                    if (checkBox.Checked)
                    {
                        factura = true;
                        CargarTextoPreciosModificar();
                        CargarTextoPreciosNuevo();
                    }
                    else
                    {
                        factura = false;
                        CargarTextoPreciosModificar();
                        CargarTextoPreciosNuevo();
                    }
                }
            }
            
        }

        private void MetroTextBox2_Leave(object sender, EventArgs e)
        {
            if(modificar == false)
            {
                try
                {
                    cargo_extra = Convert.ToDouble(txtCargo.Text);
                    txtCargo.Text = string.Format("{0:c2}", cargo_extra);
                    cargo_extra = Convert.ToDouble(txtCargo.Text);
                    CargarTextoPrecios();
                }
                catch
                {
                    txtCargo.Text = string.Format("{0:c2}", cargo_extra);
                    CargarTextoPrecios();
                }
            }
            else if(modificar == true)
            {
                try
                {
                    cargo_extra = Convert.ToDouble(txtCargo.Text);
                    txtCargo.Text = string.Format("{0:c2}", cargo_extra);
                    cargo_extra = Convert.ToDouble(txtCargo.Text);
                    CargarTextoPreciosModificar();
                    CargarTextoPreciosNuevo();
                }
                catch
                {
                    txtCargo.Text = string.Format("{0:c2}", cargo_extra);
                    CargarTextoPreciosModificar();
                    CargarTextoPreciosNuevo();
                }
            }

        }

        private void BtnCambiarTabla_Click(object sender, EventArgs e)
        {
            if (nuevo == false)
            {
                nuevo = true;
                btnCambiarTabla.Text = "  MODIFICAR PRODUCTOS";
                tablaCotizacion.Visible = true;
                tablaCotizacionModificar.Visible = false;
                btnAgregar.Enabled = true;
                comboBoxCategoria.Enabled = true;
                txtInfoProductos.Text = "PRODUCTOS AGREGADOS";

            }
            else if (nuevo == true)
            {
                nuevo = false;
                btnCambiarTabla.Text = "  AGREGAR PRODUCTOS";
                tablaCotizacion.Visible = false;
                tablaCotizacionModificar.Visible = true;
                btnAgregar.Enabled = false;
                comboBoxCategoria.Enabled = false;
                txtInfoProductos.Text = "PRODUCTOS A MODIFICAR";

                for (int i = 1; i <= 6; i++)
                {
                    limpiarTabla(i);
                }

            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            Boolean vacioNuevo = true;
            Boolean vacioModificar = false;
            Boolean cambios = false;

            int tc = tablaCotizacion.Rows.Count;
            if (tc != 0)
            {
                vacioNuevo = false;
            }
            else
            {
                vacioNuevo = true;
            }

            int tm = listaEliminados.Count;
            if (tm != 0)
            {
                vacioModificar = false;
            }
            else
            {
                vacioModificar = true;
            }

            if (modificar == false)
            {
                
                if (vacioNuevo==false)
                {
                    if (tipo_envio != null)
                    {
                        this.Enabled = false;
                        await CargarCotizacion();
                        System.Threading.Thread.Sleep(5000);
                        this.Enabled = true;
                    }
                    else
                    {
                        DialogResult pregunta;
                        pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un tipo de envío", "Error al generar la cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
                else
                {

                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "La tabla de productos esta vacia", "Error al generar la cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }else if(modificar == true){
                try {
                    this.Enabled = false;
                    DialogResult pregunta;

                    pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea modificar la cotizacion?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (pregunta == DialogResult.Yes)
                    {
                        if (tipo_envio != null)
                        {
                            if (vacioModificar == false)
                            {
                                eliminarDetalleCotizacion();
                                cambios = true;
                            }

                            if (vacioNuevo == false)
                            {
                                this.Enabled = false;
                                CargarCotizacionModificar();
                                cambios = true;
                                this.Enabled = true;
                            }

                            if (cambios == true)
                            {
                                int idCo = idCotizacion;
                                agregarTablaMaterial(idCo);
                                modificarDetallesCotizacion();

                            }
                            else
                            {
                                modificarDetallesCotizacion();
                                //DialogResult pregunta4;
                                //pregunta4 = MetroFramework.MetroMessageBox.Show(this, "MODIFICAR", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }

                            DialogResult pregunta3;
                            pregunta3 = MetroFramework.MetroMessageBox.Show(this, "Cotización modificada correctamente", "Cotización modificada\n", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (pregunta3 == DialogResult.OK)
                            {
                                padre.Enabled = true;
                                padre.CargarDatos();
                                padre.FocusMe();
                                this.Close();
                            }
                        }
                        else
                        {
                            DialogResult pregunta9;
                            pregunta9 = MetroFramework.MetroMessageBox.Show(this, "Seleccione un tipo de envío", "Error al generar la cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                    this.Enabled = true;
                } catch {

                    DialogResult pregunta;

                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Error al modificar", "Error al modificar la cotización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void eliminarDetalleCotizacion()
        {
            Boolean eliminado = false;

            for (int i = 0; i < listaEliminados.Count; i++)
            {
                agregarInventario(Convert.ToInt32(listaEliminados[i]), idCotizacion);
                BD metodos = new BD();
                BD.ObtenerConexion();
                eliminado = metodos.eliminarProductoCotizacion(Convert.ToInt32(listaEliminados[i]), idCotizacion);
                BD.CerrarConexion();
            }

        }
        private void agregarInventario(int idDetalle,int idCotizacion)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            metodos.updateInventario(idDetalle, idCotizacion);
            BD.CerrarConexion();
        }

        private void TxtEnvio_Leave(object sender, EventArgs e)
        {
        
            if (modificar == false)
            {
                try
                {
                    envio = Convert.ToDouble(txtEnvio.Text);
                    txtEnvio.Text = string.Format("{0:c2}", envio);
                    envio = Convert.ToDouble(txtEnvio.Text);
                    envioCotizacion();
                }
                catch
                {
                    txtEnvio.Text = string.Format("{0:c2}", envio);
                    envioCotizacion();
                }
            }
            else if (modificar == true)
            {
                try
                {
                    envio = Convert.ToDouble(txtEnvio.Text);
                    txtEnvio.Text = string.Format("{0:c2}", envio);
                    envio = Convert.ToDouble(txtEnvio.Text);
                    envioCotizacion();
                }
                catch
                {
                    txtEnvio.Text = string.Format("{0:c2}", envio);
                    envioCotizacion();
                }
            }

        }

        private void envioCotizacion()
        {
            if (modificar == false)
            {
                CargarTextoPrecios();
            }
            else if (modificar == true)
            {
                CargarTextoPreciosModificar();
                CargarTextoPreciosNuevo();
            }
        }
        private void MetroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cargarTamanos()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroTamano(tablaTamano, idCategoria, idMaterial, modelo);
            tablaTamano.Columns["ID"].Visible = false;
            tablaTamano.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(modificar == false)
            {
                try {
                    string result = txtCantidad.Text;

                    if (string.IsNullOrEmpty(result) || result.Equals("0"))
                    {
                        DialogResult pregunta;

                        pregunta = MetroFramework.MetroMessageBox.Show(this, "Ingrese la cantiad de productos que desea agregar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DataRow row = dataProductosCotizacion.NewRow();
                        row["ID"] = tablaInfoProducto.SelectedRows[0].Cells["ID"].Value.ToString();
                        row["MODELO"] = tablaInfoProducto.SelectedRows[0].Cells["MODELO"].Value.ToString();
                        row["CATEGORIA"] = tablaInfoProducto.SelectedRows[0].Cells["CATEGORIA"].Value.ToString();
                        row["MATERIAL"] = tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString();
                        row["COLOR"] = tablaColorID.SelectedRows[0].Cells["COLOR"].Value.ToString();
                        row["TAMAÑO"] = tablaInfoProducto.SelectedRows[0].Cells["TAMAÑO"].Value.ToString();
                        row["TIPO"] = tablaInfoProducto.SelectedRows[0].Cells["TIPO"].Value.ToString();
                        row["CANTIDAD"] = txtCantidad.Text;
                        row["PRECIO"] = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PRECIO"].Value.ToString());
                        Double valor = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PESO"].Value.ToString()) * Convert.ToDouble(row["CANTIDAD"]);
                        row["IMPORTE"] = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PRECIO"].Value.ToString()) * Convert.ToDouble(row["CANTIDAD"]);
                        row["PESO"] = string.Format("{0:n2}", (Math.Truncate(valor * 100) / 100)) + "kg";
                        row["ID_COLOR"] = tablaColorID.SelectedRows[0].Cells["ID_COLOR"].Value.ToString();
                        row["ID_TIPO"] = tablaColorID.SelectedRows[0].Cells["ID_TIPO"].Value.ToString();
   
                        int cantidad_inventario = Convert.ToInt32(tablaInfoProducto.SelectedRows[0].Cells["CANTA"].Value.ToString());
                        int cantidad_producto = Convert.ToInt32(txtCantidad.Text);
                        int id_producto = Convert.ToInt32(tablaInfoProducto.SelectedRows[0].Cells["ID"].Value.ToString());
                        Boolean existe = existeProducto(id_producto);

                        if (existe){

                            Console.WriteLine("EXISTE");

                            if (cantidad_inventario > 0)
                            {
                                int canta = cambiarDatosProducto(cantidad_producto, id_producto);
                                row["CANTA"] = Convert.ToString(canta);
                                imprimirLista();
                            }
                            else {

                                row["CANTA"] = tablaInfoProducto.SelectedRows[0].Cells["CANTA"].Value.ToString();
                                imprimirLista();
                            }

                        }
                        else {

                            int resta_inventario = cantidad_inventario - cantidad_producto;

                            if (resta_inventario > 0)
                            {
                                Console.WriteLine("QUEDA EN EL INVENTARIO");

                                listaProductosCantidad.Rows.Add(new object[] { id_producto, resta_inventario});
                                imprimirLista();
                            }
                            else {
                                Console.WriteLine("NO EXISTE EN EL INVENTARIO");
                                listaProductosCantidad.Rows.Add(new object[] { id_producto, 0 });
                                imprimirLista();
                            }
                            
                            row["CANTA"] = tablaInfoProducto.SelectedRows[0].Cells["CANTA"].Value.ToString();

                            Console.WriteLine("AGREGANDO...");
                            //imprimirLista();
                        }

                        
                        row["PORCENTAJE"] = tablaInfoProducto.SelectedRows[0].Cells["PORCENTAJE"].Value.ToString();

                        dataProductosCotizacion.Rows.Add(row);
                        tablaCotizacion.DataSource = dataProductosCotizacion;
                        tablaCotizacion.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
                        tablaCotizacion.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";

                        Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPrecios));
                        hiloPesosYPrecios.Start();

                        
                    }
                } catch(Exception ex) {
                    DialogResult pregunta;

                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine(ex);
                }
            }
            else if(modificar == true)
            {
                try{
                    string result = txtCantidad.Text;

                    if (string.IsNullOrEmpty(result) || result.Equals("0"))
                    {
                        DialogResult pregunta;

                        pregunta = MetroFramework.MetroMessageBox.Show(this, "Ingrese la cantiad de productos que desea agregar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DataRow row = dataProductosCotizacion.NewRow();
                        row["ID"] = tablaInfoProducto.SelectedRows[0].Cells["ID"].Value.ToString();
                        row["MODELO"] = tablaInfoProducto.SelectedRows[0].Cells["MODELO"].Value.ToString();
                        row["CATEGORIA"] = tablaInfoProducto.SelectedRows[0].Cells["CATEGORIA"].Value.ToString();
                        row["MATERIAL"] = tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString();
                        row["COLOR"] = tablaColorID.SelectedRows[0].Cells["COLOR"].Value.ToString();
                        row["TAMAÑO"] = tablaInfoProducto.SelectedRows[0].Cells["TAMAÑO"].Value.ToString();
                        row["TIPO"] = tablaInfoProducto.SelectedRows[0].Cells["TIPO"].Value.ToString();
                        row["CANTIDAD"] = txtCantidad.Text;
                        row["PRECIO"] = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PRECIO"].Value.ToString());
                        row["IMPORTE"] = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PRECIO"].Value.ToString()) * Convert.ToDouble(row["CANTIDAD"]);
                        Double valor = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PESO"].Value.ToString()) * Convert.ToDouble(row["CANTIDAD"]);
                        row["PESO"] = string.Format("{0:n2}", (Math.Truncate(valor * 100) / 100)) + "kg";
                        row["ID_COLOR"] = tablaColorID.SelectedRows[0].Cells["ID_COLOR"].Value.ToString();
                        row["ID_TIPO"] = tablaColorID.SelectedRows[0].Cells["ID_TIPO"].Value.ToString();
                        row["CANTA"] = tablaInfoProducto.SelectedRows[0].Cells["CANTA"].Value.ToString();
                        row["PORCENTAJE"] = tablaInfoProducto.SelectedRows[0].Cells["PORCENTAJE"].Value.ToString();

                        dataProductosCotizacion.Rows.Add(row);
                        tablaCotizacion.DataSource = dataProductosCotizacion;
                        tablaCotizacion.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
                        tablaCotizacion.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";


                        Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPreciosNuevo));
                        hiloPesosYPrecios.Start();



                    }
                }
                catch {
                    DialogResult pregunta;

                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           

        }

        private Boolean existeProducto(int id_producto) {

            Boolean existe = false;


            foreach (DataRow dr in listaProductosCantidad.Rows) { 

                 int id_listaProducto = Convert.ToInt32(dr["id_producto"]);

                 if (id_producto == id_listaProducto){
                    return true;
                }

            }
            return existe;

        }

        private int cambiarDatosProducto(int cantidad_productos, int id_producto) {
            int resta_inventario = 0;
            foreach (DataRow dr in listaProductosCantidad.Rows)
            {

                int id_lista = Convert.ToInt32(dr["id_producto"]);
                int cantidad_inventario = Convert.ToInt32(dr["cantidad"]);

                if (id_lista == id_producto)
                {

                    if (cantidad_inventario == 0)
                    {
                        resta_inventario = 0;
                    }
                    else
                    {
                        int resta = cantidad_inventario - cantidad_productos;

                        if (resta >= 0)
                        {

                            dr["cantidad"] = resta;
                            resta_inventario = resta;

                        }
                        else
                        {
                            resta_inventario = 0;
                        }
                    }

                }


            }
            return resta_inventario;

        }

        private void imprimirLista() {
            foreach (DataRow dr in listaProductosCantidad.Rows)
            {

                int id_listaProducto = Convert.ToInt32(dr["id_producto"]);
                int cantidad_inventario = Convert.ToInt32(dr["cantidad"]);
                Console.WriteLine(id_listaProducto + " " + cantidad_inventario);
            }


        }

        private void restarInventarioTabla( int id_producto , int cantidad) {

            foreach (DataRow dr in listaProductosCantidad.Rows)
            {

                int id_listaProducto = Convert.ToInt32(dr["id_producto"]);
                int cantidad_inventario = Convert.ToInt32(dr["cantidad"]);

            }

        }
        private void cargarTipo()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarTiposForCotizacion(tablaTipo, idCategoria);
            tablaTipo.Columns["ID"].Visible = false;
            tablaTipo.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void cargarColores()
        {

            Cursor.Current = Cursors.WaitCursor;
            BD.listarColoresForCotizacion(tablaColor);
            tablaColor.Columns["ID"].Visible = false;
            tablaColor.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void cargarProducto(int c)
        {

            Cursor.Current = Cursors.WaitCursor;
            if (c == 1)
            {
                dataCantidad = new DataTable();
                dataCantidad.Columns.Add("ID_COLOR", typeof(String));
                dataCantidad.Columns.Add("ID_TIPO", typeof(String));
                dataCantidad.Columns.Add("COLOR", typeof(String));
                tablaColorID.DataSource = dataCantidad;

                dataCantidad.Rows.Add(tablaColor.SelectedRows[0].Cells["ID"].Value.ToString(), tablaTipo.SelectedRows[0].Cells["ID"].Value.ToString(), tablaColor.SelectedRows[0].Cells["COLOR"].Value.ToString());
                tablaColorID.DataSource = dataCantidad;
                tablaColorID.Columns["ID_COLOR"].Visible = false;
                tablaColorID.Columns["ID_TIPO"].Visible = false;
            }
            else
            {
                BD.listarProductoForCotizacion(tablaInfoProducto, idCategoria, idMaterial, modelo, idTamano, idTipo, tipo_cliente);
                tablaInfoProducto.Columns["PESO"].Visible = false;
                tablaInfoProducto.Columns["PORCENTAJE"].Visible = false;
                tablaInfoProducto.Columns["CANTA"].Visible = false;

                dataCantidad = new DataTable();
                dataCantidad.Columns.Add("ID_COLOR", typeof(String));
                dataCantidad.Columns.Add("ID_TIPO", typeof(String));
                dataCantidad.Columns.Add("COLOR", typeof(String));
                tablaColorID.DataSource = dataCantidad;

                dataCantidad.Rows.Add(tablaColor.SelectedRows[0].Cells["ID"].Value.ToString(), tablaTipo.SelectedRows[0].Cells["ID"].Value.ToString(), tablaColor.SelectedRows[0].Cells["COLOR"].Value.ToString());
                tablaColorID.DataSource = dataCantidad;
                tablaColorID.Columns["ID_COLOR"].Visible = false;
                tablaColorID.Columns["ID_TIPO"].Visible = false;

                tablaInfoProducto.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
                tablaInfoProducto.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }
        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
            }
        }

        private void limpiarTabla(int s)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (s)
            {
                case 1:
                    DataTable headerMaterial = new DataTable();
                    headerMaterial.Columns.Add("MATERIAL", typeof(String));
                    tablaMaterial.DataSource = headerMaterial;
                    tablaMaterial.Enabled = false;
                    break;
                case 2:
                    DataTable headerModelo = new DataTable();
                    headerModelo.Columns.Add("MODELO", typeof(String));
                    tablaModelo.DataSource = headerModelo;
                    tablaModelo.Enabled = false;
                    break;
                case 3:
                    DataTable headerTipo = new DataTable();
                    headerTipo.Columns.Add("TIPO", typeof(String));
                    tablaTipo.DataSource = headerTipo;
                    tablaTipo.Enabled = false;
                    break;
                case 4:
                    DataTable headerColor = new DataTable();
                    headerColor.Columns.Add("COLOR", typeof(String));
                    tablaColor.DataSource = headerColor;
                    tablaColor.Enabled = false;
                    break;
                case 5:
                    DataTable headerTamano = new DataTable();
                    headerTamano.Columns.Add("TAMAÑO", typeof(String));
                    tablaTamano.DataSource = headerTamano;
                    tablaTamano.Enabled = false;
                    break;
                case 6:
                    DataTable headerProductoInfo = new DataTable();
                    headerProductoInfo.Columns.Add("ID", typeof(String));
                    headerProductoInfo.Columns.Add("MODELO", typeof(String));
                    headerProductoInfo.Columns.Add("CATEGORIA", typeof(String));
                    headerProductoInfo.Columns.Add("MATERIAL", typeof(String));
                    headerProductoInfo.Columns.Add("COLOR", typeof(String));
                    headerProductoInfo.Columns.Add("TAMAÑO", typeof(String));
                    headerProductoInfo.Columns.Add("DECRIPCION", typeof(String));
                    headerProductoInfo.Columns.Add("PESO", typeof(String));
                    headerProductoInfo.Columns.Add("PRECIO", typeof(String));
                    tablaInfoProducto.DataSource = headerProductoInfo;

                    dataCantidad = new DataTable();
                    dataCantidad.Columns.Add("COLOR", typeof(String));
                    tablaColorID.DataSource = dataCantidad;
                    tablaInfoProducto.Enabled = false;
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void cargarDatosTablaCotizacion()
        {
            dataProductosCotizacion = new DataTable();
            dataProductosCotizacion.Columns.Add("ID");
            dataProductosCotizacion.Columns.Add("MODELO");
            dataProductosCotizacion.Columns.Add("CATEGORIA");
            dataProductosCotizacion.Columns.Add("MATERIAL");
            dataProductosCotizacion.Columns.Add("COLOR");
            dataProductosCotizacion.Columns.Add("TAMAÑO");
            dataProductosCotizacion.Columns.Add("TIPO");
            dataProductosCotizacion.Columns.Add("PESO");
            dataProductosCotizacion.Columns.Add("CANTIDAD").MaxLength = 4;
            dataProductosCotizacion.Columns.Add("PRECIO").DataType = System.Type.GetType("System.Double");
            dataProductosCotizacion.Columns.Add("IMPORTE").DataType = System.Type.GetType("System.Double");
            dataProductosCotizacion.Columns.Add("ID_COLOR");
            dataProductosCotizacion.Columns.Add("ID_TIPO");
            dataProductosCotizacion.Columns.Add("CANTA");
            dataProductosCotizacion.Columns.Add("PORCENTAJE");

            tablaCotizacion.DataSource = dataProductosCotizacion;

            tablaCotizacion.Columns["ID_COLOR"].Visible = false;
            tablaCotizacion.Columns["ID_TIPO"].Visible = false;
            tablaCotizacion.Columns["CANTA"].Visible = false;
            tablaCotizacion.Columns["PORCENTAJE"].Visible = false;
            tablaCotizacion.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
            tablaCotizacion.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";
        }
        private void CargarTextoPrecios()
        {
            double auxPrecios = 0;
            double auxPrecios2 = 0;
            double precioFinal = 0;
            double auxPesos = 0;
            pesoFinal = 0;
            cantidad_productos = 0;
            total = 0;
            subtotal = 0;
            tablaMDF = 0;
            tablaMOLDURA = 0;
            tablaPINO = 0;
            int i = 0;
            foreach (DataRow rowN in dataProductosCotizacion.Rows)
            {
                double cantidad = Convert.ToDouble(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                string cadena = dataProductosCotizacion.Rows[i]["PRECIO"].ToString();
                string resultado = cadena.Replace("$", "");
                string cadena2 = dataProductosCotizacion.Rows[i]["PESO"].ToString();
                string resultado2 = cadena2.Replace("k", "");
                string resultado3 = resultado2.Replace("g", "");
                auxPrecios = Convert.ToDouble(resultado);
                auxPrecios2 = auxPrecios * cantidad;
                precioFinal = precioFinal + auxPrecios2;
                auxPesos = Convert.ToDouble(resultado3);
                pesoFinal = pesoFinal + auxPesos;
                cantidad_productos = cantidad_productos + Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                i++;
            }

            if (tipoEnvioCb == 1)
            {
                calcularpaqueteria();
            }

            Double extras = envio + cargo_extra;
            subtotal = precioFinal + extras;

            if (factura == true)
            {
                totalIVA = subtotal * 0.16;
            }
            else
            {
                totalIVA = 0;

            }

            total = subtotal + totalIVA ;

            cargarDatosPrecios();
        }
        private void CargarTextoPreciosNuevo()
        {
            double auxPrecios = 0;
            double auxPrecios2 = 0;
            double precioFinal = 0;
            double auxPesos = 0;
            pesoFinal_nuevo = 0;
            cantidad_productos_nuevo = 0;
            total_nuevo = 0;
            subtotal_nuevo = 0;
            int i = 0;
            foreach (DataRow rowN in dataProductosCotizacion.Rows)
            {
                double cantidad = Convert.ToDouble(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                string cadena = dataProductosCotizacion.Rows[i]["PRECIO"].ToString();
                string resultado = cadena.Replace("$", "");
                string cadena2 = dataProductosCotizacion.Rows[i]["PESO"].ToString();
                string resultado2 = cadena2.Replace("k", "");
                string resultado3 = resultado2.Replace("g", "");
                auxPrecios = Convert.ToDouble(resultado);
                auxPrecios2 = auxPrecios * cantidad;
                precioFinal = precioFinal + auxPrecios2;
                auxPesos = Convert.ToDouble(resultado3);
                pesoFinal_nuevo = pesoFinal_nuevo + auxPesos;
                cantidad_productos_nuevo = cantidad_productos_nuevo + Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                i++;
            }
            subtotal_nuevo = precioFinal;
            cargarDatosPrecios();
        }
        private void CargarTextoPreciosModificar()
        {
            double auxPrecios = 0;
            double auxPrecios2 = 0;
            double precioFinal = 0;
            double auxPesos = 0;
            pesoFinal_modificar = 0;
            cantidad_productos_modificar = 0;
            total_modificar = 0;
            subtotal_modificar = 0;
            int i = 0;
            foreach (DataRow rowN in dataProductosModificar.Rows)
            {
                double cantidad = Convert.ToDouble(dataProductosModificar.Rows[i]["CANTIDAD"]);
                string cadena = dataProductosModificar.Rows[i]["PRECIO"].ToString();
                string resultado = cadena.Replace("$", "");
                string cadena2 = dataProductosModificar.Rows[i]["PESO"].ToString();
                string resultado2 = cadena2.Replace("k", "");
                string resultado3 = resultado2.Replace("g", "");
                auxPrecios = Convert.ToDouble(resultado);
                auxPrecios2 = auxPrecios * cantidad;
                precioFinal = precioFinal + auxPrecios2;
                auxPesos = Convert.ToDouble(resultado3);
                pesoFinal_modificar = pesoFinal_modificar + auxPesos;
                cantidad_productos_modificar = cantidad_productos_modificar + Convert.ToInt32(dataProductosModificar.Rows[i]["CANTIDAD"]);
                i++;
            }
            subtotal_modificar = precioFinal;

            cargarDatosPrecios();
        }
        private async Task CargarCotizacion()
        {

            int idUsuario = Login.idUsuario;
            string observacion = Convert.ToString(txtObservaciones.Text);
            if (observacion.Equals(""))
            {
                observacion = "NINGUNA";
            }
            int noCotizacionCliente;
            int nocotizacion = Convert.ToInt32(datosClientes.Rows[comboBoxClientes2.SelectedIndex]["nocotizacion"]);
            if (nocotizacion == 0)
            {
                noCotizacionCliente = 1;
            }
            else
            {
                noCotizacionCliente = nocotizacion + 1;
            }
            int isProduccion = 0;
            string fecha = obtenerFecha();
            if (prioridad.Equals(""))
            {
                prioridad = "NORMAL";
            }
            double pesoTotal = Convert.ToDouble(pesoFinal);
            agregar = BD.InsertarCotizacion(idCliente, idUsuario, observacion, envio, noCotizacionCliente, isProduccion, fecha, cargo_extra, 0, 0, 0, prioridad, pesoTotal, totalIVA, tipo_envio);
            BD.modificarNoCotizacion(idCliente, noCotizacionCliente);
            DataTable idCotizacionActual = BD.consultaIdCotizaion(idCliente, idUsuario);
            int idCotizacion = Convert.ToInt32(idCotizacionActual.Rows[0]["id_cotizacion"]);
            if (agregar == true)
            {
                int i = 0;
                foreach (DataRow row in dataProductosCotizacion.Rows)
                {
                    int idProducto = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID"]);
                    int idColor = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_COLOR"]);
                    int idTipo = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_TIPO"]);
                    int cantida = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                    int cantidadA = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTA"]);
                    Double precioN = Convert.ToDouble(dataProductosCotizacion.Rows[i]["PRECIO"]);
                    int cantidadP = 0;
                    if (cantida <= cantidadA)
                    {
                        int cantidadFinal = cantidadA - cantida;
                        cantidadP = 0;
                        cantidadA = cantida;
                        BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantidadA, cantidadP, precioN);

                        BD metodos = new BD();
                        BD.ObtenerConexion();
                        metodos.modificarProducto(idProducto, cantidadFinal);
                        BD.CerrarConexion();
                    }
                    else
                    {
                        cantidadP = cantida - cantidadA;
                        BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantidadA, cantidadP, precioN);

                        BD metodos = new BD();
                        BD.ObtenerConexion();
                        metodos.modificarProducto(idProducto, 0);
                        BD.CerrarConexion();
                    }
                    i++;
                }
                double precioFinal = Convert.ToDouble(total);
                BD.AgregarCuentaCliente(idCotizacion, precioFinal);
                agregarTablaMaterial(idCotizacion);
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Cotización agregada correctamente", "Cotización agregada", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    padre.Enabled = true;
                    padre.CargarDatos();
                    padre.FocusMe();
                    this.Close();
                }
            }
            else if (agregar == false)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarCotizacionModificar()
        {
            int i = 0;
            foreach (DataRow row in dataProductosCotizacion.Rows)
            {
                int idProducto = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID"]);
                int idColor = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_COLOR"]);
                int idTipo = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_TIPO"]);
                int cantida = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTIDAD"]);
                int cantidadA = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTA"]);
                Double precioN = Convert.ToDouble(dataProductosCotizacion.Rows[i]["PRECIO"]);
                int cantidadP = 0;
                if (cantida <= cantidadA)
                {
                    int cantidadFinal = cantidadA - cantida;
                    cantidadP = 0;
                    cantidadA = cantida;
                    BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantidadA, cantidadP, precioN);

                    BD metodos = new BD();
                    BD.ObtenerConexion();
                    metodos.modificarProducto(idProducto, cantidadFinal);
                    BD.CerrarConexion();
                }
                else
                {
                    cantidadP = cantida - cantidadA;
                    BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantidadA, cantidadP, precioN);

                    BD metodos = new BD();
                    BD.ObtenerConexion();
                    metodos.modificarProducto(idProducto, 0);
                    BD.CerrarConexion();
                }
                i++;
            }

        }
        private string obtenerFecha()
        {
            DateTime t = BD.ObtenerFecha();
            if (t != null)
            {
                return txtFecha = t.Year + "-" + t.Month + "-" + t.Day;
            }
            else
            {
                t = DateTime.Now;
                string date = t.ToString("d");
                return date;
            }

        }
        private void agregarTablaMaterial(int idCotizacion)
        {
            DataTable dataProductosMateriales = BD.listarProductosCotizacionTablas(idCotizacion);

            int i = 0;
            foreach (DataRow row in dataProductosMateriales.Rows)
            {
                if (dataProductosMateriales.Rows[i]["MATERIAL"].Equals("MDF"))
                {
                    double cantidadT = Convert.ToDouble(txtCantidad.Text);
                    auxtablasMDF = Convert.ToDouble(dataProductosMateriales.Rows[i]["PORCENTAJE"].ToString()) * Convert.ToInt32(dataProductosMateriales.Rows[i]["CANTIDAD"].ToString());
                    tablaMDF = tablaMDF + auxtablasMDF;
                }
                if (dataProductosMateriales.Rows[i]["MATERIAL"].Equals("MOLDURA"))
                {
                    double cantidadT = Convert.ToDouble(txtCantidad.Text);
                    auxtablasMOLDURA = Convert.ToDouble(dataProductosMateriales.Rows[i]["PORCENTAJE"].ToString()) * Convert.ToInt32(dataProductosMateriales.Rows[i]["CANTIDAD"].ToString());
                    tablaMOLDURA = tablaMOLDURA + auxtablasMOLDURA;
                }
                if (dataProductosMateriales.Rows[i]["MATERIAL"].Equals("PINO"))
                {
                    double cantidadT = Convert.ToDouble(txtCantidad.Text);
                    auxtablasPINO = Convert.ToDouble(dataProductosMateriales.Rows[i]["PORCENTAJE"].ToString()) * Convert.ToInt32(dataProductosMateriales.Rows[i]["CANTIDAD"].ToString());
                    tablaPINO = tablaPINO + auxtablasPINO;
                }
                i++;
            }

            BD.ingresarTablasCotizacion(idCotizacion, tablaMDF,tablaMOLDURA,tablaPINO);

        }
        private void modificarDetallesCotizacion()
        {

            string ob = txtObservaciones.Text;
            BD.modificarDetallesCotizacion(idCotizacion, ob,(float) Convert.ToDouble(envio),cargo_extra,prioridad, (float)Convert.ToDouble(pesoFinal), (float)Convert.ToDouble(totalIVA),tipo_envio);
            BD.modificarCuentaCotizacion(idCotizacion, (float)Convert.ToDouble(total));

        }
        private void cargarBandera()
        {
            if (bandera == 3)
            {
                tablaCotizacion.Visible = false;
                tablaCotizacionModificar.Visible = true;

                comboBoxClientes2.Enabled = false;
                modificar = true;
                btnCambiarTabla.Visible = true;

                btnAgregar.Enabled = false;
                btnQuitar.Enabled = true;

                txtInfoProductos.Text = "PRODUCTOS A MODIFICAR";
                btnGenerar.Text = "MODIFICAR COTIZACIÓN";

                //btnGenerar.Enabled = false;

                llenarDatosModificar();
                cargarTablaModificar();
            }
            else
            {
                cargarDatosPrecios();
            }
        }
        private void llenarDatosModificar()
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            datosCliente = metodos.consultarCliente(idCotizacion);

            txtObservaciones.Text = datosCliente.GetString(0);
            String nombre = datosCliente.GetString(2);
            envio_cotizacion = datosCliente.GetFloat(12);
            tipo_cliente_c = datosCliente.GetString(14);
            idClienteModificar = datosCliente.GetInt32(15);
            total_cotizacion = datosCliente.GetDouble(16);
            cargo_extra_cotizacion = datosCliente.GetDouble(17);
            pesoFinal_cotizacion = datosCliente.GetFloat(18);
            totalIVA_cotizacion = datosCliente.GetFloat(19);
            String prio = datosCliente.GetString(20);
            tipo_envio = datosCliente.GetString(21);

            cbTipoEnvio.SelectedIndex = cbTipoEnvio.FindStringExact(tipo_envio);
            tipoEnvioCb = cbTipoEnvio.SelectedIndex;

            if (prio.Equals("NORMAL"))
            {
                comboUrgencia.SelectedIndex = 0;
            }else if (prio.Equals("URGENTE"))
            {
                comboUrgencia.SelectedIndex = 1;
            }

            comboBoxClientes2.Text = nombre;
            tipo_cliente = tipo_cliente_c;
            lblTipoC.Text = tipo_cliente;
            envio = envio_cotizacion;
            cargo_extra = cargo_extra_cotizacion;
            totalIVA = totalIVA_cotizacion;
            txtEnvio.Text = string.Format("{0:c2}", envio);
            txtCargo.Text = string.Format("{0:c2}", cargo_extra);
            txtIVA.Text = string.Format("{0:c2}", totalIVA);

            BD.CerrarConexion();

            if (totalIVA > 0)
            {
                checkBox.Checked = true;
                factura = true;
            }
            else
            {
                checkBox.Checked = false;
                factura = false;
            }
            //cargarDatosPrecios();
        }
        private void cargarDatosPrecios()
        {
            if(modificar == true)
            {


                Double extras = envio + cargo_extra;
                subtotal = subtotal_modificar+subtotal_nuevo+extras;
                pesoFinal = pesoFinal_modificar+pesoFinal_nuevo;
                cantidad_productos = cantidad_productos_modificar + cantidad_productos_nuevo;

                if (tipoEnvioCb == 1)
                {
                    calcularpaqueteria();
                }

                if (factura == true)
                {
                    totalIVA = subtotal * 0.16;
                }
                else
                {
                    totalIVA = 0;

                }

                total = subtotal+totalIVA;
            }


            txtSubTotal.Text = string.Format("{0:c2}", subtotal);
            txtIVA.Text = string.Format("{0:c2}", totalIVA);
            txtEnvio.Text = string.Format("{0:c2}", envio);
            txtCargo.Text = string.Format("{0:c2}", cargo_extra);
            txtTotal.Text = string.Format("{0:c2}", total);
            txtPesoTotal.Text = Convert.ToString(pesoFinal) + "kg";
            txtProductos.Text = cantidad_productos.ToString();



            //calcular cajas totales
            double cajas = pesoFinal / 25;

            label1.Text = "Total Cajas: " + Math.Ceiling(cajas);

            //calcular envio por estafeta 






        }
        private void cargarTablaModificar()
        {
            Cursor.Current = Cursors.WaitCursor;
            dataProductosModificar = BD.listarProductosCotizacionModificar(idCotizacion);

            int i = 0;
            foreach (DataRow row in dataProductosModificar.Rows)
            {
                float valor = (float) Convert.ToDouble(dataProductosModificar.Rows[i]["PESO"]) * (float) Convert.ToDouble(dataProductosModificar.Rows[i]["CANTIDAD"]);
                String peso_valor = string.Format("{0:n2}",valor);
                dataProductosModificar.Rows[i]["PESO"] = peso_valor;
                i++;
            }

            Cursor.Current = Cursors.Default;
            tablaCotizacionModificar.DataSource = dataProductosModificar;
            tablaCotizacionModificar.Columns["ID_DETALLE"].Visible = false;
            tablaCotizacionModificar.Columns["COLOR_ID"].Visible = false;
            tablaCotizacion.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
            tablaCotizacion.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";
            check = true;
            tablaCotizacionModificar.Rows[0].Selected = false;


            CargarTextoPreciosModificar();
        }
    }
}
