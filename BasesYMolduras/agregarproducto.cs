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
        String modelo = "";
        float precio_frecuente=0, precio_publico=0, precio_mayorista=0,porcentaje=0,peso=0;
        Producto producto;
        public agregarproducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
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
            producto.Enabled = true;
            this.Close();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ID CATEGORIA = " + id_categoria);
            Console.WriteLine("ID MATERIAL = " + id_material);

            if (checkModeloN.Checked)
            {
                Console.WriteLine("MODELO NUEVO = " + txtModelo.Text);
            }
            else if (checkModeloE.Checked)
            {
                Console.WriteLine("MODELO EXISTENTE = " + modelo);
            }

            Console.WriteLine("TIPO = " + id_tipo);

            if (checkTamanoN.Checked)
            {
                Console.WriteLine("TAMAÑO NUEVO = " + txtTamano.Text);
            }
            else if (checkTamanoE.Checked)
            {
                Console.WriteLine("TAMAÑO EXISTENTE = " + id_tamano);
            }

            Console.WriteLine("DESCRIPCION = " + txtDescripcion.Text);

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
                Console.WriteLine("ACTIVADO");
                checkModeloE.Checked = false;
                txtModelo.Enabled = true;
                cbModelo.Enabled = false;

                llenarComboTipo();
                cbTipo.SelectedIndex = cbMaterial.FindStringExact("");
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
                Console.WriteLine("ACTIVADO");
                cbModelo.Enabled = true;
                txtModelo.Enabled = false;
                checkModeloN.Checked = false;
                llenarComboModelo();
                cbModelo.SelectedIndex = cbMaterial.FindStringExact("");

                llenarComboTipo();
                cbTipo.SelectedIndex = cbMaterial.FindStringExact("");
                cbTipo.Enabled = true;

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
    }
}
