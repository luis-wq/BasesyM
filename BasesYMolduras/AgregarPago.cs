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
    public partial class AgregarPago : MetroFramework.Forms.MetroForm
    {
        Pagos padre;
        int idCuentaCliente;
        double total;
        public AgregarPago(Pagos padre, int idAgregarPago, double total)
        {
            InitializeComponent();
            this.idCuentaCliente = idAgregarPago;
            this.total = total;
            this.padre = padre;
        }

        private void AgregarPago_Load(object sender, EventArgs e)
        {
            txtTotal.Text = " /" + Convert.ToString(total) + ".00";
        }

        private void TxtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }
    }
}
