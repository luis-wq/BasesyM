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
        internal static int idUsuario;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.AutoSize = false;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {



        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PanelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MetroButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String usuario = this.txtUsuario.Text;
                String contrasena = this.txtContrasena.Text;

                BD metodos = new BD();
                BD.ObtenerConexion();
                Boolean login = metodos.consultaLogin(usuario, contrasena);
                BD.CerrarConexion();

                if (usuario == "" || contrasena == "")
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "  Ingrese Usuario y Contraseña", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MetroFramework.MetroMessageBox.
                    Show(this, "  Usuario / Contraseña Incorrecto", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (login == true)
                {
                    BD.ObtenerConexion();
                    idUsuario = metodos.consultaId(usuario, contrasena);
                    BD.CerrarConexion();
                    
                    Inicio objForm2 = new Inicio(this,usuario,contrasena);
                    objForm2.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.
                    Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
