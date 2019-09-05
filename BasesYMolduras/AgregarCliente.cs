using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BasesYMolduras
{
    public partial class AgregarCliente : MetroFramework.Forms.MetroForm
    {
        Boolean tipo_cliente_cambio, agregar, detalle;
        string tipo_usuario, id;
        Listados Padre = null;
        int bandera = 0;
        public AgregarCliente(Listados padre, int bandera, string tipo_usuario,string id)
        {
            Padre = padre;
            this.bandera = bandera;
            this.id = id;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();

            ComboBoxTipoCliente.Items.Add("PUBLICO");
            ComboBoxTipoCliente.Items.Add("FRECUENTE");
            ComboBoxTipoCliente.Items.Add("MAYORISTA");
        }
        public AgregarCliente(Listados padre, int bandera, string tipo_usuario,Boolean detalle)
        {
            Padre = padre;
            this.detalle = detalle;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();

            ComboBoxTipoCliente.Items.Add("PUBLICO");
            ComboBoxTipoCliente.Items.Add("FRECUENTE");
            ComboBoxTipoCliente.Items.Add("MAYORISTA");
        }

        private void TxtCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void BtnAceptarCliente_Click(object sender, EventArgs e)
        {
            Boolean isCorrect = false;
            if (!email_bien_escrito(txtCorreo.Text)) {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "El correo electronico no es correcto", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            String razon = txtRazonSocial.Text, rfc = txtRFC.Text, correo = txtCorreo.Text, sitioW = txtSitioWeb.Text;
            string cel1 = txtCelular.Text, cel2 = txtCelular2.Text, telofi = txtTelOfi.Text, calle = txtCalle.Text;
            string colonia = txtColonia.Text, numE = txtNumeroE.Text, numI = txtNumeroI.Text, ciudad = txtCiudad.Text;
            string estado = txtEstado.Text, pais = txtPais.Text, cp = txtCP.Text, referencia = txtReferencia.Text, observaciones = txtObservaciones.Text;
            if (!tipo_cliente_cambio)
            {
                isCorrect = false;
                MetroFramework.MetroMessageBox.
                Show(this, " Selecciona un tipo de cliente", "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (string.IsNullOrEmpty(razon) || string.IsNullOrEmpty(rfc) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(sitioW)
                    || string.IsNullOrEmpty(cel1) || string.IsNullOrEmpty(cel2) || string.IsNullOrEmpty(telofi) || string.IsNullOrEmpty(calle)
                    || string.IsNullOrEmpty(colonia) || string.IsNullOrEmpty(numE) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado) 
                    || string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(cp) || string.IsNullOrEmpty(referencia) || string.IsNullOrEmpty(observaciones))
                {
                    isCorrect = false;
                    MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    isCorrect = true;
                }
            }

            if (isCorrect) {
                //Agregar Cliente.
                BD metodos = new BD();
                BD.ObtenerConexion();
                agregar = metodos.agregarCliente(razon,rfc,correo,sitioW,calle,colonia,numE,numI,referencia,ciudad,estado,pais,cp,cel1,cel2,telofi,ComboBoxTipoCliente.Text,observaciones);
                BD.CerrarConexion();


                if (agregar == true)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Cliente agregado correctamente, ¿Desea agregar otro cliente?", "Cliente agregado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (pregunta == DialogResult.Yes)
                    {
                        limpiarTextBox();
                    }
                    else if (pregunta == DialogResult.No)
                    {
                        Padre.Close();
                        Inicio home = new Inicio(id);
                        home.Show();
                        home.FocusMe();
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

        private void limpiarTextBox()
        {

            ComboBoxTipoCliente.Items.Clear();
            this.txtCalle.Text = "";
            this.txtCelular.Text = "";
            this.txtCelular2.Text = "";
            this.txtCiudad.Text = "";
            this.txtColonia.Text = "";
            this.txtCorreo.Text = "";
            this.txtCP.Text = "";
            this.txtEstado.Text = "";
            this.txtNumeroE.Text = "";
            this.txtNumeroI.Text = "";
            this.txtObservaciones.Text = "";
            this.txtPais.Text = "";
            this.txtRazonSocial.Text = "";
            this.txtReferencia.Text = "";
            this.txtRFC.Text = "";
            this.txtSitioWeb.Text = "";
            this.txtTelOfi.Text = "";

            ComboBoxTipoCliente.Items.Add("PUBLICO");
            ComboBoxTipoCliente.Items.Add("FRECUENTE");
            ComboBoxTipoCliente.Items.Add("MAYORISTA");
        }

        private void TxtCelular2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void MetroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtNumeroE_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtNumeroI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtCP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnCancelarCliente_Click(object sender, EventArgs e)
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

        private void ComboBoxTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_cliente_cambio = true;
        }
    }
}
