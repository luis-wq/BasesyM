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
            if (tablaProductos.RowCount != 0)
            {

                try
                {
                    txtGenerando.Text = "GENERANDO DOCUMENTO ...";
                    Cursor.Current = Cursors.WaitCursor;
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
                        hoja_trabajo.Cells[10, 15] = "Total resta:";
                        hoja_trabajo.Cells[11, 15] = "Total:";
                        hoja_trabajo.Cells[9, 17] = string.Format("{0:c2}", total_abonado);
                        hoja_trabajo.Cells[10, 17] = string.Format("{0:c2}", total_resta);
                        hoja_trabajo.Cells[11, 17] = string.Format("{0:c2}", total);

                        //hoja_trabajo.Cells[2,8] = "Reporteador";

                        hoja_trabajo.Cells[6, 3] = "Fecha inicial búsqueda: " + fecha1;
                        hoja_trabajo.Cells[11, 3] = "Fecha termino búsqueda : " + fecha2;

                        aplicacion.get_Range("H2:L4").Merge(true);
                        Microsoft.Office.Interop.Excel.Range titulo = hoja_trabajo.get_Range("H2:L4");
                        titulo.Merge();
                        titulo.Value = "Reporteador";

                        //titulo.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //titulo.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        titulo.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        titulo.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        titulo.Font.Size = 36;
                        titulo.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                        titulo.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;
                        titulo.Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;

                        ///////////////////////////////
                        //
                        aplicacion.get_Range("H7:L10").Merge(true);
                        Microsoft.Office.Interop.Excel.Range nombre = hoja_trabajo.get_Range("H7:L10");
                        nombre.Merge();
                        nombre.Value = "BASES Y MOLDURAS";
                        nombre.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        nombre.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        nombre.Font.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbGreen;
                        nombre.Font.Size = 30;
                        //Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)hoja_trabajo.Cells[6, 9];
                        //float Left = (float)((double)oRange.Left);
                        //float Top = (float)((double)oRange.Top);
                        //C:\\Users\\Alejandro\\Source\\Repos\\BasesYMolduras\\BasesYMolduras\\Resources\\logo.png
                        //Resources/logo.png
                        //hoja_trabajo.Shapes.AddPicture(@"\Resources\logo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 175, 100);

                        ////////////////////////////

                        aplicacion.get_Range("O6", "P11").Merge(true);
                        aplicacion.get_Range("C6", "E6").Merge(true);
                        aplicacion.get_Range("C11", "E11").Merge(true);

                        Microsoft.Office.Interop.Excel.Range encabezado = hoja_trabajo.get_Range("B5:R12");
                        encabezado.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                        encabezado.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhiteSmoke;

                        //O6:Q11


                        Microsoft.Office.Interop.Excel.Range rango_precios = hoja_trabajo.get_Range("O6:Q11");
                        Microsoft.Office.Interop.Excel.Borders borde_total_precios = rango_precios.Borders;
                        borde_total_precios.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        borde_total_precios.Weight = 3d;

                        Microsoft.Office.Interop.Excel.Range rango_fecha1 = hoja_trabajo.get_Range("C6:E6");
                        Microsoft.Office.Interop.Excel.Borders borde_fecha1 = rango_fecha1.Borders;
                        borde_fecha1.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        borde_fecha1.Weight = 3d;

                        Microsoft.Office.Interop.Excel.Range rango_fecha2 = hoja_trabajo.get_Range("C11:E11");
                        Microsoft.Office.Interop.Excel.Borders borde_fecha2 = rango_fecha2.Borders;
                        borde_fecha2.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        borde_fecha2.Weight = 3d;



                        //CONTENIDO
                        hoja_trabajo.Cells[13, 2] = "No. Cotizacion";
                        hoja_trabajo.Cells[13, 3] = "Vendedor";
                        hoja_trabajo.Cells[13, 5] = "Nombre del cliente";
                        hoja_trabajo.Cells[13, 8] = "No. Pedido";
                        hoja_trabajo.Cells[13, 9] = "Fecha de cotización";
                        hoja_trabajo.Cells[13, 11] = "T. Cajas";
                        hoja_trabajo.Cells[13, 12] = "T. Cuadros";
                        hoja_trabajo.Cells[13, 13] = "T. Placas";
                        hoja_trabajo.Cells[13, 14] = "T. Abonado";
                        hoja_trabajo.Cells[13, 15] = "T. Resta";
                        hoja_trabajo.Cells[13, 16] = "Total";
                        hoja_trabajo.Cells[13, 17] = "Estatus del pedido";

                        int hi = 14;
                        int hj = 2;
                        for (int i = 0; i < tablaProductos.Rows.Count; i++)
                        {
                            for (int j = 0; j < tablaProductos.Columns.Count; j++)
                            {

                                if (j == 2)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tablaProductos.Rows[i].Cells[j].Value.ToString();
                                    hj = hj + 2;
                                    aplicacion.get_Range("E" + hi.ToString(), "G" + hi.ToString()).Merge(true);
                                }
                                else if (j == 1)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tablaProductos.Rows[i].Cells[j].Value.ToString();
                                    hj = hj + 1;
                                    aplicacion.get_Range("C" + hi.ToString(), "D" + hi.ToString()).Merge(true);
                                }
                                else if (j == 4)
                                {
                                    DateTime fecha = DateTime.Parse(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                    hoja_trabajo.Cells[hi, hj] = fecha.ToString("yyyy-MM-dd");
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj = hj + 1;
                                    aplicacion.get_Range("I" + hi.ToString(), "J" + hi.ToString()).Merge(true);

                                }
                                else if (j == 4)
                                {
                                    DateTime fecha = DateTime.Parse(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                    hoja_trabajo.Cells[hi, hj] = fecha.ToString("yyyy-MM-dd");
                                    //hoja_trabajo.Range[hi, hj].Style.Color = Color.LightBlue;
                                    hj = hj + 1;
                                    aplicacion.get_Range("I" + hi.ToString(), "J" + hi.ToString()).Merge(true);

                                }

                                else if (j == 11)
                                {
                                    hoja_trabajo.Cells[hi, hj] = tablaProductos.Rows[i].Cells[j].Value.ToString();
                                    hj = hj + 1;
                                    aplicacion.get_Range("Q" + hi.ToString(), "R" + hi.ToString()).Merge(true);

                                }
                                else if (j == 8 || j == 9 || j == 10)
                                {
                                    float num = (float)Convert.ToDouble(tablaProductos.Rows[i].Cells[j].Value.ToString());
                                    String numero = string.Format("{0:c2}", num);
                                    hoja_trabajo.Cells[hi, hj] = numero;
                                }
                                else
                                {
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
                        bordeTotal.Weight = 3d;

                        //

                        //bold
                        hoja_trabajo.Range["B13:R13"].Font.Bold = true;
                        hoja_trabajo.Range["O6:P11"].Font.Bold = true;

                        hoja_trabajo.Range["O6:Q8"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightGreen;
                        hoja_trabajo.Range["O9:Q11"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightYellow;
                        hoja_trabajo.Range["B13:R13"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightGreen;
                        hoja_trabajo.Range["C6"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightSkyBlue;
                        hoja_trabajo.Range["C11"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightSkyBlue;

                        aplicacion.get_Range("C13", "D13").Merge(true);
                        aplicacion.get_Range("E13", "G13").Merge(true);
                        aplicacion.get_Range("I13", "J13").Merge(true);
                        aplicacion.get_Range("Q13", "R13").Merge(true);


                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        txtGenerando.Text = "";

                        try {
                            System.Diagnostics.Process.Start(fichero.FileName);
                        }
                        catch {
                            DialogResult pregunta2;
                            pregunta2 = MetroFramework.MetroMessageBox.Show(this, "No se puede abrir el documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        

                        DialogResult pregunta;
                        pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito\n Guardado en: " + fichero.FileName + " ", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Cursor.Current = Cursors.Default;

                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        txtGenerando.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha generado este documento", "AVISO"+ex, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Error" + ex);
                    Cursor.Current = Cursors.Default;
                    txtGenerando.Text = "";
                }
            }
            else {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "No existeb datos para generar el documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
