﻿using System;
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
    public partial class CotizacionesRealizadas : MetroFramework.Forms.MetroForm
    {
        Inicio padre;
        DataTable datosCotizaciones;
        String tipo_usuario;
        DateTime t;
        public CotizacionesRealizadas(Inicio padre,String tipo_usuario,DateTime t)
        {
            this.padre = padre;
            this.tipo_usuario = tipo_usuario;
            this.t = t;
            InitializeComponent();
        }

        private void CotizacionesRealizadas_Load(object sender, EventArgs e)
        {
            int id_usuario = Login.idUsuario;
            if (tipo_usuario.Equals("ADMINISTRADOR"))
            {
                datosCotizaciones = BD.listarCotizacionesRealizadas();
            }
            else {

                datosCotizaciones = BD.listarCotizacionesRealizadasUsuario(id_usuario);
            }

            lista.DataSource = datosCotizaciones;
            lista.Columns[lista.Columns["ID"].Index].Width = 40;
            lista.Columns[lista.Columns["CLIENTE"].Index].Width = 150;
            lista.Columns[lista.Columns["USUARIO"].Index].Width = 80;
            lista.Columns[lista.Columns["OBSERVACIONES"].Index].Visible = false;
            lista.Columns[lista.Columns["ENVIO"].Index].Visible = false;
            lista.Columns[lista.Columns["NOCLIENTE"].Index].Width = 80;
            lista.Columns[lista.Columns["FECHA"].Index].Width = 100;
            lista.Columns[lista.Columns["CARGOEXTRA"].Index].Visible = false; 
            lista.Columns[lista.Columns["MDF"].Index].Width = 80;
            lista.Columns[lista.Columns["PINO"].Index].Width = 80;
            lista.Columns[lista.Columns["MOLDURAS"].Index].Width = 80;
            lista.Columns[lista.Columns["PRIORIDAD"].Index].Visible = false;
            lista.Columns[lista.Columns["PESO"].Index].Visible = false;

        }

        private void BtnPagos_Click(object sender, EventArgs e)
        {
            try
            {
                Pagos p = new Pagos(this, Convert.ToInt32(lista.CurrentRow.Cells["ID"].Value), 0, t);
                p.Show();
                this.Enabled = true;
            }
            catch { }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                generarPDF(tipo_usuario, Convert.ToInt32(lista.CurrentRow.Cells["ID"].Value));
            }
            catch { }
            }
        private void generarPDF(string tipo, int idProduccion)
        {
            GenerarPDF form = new GenerarPDF(this, tipo, idProduccion,0);
            form.Show();
            this.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cajas cajas = new Cajas(this, Convert.ToInt32(lista.CurrentRow.Cells["ID"].Value), 0);
                cajas.Show();
                this.Enabled = false;
            } catch
            {

            }
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            try
            {
                VerDetalleDiasProduccion detalle = new VerDetalleDiasProduccion(this, Convert.ToInt32(lista.CurrentRow.Cells["ID"].Value));
                detalle.Show();
                this.Enabled = false;
            }
            catch {

            }
        }
    }
}
