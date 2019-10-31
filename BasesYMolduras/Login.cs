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
        internal static string tipo;
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

        private async void MetroButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String usuario = this.txtUsuario.Text;
                String contrasena = this.txtContrasena.Text;
                Boolean campos=true,login=false;

                txtContrasena.Enabled = false;
                txtUsuario.Enabled = false;

                spinnerLogin.Visible = true;
                btnIngresar.Visible = false;

                if (usuario == "" || contrasena == "")
                {
                    spinnerLogin.Visible = false;
                    btnIngresar.Visible = true;
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
                    campos= false;
                    txtContrasena.Enabled = true;
                    txtUsuario.Enabled = true;
                }
                else
                {
                    login = await loginBDAsync(usuario, contrasena);
                    spinnerLogin.Visible = false;
                    btnIngresar.Visible = true;
                }

                if (login == false && campos == true)
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "  Usuario / Contraseña Incorrecto", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasena.Enabled = true;
                    txtUsuario.Enabled = true;
                }
                else if (login == true && campos == true)
                {
                    txtContrasena.Enabled = true;
                    txtUsuario.Enabled = true;

                    BD metodos = new BD();
                    BD.ObtenerConexion();
                    idUsuario = metodos.consultaId(usuario,contrasena);
                    BD.CerrarConexion();

                    BD.ObtenerConexion();
                    tipo = metodos.consultaTipo(usuario, contrasena);
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
        private Task<Boolean> loginBDAsync(string usuario, string contrasena)
        {
            return Task.Run(() => {
                BD metodos = new BD();
                BD.ObtenerConexion();
                Boolean login = metodos.consultaLogin(usuario, contrasena);
                BD.CerrarConexion();
                System.Threading.Thread.Sleep(2000);
                return login;
            });
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
