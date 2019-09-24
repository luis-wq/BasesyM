using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class AgregarCotizacion : MetroFramework.Forms.MetroForm
    {
        DataTable ItemCotizacion, datosPreciosSeleccion;
        Listados Padre = null;
        int bandera = 0;
        int tareaBandera = 0;
        string tipo_usuario, id;
        Boolean isGuardarDatos, isFirstTime, isCargarCategorias = false, isCargarModelos = false, isFirstTimeCliente = true;
        DataTable datosCategorias, datosMateriales, datosClientes, datosModelo, datosTamanio, datosColores, datosTipo;
        public AgregarCotizacion(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCliente)
        {
            InitializeComponent();
            this.Padre = padre;
            this.bandera = bandera;
            this.tareaBandera = tareaBandera;
            this.tipo_usuario = tipo_usuario;
            this.id = id;
            isFirstTime = true;
        }


        private void AgregarCotizacion_Load(object sender, EventArgs e) 
        {

            isGuardarDatos = false;
            ItemCotizacion = new DataTable();
            ItemCotizacion.Columns.Add("MODELO");
            ItemCotizacion.Columns.Add("CATEGORIA");
            ItemCotizacion.Columns.Add("MATERIAL");
            ItemCotizacion.Columns.Add("COLOR");
            ItemCotizacion.Columns.Add("TAMAÑO");
            ItemCotizacion.Columns.Add("CANT").MaxLength = 4;
            ItemCotizacion.Columns.Add("PRECIO");
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
            
        }
        private void CargarDatosHilo()
        {
            UseWaitCursor = true;
            //Listados.ActiveForm.Enabled = false;
            
            this.CargarDatos();

            UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            //Listados.ActiveForm.Enabled = true;
            this.Refresh();

            
        }
        private void CargarDatos()
        {
            datosColores = BD.listarColores();
            comboColor.DataSource = datosColores;
            comboColor.ValueMember = "NOMBRE";
            comboColor.DisplayMember = "NOMBRE";
            comboUrgencia.Items.Add("URGENTE");
            comboUrgencia.Items.Add("NORMAL");
            comboCategoria.Items.Add("Seleccionar");
            datosClientes = BD.listarClientesForCotizacion();
            comboCliente.DataSource = datosClientes;
            comboCliente.ValueMember = "RAZONSOCIAL";
            comboCliente.DisplayMember = "RAZONSOCIAL";

        }
        private void Loading(int metodo) {
            switch (metodo) {
                case 1: selectCliente(); break;
                case 2: selectTipo(); break;
                case 3: selectModelos(); break;
                case 4: selectCategoria();
                    selectTipo();
                    break;
                case 5: selectMaterial(); break;
            }
            
        }
        private void limpiarCampos() {
            datosCategorias = BD.listarCategoriasForCotizacion();
            comboCategoria.DataSource = datosCategorias;
            comboCategoria.ValueMember = "NOMBRE";
            comboCategoria.DisplayMember = "NOMBRE";
        }
        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
                Loading(1);
        }

        private void selectCliente() {
                DataRow row = datosClientes.Rows[comboCliente.SelectedIndex];
                txtCliente.Text = row["RAZONSOCIAL"].ToString();
        }

        private void ComboModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
                Loading(5);
        }

        private void ComboCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (isFirstTime == true)
            {
                datosCategorias = BD.listarCategoriasForCotizacion();
                comboCategoria.DataSource = datosCategorias;
                comboCategoria.ValueMember = "NOMBRE";
                comboCategoria.DisplayMember = "NOMBRE";
                isFirstTime = false;

            }
            else
            {
                Loading(4);
                isCargarCategorias = true;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
            }
        }

        private void ComboMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Loading(3);
        }

        private void ComboTamanio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboDescripcion.DataSource = datosTamanio;
            comboDescripcion.ValueMember = "descripcion";
            comboDescripcion.DisplayMember = "descripcion";
        }



        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCotizacion.Rows.RemoveAt(lista.CurrentRow.Index);
                lista.DataSource = ItemCotizacion;
            }
            catch {
                DialogResult pregunta;

                pregunta = MetroFramework.MetroMessageBox.Show(this, "No hay productos agregados o no ha seleccionado alguno.", "Error al quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;


            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
              DataRow row = ItemCotizacion.NewRow();
              row["MODELO"] = comboModelo.GetItemText(comboModelo.SelectedItem).ToString();
              row["CATEGORIA"] = comboCategoria.GetItemText(comboCategoria.SelectedItem).ToString();
              row["MATERIAL"] = comboMaterial.GetItemText(comboMaterial.SelectedItem).ToString();
              row["COLOR"] = comboColor.GetItemText(comboColor.SelectedItem).ToString();
              row["TAMAÑO"] = comboTamanio.GetItemText(comboTamanio.SelectedItem).ToString();
              row["CANT"] = txtCantidad.Text;


              datosPreciosSeleccion = BD.consultaPrecio(comboModelo.GetItemText(comboModelo.SelectedItem).ToString(),
                  Convert.ToInt32(datosTamanio.Rows[comboTamanio.SelectedIndex]["id_tamano"]), 
                  Convert.ToInt32(datosMateriales.Rows[comboMaterial.SelectedIndex]["id_material"]), 
                  Convert.ToInt32(datosCategorias.Rows[comboCategoria.SelectedIndex]["id_categoria"]));

              if (datosClientes.Rows[comboCliente.SelectedIndex]["tipo_cliente"].Equals("PUBLICO"))
              {
                  row["PRECIO"] = "$" + datosPreciosSeleccion.Rows[0]["precio_publico"];
              }
              else if (datosClientes.Rows[comboCliente.SelectedIndex]["tipo_cliente"].Equals("FRECUENTE"))
              {
                  row["PRECIO"] = "$" + datosPreciosSeleccion.Rows[0]["precio_frecuente"];
              }
              else if (datosClientes.Rows[comboCliente.SelectedIndex]["tipo_cliente"].Equals("MAYORISTA"))
              {
                  row["PRECIO"] = "$" + datosPreciosSeleccion.Rows[0]["precio_mayorista"];
              }

              ItemCotizacion.Rows.Add(row);
              lista.DataSource = ItemCotizacion;
              lista.Columns[lista.Columns["CANT"].Index].Width = 55;
              lista.Columns[lista.Columns["PRECIO"].Index].Width = 65;
              if (!isGuardarDatos)
              {
                  datosCategorias = BD.listarCategoriasForCotizacion();
                  comboCategoria.DataSource = datosCategorias;
                  comboCategoria.ValueMember = "NOMBRE";
                  comboCategoria.DisplayMember = "NOMBRE";
              }

            txtCliente.Text = comboModelo.GetItemText(comboModelo.SelectedItem).ToString();
        }

        private void selectTipo() {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboTipo.DataSource = null;
                    comboTipo.Items.Clear();
                    datosTipo = BD.listarTiposForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTipo.DataSource = datosTipo;
                    comboTipo.ValueMember = "NOMBRE";
                    comboTipo.DisplayMember = "NOMBRE";
        }

  

        private void selectModelos() {
                    DataRow row = datosMateriales.Rows[comboMaterial.SelectedIndex];
                    DataRow rowCategoria = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboModelo.DataSource = null;
                    comboModelo.Items.Clear();
                    datosModelo = BD.listarModelosForMaterial(Convert.ToInt32(row["id_material"].ToString()), Convert.ToInt32(rowCategoria["id_categoria"].ToString()));
                    comboModelo.DataSource = datosModelo;
                    comboModelo.ValueMember = "NOMBRE";
                    comboModelo.DisplayMember = "NOMBRE";
        }

        private void CheckCampos_CheckedChanged(object sender, EventArgs e)
        {
            if (!isGuardarDatos)
            {
                isGuardarDatos = true;
            }
            else
            {
                isGuardarDatos = false;
            }
        }

   

        private void selectCategoria() {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboMaterial.DataSource = null;
                    comboMaterial.Items.Clear();
                    datosMateriales = BD.listarMaterialesForCategorias(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboMaterial.DataSource = datosMateriales;
                    comboMaterial.ValueMember = "NOMBRE";
                    comboMaterial.DisplayMember = "NOMBRE";
                    comboModelo.DataSource = null;
                    comboModelo.Items.Clear();
                    comboTamanio.DataSource = null;
                    comboTamanio.Items.Clear();
                comboDescripcion.DataSource = null;
                comboDescripcion.Items.Clear();
        }



        private void selectMaterial() {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboTamanio.DataSource = null;
                    comboTamanio.Items.Clear();
                    datosTamanio = BD.listarTamaniosForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTamanio.DataSource = datosTamanio;
                    comboTamanio.ValueMember = "NOMBRE";
                    comboTamanio.DisplayMember = "NOMBRE";
        }
    }
}
