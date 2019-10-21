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
    public partial class Produccion : MetroFramework.Forms.MetroForm
    {
        Inicio Padre = null;
        string tipo_usuario;
        int idProduccion;
        public Produccion(Inicio padre, string tipo_usuario)
        {
            Padre = padre;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            int idProduccion = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
            generarPDF(tipo_usuario, idProduccion);
        }

        private void generarPDF(string tipo, int idProduccion)
        {
            GenerarPDF form = new GenerarPDF(this,tipo,idProduccion);
            form.Show();
            this.Enabled = false; //Productos
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void listarTabla() {
            BD.listarProducciones(lista);
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            listarTabla();
        }
    }
}
