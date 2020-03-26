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
            try
            {
                filtroFecha();
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.
                Show(this, " Intentelo de nuevo", "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
            try
            {
                filtroFecha();
            }
            catch (Exception) {
                MetroFramework.MetroMessageBox.
                Show(this, " Intentelo de nuevo", "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void filtroFecha() {
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

            DataTable totalCajas = BD.totalCajas(fecha1, fecha2);


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

                foreach (DataRow rowCa in totalCajas.Rows)
                {
                    int id_ca = Convert.ToInt32(rowCa["ID"]);
                    if (id == id_ca)
                    {
                        rowR["T. Cajas"] = rowCa["NUM"];
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
                    Microsoft.Office.Interop.Excel.Range inicio;
                    Microsoft.Office.Interop.Excel.Range ultimo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                    hoja_trabajo.Range["B5:M5"].Font.Bold = true;



                    //ENCABEZADO
                    hoja_trabajo.Cells[6, 15] = "Total de cajas usadas:";
                    hoja_trabajo.Cells[7, 15] = "Total de cuadros:";
                    hoja_trabajo.Cells[8, 15] = "Total de placas:";
                    hoja_trabajo.Cells[6, 17] = "" + total_cajas;
                    hoja_trabajo.Cells[7, 17] = "" + total_cuadros;
                    hoja_trabajo.Cells[8, 17] = "" + total_placas;

                    hoja_trabajo.Cells[9, 15] = "Total abonado:";
                    hoja_trabajo.Cells[10,15] = "Total resta:";
                    hoja_trabajo.Cells[11,15] = "Total:";
                    hoja_trabajo.Cells[9,17] = string.Format("{0:c2}", total_abonado);
                    hoja_trabajo.Cells[10,17] = string.Format("{0:c2}", total_resta);
                    hoja_trabajo.Cells[11,17] = string.Format("{0:c2}", total);







                    //CONTENIDO
                    hoja_trabajo.Cells[13, 2] = "No. Cotizacion";
                    hoja_trabajo.Cells[13, 3] = "Vendedor";
                    hoja_trabajo.Cells[13, 4] = "Nombre del cliente";
                    hoja_trabajo.Cells[13, 5] = "No. Pedido";
                    hoja_trabajo.Cells[13, 6] = "Fecha de cotización";
                    hoja_trabajo.Cells[13, 7] = "T. Cajas";
                    hoja_trabajo.Cells[13, 8] = "T. Cuadros";
                    hoja_trabajo.Cells[13, 9] = "T. Placas";
                    hoja_trabajo.Cells[13, 10] = "T. Abonado";
                    hoja_trabajo.Cells[13, 11] = "T. Resta";
                    hoja_trabajo.Cells[13, 12] = "Total";
                    hoja_trabajo.Cells[13, 13] = "Estatus del pedido";

                    int hi = 14;
                    int hj = 2;
                    for (int i = 0; i < tablaProductos.Rows.Count; i++)
                    {
                        for (int j = 0; j < tablaProductos.Columns.Count; j++)
                        {
                            
                            if (j == 4)
                            {
                                DateTime fecha = DateTime.Parse(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                hoja_trabajo.Cells[hi, hj] = fecha.ToString("yyyy-MM-dd");
                                //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;


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


                    //bordes
                    inicio = hoja_trabajo.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    ultimo = hoja_trabajo.get_Range("B13", inicio);
                    Microsoft.Office.Interop.Excel.Borders bordeTotal = ultimo.Borders;
                    bordeTotal.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    bordeTotal.Weight = 4d;

                    //bold
                    //hoja_trabajo.Range["B13:R13"].Font.Bold = true;


                    libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
            }
            catch (Exception ex)
            {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha generado este documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine("Error" + ex);
            }
        }
    }
}
