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
        Cargando cargar;
        Listados Padre = null;
        int bandera = 0;
        int tareaBandera = 0;
        string tipo_usuario, id;
        Boolean isGuardarDatos, isFirstTime, isCargarCategorias = false, isCargarModelos = false;
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
            cargar = new Cargando();
            cargar.Show();
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            isGuardarDatos = false;
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

            cargar.Hide();
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;
        }

        private void CargarDatos()
        {
            
            datosClientes = BD.listarClientesForCotizacion();
            comboCliente.DataSource = datosClientes;
            comboCliente.ValueMember = "RAZONSOCIAL";
            comboCliente.DisplayMember = "RAZONSOCIAL";
/*            datosCategorias = BD.listarCategoriasForCotizacion();
            comboCategoria.DataSource = datosCategorias;
            comboCategoria.ValueMember = "NOMBRE";
            comboCategoria.DisplayMember = "NOMBRE";*/
            datosColores = BD.listarColores();
            comboColor.DataSource = datosColores;
            comboColor.ValueMember = "NOMBRE";
            comboColor.DisplayMember = "NOMBRE";
            comboUrgencia.Items.Add("URGENTE");
            comboUrgencia.Items.Add("NORMAL");
            comboCategoria.Items.Add("Seleccionar");
            BD metodos = new BD();
            BD.ObtenerConexion();
            MySqlDataReader datosUsuario = metodos.consultaUsuario(id);
            txtVendedor.Text = datosUsuario.GetString(0);
            BD.CerrarConexion();
        }

        private void Loading(int metodo) {
            cargar.Show();
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            switch (metodo) {
                case 1: selectCliente(); break;
                case 2: selectTipo(); break;
                case 3: selectModelos(); break;
                case 4: selectCategoria();
                    selectTipo();
                    break;
                case 5: selectMaterial(); break;
            }
            cargar.Hide();
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;
        }
        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading(1);
        }

        private void selectCliente() {
                DataRow row = datosClientes.Rows[comboCliente.SelectedIndex];
                txtCliente.Text = row["RAZONSOCIAL"].ToString();

        }
        private void ComboTamanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectTipo() {
                try
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboTipo.Items.Clear();
                    datosTipo = BD.listarTiposForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTipo.DataSource = datosTipo;
                    comboTipo.ValueMember = "NOMBRE";
                    comboTipo.DisplayMember = "NOMBRE";
                }
                catch
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    datosTipo = BD.listarTiposForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTipo.DataSource = datosTipo;
                    comboTipo.ValueMember = "NOMBRE";
                    comboTipo.DisplayMember = "NOMBRE";
                }
        }

        private void ComboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCargarCategorias)
            {
                isCargarCategorias = false;
            }
            else {
                Loading(3);
                isCargarModelos = true;
            }
        }

        private void selectModelos() {
    
                try
                {
                    DataRow row = datosMateriales.Rows[comboMaterial.SelectedIndex];
                    DataRow rowCategoria = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboModelo.Items.Clear();
                    datosModelo = BD.listarModelosForMaterial(Convert.ToInt32(row["id_material"].ToString()), Convert.ToInt32(rowCategoria["id_categoria"].ToString()));
                    comboModelo.DataSource = datosModelo;
                    comboModelo.ValueMember = "NOMBRE";
                    comboModelo.DisplayMember = "NOMBRE";
                }
                catch
                {
                    DataRow row = datosMateriales.Rows[comboMaterial.SelectedIndex];
                    DataRow rowCategoria = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    datosModelo = BD.listarModelosForMaterial(Convert.ToInt32(row["id_material"].ToString()), Convert.ToInt32(rowCategoria["id_categoria"].ToString()));
                    comboModelo.DataSource = datosModelo;
                    comboModelo.ValueMember = "NOMBRE";
                    comboModelo.DisplayMember = "NOMBRE";
                }
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

        private void ComboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirstTime == true)
            {
                datosCategorias = BD.listarCategoriasForCotizacion();
                comboCategoria.DataSource = datosCategorias;
                comboCategoria.ValueMember = "NOMBRE";
                comboCategoria.DisplayMember = "NOMBRE";
                isFirstTime = false;
            }
            else { 
            Loading(4);
                isCargarCategorias = true;
            }
        }

        private void selectCategoria() {
            
                try
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboMaterial.Items.Clear();
                    datosMateriales = BD.listarMaterialesForCategorias(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboMaterial.DataSource = datosMateriales;
                    comboMaterial.ValueMember = "NOMBRE";
                    comboMaterial.DisplayMember = "NOMBRE";
                    comboModelo.DataSource = null;
                    comboModelo.Items.Clear();
                    comboTamanio.DataSource = null;
                    comboTamanio.Items.Clear();
                }
                catch
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    datosMateriales = BD.listarMaterialesForCategorias(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboMaterial.DataSource = datosMateriales;
                    comboMaterial.ValueMember = "NOMBRE";
                    comboMaterial.DisplayMember = "NOMBRE";
                    comboModelo.DataSource = null;
                    comboModelo.Items.Clear();
                    comboTamanio.DataSource = null;
                    comboTamanio.Items.Clear();
            }
        }

        private void ComboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCargarModelos) {
                isCargarModelos = false;
            }
            else { 
            Loading(5);
            }
        }

        private void selectMaterial() {

                try
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    comboTamanio.Items.Clear();
                    datosTamanio = BD.listarTamaniosForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTamanio.DataSource = datosTamanio;
                    comboTamanio.ValueMember = "NOMBRE";
                    comboTamanio.DisplayMember = "NOMBRE";
                }
                catch
                {
                    DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                    datosTamanio = BD.listarTamaniosForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                    comboTamanio.DataSource = datosTamanio;
                    comboTamanio.ValueMember = "NOMBRE";
                    comboTamanio.DisplayMember = "NOMBRE";
                }
        }
    }
}
