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
    public partial class Listados : MetroFramework.Forms.MetroForm
    {
        DataTable dt;
        string tipo_usuario;
        Inicio Padre = null;
        int bandera = 0;
        public Listados(Inicio padre, int bandera,string tipo_usuario)
        {
            Padre = padre;
            this.bandera = bandera;
            this.tipo_usuario = tipo_usuario;
            InitializeComponent();
            dt = BD.listarUsuarios(lista);


        }



        private void Listados_Load(object sender, EventArgs e)
        {

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
                case 4: AgregarCliente(bandera, tipo_usuario); break;    //Usuario
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
            AgregarCliente form = new AgregarCliente(this, bandera, tipo);
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
                                let codigo = Convert.ToString(item[1] == null ? string.Empty : item[1].ToString())
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
    }
}
