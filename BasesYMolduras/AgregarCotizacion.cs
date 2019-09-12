using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class AgregarCotizacion : MetroFramework.Forms.MetroForm
    {
        public AgregarCotizacion(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCliente)
        {
            InitializeComponent();
        }

        private void AgregarCotizacion_Load(object sender, EventArgs e)
        {
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
            DataTable dt = BD.listarClientesForCotizacion();
            comboCliente.DataSource = dt;
            comboCliente.ValueMember = "RAZONSOCIAL";
            comboCliente.DisplayMember = "RAZONSOCIAL";
        }
    }
}
