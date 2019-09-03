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
    public partial class Inicio : MetroFramework.Forms.MetroForm
    {
        string tipo_usuario;
        Login Padre = null;
        MySqlDataReader datosUsuario;
        public Inicio(Login padre)
        {
            Padre = padre;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            datosUsuario = metodos.consultaUsuario();
            txtNombre.Text = datosUsuario.GetString(0);
            txtTipoUser.Text = datosUsuario.GetString(1);
            tipo_usuario = datosUsuario.GetString(1);
            BD.CerrarConexion();
            obtenerFecha();
        }

        private void obtenerFecha() {
            DateTime t = BD.ObtenerFecha();
            txtFecha.Text = t.Day + "/" + t.Month + "/" + t.Year + " - " + t.Hour + ": " + t.Minute + ": " + t.Second;
        }
        private void MetroButton1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            IniciarListados(4,tipo_usuario); //Clientes
        }

        private void BtnClientes_MouseEnter(object sender, EventArgs e)
        {
            this.btnClientes.BackColor = Color.Green;
           
        }

        private void BtnClientes_MouseLeave(object sender, EventArgs e)
        {
            this.btnClientes.BackColor = Color.FromArgb(10, 189, 227);
        }

        private void BtnUsuarios_MouseEnter(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.Green;
        }

        private void BtnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.FromArgb(243, 104, 224);
        }

        private void BtnCotizaciones_MouseEnter(object sender, EventArgs e)
        {
            this.btnCotizaciones.BackColor = Color.Green;
        }

        private void BtnCotizaciones_MouseLeave(object sender, EventArgs e)
        {
            this.btnCotizaciones.BackColor = Color.FromArgb(16, 172, 132);
        }

        private void BtnProductos_MouseEnter(object sender, EventArgs e)
        {
            this.btnProductos.BackColor = Color.Green;
        }

        private void BtnProductos_MouseLeave(object sender, EventArgs e)
        {
            this.btnProductos.BackColor = Color.FromArgb(238, 82, 83);
        }

        private void BtnProducciones_MouseEnter(object sender, EventArgs e)
        {
            this.btnProducciones.BackColor = Color.Green;
        }

        private void BtnProducciones_MouseLeave(object sender, EventArgs e)
        {
            this.btnProducciones.BackColor = Color.FromArgb(95, 39, 206);
        }

        private void BtnControl_MouseEnter(object sender, EventArgs e)
        {
            this.btnControl.BackColor = Color.Green;
        }

        private void BtnControl_MouseLeave(object sender, EventArgs e)
        {
            this.btnControl.BackColor = Color.FromArgb(87, 101, 116);
        }

        private void BtnCotRe_MouseEnter(object sender, EventArgs e)
        {
            this.btnCotRe.BackColor = Color.Green;
        }

        private void BtnCotRe_MouseLeave(object sender, EventArgs e)
        {
            this.btnCotRe.BackColor = Color.FromArgb(34, 47, 62);
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            IniciarListados(1,tipo_usuario); //Usuarios
        }

        private void IniciarListados(int bandera,string tipo) {
            Listados form = new Listados(this, bandera,tipo);
            form.Show();
            this.Enabled = false;
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            IniciarListados(2,tipo_usuario); //Productos
        }

        private void BtnCotizaciones_Click(object sender, EventArgs e)
        {
            IniciarListados(3,tipo_usuario); //Cotizaciones
        }

        private void BtnProducciones_Click(object sender, EventArgs e)
        {
            IniciarListados(5,tipo_usuario); //Producciones
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            IniciarListados(6,tipo_usuario); //Control de estados
        }

        private void BtnCotRe_Click(object sender, EventArgs e)
        {
            IniciarListados(7,tipo_usuario); //Cotizaciones realizadas.
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Estas seguro?", "Cerrar Sesión", MessageBoxButtons.YesNo);
            if (pregunta == DialogResult.Yes)
            {
                Login a = new Login();
                a.Show();
                this.Close();
            }
        }
    }
}
