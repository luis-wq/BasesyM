using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        DateTime t;
        string tipo_usuario, id;
        Inicio Padre = null;
        int bandera = 0;
        int tareaBandera = 0;
        int buscarSelect = 0;
        int idTablaSelect = 0;
        string fecha;

        public Listados(Inicio padre, int bandera,string tipo_usuario,string id,DateTime t)
        {
            CheckForIllegalCrossThreadCalls = false;
            Padre = padre;
            this.id = id;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            this.t = t;
            InitializeComponent();
            llenarCombo(bandera);
            titulo();
           
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
            btnPagos.Visible = false;
            btnAprobar.Visible = false;
            if (tipo_usuario.Equals("VENDEDOR") || tipo_usuario.Equals("PRODUCCION")) {
                btnAprobar.Enabled = false;
            }
            //Método que hace toda la carga de datos
            switch (bandera)
            {
                case 1:
                    panelCartera.Visible = false;
                    dt = BD.listarUsuarios(lista);
                    break;    //Usuario
                case 4:
                    panelCartera.Visible = false;
                    if (tipo_usuario.Equals("ADMINISTRADOR"))
                    {
                        dt = BD.listarClientesAdmin(lista);
                    } else {
                        dt = BD.listarClientes(lista, Convert.ToInt32(id));
                    } break;    //Clientes
                case 3:
                    btnPagos.Visible = true;
                    btnAprobar.Visible = true;
                    if (tipo_usuario.Equals("ADMINISTRADOR"))
                    {
                        dt = BD.listarCotizacionesByUserAdmin(lista);
                        lista.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                        lista.Columns["PAGADO"].DefaultCellStyle.Format = "C2";
                        lista.Columns["RESTA"].DefaultCellStyle.Format = "C2";
                    }
                    else { dt = BD.listarCotizacionesByUser(lista, id);
                        lista.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                        lista.Columns["PAGADO"].DefaultCellStyle.Format = "C2";
                        lista.Columns["RESTA"].DefaultCellStyle.Format = "C2";
                    }

                    Double total_total = 0;
                    Double total_pagado = 0;
                    Double total_resta = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        total_total += Convert.ToDouble(dt.Rows[i]["TOTAL"]);
                        total_pagado += Convert.ToDouble(dt.Rows[i]["PAGADO"]);
                        total_resta += Convert.ToDouble(dt.Rows[i]["RESTA"]);
                    }
                    txtTotalCartera.Text = string.Format("{0:c2}", total_total);
                    txtTotalPagado.Text = string.Format("{0:c2}", total_pagado);
                    txtTotalResta.Text = string.Format("{0:c2}", total_resta);
                    break;
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
                case 1: AgregarUsuario(tareaBandera, idTablaSelect); break;    //Usuario
                case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idTablaSelect); break;    //Cliente
                case 3: AgregarCotizaciones(bandera, tipo_usuario, tareaBandera, idTablaSelect); break; //Cotizaciones
            }
        }
        
        private void AgregarUsuario(int tareaBandera, int idTablaSelect)
        {
            Seguridad form = new Seguridad(this, tareaBandera, idTablaSelect);
            form.Show();
            this.Enabled = false;
        }
        private void AgregarCliente(int bandera, string tipo, int tareaBandera, int idTablaSelect)
        {
            AgregarCliente form = new AgregarCliente(this, bandera, tipo, id, tareaBandera, idTablaSelect);
            form.Show();
            this.Enabled = false;
        }

        private void AgregarCotizaciones(int bandera, string tipo, int tareaBandera, int idTablaSelect)
        {
            if (tareaBandera == 3)
            {
                int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                BD metodos = new BD();
                BD.ObtenerConexion();
                Boolean pro = metodos.consultaProduccion(id);
                BD.CerrarConexion();

                if (pro == true)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "No se puede modificar la cotización", "Cotizacion en producción\n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    Cotizacion form = new Cotizacion(this, tareaBandera, idTablaSelect,Convert.ToInt32(this.id),tipo_usuario);
                    form.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                Cotizacion form = new Cotizacion(this, tareaBandera, idTablaSelect,Convert.ToInt32(id),tipo_usuario);
                form.Show();
                this.Enabled = false;
            }
        }

        private void AgregarPago(int bandera, string tipo, int tareaBandera)
        {
            try
            {
                int idCotizacion = Convert.ToInt32(dt.Rows[lista.CurrentRow.Index]["ID"]);
                Pagos form = new Pagos(this, bandera, tipo, id, tareaBandera, idCotizacion, t);
                form.Show();
                this.Enabled = false;
            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                idTablaSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1:
                        procesoEliminarUsuario();
                        break;    //Usuario
                    case 3:
                        procesoEliminarCotizacion();
                        break;
                    case 4: procesoEliminarCliente(); break;    //Cliente
                }
                this.Refresh();
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
        private void procesoEliminarCotizacion()
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar la cotización?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (pregunta == DialogResult.Yes)
            {
                Thread hilo = new Thread(new ThreadStart(this.EliminarDatoCotizacion));
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
            panelCRUD.Enabled = false;
            int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());

            this.DeleteUsuario(id);

            UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            panelCRUD.Enabled = true;
            CargarDatos();
            //this.Refresh();
            }
            catch
            {
                MetroFramework.MetroMessageBox.
                Show(this, "No hay usuarios registrados", "Error al eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panelCRUD.Enabled = true;
                this.Refresh();
            }
        }
        private void EliminarDatoCotizacion()
        {
            try
            {
                UseWaitCursor = true;
                panelCRUD.Enabled = false;
                int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());

                this.DeleteCotizacion(id);

                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panelCRUD.Enabled = true;
                CargarDatos();
                //this.Refresh();
            }
            catch
            {
                MetroFramework.MetroMessageBox.
                Show(this, "No hay cotizaciones", "Error al eliminar cotización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panelCRUD.Enabled = true;
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
                    BD.listarUsuarios(lista);
                }
            }
        }
        private void DeleteCotizacion(int id)
        {

            DataTable dataProductosModificar = BD.listarProductosCotizacionModificar(id);

            int i = 0;
            foreach (DataRow row in dataProductosModificar.Rows)
            {
                int idDetalle = Convert.ToInt32(dataProductosModificar.Rows[i]["ID_DETALLE"].ToString());
                eliminarDetalleCotizacion(id, idDetalle);
                i++;
            }

            Boolean isDelete = false;
            //Método que hace toda la carga de datos
            BD metodos = new BD();
            BD.ObtenerConexion();
            isDelete = metodos.borrarCotizacion(id);
            BD.CerrarConexion();
            if (!isDelete)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Revisa tu conexión a internet e inténtalo de nuevo", "Error al eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Cotizacion eliminado correctamente", "Cotización eliminada", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    BD.listarUsuarios(lista);
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
            panelCRUD.Enabled = false;
            try { 
            int id = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
            
            this.DeleteCliente(id);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panelCRUD.Enabled = true;
                CargarDatos();
            }
            catch {
                MetroFramework.MetroMessageBox.
                Show(this, "No hay clientes registrados", "Error al eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                panelCRUD.Enabled = true;
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
                    BD.listarClientes(lista,Convert.ToInt32(id));
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
                idTablaSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1: AgregarUsuario(tareaBandera, idTablaSelect); break;    //Usuario
                    case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idTablaSelect); break;    //Cliente
                    case 3:generarPDF();break;

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
                comboBoxBuscar.Items.Add("TIPO");
                comboBoxBuscar.Items.Add("NOMBRE");
                comboBoxBuscar.Items.Add("APELLIDO PATERNO");
                comboBoxBuscar.Items.Add("APELLIDO MATERNO");
            }
            else if (bandera == 4) // Llena el combo para clientes
            {
                comboBoxBuscar.Items.Add("ID");
                comboBoxBuscar.Items.Add("RAZON SOCIAL");
                comboBoxBuscar.Items.Add("RFC");
                comboBoxBuscar.Items.Add("TIPO");
                comboBoxBuscar.Items.Add("CELULAR1");
                comboBoxBuscar.Items.Add("CIUDAD");
            }else if(bandera == 3)
            {
                comboBoxBuscar.Items.Add("CLIENTE");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                tareaBandera = 3;
                idTablaSelect = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
                switch (bandera)
                {
                    case 1: AgregarUsuario(tareaBandera, idTablaSelect); break;    //Usuario
                    case 4: AgregarCliente(bandera, tipo_usuario, tareaBandera, idTablaSelect); break;    //Cliente
                    case 3: AgregarCotizaciones(bandera, tipo_usuario, tareaBandera, idTablaSelect); break; //Cotizaciones
                }

            }
            catch
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Seleccione una dato en la tabla", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
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
                    case "TIPO":
                        select = 2;
                        break;
                    case "NOMBRE":
                        select = 3;
                        break;
                    case "APELLIDO PATERNO":
                        select = 4;
                        break;
                    case "APELLIDO MATERNO":
                        select = 5;
                        break;
                }
            }
            else if (bandera == 4) {
                switch (seleccionado) // retorna el valor para la busqueda de cliente
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
                    case "TIPO":
                        select = 3;
                        break;
                    case "CELULAR1":
                        select = 4;
                        break;
                    case "CIUDAD":
                        select = 5;
                        break;
                }
            }else if(bandera == 3)
            {
                switch (seleccionado) // retorna el valor para la busqueda de cliente
                {
                    case "CLIENTE":
                        select = 1;
                        break;
                }
            }

            return select;
        }

        private void BtnPagos_Click(object sender, EventArgs e)
        {
            AgregarPago(bandera,tipo_usuario,tareaBandera);
        }

        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "Desea aprobar esta cotización", "Aviso", MessageBoxButtons.YesNo , MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                DataTable isUltima = BD.obtenerIsUltimaProduccion();
                int ultimo = 0;
                try
                {
                    ultimo = Convert.ToInt32(isUltima.Rows[0]["isUltimaProduccion"]);
                }
                catch
                {
                    ultimo = 0;
                }
                int Nuevoultimo = ultimo + 1;
                BD.aprobarProduccion(Convert.ToInt32(dt.Rows[lista.CurrentRow.Index]["ID"]),Nuevoultimo);
                BD.agregarControl(Convert.ToInt32(dt.Rows[lista.CurrentRow.Index]["ID"]), "nada");
                BD.agregarCaja(Convert.ToInt32(dt.Rows[lista.CurrentRow.Index]["ID"]));
                CargarDatos();

            }

        }

        private void titulo()
        {
            switch (bandera)
            {
                case 1:
                    lblTitulo.Text = "LISTADO \nUSUARIOS";
                    break;
                case 2:
                    lblTitulo.Text = "LISTADO \nUSUARIOS";
                    break;
                case 3:
                    lblTitulo.Text = "LISTADO \nCOTIZACIONES";
                    break;
                case 4:
                    lblTitulo.Text = "LISTADO \nCLIENTES";
                    break;
                case 5:
                    lblTitulo.Text = "LISTADO \nPRODUCCIONES";
                    break;
                case 6:
                    lblTitulo.Text = "LISTADO \nCONTROL \nDE ESTADO";
                    break;
            }
        }

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {

        }
        private void eliminarDetalleCotizacion(int idCotizacion, int idDetalle)
        {

            agregarInventario(Convert.ToInt32(idDetalle), idCotizacion);
            BD metodos = new BD();
            BD.ObtenerConexion();
            metodos.eliminarProductoCotizacion(Convert.ToInt32(idDetalle), idCotizacion);
            BD.CerrarConexion();
            

        }
        private void agregarInventario(int idDetalle, int idCotizacion)
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            metodos.updateInventario(idDetalle, idCotizacion);
            BD.CerrarConexion();
        }

        private string obtenerFecha()
        {
            t = BD.ObtenerFecha();
            return fecha = Convert.ToString(t.Day + t.Month + t.Year + t.Hour + t.Minute + t.Second);
        }
        private void generarPDF()
        {
            int idCotizacion = Convert.ToInt32(lista.SelectedRows[0].Cells["ID"].Value.ToString());
            String tipo = Login.tipo;
            GenerarPDF form = new GenerarPDF(this, tipo, idCotizacion,2);
            form.Show();
            this.Enabled = false; 
        }
    }
}
