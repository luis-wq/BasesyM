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
    
    public partial class agregarproducto : MetroFramework.Forms.MetroForm
    {

        int id_categoria = 0, id_material=0, id_tipo = 0, id_tamano;
        String modelo = "", tamano = "", descripcion="";
        float precio_frecuente=0, precio_publico=0, precio_mayorista=0,porcentaje=0,peso=0;
        Producto productoVentana;
        public agregarproducto(Producto producto)
        {
            InitializeComponent();
            this.productoVentana = producto;
            llenarComboCategoria();
        }

        private void agregarproducto_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MetroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MetroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void MetroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            productoVentana.Enabled = true;
            productoVentana.Show();
            this.Close();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea agregar el producto?", "Agregar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                agregarProducto();
            }
            else if (pregunta == DialogResult.No)
            {

            }


        }
        private void agregarProducto() {
            try
            {
                porcentaje = (float)Convert.ToDouble(txtPrecioF.Text);
                peso = (float)Convert.ToDouble(txtPrecioF.Text);
            }
            catch
            {
                porcentaje = 0;
                peso = 0;
            }


            descripcion = txtDescripcion.Text;

            if (checkModeloN.Checked)
            {
                modelo = txtModelo.Text;
            }
            else if (checkModeloE.Checked)
            {
                modelo = Convert.ToString(cbModelo.SelectedValue);
            }


            if (checkTamanoN.Checked)
            {
                tamano = txtTamano.Text;

            }
            else if (checkTamanoE.Checked)
            {
                tamano = "#existeTamano%&";
            }


            if (id_categoria != 0 && id_material != 0 && id_tipo != 0 && !modelo.Equals("") && !tamano.Equals("") && !descripcion.Equals(""))
            {

                if (tamano.Equals("#existeTamano%&"))
                {
                    if (id_tamano != 0)
                    {
                        BD existeProduct = new BD();
                        //(String modelo, int id_tamano, int id_material, int id_categoria, int id_tipo)
                        Boolean productoEx = existeProduct.existeProducto(modelo, id_tamano, id_material, id_categoria, id_tipo);

                        if (!productoEx)
                        {
                            BD insertProducto = new BD();
                            Boolean producto = insertProducto.agregarProductoNuevo(modelo, id_tamano, precio_publico, precio_frecuente, precio_mayorista, porcentaje, peso, id_material, id_categoria, id_tipo);

                            if (producto)
                            {
                                DialogResult pregunta;
                                pregunta = MetroFramework.MetroMessageBox.Show(this, "Producto agregado correctamente, ¿Desea salir?", "Usuario modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (pregunta == DialogResult.Yes)
                                {
                                    productoVentana.Enabled = true;
                                    productoVentana.Show();
                                    this.Close();
                                }
                                else if (pregunta == DialogResult.No)
                                {

                                }
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.
                                Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.
                        Show(this, "El producto ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.
                        Show(this, "El tamaño ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    //verifivar si existe tamaño
                    BD exTamano = new BD();
                    Boolean existe = exTamano.existeTamano(tamano, descripcion, id_categoria);
                    Console.WriteLine(existe);
                    if (!existe)
                    {

                        //Crear nuevo registro de tamaño

                        BD insertTamano = new BD();
                        id_tamano = insertTamano.agregarTamanoNuevo(tamano, descripcion, id_categoria);

                        BD insertProducto = new BD();
                        Boolean producto = insertProducto.agregarProductoNuevo(modelo, id_tamano, precio_publico, precio_frecuente, precio_mayorista, porcentaje, peso, id_material, id_categoria, id_tipo);

                        if (producto)
                        {
                            DialogResult pregunta;
                            pregunta = MetroFramework.MetroMessageBox.Show(this, "Producto agregado correctamente, ¿Desea salir?", "Usuario modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (pregunta == DialogResult.Yes)
                            {
                                productoVentana.Enabled = true;
                                productoVentana.Show();
                                this.Close();
                            }
                            else if (pregunta == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.
                            Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {

                        MetroFramework.MetroMessageBox.
                             Show(this, "El tamaño ingresado ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }


            }
            else
            {

                MetroFramework.MetroMessageBox.
                            Show(this, "Llene todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void CheckModelo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MetroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void MetroLabel11_Click(object sender, EventArgs e)//
        {

        }

        private void CbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
            Console.WriteLine("ID CATEGORIA" + id_categoria);
            llenarComboMaterial(id_categoria);
            cbMaterial.Enabled = true;
            cbMaterial.SelectedIndex = cbMaterial.FindStringExact("");
            limpiarDatos(1);
        }

        private void llenarComboCategoria() {

            DataTable datosCategorias = BD.listarCategoriasForCotizacion();
            cbCategoria.DataSource = datosCategorias;
            cbCategoria.ValueMember = "id_categoria";
            cbCategoria.DisplayMember = "NOMBRE";
            cbCategoria.Enabled = true;
        }

        private void CbMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id_material = Convert.ToInt32(cbMaterial.SelectedValue);
            checkModeloE.Enabled = true;
            checkModeloN.Enabled = true;
            limpiarDatos(2);
        }

        private void llenarComboMaterial(int id_categoria)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosMateriales = BD.listarMaterialesForCategorias(id_categoria);
            cbMaterial.ValueMember = "id_material";
            cbMaterial.DisplayMember = "NOMBRE";
            cbMaterial.DataSource = datosMateriales;
            Cursor.Current = Cursors.Default;

        }

        private void CheckModeloN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkModeloN.Checked)
            {
                limpiarDatos(3);
                checkModeloE.Checked = false;
                txtModelo.Enabled = true;
                cbModelo.Enabled = false;
                cbModelo.SelectedIndex = cbModelo.FindStringExact("");

                llenarComboTipo();
                cbTipo.SelectedIndex = cbTipo.FindStringExact("");
                cbTipo.Enabled = true;

            }
            else {
                Console.WriteLine("DESACTIVADO");
                
            }
        }

        private void CheckModeloE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkModeloE.Checked)
            {
                limpiarDatos(3);
                Console.WriteLine("ACTIVADO");
                cbModelo.Enabled = true;
                txtModelo.Text = "";
                txtModelo.Enabled = false;
                checkModeloN.Checked = false;
                llenarComboModelo();
                cbModelo.SelectedIndex = cbModelo.FindStringExact("");

                llenarComboTipo();
                cbTipo.SelectedIndex = cbTipo.FindStringExact("");
                cbTipo.Enabled = false;



            }
            else
            {
                Console.WriteLine("DESACTIVADO");

            }
        }

        private void CheckTamanoN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTamanoN.Checked)
            {
                Console.WriteLine("ACTIVADO");
                checkTamanoE.Checked = false;
                txtTamano.Enabled = true;
                cbTamano.Enabled = false;
                cbTamano.SelectedIndex = cbTamano.FindStringExact("");
                txtDescripcion.Text = "";
                txtDescripcion.Enabled = true;
            }
            else
            {
                Console.WriteLine("DESACTIVADO");

            }
        }

        private void CheckTamanoE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTamanoE.Checked)
            {
                Console.WriteLine("ACTIVADO");
                checkTamanoN.Checked = false;
                txtTamano.Enabled = false;
                txtDescripcion.Enabled = false;

                llenarComboTamano();
                cbTamano.SelectedIndex = cbMaterial.FindStringExact("");
                cbTamano.Enabled = true;
                txtDescripcion.Text = "";
                txtTamano.Text = "";
            }
            else
            {
                Console.WriteLine("DESACTIVADO");

            }
        }

        private void llenarComboModelo()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosModelo = BD.listarProductosFiltroMaterialCombo(id_categoria, id_material);
            cbModelo.ValueMember = "MODELO";
            cbModelo.DisplayMember = "MODELO";
            cbModelo.DataSource = datosModelo;
            Cursor.Current = Cursors.Default;
        }

        private void llenarComboTipo() {
            //SELECT `id_tipo`, `nombre` AS NOMBRE FROM `Tipo` WHERE `fk_categoria` =  
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosModelo = BD.listarTipoCombo(id_categoria);
            cbTipo.ValueMember = "id_tipo";
            cbTipo.DisplayMember = "NOMBRE";
            cbTipo.DataSource = datosModelo;
            Cursor.Current = Cursors.Default;
        }

        private void CbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {

            limpiarDatos(4);
            id_tipo = Convert.ToInt32(cbTipo.SelectedValue);
            checkTamanoE.Enabled = true;
            checkTamanoN.Enabled = true;


        }

        private void TxtPrecioM_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_mayorista = (float)Convert.ToDouble(txtPrecioM.Text);
                txtPrecioM.Text = string.Format("{0:c2}", precio_mayorista);
                precio_mayorista = (float)Convert.ToDouble(txtPrecioM.Text);
            }
            catch
            {
                txtPrecioM.Text = string.Format("{0:c2}", precio_mayorista);
            }
        }

        private void TxtPrecioF_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_frecuente = (float)Convert.ToDouble(txtPrecioF.Text);
                txtPrecioF.Text = string.Format("{0:c2}", precio_frecuente);
                precio_frecuente = (float)Convert.ToDouble(txtPrecioF.Text);
            }
            catch
            {
                txtPrecioF.Text = string.Format("{0:c2}", precio_frecuente);
            }
        }

        private void TxtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtPeso_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtPrecioP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtPrecioP_Leave(object sender, EventArgs e)
        {
            try
            {
                precio_publico = (float)Convert.ToDouble(txtPrecioP.Text);
                txtPrecioP.Text = string.Format("{0:c2}", precio_publico);
                precio_publico = (float)Convert.ToDouble(txtPrecioP.Text);
            }
            catch
            {
                txtPrecioP.Text = string.Format("{0:c2}", precio_publico);
            }
        }

        private void CbTamano_SelectionChangeCommitted(object sender, EventArgs e)
        {
            id_tamano = Convert.ToInt32(cbTamano.SelectedValue);
            BD bd = new BD();
            String descripcion = bd.getDescripcionTamano(id_tamano);
            txtDescripcion.Text = descripcion;
            //getDescripcionTamano
        }

        private void CbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            modelo = Convert.ToString(cbModelo.SelectedValue);
            cbTipo.Enabled = true;
            
        }

        private void llenarComboTamano()
        {
            //SELECT `id_tipo`, `nombre` AS NOMBRE FROM `Tipo` WHERE `fk_categoria` =  
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosModelo = BD.listarTamanoCombo(id_categoria);
            cbTamano.ValueMember = "id_tamano";
            cbTamano.DisplayMember = "TAMANO";
            cbTamano.Name = "descripcion";
            cbTamano.DataSource = datosModelo;
            Cursor.Current = Cursors.Default;
        }

        private void limpiarDatos(int opcion) {

            switch (opcion)
            {

                case 1:
                    id_material = 0;
                    cbMaterial.SelectedIndex = cbMaterial.FindStringExact("");

                    txtModelo.Text = "";
                    txtModelo.Enabled = false;
                    checkModeloN.Checked = false;
                    checkModeloN.Enabled = false;

                    modelo = "";
                    cbModelo.SelectedIndex = cbModelo.FindStringExact("");
                    cbModelo.Enabled = false;
                    checkModeloE.Checked = false;
                    checkModeloE.Enabled = false;

                    id_tipo = 0;
                    cbTipo.SelectedIndex = cbTipo.FindStringExact("");
                    cbTipo.Enabled = false;

                    txtTamano.Text = "";
                    txtTamano.Enabled = false;
                    checkTamanoN.Enabled = false;
                    checkTamanoN.Checked = false;

                    id_tamano = 0;
                    cbTamano.SelectedIndex = cbTamano.FindStringExact("");
                    cbModelo.Enabled = false;
                    checkTamanoE.Checked = false;
                    checkTamanoE.Enabled = false;

                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;

                    break;

                case 2:

                    txtModelo.Text = "";
                    txtModelo.Enabled = false;
                    checkModeloN.Checked = false;

                    modelo = "";
                    cbModelo.SelectedIndex = cbModelo.FindStringExact("");
                    cbModelo.Enabled = false;
                    checkModeloE.Checked = false;

                    id_tipo = 0;
                    cbTipo.SelectedIndex = cbTipo.FindStringExact("");
                    cbTipo.Enabled = false;

                    txtTamano.Text = "";
                    txtTamano.Enabled = false;
                    checkTamanoN.Enabled = false;
                    checkTamanoN.Checked = false;

                    id_tamano = 0;
                    cbTamano.SelectedIndex = cbTamano.FindStringExact("");
                    cbModelo.Enabled = false;
                    checkTamanoE.Checked = false;
                    checkTamanoE.Enabled = false;

                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;

                    break;

                case 3:


                    id_tipo = 0;
                    cbTipo.SelectedIndex = cbTipo.FindStringExact("");
                    cbTipo.Enabled = false;

                    txtTamano.Text = "";
                    txtTamano.Enabled = false;
                    checkTamanoN.Enabled = false;
                    checkTamanoN.Checked = false;

                    id_tamano = 0;
                    cbTamano.SelectedIndex = cbTamano.FindStringExact("");
                    cbModelo.Enabled = false;
                    checkTamanoE.Checked = false;
                    checkTamanoE.Enabled = false;

                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;

                    break;

                case 4:


                    txtTamano.Text = "";
                    txtTamano.Enabled = false;
                    checkTamanoN.Enabled = false;
                    checkTamanoN.Checked = false;

                    id_tamano = 0;
                    cbTamano.SelectedIndex = cbTamano.FindStringExact("");
                    cbTamano.Enabled = false;
                    checkTamanoE.Checked = false;
                    checkTamanoE.Enabled = false;

                    txtDescripcion.Text = "";
                    txtDescripcion.Enabled = false;

                    break;
            }
        }
    }
}
