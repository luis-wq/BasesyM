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
        string tipo_usuario;
        int tareaBandera,id;
        Listados Padre = null;
        int bandera = 0;
        MySqlDataReader datosUsuario;
        public AgregarUsuario(Listados padre, int bandera, string tipo_usuario, int tareaBandera,int id)
        {
            Padre = padre;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            this.tareaBandera = tareaBandera;
            this.id = id;
            InitializeComponent();
            tareaRealizar();

        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

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
            String tipo = this.ComboBoxTipo.Text;
            String nombre = this.txtNombre.Text;
            String ap = this.txtAP.Text;
            String am = this.txtAM.Text;
            String usuario = this.txtUser.Text;
            String pin = this.txtPIN.Text;
            Boolean agregar;

            if (tipo == "" || nombre == "" || ap == "" || am == "" || usuario == "" || pin == "") {

                /*if (tipo == "") {
                    this.ComboBoxTipo.Focus();
                } else if (nombre == "") {
                    this.txtNombre.Focus();
                }else if (ap== "") {
                    this.txtAP.Focus();
                }else if (am == ""){
                    this.txtAM.Focus();
                }else if (usuario == ""){
                    this.txtUser.Focus();
                }else if (pin == ""){
                    this.txtPIN.Focus();
                }*/

                MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                BD metodos = new BD();
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
                    break;    
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }
        private void consultarUsuario(int tareaBander)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            datosUsuario = metodos.consultaUsuarioDetalles(id); 

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
                ComboBoxTipo.Items.Add("VENDEDOR");
                ComboBoxTipo.Items.Add("PRODUCCION");
                ComboBoxTipo.SelectedIndex = ComboBoxTipo.FindStringExact(tipo);
            }

            BD.CerrarConexion();
        }

    }

}
