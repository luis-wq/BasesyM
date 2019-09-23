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
    public partial class AgregarUsuario : MetroFramework.Forms.MetroForm
    {
        string nombreUsuarioModificar;
        int tareaBandera,idTabla;
        Listados Padre = null;
        MySqlDataReader datosUsuario;
        public AgregarUsuario(Listados padre, int tareaBandera,int idTabla)
        {
            Padre = padre;
            this.tareaBandera = tareaBandera;
            this.idTabla = idTabla;
 
            InitializeComponent();
            tareaRealizar();

        }


        private void MetroButton1_Click(object sender, EventArgs e)
        {

            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
            }

        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            agregarUsuario();
        }

        private void limpiarTextBox() {

            ComboBoxTipo.Items.Clear();
            this.txtNombre.Text = "";
            this.txtAP.Text = "";
            this.txtAM.Text = "";
            this.txtUser.Text = "";
            this.txtPIN.Text = "";

            ComboBoxTipo.Items.Add("VENDEDOR");
            ComboBoxTipo.Items.Add("PRODUCCION");
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void tareaRealizar()
        {
            switch (tareaBandera)
            {   //Detalles
                case 1:
                    btnSalir.Visible = true;
                    lblTitulo.Text = "DETALLE DE USUARIO";

                    txtNombre.Enabled = false;
                    txtAP.Enabled = false;
                    txtAM.Enabled = false;
                    txtUser.Enabled = false;
                    txtPIN.Enabled = false;
                    

                    consultarUsuario(tareaBandera);

                    break;
                //Agregar
                case 2:
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    lblTitulo.Text = "AGREGAR USUARIO";
                    ComboBoxTipo.Items.Add("VENDEDOR");
                    ComboBoxTipo.Items.Add("PRODUCCION");

                    break;
                //Modificar
                case 3:

                    lblTitulo.Text = "MODIFICAR USUARIO";
                    btnModificar.Visible = true;
                    btnCancelar.Visible = true;
                    consultarUsuario(tareaBandera);
                    nombreUsuarioModificar = txtUser.Text;
                    break;    
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            modificarUsuario();
        }

        private void agregarUsuario() {

            String tipo = this.ComboBoxTipo.Text;
            String nombre = this.txtNombre.Text;
            String ap = this.txtAP.Text;
            String am = this.txtAM.Text;
            String usuario = this.txtUser.Text;
            String pin = this.txtPIN.Text;
            Boolean agregar;
            Boolean usuarioExiste;

            BD metodos = new BD();
            BD.ObtenerConexion();
            usuarioExiste = metodos.usuarioExiste(usuario);
            BD.CerrarConexion();

            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ap) || string.IsNullOrEmpty(am) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pin))
            {

                MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (usuarioExiste == true)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Ya existe un usuario con nombre de usuario: "+ usuario, "Error al ingresar nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                BD.ObtenerConexion();
                agregar = metodos.agregarUsuario(tipo, nombre, ap, am, usuario, pin);
                BD.CerrarConexion();


                if (agregar == true)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Usuario agregado correctamente, ¿Desea agregar otro usuario?", "Usuario agregado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (pregunta == DialogResult.Yes)
                    {
                        limpiarTextBox();
                    }
                    else if (pregunta == DialogResult.No)
                    {
                        Padre.Enabled = true;
                        Padre.FocusMe();
                        Padre.CargarDatos();
                        this.Close();
                    }

                }
                else if (agregar == false)
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        public void modificarUsuario() {

            String tipo = this.ComboBoxTipo.Text;
            String nombre = this.txtNombre.Text;
            String ap = this.txtAP.Text;
            String am = this.txtAM.Text;
            String usuario = this.txtUser.Text;
            String pin = this.txtPIN.Text;
            Boolean agregar;
            Boolean usuarioExiste;
            BD metodos = new BD();

            if (nombreUsuarioModificar.Equals(usuario))
            {
                usuarioExiste = false;
            }
            else
            {
                BD.ObtenerConexion();
                usuarioExiste = metodos.usuarioExiste(usuario);
                BD.CerrarConexion();
            }

            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ap) || string.IsNullOrEmpty(am) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pin))
            {

                MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (usuarioExiste == true)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Ya existe un usuario con nombre de usuario: " + usuario, "Error al ingresar nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BD.ObtenerConexion();
                agregar = metodos.modificarUsuario(tipo, nombre, ap, am, usuario, pin, idTabla);
                BD.CerrarConexion();


                if (agregar == true)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Usuario modificado correctamente, ¿Desea salir?", "Usuario modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    nombreUsuarioModificar = usuario;
                    if (pregunta == DialogResult.Yes)
                    {
                        Padre.Enabled = true;
                        Padre.FocusMe();
                        Padre.CargarDatos();
                        this.Close();
                    }
                    else if (pregunta == DialogResult.No)
                    {

                    }

                }
                else if (agregar == false)
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void TxtPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void consultarUsuario(int tareaBandera)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            datosUsuario = metodos.consultaUsuarioDetalles(idTabla); 

            txtNombre.Text = datosUsuario.GetString(3);
            txtAP.Text = datosUsuario.GetString(4);
            txtAM.Text = datosUsuario.GetString(5);
            txtUser.Text = datosUsuario.GetString(0);
            txtPIN.Text = datosUsuario.GetString(1);


            if (tareaBandera == 1)
            {
                String tipo = datosUsuario.GetString(2);
                ComboBoxTipo.Items.Add(tipo);
                ComboBoxTipo.SelectedIndex = ComboBoxTipo.FindStringExact(tipo);
                ComboBoxTipo.Enabled = false;
            }
            else if (tareaBandera == 3)
            {

                String tipo = datosUsuario.GetString(2);
                ComboBoxTipo.Items.Add(tipo);
                ComboBoxTipo.SelectedIndex = ComboBoxTipo.FindStringExact(tipo);

                if (tipo.Equals("VENDEDOR")) {
                    ComboBoxTipo.Items.Add("PRODUCCION");
                }
                else if (tipo.Equals("PRODUCCION"))
                {
                    ComboBoxTipo.Items.Add("VENDEDOR");
                }
                else if (tipo.Equals("ADMINISTRADOR"))
                {

                }
            }

            BD.CerrarConexion();
        }

    }

}
