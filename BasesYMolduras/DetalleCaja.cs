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
    public partial class DetalleCaja : MetroFramework.Forms.MetroForm
    {
        int idCotizacion, idCaja;
        Cajas padre;
        DataTable datosCotizacion;
        public DetalleCaja(Cajas padre,int idCotizacion,int idCaja)
        {
            InitializeComponent();
            this.padre = padre;
            this.idCotizacion = idCotizacion;
            this.idCaja = idCaja;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            padre.Refrescar();
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {

        }

    }
}
