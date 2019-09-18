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
        Listados Padre = null;
        int bandera = 0;
        int tareaBandera = 0;
        string tipo_usuario, id;
        Boolean isGuardarDatos;
        DataTable datosCategorias, datosMateriales, datosClientes, datosModelo, datosTamanio, datosColores, datosTipo;
        public AgregarCotizacion(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCliente)
        {
            InitializeComponent();
            this.Padre = padre;
            this.bandera = bandera;
            this.tareaBandera = tareaBandera;
            this.tipo_usuario = tipo_usuario;
            this.id = id;
        }

        private void AgregarCotizacion_Load(object sender, EventArgs e)
        {
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
        }

        private void CargarDatos()
        {
            datosClientes = BD.listarClientesForCotizacion();
            comboCliente.DataSource = datosClientes;
            comboCliente.ValueMember = "RAZONSOCIAL";
            comboCliente.DisplayMember = "RAZONSOCIAL";
            datosCategorias = BD.listarCategoriasForCotizacion();
            comboCategoria.DataSource = datosCategorias;
            comboCategoria.ValueMember = "NOMBRE";
            comboCategoria.DisplayMember = "NOMBRE";
            datosColores = BD.listarColores();
            comboColor.DataSource = datosColores;
            comboColor.ValueMember = "NOMBRE";
            comboColor.DisplayMember = "NOMBRE";
            comboUrgencia.Items.Add("URGENTE");
            comboUrgencia.Items.Add("NORMAL");
            BD metodos = new BD();
            BD.ObtenerConexion();
            MySqlDataReader datosUsuario = metodos.consultaUsuario(id);
            txtVendedor.Text = datosUsuario.GetString(0);
            BD.CerrarConexion();
        }

        private void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = datosClientes.Rows[comboCliente.SelectedIndex];
            txtCliente.Text = row["RAZONSOCIAL"].ToString();
        }

        private void ComboTamanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = datosCategorias.Rows[comboCategoria.SelectedIndex];
                comboTipo.Items.Clear();
                datosTipo = BD.listarTiposForCategoria(Convert.ToInt32(row["id_categoria"].ToString()));
                comboTipo.DataSource = datosTamanio;
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
            cargarModelos();
        }

        private void cargarModelos() {
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
            catch {
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
