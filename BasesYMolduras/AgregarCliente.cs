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
using MySql.Data.MySqlClient;

namespace BasesYMolduras
{
    public partial class AgregarCliente : MetroFramework.Forms.MetroForm
    {
        Boolean tipo_cliente_cambio, agregar, detalle;
        string tipo_usuario, id,rfcModificar;
        Listados Padre = null;
        int bandera = 0, tareaBandera,idCliente;
        MySqlDataReader datosCliente;
        public AgregarCliente(Listados padre, int bandera, string tipo_usuario,string id, int tareaBandera, int idCliente)
        {
            Padre = padre;
            this.bandera = bandera;
            this.id = id;
            this.tipo_usuario = tipo_usuario;
            this.tareaBandera = tareaBandera;
            this.idCliente = idCliente;

            InitializeComponent();

            tareaRealizar();


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

            if (email_bien_escrito(txtCorreo.Text))
            {
                AgregarClienteBueno();
            }
            else {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "El correo electronico no es correcto", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void AgregarClienteBueno() {
            Boolean isCorrect = false;
            Boolean clienteExiste;
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
            else
            {
                if (string.IsNullOrEmpty(razon) || string.IsNullOrEmpty(rfc) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(sitioW)
                    || string.IsNullOrEmpty(cel1) || string.IsNullOrEmpty(cel2) || string.IsNullOrEmpty(telofi) || string.IsNullOrEmpty(calle)
                    || string.IsNullOrEmpty(colonia) || string.IsNullOrEmpty(numE) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado)
                    || string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(cp) || string.IsNullOrEmpty(referencia) || string.IsNullOrEmpty(observaciones))
                {
                    isCorrect = false;
                    MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    isCorrect = true;
                }
            }
            BD metodos = new BD();
            BD.ObtenerConexion();
            clienteExiste = metodos.clienteExiste(rfc);
            BD.CerrarConexion();

            if (clienteExiste == true) {
                MetroFramework.MetroMessageBox.
               Show(this, "Ya existe un cliente con el RFC: " + rfc, "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isCorrect)
            {
                //Agregar Cliente.
                BD.ObtenerConexion();
                agregar = metodos.agregarCliente(razon, rfc, correo, sitioW, calle, colonia, numE, numI, referencia, ciudad, estado, pais, cp, cel1, cel2, telofi, ComboBoxTipoCliente.Text, observaciones,id);
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
                        /*
                        Padre.Close();
                        Inicio home = new Inicio(id);
                        home.Show();
                        home.FocusMe();
                        */
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
            /*//Para obligar a que sólo se introduzcan números 
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
            }*/
        }

        private void TxtNumeroI_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*//Para obligar a que sólo se introduzcan números 
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
            }*/
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (email_bien_escrito(txtCorreo.Text))
            {
                AgregarTodo();
            }
            else {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "El correo electronico no es correcto", "Error de correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void AgregarTodo() {
            Boolean clienteExiste;
            Boolean isCorrect = false;
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
            else
            {
                if (string.IsNullOrEmpty(razon) || string.IsNullOrEmpty(rfc) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(sitioW)
                    || string.IsNullOrEmpty(cel1) || string.IsNullOrEmpty(cel2) || string.IsNullOrEmpty(telofi) || string.IsNullOrEmpty(calle)
                    || string.IsNullOrEmpty(colonia) || string.IsNullOrEmpty(numE) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado)
                    || string.IsNullOrEmpty(pais) || string.IsNullOrEmpty(cp) || string.IsNullOrEmpty(referencia) || string.IsNullOrEmpty(observaciones))
                {
                    isCorrect = false;
                    MetroFramework.MetroMessageBox.
                Show(this, " Ingrese todos los datos", "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    isCorrect = true;
                }
            }

            BD metodos = new BD();


            if (rfcModificar.Equals(rfc))
            {
                clienteExiste = false;
            }
            else
            {
                BD.ObtenerConexion();
                clienteExiste = metodos.clienteExiste(rfc);
                BD.CerrarConexion();
            }

            if (clienteExiste == true)
            {
                MetroFramework.MetroMessageBox.
               Show(this, "Ya existe un cliente con el RFC: " + rfc, "Error al ingresar nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isCorrect)
            {
                //Agregar Cliente.
                BD.ObtenerConexion();
                agregar = metodos.modificarCliente(razon, rfc, correo, sitioW, calle, colonia, numE, numI, referencia, ciudad, estado, pais, cp, cel1, cel2, telofi, ComboBoxTipoCliente.Text, observaciones, idCliente);
                BD.CerrarConexion();


                if (agregar == true)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Cliente modificado correctamente, ¿Desea salir?", "Cliente modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    rfcModificar = rfc;
                    if (pregunta == DialogResult.Yes)
                    {
                        /*
                        Padre.Close();
                        Inicio home = new Inicio(id);
                        home.Show();
                        home.FocusMe();
                        this.Close();
                        */
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void TxtCelular_Click(object sender, EventArgs e)
        {

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

        private void tareaRealizar()
        {
            switch (tareaBandera)
            {   //Detalles
                case 1:
                    btnSalir.Visible = true;
                    lblTitulo.Text = "DETALLE DE CLIENTE";

                    this.txtCalle.Enabled = false;
                    this.txtCelular.Enabled = false;
                    this.txtCelular2.Enabled = false;
                    this.txtCiudad.Enabled = false;
                    this.txtColonia.Enabled = false;
                    this.txtCorreo.Enabled = false;
                    this.txtCP.Enabled = false;
                    this.txtEstado.Enabled = false;
                    this.txtNumeroE.Enabled = false;
                    this.txtNumeroI.Enabled = false;
                    this.txtObservaciones.Enabled = false;
                    this.txtPais.Enabled = false;
                    this.txtRazonSocial.Enabled = false;
                    this.txtReferencia.Enabled = false;
                    this.txtRFC.Enabled = false;
                    this.txtSitioWeb.Enabled = false;
                    this.txtTelOfi.Enabled = false;


                    consultarCliente(tareaBandera);

                    break;
                //Agregar
                case 2:
                    btnCancelarCliente.Visible = true;
                    btnAceptarCliente.Visible = true;

                    lblTitulo.Text = "AGREGAR CLIENTE";

                    ComboBoxTipoCliente.Items.Add("PUBLICO");
                    ComboBoxTipoCliente.Items.Add("FRECUENTE");
                    ComboBoxTipoCliente.Items.Add("MAYORISTA");

                    break;
                //Modificar
                case 3:
                    lblTitulo.Text = "MODIFICAR CLIENTE";
                    btnModificar.Visible = true;
                    btnCancelarCliente.Visible = true;
                    consultarCliente(tareaBandera);
                    rfcModificar = this.txtRFC.Text;
                    break;
            }
        }

        private void consultarCliente(int tareaBandera)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            datosCliente = metodos.consultaClienteDetalles(idCliente);

            this.txtCalle.Text = datosCliente.GetString(4);
            this.txtCelular.Text = datosCliente.GetString(13);
            this.txtCelular2.Text = datosCliente.GetString(14);
            this.txtCiudad.Text = datosCliente.GetString(9);
            this.txtColonia.Text = datosCliente.GetString(5);
            this.txtCorreo.Text = datosCliente.GetString(2);
            this.txtCP.Text = datosCliente.GetUInt32(12).ToString();
            this.txtEstado.Text = datosCliente.GetString(10);
            this.txtNumeroE.Text = datosCliente.GetString(6);
            this.txtNumeroI.Text = datosCliente.GetString(7);
            this.txtObservaciones.Text = datosCliente.GetString(17);
            this.txtPais.Text = datosCliente.GetString(11);
            this.txtRazonSocial.Text = datosCliente.GetString(0);
            this.txtReferencia.Text = datosCliente.GetString(8);
            this.txtRFC.Text = datosCliente.GetString(1);
            this.txtSitioWeb.Text = datosCliente.GetString(3);
            this.txtTelOfi.Text = datosCliente.GetUInt32(15).ToString();

            if (tareaBandera == 1)
            {
                String tipo = datosCliente.GetString(16);
                ComboBoxTipoCliente.Items.Add(tipo);
                ComboBoxTipoCliente.SelectedIndex = ComboBoxTipoCliente.FindStringExact(tipo);
                ComboBoxTipoCliente.Enabled = false;
            }
            else if (tareaBandera == 3)
            {
                String tipo = datosCliente.GetString(16);
                ComboBoxTipoCliente.Items.Add("PUBLICO");
                ComboBoxTipoCliente.Items.Add("FRECUENTE");
                ComboBoxTipoCliente.Items.Add("MAYORISTA");

                ComboBoxTipoCliente.SelectedIndex = ComboBoxTipoCliente.FindStringExact(tipo);
            }

            BD.CerrarConexion();
        }

    }
}
