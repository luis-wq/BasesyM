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
        int idCategoria, idMaterial, idTablaSelect,cantidadTablaSelect;
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

            cargarTablaCategoria();


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
            DataTable datosMateriales = BD.listarMaterialesForCategorias(idCategoria);
            comboBoxMaterial.ValueMember = "id_material";
            comboBoxMaterial.DisplayMember = "NOMBRE";
            comboBoxMaterial.DataSource = datosMateriales;

        }

        private void ComboBoxMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idMaterial = Convert.ToInt32(comboBoxMaterial.SelectedValue);
            cargarTablaMaterial();
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            if (idTablaSelect == 0)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione un producto de la tabla", "Seleccione un producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult pregunta;
                int cantidadP = Convert.ToInt32(txtCantidad.Value) - cantidadTablaSelect;
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
            txtCantidad.Minimum = 0;
            idTablaSelect = Convert.ToInt32(tablaProductos.SelectedRows[0].Cells["ID"].Value.ToString());
            cantidadTablaSelect = Convert.ToInt32(tablaProductos.SelectedRows[0].Cells["CANTIDAD"].Value.ToString());
            txtCantidad.Value = cantidadTablaSelect;
            txtCantidad.Minimum = cantidadTablaSelect;
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
                                let codigo = Convert.ToString(item[1] == null ? string.Empty : item[1].ToString())
                                where codigo.Contains(busqueda)
                                select item).CopyToDataTable();
                //Mostramos las coincidencias
                tablaProductos.DataSource = df;
            }
            catch (Exception ex)
            {

            }
        }


        private void listarProductos()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductos(tablaProductos);
            dt = BD.listarProductos(tablaProductos);
            Cursor.Current = Cursors.Default;
        }

        private void TablaProductos_DataSourceChanged(object sender, EventArgs e)
        {
            lblProductos.Text = "Productos Encontrados: " + tablaProductos.RowCount;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void cargarTablaCategoria()
        {

            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroCategoria(tablaProductos, idCategoria);
            dt = BD.listarProductosFiltroCategoria(tablaProductos, idCategoria);
            Cursor.Current = Cursors.Default;
        }

        private void cargarTablaMaterial()
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
            modificarP = metodos.modificarProducto(idTablaSelect,cantidad);
            BD.CerrarConexion();

            if(modificarP == true)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Producto modificado correctamente", "Producto modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridViewRow row = tablaProductos.CurrentRow;
                row.Cells["CANTIDAD"].Value = cantidad.ToString();

            }
            else
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Error al modificar el producto", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
