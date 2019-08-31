using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BasesYMolduras
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            String usuario = this.txtUsuario.Text;
            String contrasena = this.txtContrasena.Text;

            BD metodos = new BD();
            BD.ObtenerConexion();
            Boolean login = metodos.consultaLogin(usuario,contrasena);

            BD.CerrarConexion();

            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("  Ingrese Usuario y Contraseña", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (usuario == "")
                {
                    this.txtUsuario.Focus();
                }
                else if (contrasena == "")
                {
                    this.txtContrasena.Focus();
                }
                return;
            }
            else if (login == false)
            {
                MessageBox.Show("  Usuario / Contraseña Incorrecto", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (login == true) {
                Inicio objForm2 = new Inicio(this);
                objForm2.Show();
                this.Hide();
            }



        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
