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
    public partial class AgregarUsuario : MetroFramework.Forms.MetroForm
    {
        string tipo_usuario;
        Listados Padre = null;
        int bandera = 0;
        public AgregarUsuario(Listados padre, int bandera, string tipo_usuario)
        {
            Padre = padre;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();

            ComboBoxTipo.Items.Add("VENDEDOR");
            ComboBoxTipo.Items.Add("PRODUCCION");
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


    }
}
