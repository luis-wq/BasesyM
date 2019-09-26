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

namespace BasesYMolduras
{
    public partial class Producto : MetroFramework.Forms.MetroForm
    {
        Inicio Padre;
        DataTable datosCategorias,dt;
        int idCategoria, idMaterial, idTablaSelect,cantidadTablaSelect;
        public Producto(Inicio padre)
        {
            this.Padre = padre;
            InitializeComponent();
            cargarCategoria();
            listarProductos();


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
            BD.listarProductosFiltroCategoria(tablaProductos, idCategoria);
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
            BD.listarProductosFiltroMaterial(tablaProductos,idCategoria,idMaterial);
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            modificarProducto();
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
            BD.listarProductos(tablaProductos);
            dt = BD.listarProductos(tablaProductos);
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
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Producto modificado correctamente, ¿Desea salir?", "Producto modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            else
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Error al modificar el producto", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
