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
        int idCategoria, idMaterial, idTamano, idTablaSelect, idProducto, cantidadProductoInicial;
        MySqlDataReader datosProducto;
        public Producto(Inicio padre)
        {
            this.Padre = padre;
            InitializeComponent();
            cargarCategoria();
            botonModificar();
            comboBoxCategoria.SelectedIndex = comboBoxCategoria.FindStringExact("");
            
        }
        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
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
            txtPP.Text = datosProducto.GetFloat(7).ToString();
            txtPF.Text = datosProducto.GetFloat(8).ToString();
            txtPM.Text = datosProducto.GetFloat(9).ToString();
            txtDescripcion.Text = datosProducto.GetString(10);
            BD.CerrarConexion();

            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR") || tipo.Equals("PRODUCCION"))
            {
                txtCantidad.Enabled = true;
                btnModificarPrecio.Enabled = true;
                txtPP.Enabled = true;
                txtPF.Enabled = true;
                txtPM.Enabled = true;
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

                pregunta = MetroFramework.MetroMessageBox.Show(this, "\nEl precio se modificara en todos los productos con las siguientes características:\n\n" +
                    "Categoria: "+categoria+"\n" +
                    "Material: "+material+"\n" +
                    "Tamaño: "+tamano+"", "Modificar precio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            int precioP = Convert.ToInt32(txtPP.Text);
            int precioF = Convert.ToInt32(txtPF.Text);
            int precioM = Convert.ToInt32(txtPM.Text);

            Boolean modificarP;

            BD metodos = new BD();
            BD.ObtenerConexion();
            modificarP = metodos.modificarPrecio(precioP,precioF,precioM,idCategoria,idMaterial,idTamano);
            BD.CerrarConexion();

            if (modificarP == true)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Precio modificado correctamente", "Precio modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPP.Text = precioP.ToString();
                txtPF.Text = precioF.ToString();
                txtPM.Text = precioM.ToString();
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
            txtTipo.Enabled = false;
        }

        private void botonModificar()
        {
            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR") || tipo.Equals("PRODUCCION"))
            {
                btnModificarPrecio.Visible = true;
            }
            else
            {
                btnModificarProducto.Visible = false;
            }
        }
    }
}
