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
using MySql.Data.MySqlClient;

namespace BasesYMolduras
{
    public partial class Inicio : MetroFramework.Forms.MetroForm
    {
        string id;
        string tipo_usuario, usuario,contrasena;
        Login Padre = null;
        MySqlDataReader datosUsuario;
        public Inicio(Login padre,string usuario,string contrasena)
        {
            CheckForIllegalCrossThreadCalls = false;
            Padre = padre;
            this.usuario = usuario;
            this.contrasena = contrasena;
            InitializeComponent();
        }

        public Inicio(string id)
        {
            this.id = id;
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }


        private async void Form2_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            metroPanel1.Enabled = false;
            await CargarDatosAsync();
            System.Threading.Thread.Sleep(2000);
            metroPanel1.Enabled = true;
            Cursor.Current = Cursors.Default;

        }

        private async Task CargarDatosAsync()
        {
            await Task.Run(() => {
                //Método que hace toda la carga de datos
                BD metodos = new BD();
                BD.ObtenerConexion();
                MySqlDataReader datos = metodos.ObtenerIdUsuario(usuario, contrasena);
                id = datos.GetUInt32(0).ToString();
                BD.CerrarConexion();
                BD.ObtenerConexion();
                datosUsuario = metodos.consultaUsuario(id);
                txtNombre.Text = datosUsuario.GetString(0);
                txtTipoUser.Text = datosUsuario.GetString(1);
                tipo_usuario = datosUsuario.GetString(1);
                BD.CerrarConexion();
                if (tipo_usuario.Equals("VENDEDOR"))
                {
                    btnUsuarios.Enabled = false;
                    btnControl.Enabled = false;
                    btnCotRe.Enabled = false;
                }
                if (tipo_usuario.Equals("PRODUCCION"))
                {
                    btnUsuarios.Enabled = false;
                    btnCotizaciones.Enabled = false;
                    btnProductos.Enabled = false;
                    btnClientes.Enabled = false;
                    btnCotRe.Enabled = false;
                    btnClientes.BackColor = Color.Red;
                    btnUsuarios.BackColor = Color.Red;
                    btnProductos.BackColor = Color.Red;
                    btnCotizaciones.BackColor = Color.Red;
                    btnCotRe.BackColor = Color.Red;
                }
                obtenerFecha();
            });

        }

        private void obtenerFecha() {
            DateTime t = BD.ObtenerFecha();
            txtFecha.Text = t.Day + "/" + t.Month + "/" + t.Year;
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
            this.btnClientes.BackColor = Color.Blue;
        }

        private void BtnUsuarios_MouseEnter(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.Green;
        }

        private void BtnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.SlateGray;
        }

        private void BtnCotizaciones_MouseEnter(object sender, EventArgs e)
        {
            this.btnCotizaciones.BackColor = Color.Green;
        }

        private void BtnCotizaciones_MouseLeave(object sender, EventArgs e)
        {
            this.btnCotizaciones.BackColor = Color.Navy;
        }

        private void BtnProductos_MouseEnter(object sender, EventArgs e)
        {
            this.btnProductos.BackColor = Color.Green;
        }

        private void BtnProductos_MouseLeave(object sender, EventArgs e)
        {
            this.btnProductos.BackColor = Color.LightSlateGray;
        }

        private void BtnProducciones_MouseEnter(object sender, EventArgs e)
        {
            this.btnProducciones.BackColor = Color.Green;
        }

        private void BtnProducciones_MouseLeave(object sender, EventArgs e)
        {
            this.btnProducciones.BackColor = Color.Purple;
        }

        private void BtnControl_MouseEnter(object sender, EventArgs e)
        {
            this.btnControl.BackColor = Color.Green;
        }

        private void BtnControl_MouseLeave(object sender, EventArgs e)
        {
            this.btnControl.BackColor = Color.SlateBlue;
        }

        private void BtnCotRe_MouseEnter(object sender, EventArgs e)
        {
            this.btnCotRe.BackColor = Color.Green;
        }

        private void BtnCotRe_MouseLeave(object sender, EventArgs e)
        {
            this.btnCotRe.BackColor = Color.Black;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            IniciarListados(1,tipo_usuario); //Usuarios
        }

        private void IniciarListados(int bandera,string tipo) {
            Listados form = new Listados(this, bandera,tipo,id);
            form.Show();
            this.Enabled = false;
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Producto form = new Producto(this);
            form.Show();
            this.Enabled = false; //Productos
        }

        private void BtnCotizaciones_Click(object sender, EventArgs e)
        {
            IniciarListados(3,tipo_usuario); //Cotizaciones
        }

        private void BtnProducciones_Click(object sender, EventArgs e)
        {
            //Producciones
            Produccion form = new Produccion(this,tipo_usuario);
            form.Show();
            this.Enabled = false;
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            ControlEstado form = new ControlEstado(this);
            form.Show();
            //this.Enabled = false; //Control de estado
        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inicio_VisibleChanged(object sender, EventArgs e)
        {
            //obtenerFecha();
        }

        private void Inicio_Activated(object sender, EventArgs e)
        {
            //obtenerFecha();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {

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
