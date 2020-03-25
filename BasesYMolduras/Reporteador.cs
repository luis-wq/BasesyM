using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BasesYMolduras
{
    public partial class Reporteador : MetroFramework.Forms.MetroForm
    {
        Produccion produccion;
        int total_cajas, total_cuadros, total_placas;
        float total_abonado, total_resta, total;
        string fecha1;
        string fecha2;


        private void Date1_ValueChanged(object sender, EventArgs e)
        {
            fecha1 = date1.Value.ToString("yyyy-MM-dd");
            fecha2 = date2.Value.ToString("yyyy-MM-dd");

            total_cajas = 0;
            total_cuadros = 0;
            total_placas = 0;
            total_abonado = 0;
            total_resta = 0;
            total = 0;

            Cursor.Current = Cursors.WaitCursor;
            DataTable reporteador = BD.tableReporteador(fecha1, fecha2);

            DataTable totalCuadros = BD.totalCuadros(fecha1, fecha2);

            DataTable totalPlacas = BD.totalPlacas(fecha1, fecha2);


            foreach (DataRow rowR in reporteador.Rows)
            {

                int id = Convert.ToInt32(rowR["No. Cotizacion"]);

                foreach (DataRow rowC in totalCuadros.Rows)
                {
                    int id_c = Convert.ToInt32(rowC["ID"]);
                    if (id == id_c)
                    {
                        rowR["T. Cuadros"] = rowC["NUM"];
                        break;
                    }
                }

                foreach (DataRow rowP in totalPlacas.Rows)
                {
                    int id_p = Convert.ToInt32(rowP["ID"]);
                    if (id == id_p)
                    {
                        rowR["T. Placas"] = rowP["NUM"];
                        break;
                    }
                }



            }

            foreach (DataRow rowR in reporteador.Rows)
            {
                total_cajas = total_cajas + Convert.ToInt32(rowR["T. Cajas"]);
                total_cuadros = total_cuadros + Convert.ToInt32(rowR["T. Cuadros"]);
                total_placas = total_placas + Convert.ToInt32(rowR["T. Placas"]);
                total_abonado = total_abonado + (float)Convert.ToDouble(rowR["T. Abonado"]);
                total_resta = total_resta + (float)Convert.ToDouble(rowR["T. Resta"]);
                total = total + (float)Convert.ToDouble(rowR["Total"]);

            }

            tablaProductos.DataSource = reporteador;
            tablaProductos.Columns["T. Abonado"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["T. Resta"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["Total"].DefaultCellStyle.Format = "C2";

            txtTotalCajas.Text = "" + total_cajas;
            txtTotalCuadros.Text = "" + total_cuadros;
            txtTotalPlacas.Text = "" + total_placas;
            txtTotalAbonado.Text = string.Format("{0:c2}", total_abonado);
            txtTotalResta.Text = string.Format("{0:c2}", total_resta);
            txtTotal.Text = string.Format("{0:c2}", total);
            Cursor.Current = Cursors.Default;
        }

        public Reporteador(Produccion produccion)
        {
            this.produccion = produccion;
            InitializeComponent();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            produccion.Enabled = true;
            produccion.FocusMe();
        }

        private void Date2_ValueChanged(object sender, EventArgs e)
        {
            fecha1 = date1.Value.ToString("yyyy-MM-dd");
            fecha2 = date2.Value.ToString("yyyy-MM-dd");

            total_cajas = 0;
            total_cuadros = 0;
            total_placas = 0;
            total_abonado = 0;
            total_resta = 0;
            total = 0;

            Cursor.Current = Cursors.WaitCursor;
            DataTable reporteador = BD.tableReporteador(fecha1, fecha2);

            DataTable totalCuadros = BD.totalCuadros(fecha1, fecha2);

            DataTable totalPlacas = BD.totalPlacas(fecha1, fecha2);


            foreach (DataRow rowR in reporteador.Rows)
            {

                int id = Convert.ToInt32(rowR["No. Cotizacion"]);

                foreach (DataRow rowC in totalCuadros.Rows)
                {
                    int id_c = Convert.ToInt32(rowC["ID"]);
                    if (id == id_c)
                    {
                        rowR["T. Cuadros"] = rowC["NUM"];
                        break;
                    }
                }

                foreach (DataRow rowP in totalPlacas.Rows)
                {
                    int id_p = Convert.ToInt32(rowP["ID"]);
                    if (id == id_p)
                    {
                        rowR["T. Placas"] = rowP["NUM"];
                        break;
                    }
                }



            }

            foreach (DataRow rowR in reporteador.Rows)
            {
                total_cajas = total_cajas + Convert.ToInt32(rowR["T. Cajas"]);
                total_cuadros = total_cuadros + Convert.ToInt32(rowR["T. Cuadros"]);
                total_placas = total_placas + Convert.ToInt32(rowR["T. Placas"]);
                total_abonado = total_abonado + (float)Convert.ToDouble(rowR["T. Abonado"]);
                total_resta = total_resta + (float)Convert.ToDouble(rowR["T. Resta"]);
                total = total + (float)Convert.ToDouble(rowR["Total"]);

            }

            tablaProductos.DataSource = reporteador;
            tablaProductos.Columns["T. Abonado"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["T. Resta"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["Total"].DefaultCellStyle.Format = "C2";

            txtTotalCajas.Text = "" + total_cajas;
            txtTotalCuadros.Text = "" + total_cuadros;
            txtTotalPlacas.Text = "" + total_placas;
            txtTotalAbonado.Text = string.Format("{0:c2}", total_abonado);
            txtTotalResta.Text = string.Format("{0:c2}", total_resta);
            txtTotal.Text = string.Format("{0:c2}", total);
            Cursor.Current = Cursors.Default;
        }

        private void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                    SaveFileDialog fichero = new SaveFileDialog();
                fichero.FileName = "reporteador_" + fecha1 + "-" + fecha2;
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    //Recorremos el DataGridView rellenando la hoja de trabajo

                    hoja_trabajo.Cells[5, 2] = "No. Cotizacion";
                    hoja_trabajo.Cells[5, 3] = "Vendedor";
                    hoja_trabajo.Cells[5, 4] = "Nombre del cliente";
                    hoja_trabajo.Cells[5, 5] = "No. Pedido";
                    hoja_trabajo.Cells[5, 6] = "Fecha de cotización";
                    hoja_trabajo.Cells[5, 7] = "T. Cajas";
                    hoja_trabajo.Cells[5, 8] = "T. Cuadros";
                    hoja_trabajo.Cells[5, 9] = "T. Placas";
                    hoja_trabajo.Cells[5, 10] = "T. Abonado";
                    hoja_trabajo.Cells[5, 11] = "T. Resta";
                    hoja_trabajo.Cells[5, 12] = "Total";
                    hoja_trabajo.Cells[5, 13] = "Estatus del pedido";



                    int hi = 6;
                    int hj = 2;
                    for (int i = 0; i < tablaProductos.Rows.Count; i++)
                    {
                        for (int j = 0; j < tablaProductos.Columns.Count; j++)
                        {
                            
                            if (j == 4)
                            {
                                DateTime fecha = DateTime.Parse(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                hoja_trabajo.Cells[hi, hj] = fecha.ToString("yyyy-MM-dd");
                            }
                            else if (j == 8 || j == 9 || j == 10)
                            {
                                float num = (float)Convert.ToDouble(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                String numero = string.Format("{0:c2}", num);
                                hoja_trabajo.Cells[hi, hj] = numero;
                            }
                            else {
                                hoja_trabajo.Cells[hi, hj] = tablaProductos.Rows[i].Cells[j].Value.ToString();
                            }
                            hj++;
                        }
                        hj = 2;
                        hi++;
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha generado este documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
