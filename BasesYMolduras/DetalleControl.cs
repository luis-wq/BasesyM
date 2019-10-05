﻿using System;
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
    public partial class DetalleControl : MetroFramework.Forms.MetroForm
    {
        DataTable datos;
        int IdCotizacion;
        ControlEstado padre;
        DateTime t;
        string fecha;
        public DetalleControl(ControlEstado padre, int IdCotizacion)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.padre = padre;
            this.IdCotizacion = IdCotizacion;
        }

        private void DetalleControl_Load(object sender, EventArgs e)
        {
            txtNombre.Text = "ORDEN: " + IdCotizacion;
            Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.cargarDatos));
            hiloPesosYPrecios.Start();
            //cargarDatos();
        }

        private void cargarDatos() {
            fecha = obtenerFecha();
            datos = BD.DatosControlForCotizacion(IdCotizacion);
            txtFecha.Text = "Fecha de Orden: "+Convert.ToString(datos.Rows[0]["Fecha"]);
            txtCliente.Text = "Cliente: " + Convert.ToString(datos.Rows[0]["razon_social"]);
            txtNoPedido.Text = "No. Pedido del Cliente: " + Convert.ToString(datos.Rows[0]["NoCotizacionesCliente"]);
            btnEstado.Text = Convert.ToString(datos.Rows[0]["estado"]);
            if (!datos.Rows[0]["makilaF"].Equals(""))
            {
                AgregarEstado(1,"Seleccionado");
            }
            if (!datos.Rows[0]["lijadoF"].Equals(""))
            {
                AgregarEstado(2, "Seleccionado");
            }
            if (!datos.Rows[0]["selladoF"].Equals(""))
            {
                AgregarEstado(3, "Seleccionado");
            }
            if (!datos.Rows[0]["pulidoF"].Equals(""))
            {
                AgregarEstado(4, "Seleccionado");
            }
            if (!datos.Rows[0]["pinturaF"].Equals(""))
            {
                AgregarEstado(5, "Seleccionado");
            }
            if (!datos.Rows[0]["empaquetadoF"].Equals(""))
            {
                AgregarEstado(6, "Seleccionado");
            }
            if (!datos.Rows[0]["envioF"].Equals(""))
            {
                AgregarEstado(7, "Seleccionado");
            }
        }

        private void BtnEstado_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;
            pregunta = MetroFramework.MetroMessageBox.Show(this, "Este es el estado actual de la orden", "Estado de Orden", MessageBoxButtons.OK);
        }

        private void BtnMakila_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["makilaF"].Equals("") || datos.Rows[0]["makilaF"] == null || datos.Rows[0]["makilaF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(1);
                }
            }
            else {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }

        }
        private void AgregarEstado(int boton) {
            string anio = "";
            string mes = "";
            string dia = "";
            DateTime oldDate;
            int differenceInDays;
            TimeSpan ts;
            switch (boton) {
                case 1: //btnMakila
                    btnMakila.BackColor = Color.Green;
                    txtFechaMakila.ForeColor = Color.Red;
                    txtFechaMakila.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasMakila.Text = "Dias: " + differenceInDays;
                    break;
                case 2: //Lijado
                    btnLijado.BackColor = Color.Green;
                    txtFechaLijado.ForeColor = Color.Red;
                    txtFechaLijado.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasLijado.Text = "Dias: " + differenceInDays;
                    break;
                case 3: //Sellado
                    btnSellado.BackColor = Color.Green;
                    txtFechaSellado.ForeColor = Color.Red;
                    txtFechaSellado.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasSellado.Text = "Dias: " + differenceInDays;
                    break;
                case 4: //Pulido
                    btnPulido.BackColor = Color.Green;
                    txtFechaPulido.ForeColor = Color.Red;
                    txtFechaPulido.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasPulido.Text = "Dias: " + differenceInDays;
                    break;
                case 5: //Pintura
                    btnPintura.BackColor = Color.Green;
                    txtFechaPintura.ForeColor = Color.Red;
                    txtFechaPintura.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasPintura.Text = "Dias: " + differenceInDays;
                    break;
                case 6: //Empaquetado
                    btnEmpaquetado.BackColor = Color.Green;
                    txtFechaEmpaquetado.ForeColor = Color.Red;
                    txtFechaEmpaquetado.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasEmpaquetado.Text = "Dias: " + differenceInDays;
                    break;
                case 7: //Envio
                    btnEnvio.BackColor = Color.Green;
                    txtFechaEnvio.ForeColor = Color.Red;
                    txtFechaEnvio.Text = obtenerFecha();
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    ts = t - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasEnvio.Text = "Dias: " + differenceInDays;
                    break;
            }
        }

        private void AgregarEstado(int boton,string algo)
        {
            string anio = "";
            string mes = "";
            string dia = "";
            string anioNew = "";
            string mesNew = "";
            string diaNew = "";
            DateTime oldDate, tNew;
            TimeSpan ts;
            int differenceInDays;
            switch (boton)
            {
                case 1: //btnMakila
                    btnMakila.BackColor = Color.Green;
                    txtFechaMakila.ForeColor = Color.Red;
                    txtFechaMakila.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasMakila.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Makilado";
                    break;
                case 2: //Lijado
                    btnLijado.BackColor = Color.Green;
                    txtFechaLijado.ForeColor = Color.Red;
                    txtFechaLijado.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasLijado.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Lijado";
                    break;
                case 3: //Sellado
                    btnSellado.BackColor = Color.Green;
                    txtFechaSellado.ForeColor = Color.Red;
                    txtFechaSellado.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasSellado.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Sellado";
                    break;
                case 4: //Pulido
                    btnPulido.BackColor = Color.Green;
                    txtFechaPulido.ForeColor = Color.Red;
                    txtFechaPulido.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasPulido.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Pulido";
                    break;
                case 5: //Pintura
                    btnPintura.BackColor = Color.Green;
                    txtFechaPintura.ForeColor = Color.Red;
                    txtFechaPintura.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasPintura.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Pintado";
                    break;
                case 6: //Empaquetado
                    btnEmpaquetado.BackColor = Color.Green;
                    txtFechaEmpaquetado.ForeColor = Color.Red;
                    txtFechaEmpaquetado.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasEmpaquetado.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Empaquetado";
                    break;
                case 7: //Envio
                    btnEnvio.BackColor = Color.Green;
                    txtFechaEnvio.ForeColor = Color.Red;
                    txtFechaEnvio.Text = fecha;
                    anio = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(6, 4);
                    mes = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(3, 2);
                    dia = Convert.ToString(datos.Rows[0]["Fecha"]).Substring(0, 2);
                    anioNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(0, 4);
                    mesNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(5, 2);
                    diaNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(8, 2);
                    oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                    tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                    ts = tNew - oldDate;
                    differenceInDays = ts.Days;
                    txtDiasEnvio.Text = "Dias: " + differenceInDays;
                    btnEstado.Text = "Enviado";
                    break;

            }
        }
        private string obtenerFecha()
        {
            t = BD.ObtenerFecha();
            fecha = t.Day + "/" + t.Month + "/" + t.Year;
            return fecha;
        }

        private void BtnLijado_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["lijadoF"].Equals("") || datos.Rows[0]["lijadoF"] == null || datos.Rows[0]["lijadoF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(2);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnSellado_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["selladoF"].Equals("") || datos.Rows[0]["selladoF"] == null || datos.Rows[0]["selladoF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(3);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnPulido_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["pulidoF"].Equals("") || datos.Rows[0]["pulidoF"] == null || datos.Rows[0]["pulidoF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(4);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnPintura_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["pinturaF"].Equals("") || datos.Rows[0]["pinturaF"] == null || datos.Rows[0]["pinturaF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(5);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnEmpaquetado_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["empaquetadoF"].Equals("") || datos.Rows[0]["empaquetadoF"] == null || datos.Rows[0]["empaquetadoF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(6);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnEnvio_Click(object sender, EventArgs e)
        {
            if (datos.Rows[0]["envioF"].Equals("") || datos.Rows[0]["envioF"] == null || datos.Rows[0]["envioF"].Equals("NULL"))
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Esta acción no se puede revertir", "Aviso", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    AgregarEstado(7);
                }
            }
            else
            {
                DialogResult preguntaM = MetroFramework.MetroMessageBox.Show(this, "Este evento ya ha ocurrido", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }
    }
}
