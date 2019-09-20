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
    public partial class Producto : MetroFramework.Forms.MetroForm
    {
        Inicio Padre;
        DataTable datosCategorias;
        public Producto(Inicio padre)
        {
            this.Padre = padre;
            InitializeComponent();
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

        private void ComboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarCategoria()
        {

        }
    }
}
