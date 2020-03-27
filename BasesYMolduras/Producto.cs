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
        float precio_frecuente, precio_publico, precio_mayorista;
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
            txtPP.Text = string.Format("{0:c2}", precio_publico);
            txtPF.Text = string.Format("{0:c2}", precio_frecuente);
            txtPM.Text = string.Format("{0:c2}", precio_mayorista);
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

                pregunta = MetroFramework.MetroMessageBox.Show(this, "\nEl precio se modificara", "Modificar precio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            modificarP = metodos.modificarPrecio(precio_publico,precio_frecuente,precio_mayorista,idProducto);
            BD.CerrarConexion();

            if (modificarP == true)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Precio modificado correctamente", "Precio modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPP.Text = string.Format("{0:c2}", precio_publico);
                txtPF.Text = string.Format("{0:c2}", precio_frecuente);
                txtPM.Text = string.Format("{0:c2}", precio_mayorista);
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
