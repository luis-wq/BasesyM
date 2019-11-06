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
    public partial class VerDetalleDiasProduccion : MetroFramework.Forms.MetroForm
    {
        CotizacionesRealizadas padre;
        int idCotizacion;
        DataTable datos;
        public VerDetalleDiasProduccion(CotizacionesRealizadas padre,int idCotizacion)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
        }

        private void VerDetalleDiasProduccion_Load(object sender, EventArgs e)
        {
            datos = BD.DatosControlForCotizacionesRealizadas(idCotizacion);
            txtCotizacion.Text = "Detalle de la Cotización: "+idCotizacion;
            string cadena = Convert.ToString(datos.Rows[0]["Fecha"]);

            string resultado = cadena.Substring(0, 10);
            txtFecha.Text = "Fecha de Cotización: " + resultado;
            AgregarEstado();
        }


        private void AgregarEstado()
        {
            try
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
                //btnMakila
                txtFechaMakila.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["makilaF"]);
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
                txtDiasMakila.Text = "A los " + differenceInDays + " Días de la fecha original";

            //Lijado
                        txtFechaLijado.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["lijadoF"]);
                        anio = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["makilaF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasLijado.Text = "A los " + differenceInDays + " Días de la fecha anterior";
             
                        txtFechaSellado.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["selladoF"]);
                        anio = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["lijadoF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasSellado.Text = "A los " + differenceInDays + " Días de la fecha anterior";
                  
                        txtFechaPulido.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["pulidoF"]);
                        anio = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["selladoF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasPulido.Text = "A los " + differenceInDays + " Días de la fecha anterior";
                    
                        txtFechaPintura.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["pinturaF"]);
                        anio = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["pulidoF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasPintura.Text = "A los " + differenceInDays + " Días de la fecha anterior";
                   
                        txtFechaEmpaquetado.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["empaquetadoF"]);
                        anio = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["pinturaF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasEmpaquetado.Text = "A los " + differenceInDays + " Días de la fecha anterior";
                 
                        txtFechaEnvio.Text = "Ha ocurrido en la fecha: " + Convert.ToString(datos.Rows[0]["envioF"]);
                        anio = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(0, 4);
                        mes = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(5, 2);
                        dia = Convert.ToString(datos.Rows[0]["empaquetadoF"]).Substring(8, 2);
                        anioNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(0, 4);
                        mesNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(5, 2);
                        diaNew = Convert.ToString(datos.Rows[0]["envioF"]).Substring(8, 2);
                        oldDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                        tNew = new DateTime(Convert.ToInt32(anioNew), Convert.ToInt32(mesNew), Convert.ToInt32(diaNew));
                        ts = tNew - oldDate;
                        differenceInDays = ts.Days;
                        txtDiasEnvio.Text = "A los " + differenceInDays + " Días de la fecha anterior";
                  
            }
            finally
            {

            }
        }

        private void BtnCierra_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }
    }
}
