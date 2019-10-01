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
        int idCategoria, idMaterial, idTablaSelect, idTablaSelectTam,cantidadProductoInicial;
        MySqlDataReader datosProducto;
        public Producto(Inicio padre)
        {
            this.Padre = padre;
            InitializeComponent();
            cargarCategoria();
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

        private void ComboBoxMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idMaterial = Convert.ToInt32(comboBoxMaterial.SelectedValue);
            tablaProductos2.DataSource = 0;
            tablaProductos2.Enabled = false;
            cargarTablaModelo();
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            if (idTablaSelectTam == 0)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un producto de la tabla tamaños", "Seleccione un producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            Cursor.Current = Cursors.WaitCursor;
            txtCantidad.Enabled = true;
            txtCantidad.Minimum = 0;
            idTablaSelectTam = Convert.ToInt32(tablaProductos2.SelectedRows[0].Cells["ID"].Value.ToString());

            BD metodos = new BD();
            BD.ObtenerConexion();
            datosProducto = metodos.consultarProductoDetalle(idTablaSelectTam);

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
            txtPF.Text = datosProducto.GetFloat(7).ToString();
            txtPM.Text = datosProducto.GetFloat(7).ToString();
            BD.CerrarConexion();

            Cursor.Current = Cursors.Default;

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
            modificarP = metodos.modificarProducto(idTablaSelectTam, cantidad);
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
            idTablaSelectTam = 0;
            txtCantidad.Enabled = false;
        }
    }
}
