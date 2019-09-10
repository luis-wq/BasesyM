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

namespace BasesYMolduras
{
    public partial class Listados : MetroFramework.Forms.MetroForm
    {
        DataTable dt;
        string tipo_usuario, id;
        Inicio Padre = null;
        int bandera = 0;
        int tareaBandera = 0;
        int buscarSelect = 0;
        int idUsuarioSelect = 0;
        int idClienteSelect = 0;

        public Listados(Inicio padre, int bandera,string tipo_usuario,string id)
        {
            CheckForIllegalCrossThreadCalls = false;
            Padre = padre;
            this.id = id;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;

            InitializeComponent();

            llenarCombo(bandera);
            
        }



        private void Listados_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
        }

        private void CargarDatosHilo()
        {
            UseWaitCursor = true;
            //Listados.ActiveForm.Enabled = false;

            this.CargarDatos();

            UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            //Listados.ActiveForm.Enabled = true;
            this.Refresh();
        }
        public void CargarDatos()
        {
            if (tipo_usuario.Equals("VENDEDOR") || tipo_usuario.Equals("OPERATIVO")) {
                btnAprobar.Enabled = false;
            }
            //Método que hace toda la carga de datos
            switch (bandera)
            {
                case 1: dt = BD.listarUsuarios(lista); break;    //Usuario
                case 4: dt = BD.listarClientes(lista); break;    //Clientes
                //case 3: dt = BD.listarCotizaciones(lista); break; //Cotizaciones
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
            
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            tareaBandera = 2;
            switch (bandera) {
                case 1: AgregarUsuario(bandera,tipo_usuario,tareaBandera, idUsuarioSelect); break;    //Usuario
                case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break;    //Cliente
                //case 3: dt = BD.listarCotizaciones(lista); break; //Cotizaciones
            }
        }

        private void AgregarUsuario(int bandera, string tipo, int tareaBandera, int idUsuarioSelect)
        {
            AgregarUsuario form = new AgregarUsuario(this, bandera, tipo, tareaBandera, idUsuarioSelect);
            form.Show();
            this.Enabled = false;
        }
        private void AgregarCliente(int bandera, string tipo, int tareaBandera, int idClienteSelect)
        {
            AgregarCliente form = new AgregarCliente(this, bandera, tipo, id, tareaBandera, idClienteSelect);
            form.Show();
            this.Enabled = false;
        }

        private void AgregarCotizaciones(int bandera, string tipo, int tareaBandera, int idClienteSelect)
        {
            AgregarCotizacion form = new AgregarCotizacion(this, bandera, tipo, id, tareaBandera, idClienteSelect);
            form.Show();
            this.Enabled = false;
        }


        private void Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                idUsuarioSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                                idClienteSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1:
                        procesoEliminarUsuario();
                        break;    //Usuario
                    case 4: procesoEliminarCliente(); break;    //Cliente
                }

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void procesoEliminarUsuario()
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el usuario?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (pregunta == DialogResult.Yes)
            {
                Thread hilo = new Thread(new ThreadStart(this.EliminarDatoUsuario));
                hilo.Start();
            }
            else if (pregunta == DialogResult.No)
            {

            }
        }
        private void EliminarDatoUsuario()
        {
            try { 
            UseWaitCursor = true;
            panel1.Enabled = false;
            int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());

            this.DeleteUsuario(id);

            UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            panel1.Enabled = true;
            CargarDatos();
            //this.Refresh();
            }
            catch
            {
                MetroFramework.MetroMessageBox.
                Show(this, "No hay usuarios registrados", "Error al eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panel1.Enabled = true;
                this.Refresh();
            }
        }
        private void DeleteUsuario(int id)
        {
            Boolean isDelete = false;
            //Método que hace toda la carga de datos
            BD metodos = new BD();
            BD.ObtenerConexion();
            isDelete = metodos.borrarUsuario(id.ToString());
            BD.CerrarConexion();
            if (!isDelete)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Revisa tu conexión a internet e inténtalo de nuevo", "Error al eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Usuario eliminado correctamente", "Usuario eliminado", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    BD.listarClientes(lista);
                }
            }
        }
            private void procesoEliminarCliente() {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar el cliente?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (pregunta == DialogResult.Yes)
            {
                Thread hilo = new Thread(new ThreadStart(this.EliminarDatoCliente));
                hilo.Start();
            }
            else if (pregunta == DialogResult.No)
            {
                
            }
        }
        private void EliminarDatoCliente()
        {
            UseWaitCursor = true;
            panel1.Enabled = false;
            try { 
            int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
            
            this.DeleteCliente(id);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panel1.Enabled = true;
                this.Refresh();
            }
            catch {
                MetroFramework.MetroMessageBox.
                Show(this, "No hay clientes registrados", "Error al eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panel1.Enabled = true;
                this.Refresh();
            }
        }
        private void DeleteCliente(int id)
        {
            Boolean isDelete = false;
            //Método que hace toda la carga de datos
            BD metodos = new BD();
            BD.ObtenerConexion();
            isDelete = metodos.borrarCliente(id.ToString());
            BD.CerrarConexion();
            if (!isDelete)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Revisa tu conexión a internet e inténtalo de nuevo", "Error al eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Cliente eliminado correctamente", "Cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK) {
                    BD.listarClientes(lista);
                }
            }
            

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Si no hay filtro, restauramos el grid original y salimos
                if (txtBuscar.Text == "")
                {
                    lista.DataSource = dt;
                    return;
                }

                string busqueda = txtBuscar.Text;

                //Con LinQ buscamos las rows que coincidan
                DataTable df = (from item in dt.Rows.Cast<DataRow>()
                                let codigo = Convert.ToString(item[buscarSelect] == null ? string.Empty : item[buscarSelect].ToString())
                                where codigo.Contains(busqueda)
                                select item).CopyToDataTable();
                //Mostramos las coincidencias
                lista.DataSource = df;
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {

            try
            {
                tareaBandera = 1;
                idUsuarioSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                idClienteSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1: AgregarUsuario(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break;    //Usuario
                    case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break;    //Cliente
                }

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ComboBoxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
           String combo = this.comboBoxBuscar.Text;
            buscarSelect = seleccionado(combo);
            txtBuscar.Text = "";
        }

        private void llenarCombo(int bandera) {

            if (bandera == 1)//  Llena el combo para usuarios
            {
                comboBoxBuscar.Items.Add("ID");
                comboBoxBuscar.Items.Add("USUARIO");
                comboBoxBuscar.Items.Add("CONTRASEÑA");
                comboBoxBuscar.Items.Add("TIPO");
                comboBoxBuscar.Items.Add("NOMBRE");
            }
            else if (bandera == 4) // Llena el combo para clientes
            {
                comboBoxBuscar.Items.Add("ID");
                comboBoxBuscar.Items.Add("RAZON SOCIAL");
                comboBoxBuscar.Items.Add("RFC");
                comboBoxBuscar.Items.Add("CELULAR1");
                comboBoxBuscar.Items.Add("CELULAR2");
                comboBoxBuscar.Items.Add("TELEFONO");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                tareaBandera = 3;
                idUsuarioSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                idClienteSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1: AgregarUsuario(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break;    //Usuario
                    case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break;    //Cliente
                    case 3: AgregarCotizaciones(bandera, tipo_usuario, tareaBandera, idUsuarioSelect); break; //Cotizaciones
                }

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int seleccionado(String seleccionado)

        {
            int select = 0;
            if (bandera == 1)
            {
                switch (seleccionado) // retorna el valor para la busqueda de usuario
                {
                    case "ID":
                        select = 0;
                        break;
                    case "USUARIO":
                        select = 1;
                        break;
                    case "CONTRASEÑA":
                        select = 2;
                        break;
                    case "TIPO":
                        select = 3;
                        break;
                    case "NOMBRE":
                        select = 4;
                        break;
                }
            }
            else if (bandera == 4) {
                switch (seleccionado) // retorna el valor para la busqueda de usuario
                {
                    case "ID":
                        select = 0;
                        break;
                    case "RAZON SOCIAL":
                        select = 1;
                        break;
                    case "RFC":
                        select = 2;
                        break;
                    case "CELULAR1":
                        select = 3;
                        break;
                    case "CELULAR2":
                        select = 4;
                        break;
                    case "TELEFONO":
                        select = 4;
                        break;
                }
            }

            return select;
        }
    }
}
