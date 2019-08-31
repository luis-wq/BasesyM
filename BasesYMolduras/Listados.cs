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
    public partial class Listados : MetroFramework.Forms.MetroForm
    {


        Inicio Padre = null;
        int bandera = 0;
        public Listados(Inicio padre, int bandera)
        {
            Padre = padre;
            this.bandera = bandera;
            InitializeComponent();
 
        }



        private void Listados_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
            
        }
    }
}
