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
        public Listados(Inicio padre, int bandera,string tipo_usuario,string id)
        {
            CheckForIllegalCrossThreadCalls = false;
            Padre = padre;
            this.id = id;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();
        }



        private void Listados_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
        }

        private void CargarDatosHilo()
        {
            UseWaitCursor = true;
            Listados.ActiveForm.Enabled = false;

            this.CargarDatos();

            UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            Listados.ActiveForm.Enabled = true;
            this.Refresh();
        }
        private void CargarDatos()
        {
            if (tipo_usuario.Equals("VENDEDOR") || tipo_usuario.Equals("OPERATIVO")) {
                btnAprobar.Enabled = false;
            }
            //Método que hace toda la carga de datos
            switch (bandera)
            {
                case 1: dt = BD.listarUsuarios(lista); break;    //Usuario
                case 4: dt = BD.listarClientes(lista); break;    //Clientes
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
            switch (bandera) {
                case 1: AgregarUsuario(bandera,tipo_usuario); break;    //Usuario
                case 4: AgregarCliente(bandera, tipo_usuario); break;    //Cliente
            }
        }

        private void AgregarUsuario(int bandera, string tipo)
        {
            AgregarUsuario form = new AgregarUsuario(this, bandera, tipo);
            form.Show();
            this.Enabled = false;
        }
        private void AgregarCliente(int bandera, string tipo)
        {
            AgregarCliente form = new AgregarCliente(this, bandera, tipo,id);
            form.Show();
            this.Enabled = false;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Si no hay filtro, restauramos el grid original y salimos
                if (textBox1.Text == "")
                {
                    lista.DataSource = dt;
                    return;
                }

                string busqueda = textBox1.Text;

                //Con LinQ buscamos las rows que coincidan
                DataTable df = (from item in dt.Rows.Cast<DataRow>()
                                let codigo = Convert.ToString(item[1]  == null ? string.Empty : item[1].ToString())
                                where codigo.Contains(busqueda)
                                select item).CopyToDataTable();
                //Mostramos las coincidencias
                lista.DataSource = df;
            }
            catch (Exception ex)
            {

            }
        }

        private void Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (bandera)
            {
                case 1: procesoEliminarUsuario(); 
                    break;    //Usuario
                case 4: procesoEliminarCliente(); break;    //Cliente
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
            this.Refresh();
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

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            switch (bandera)
            {
                case 1: AgregarUsuario(bandera, tipo_usuario); break;    //Usuario
                case 4: AgregarCliente(bandera, tipo_usuario); break;    //Cliente
            }
        }
    }
}
