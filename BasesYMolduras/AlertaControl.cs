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
    public partial class AlertaControl : MetroFramework.Forms.MetroForm
    {
        public AlertaControl()  
        {
            DataTable datos = BD.obtenerIsUltimaProduccion();
            DataTable id_cotizacion = BD.obtenerIdEmergente(Convert.ToInt32(datos.Rows[0]["IsUltimaProduccion"]));
            InitializeComponent();

            txtPedido.Text = "Pedido: " + Convert.ToString(id_cotizacion.Rows[0]["id_cotizacion"]);
        }

        private void AlertaControl_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
