using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace BasesYMolduras
{
    public partial class Producto : MetroFramework.Forms.MetroForm
    {
        Inicio Padre;
        DataTable dt=null;
        DataTable tableProductosFiltro = null;
        int idCategoria, idMaterial, idTamano, idProducto, cantidadProductoInicial;
        float precio_frecuente, precio_publico, precio_mayorista, peso;
        MySqlDataReader datosProducto;

        public Producto(Inicio padre)
        {
            this.Padre = padre;
            InitializeComponent();
            botonModificar();
            cargarCategoria();
            comboBoxCategoria.SelectedIndex = comboBoxCategoria.FindStringExact("");

            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR"))
            {
                btnAgregar.Visible = true;
                btnReporte.Visible = true;
            }
            if(tipo.Equals("VENDEDOR"))
            {
                btnReporte.Visible = true;
            }
        }

        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMaterial = Convert.ToInt32(comboBoxMaterial.SelectedValue);


        }

        private void ComboBoxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCategoria = Convert.ToInt32(comboBoxCategoria.SelectedValue);
            cargarMaterial(idCategoria);
            comboBoxMaterial.SelectedIndex = comboBoxMaterial.FindStringExact("");
            limpiarInformacion();
            tablaProductos.DataSource = 0;
            tablaProductos2.DataSource = 0;

        }
        
        private void cargarCategoria()
        {
            DataTable datosCategorias = BD.listarCategoriasForCotizacion(); 
            comboBoxCategoria.DataSource = datosCategorias;
            comboBoxCategoria.ValueMember = "id_categoria";
            comboBoxCategoria.DisplayMember = "NOMBRE";
        }

        private void cargarMaterial(int idCategoria)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosMateriales = BD.listarMaterialesForCategorias(idCategoria);
            comboBoxMaterial.ValueMember = "id_material";
            comboBoxMaterial.DisplayMember = "NOMBRE";
            comboBoxMaterial.DataSource = datosMateriales;
            Cursor.Current = Cursors.Default;

        }
        private void cargarTipo(int idCategoria,int idMaterial,String tipo)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosMateriales = BD.listarMaterialesForCategorias(idCategoria);
            comboBoxMaterial.ValueMember = "id_material";
            comboBoxMaterial.DisplayMember = "NOMBRE";
            comboBoxMaterial.DataSource = datosMateriales;
            Cursor.Current = Cursors.Default;

        }

        private void ComboBoxMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiarInformacion();
            idMaterial = Convert.ToInt32(comboBoxMaterial.SelectedValue);
            tablaProductos2.DataSource = 0;
            tablaProductos2.Enabled = false;
            cargarTablaModelo();
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            if (idProducto == 0)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un tipo de producto", "Seleccione un producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult pregunta;
                int cantidadP = Convert.ToInt32(txtCantidad.Value) - cantidadProductoInicial;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea agregar " + cantidadP + " al producto?", "Modificar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.Yes)
                {
                    modificarProducto();
                }
                else if (pregunta == DialogResult.No)
                {

                }
            }

        }

        private void TablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            String modelo =tablaProductos.SelectedRows[0].Cells["MODELO"].Value.ToString();
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroTamano(tablaProductos2, idCategoria, idMaterial, modelo);
            tablaProductos2.Columns["ID"].Visible = false;
            Cursor.Current = Cursors.Default;
            tablaProductos2.Enabled = true;
            limpiarInformacion();

        }

        private void MetroTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Si no hay filtro, restauramos el grid original y salimos
                if (txtBusqueda.Text == "")
                {
                    tablaProductos.DataSource = dt;
                    return;
                }

                string busqueda = txtBusqueda.Text;

                //Con LinQ buscamos las rows que coincidan
                DataTable df = (from item in dt.Rows.Cast<DataRow>()
                                let codigo = Convert.ToString(item[0] == null ? string.Empty : item[0].ToString())
                                where codigo.Contains(busqueda)
                                select item).CopyToDataTable();
                //Mostramos las coincidencias
                tablaProductos.DataSource = df;
            }
            catch (Exception ex)
            {

            }
        }

        private void TablaProductos_DataSourceChanged(object sender, EventArgs e)
        {
            lblModelo.Text = "Modelos: " + tablaProductos.RowCount;
        }


        private void TablaProductos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarInformacion();
            String modelo = tablaProductos.SelectedRows[0].Cells["MODELO"].Value.ToString();
            idTamano = Convert.ToInt32(tablaProductos2.SelectedRows[0].Cells["ID"].Value.ToString());
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosTipos = BD.listarMaterialesForTipo(idCategoria, idMaterial, idTamano, modelo);
            txtTipo.ValueMember = "ID";
            txtTipo.DisplayMember = "TIPO";
            txtTipo.DataSource = datosTipos;
            Cursor.Current = Cursors.Default;
            txtTipo.Enabled = true;
            txtTipo.DisplayFocus = true;
            txtTipo.SelectedIndex = comboBoxMaterial.FindStringExact("");

        }

        private void TxtTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtCantidad.Minimum = 0;
            idProducto = Convert.ToInt32(txtTipo.SelectedValue);

            BD metodos = new BD();
            BD.ObtenerConexion();
            datosProducto = metodos.consultarProductoDetalle(idProducto);
            txtId.Text = datosProducto.GetUInt32(0).ToString();
            txtModelo.Text = datosProducto.GetString(1);
            txtTamano.Text = datosProducto.GetString(2);
            txtMaterial.Text = datosProducto.GetString(3);
            txtCategoria.Text = datosProducto.GetString(4);
            int cantidadProducto = datosProducto.GetInt32(5);
            cantidadProductoInicial = cantidadProducto;
            txtCantidad.Value = cantidadProducto;
            txtCantidad.Minimum = cantidadProducto;
            txtTipo.Text = datosProducto.GetString(6);
            precio_publico = datosProducto.GetFloat(7);
            precio_frecuente = datosProducto.GetFloat(8);
            precio_mayorista = datosProducto.GetFloat(9);
            peso = datosProducto.GetFloat(11);
            txtPP.Text = string.Format("{0:c2}", precio_publico);
            txtPF.Text = string.Format("{0:c2}", precio_frecuente);
            txtPM.Text = string.Format("{0:c2}", precio_mayorista);
            txtPeso.Text = string.Format("{0:0.###}", peso); 
            txtDescripcion.Text = datosProducto.GetString(10);
            BD.CerrarConexion();

            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR") || tipo.Equals("PRODUCCION"))
            {
                txtCantidad.Enabled = true;
                btnModificarPrecio.Enabled = true;
                btnModificarProducto.Enabled = true;
                txtPP.Enabled = true;
                txtPF.Enabled = true;
                txtPM.Enabled = true;
                txtPeso.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }

        private void BtnModificarPrecio_Click(object sender, EventArgs e)
        {
            if (idProducto == 0)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un tipo de producto", "Seleccione un producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult pregunta;
                int cantidadP = Convert.ToInt32(txtCantidad.Value) - cantidadProductoInicial;
                String categoria = comboBoxCategoria.Text;
                String material = comboBoxMaterial.Text;
                String tamano = tablaProductos2.SelectedRows[0].Cells["TAMAÑO"].Value.ToString();

                pregunta = MetroFramework.MetroMessageBox.Show(this, "\nEl precio y peso se modificara", "Modificar precio y peso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (pregunta == DialogResult.Yes)
                {
                    modificarPrecio();
                }
                else if (pregunta == DialogResult.No)
                {

                }
            }
        }

        private void TablaProductos2_DataSourceChanged(object sender, EventArgs e)
        {
            lblTamano.Text = "Tamaños: " + tablaProductos2.RowCount;
        }

        private void TxtPF_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_frecuente = (float) Convert.ToDouble(txtPF.Text);
                txtPF.Text = string.Format("{0:c2}", precio_frecuente);
                precio_frecuente = (float) Convert.ToDouble(txtPF.Text);
            }
            catch
            {
                txtPF.Text = string.Format("{0:c2}", precio_frecuente);
            }
        }

        private void TxtPM_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_mayorista = (float) Convert.ToDouble(txtPM.Text);
                txtPM.Text = string.Format("{0:c2}", precio_mayorista);
                precio_mayorista = (float) Convert.ToDouble(txtPM.Text);
            }
            catch
            {
                txtPM.Text = string.Format("{0:c2}", precio_mayorista);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            agregarproducto agregar = new agregarproducto(this);
            agregar.Show();
            agregar.FocusMe();
        }

        private void ComboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel17_Click(object sender, EventArgs e)
        {

        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            try
            {
                peso = (float)Convert.ToDouble(txtPeso.Text);
                txtPeso.Text = string.Format("{0:0.###}", peso);
                peso = (float)Convert.ToDouble(txtPeso.Text);
            }
            catch
            {
                txtPeso.Text = string.Format("{0:0.###}", peso);
            }
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                BD metodos = new BD();
                BD.ObtenerConexion();
                tableProductosFiltro = metodos.consultarProductoDetalleReporte();
                BD.CerrarConexion();
                /*
                Productos.id_producto AS ID, Productos.modelo AS MODELO, Tamanos.tamano AS TAMAÑO,
                Material.nombre AS MATERIAL, Categoria.nombre AS CATEGORIA, Productos.cantidad AS CANTIDAD, 
                Tipo.nombre AS TIPO, Productos.precio_publico AS PRECIO_PUBLICO, Productos.precio_frecuente AS PRECIO_FRECUENTE,
                Productos.precio_mayorista AS PRECIO_MAYORISTA, Tamanos.descripcion AS DESCRIPCION, Productos.peso AS PESO
               */
                for (int i = 0 ; i < tableProductosFiltro.Rows.Count; i++)
                {
                    for( int j = 0; j < tableProductosFiltro.Columns.Count; j++)
                    {
            
                           Console.Write(tableProductosFiltro.Rows[i][j]);
                    }

                    Console.WriteLine("");
                }
            }
            catch
            {
                txtGenerando.Text = "Error de conexión ...";
            }

            if (tableProductosFiltro.Rows.Count != 0)
            {

                try
                {
                    txtGenerando.Text = "GENERANDO DOCUMENTO ...";
                    Cursor.Current = Cursors.WaitCursor;
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.FileName = "reporte_inventario_" + Inicio.fecha;
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        Microsoft.Office.Interop.Excel.Range inicio;
                        Microsoft.Office.Interop.Excel.Range ultimo;

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                        hoja_trabajo.Range["B5:M5"].Font.Bold = true;


                        //hoja_trabajo.Cells[2,8] = "Reporteador";

                        hoja_trabajo.Cells[6, 3] = "Fecha del reporte: " + Inicio.fecha;

                        aplicacion.get_Range("H2:M4").Merge(true);
                        Microsoft.Office.Interop.Excel.Range titulo = hoja_trabajo.get_Range("H2:M4");
                        titulo.Merge();
                        titulo.Value = "INVENTARIO";

                        //titulo.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //titulo.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        titulo.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        titulo.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        titulo.Font.Size = 36;
                        titulo.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                        titulo.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;
                        titulo.Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;

                        ///////////////////////////////
                        //
                        aplicacion.get_Range("H7:M10").Merge(true);
                        Microsoft.Office.Interop.Excel.Range nombre = hoja_trabajo.get_Range("H7:M10");
                        nombre.Merge();
                        nombre.Value = "BASES Y MOLDURAS";
                        nombre.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        nombre.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        nombre.Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;
                        nombre.Font.Size = 30;

                        ////////////////////////////

                        Microsoft.Office.Interop.Excel.Range encabezado = hoja_trabajo.get_Range("B5:T12");
                        encabezado.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                        encabezado.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhiteSmoke;



                        //CONTENIDO
                        hoja_trabajo.Cells[13, 2] = "Id";
                        hoja_trabajo.Cells[13, 3] = "Modelo";
                        hoja_trabajo.Cells[13, 6] = "Tamaño";
                        hoja_trabajo.Cells[13, 8] = "Material";
                        hoja_trabajo.Cells[13, 9] = "Categoria";
                        hoja_trabajo.Cells[13, 11] = "Cantidad";
                        hoja_trabajo.Cells[13, 12] = "Tipo";
                        hoja_trabajo.Cells[13, 14] = "P. P";
                        hoja_trabajo.Cells[13, 15] = "P. F";
                        hoja_trabajo.Cells[13, 16] = "P. M";
                        hoja_trabajo.Cells[13, 17] = "Descripción";
                        hoja_trabajo.Cells[13, 20] = "Peso";

                        int hi = 14;
                        int hj = 2;
                        for (int i = 0; i < tableProductosFiltro.Rows.Count; i++)
                        {
                            for (int j = 0; j < tableProductosFiltro.Columns.Count; j++)
                            {
                                if (j == 0)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    hj++;
                                }
                                else if (j == 1)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    hj = hj + 3;
                                    aplicacion.get_Range("C" + hi.ToString(), "E" + hi.ToString()).Merge(true);
                                }
                                else if (j == 2)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    hj = hj + 2;
                                    aplicacion.get_Range("F" + hi.ToString(), "G" + hi.ToString()).Merge(true);
                                }
                                else if (j == 3)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj++;

                                }
                                else if (j == 4)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj = hj + 2;
                                    aplicacion.get_Range("I" + hi.ToString(), "J" + hi.ToString()).Merge(true);

                                }
                                else if (j == 5)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    //hoja_trabajo.Cells[hi, hj].Style.Color = Color.LightBlue;
                                    hj++;
                                }
                                else if (j == 6)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj = hj + 2;
                                    aplicacion.get_Range("L" + hi.ToString(), "M" + hi.ToString()).Merge(true);
                                }
                                else if (j == 7 || j == 8 || j == 9)
                                {
                                    float num = (float)Convert.ToDouble(tableProductosFiltro.Rows[i][j].ToString());
                                    String numero = string.Format("{0:c2}", num);
                                    hoja_trabajo.Cells[hi, hj] = numero;
                                    hj++;
                                }
                                else if (j == 10)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj = hj + 3;
                                    aplicacion.get_Range("Q" + hi.ToString(), "S" + hi.ToString()).Merge(true);
                                }
                                else if (j == 11)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tableProductosFiltro.Rows[i][j].ToString();
                                    hj++;
                                }

                            }
                            hj = 2;
                            hi++;
                        }


                        //bordes
                        inicio = hoja_trabajo.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                        ultimo = hoja_trabajo.get_Range("B13", inicio);
                        Microsoft.Office.Interop.Excel.Borders bordeTotal = ultimo.Borders;
                        bordeTotal.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        bordeTotal.Weight = 3d;

                        //

                        //bold
                        hoja_trabajo.Range["B13:T13"].Font.Bold = true;
             
                        hoja_trabajo.Range["B13:T13"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightGreen;
                        hoja_trabajo.Range["C6:E6"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightSkyBlue;

                        aplicacion.get_Range("C13", "E13").Merge(true);
                        aplicacion.get_Range("F13", "G13").Merge(true);
                        aplicacion.get_Range("I13", "J13").Merge(true);
                        aplicacion.get_Range("Q13", "S13").Merge(true);
                        aplicacion.get_Range("L13", "M13").Merge(true);


                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        txtGenerando.Text = "";

                        try
                        {
                            System.Diagnostics.Process.Start(fichero.FileName);
                        }
                        catch
                        {
                            DialogResult pregunta2;
                            pregunta2 = MetroFramework.MetroMessageBox.Show(this, "No se puede abrir el documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                        DialogResult pregunta;
                        pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito\n Guardado en: " + fichero.FileName + " ", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Cursor.Current = Cursors.Default;

                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        txtGenerando.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha generado este documento", "AVISO" + ex, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Error" + ex);
                    Cursor.Current = Cursors.Default;
                    txtGenerando.Text = "";
                }
            }
            else
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No existen datos para generar el documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtPF_Click(object sender, EventArgs e)
        {

        }

        private void TxtPP_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_publico = (float) Convert.ToDouble(txtPP.Text);
                txtPP.Text = string.Format("{0:c2}", precio_publico);
                precio_publico = (float) Convert.ToDouble(txtPP.Text);
            }
            catch
            {
                txtPP.Text = string.Format("{0:c2}", precio_publico);
            }
        }

        private void cargarTablaModelo()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroMaterial(tablaProductos, idCategoria, idMaterial);
            dt = BD.listarProductosFiltroMaterial(tablaProductos, idCategoria, idMaterial);
            Cursor.Current = Cursors.Default;
        }

        private void modificarProducto()
        {
            int cantidad = Convert.ToInt32(txtCantidad.Value);
            Boolean modificarP;

            BD metodos = new BD();
            BD.ObtenerConexion();
            modificarP = metodos.modificarProducto(idProducto, cantidad);
            BD.CerrarConexion();

            if(modificarP == true)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Producto modificado correctamente", "Producto modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCantidad.Value = cantidad;
                txtCantidad.Minimum = cantidad;
                cantidadProductoInicial = cantidad;
            }
            else
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Error al modificar el producto", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void modificarPrecio()
        {
            Boolean modificarP;

            BD metodos = new BD();
            BD.ObtenerConexion();
            //int id_producto_select = txtId.Text;
            modificarP = metodos.modificarPrecio(precio_publico,precio_frecuente,precio_mayorista,peso,idProducto);
            BD.CerrarConexion();

            if (modificarP == true)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Precio y peso modificado correctamente", "Precio y peso modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPP.Text = string.Format("{0:c2}", precio_publico);
                txtPF.Text = string.Format("{0:c2}", precio_frecuente);
                txtPM.Text = string.Format("{0:c2}", precio_mayorista);
                txtPeso.Text = string.Format("{0:0.###}", peso);
            }
            else
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Error al modificar el precio", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void limpiarInformacion()
        {
            txtCantidad.Minimum = 0;
            txtId.Text = null;
            txtModelo.Text = null;
            txtTamano.Text = null;
            txtMaterial.Text = null;
            txtCategoria.Text = null;
            int cantidadProducto = 0;
            cantidadProductoInicial = cantidadProducto;
            txtCantidad.Value = cantidadProducto;
            txtTipo.Text = null;
            txtPP.Text = null;
            txtPF.Text = null;
            txtPM.Text = null;
            idTamano = 0;
            txtCantidad.Enabled = false;
            btnModificarPrecio.Enabled = false;
            btnModificarProducto.Enabled = false;
            txtTipo.Enabled = false;
        }

        private void botonModificar()
        {
            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR") || tipo.Equals("PRODUCCION"))
            {
                btnModificarPrecio.Visible = true;
                btnModificarProducto.Enabled = false;
                if (tipo.Equals("PRODUCCION"))
                {
                    metroPanel2.Visible = false;
                    imageLogo.Visible = true;
                }
            }
            else
            {
                btnModificarProducto.Visible = false;
            }
        }
    }
}
