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
        string tipo_usuario;
        Inicio Padre = null;
        int bandera = 0;
        public Listados(Inicio padre, int bandera,string tipo_usuario)
        {
            Padre = padre;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
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

        private void BtnControl_Click(object sender, EventArgs e)
        {
            switch (bandera) {
                case 1: AgregarUsuario(bandera,tipo_usuario); break;    //Usuario
                case 4: AgregarCliente(bandera, tipo_usuario); break;    //Usuario
            }
        }

        private void AgregarUsuario(int bandera, string tipo)
        {
            AgregarUsuario form = new AgregarUsuario(this, bandera, tipo);
            form.Show();
            this.Enabled = false;
        }
        private void AgregarCliente(int bandera, string tipo)
        {
            AgregarCliente form = new AgregarCliente(this, bandera, tipo);
            form.Show();
            this.Enabled = false;
        }
    }
}
