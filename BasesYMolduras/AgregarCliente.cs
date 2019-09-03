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
    public partial class AgregarCliente : MetroFramework.Forms.MetroForm
    {
        string tipo_usuario;
        Listados Padre = null;
        int bandera = 0;
        public AgregarCliente(Listados padre, int bandera, string tipo_usuario)
        {
            Padre = padre;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
