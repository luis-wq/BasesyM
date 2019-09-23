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
    public partial class Seguridad : MetroFramework.Forms.MetroForm
    {
        Listados padre;
        int tareaBandera, idTabla;
        public Seguridad(Listados padre,int tareaBandera, int idTabla)
        {
            this.tareaBandera = tareaBandera;
            this.idTabla = idTabla;
            this.padre = padre;

            InitializeComponent();
        }

        private void BtnContra_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Login.idUsuario;
                String contrasena = this.txtContra.Text;

                BD metodos = new BD();
                BD.ObtenerConexion();
                Boolean login = metodos.consultaAdmin(id, contrasena);
                BD.CerrarConexion();

                if (contrasena == "")
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, " Ingrese contraseña", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (contrasena == "")
                    {
                        this.txtContra.Focus();
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
                    AgregarUsuario form = new AgregarUsuario(padre, tareaBandera, idTabla);
                    form.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.
                    Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnCancelarC_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
            }
        }

        private void Seguridad_Load(object sender, EventArgs e)
        {

        }
    }
}
