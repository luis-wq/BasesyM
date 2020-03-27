using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BasesYMolduras
{
    public partial class Pagos : MetroFramework.Forms.MetroForm
    {
        Listados Padre;
        CotizacionesRealizadas pad;
        Produccion pod;
        int bandera, tareaBandera, idCotizacion;
        double total, pagado;
        string tipo_usuario, id;
        DataTable datosPagos, datosCuenta;
        DateTime t;

        private void BtnControl_Click(object sender, EventArgs e)
        {
                double bass = Convert.ToDouble(total);
                pagado = Convert.ToDouble(pagado);
                if (pagado >= bass)
                {
                    MetroFramework.MetroMessageBox.
                      Show(this, "El monto pagado es mayor al adeudo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                AgregarPago form = new AgregarPago(this, Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]), total, pagado,t);
                form.Show();
                this.Enabled = false;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] b = (byte[])datosPagos.Rows[lista.CurrentRow.Index]["Imagen"];
                VerPago verpago = new VerPago(this, Convert.ToString(datosPagos.Rows[lista.CurrentRow.Index]["URL_pago"]), b);

                verpago.Show();
                this.Enabled = false;
            }
            catch {
                MetroFramework.MetroMessageBox.
                  Show(this, "No has seleccionado un pago o no se encuentra ningún pago registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (bandera == 0)
            {
                pad.Enabled = true;
                pad.FocusMe();
                this.Close();
            }
            else if(bandera == 6)
            {
                pod.Enabled = true;
                pod.FocusMe();
                this.Close();
                pod.listarTabla();
            }
            else
            {
                Padre.Enabled = true;
                Padre.FocusMe();
                this.Close();
                Padre.CargarDatos();

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            String id_pago = "", fecha = "", monto = "", forma = "", concepto = "", nombre = "",pago_letras="";

            try
            {
                int id = Convert.ToInt32(lista.SelectedRows[0].Cells["id_pago"].Value.ToString());
                DataTable reporteador = BD.informacionPago(id);


                foreach (DataRow row in reporteador.Rows)
                {
                    id_pago = row["ID"].ToString();
                    fecha = row["FECHA"].ToString();
                    monto = row["PAGADO"].ToString();
                    forma = row["FORMA"].ToString();
                    concepto = row["CONCEPTO"].ToString();
                    nombre = row["NOMBRE"].ToString();

                    pago_letras = toText(Convert.ToDouble(monto));
                    Console.WriteLine(id_pago);
                    Console.WriteLine(fecha);
                    Console.WriteLine(monto);
                    Console.WriteLine(pago_letras);
                    Console.WriteLine(forma);
                    Console.WriteLine(concepto);
                    Console.WriteLine(nombre);
                }
                DateTime fecha_pago = DateTime.Parse(fecha);
                fecha = fecha_pago.ToString("dd/MM/yyyy");
                //System.Diagnostics.Process.Start("recibo_No." + id_pago + ".pdf");
                System.Diagnostics.Process.Start(@"PDF\recibo_No." + id_pago + ".pdf");
            }
            catch {

                Document doc = new Document(PageSize.A4.Rotate(), 80f, 80f, 70f, 70f);
                BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                var FontColour = new BaseColor(255, 255, 255);

                iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
                //iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);

                iTextSharp.text.Font f_14_bold = new iTextSharp.text.Font(arial, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f_22_bold = new iTextSharp.text.Font(arial, 22, iTextSharp.text.Font.BOLD, FontColour);
                iTextSharp.text.Font f_20_bold = new iTextSharp.text.Font(arial, 20, iTextSharp.text.Font.BOLD, FontColour);
                iTextSharp.text.Font f_17_bold = new iTextSharp.text.Font(arial, 17, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f_17_bold_c = new iTextSharp.text.Font(arial, 17, iTextSharp.text.Font.BOLD, FontColour);
                iTextSharp.text.Font f_15_normal = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font f_15_normal_c = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.NORMAL, FontColour);
                iTextSharp.text.Font f_10_bold = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD, FontColour);
                iTextSharp.text.Font f_10_bold_2 = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f_9_normal = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.NORMAL);

                FileStream os = new FileStream("PDF\\" + "recibo_No." + id_pago + ".pdf", FileMode.Create);
                //FileStream os = new FileStream("recibo_No." + id_pago + ".pdf", FileMode.Create);

                using (os)
                {
                    PdfWriter pw = PdfWriter.GetInstance(doc, os);
                    doc.Open();
                    float[] width = new float[] { 100f, 100f };

                    PdfPTable table_general = new PdfPTable(1);
                    table_general = new PdfPTable(1);


                    PdfPTable table1 = new PdfPTable(1);
                    table1 = new PdfPTable(1);
                    table1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    PdfPCell cel1_1 = new PdfPCell(new Phrase("BASES Y MOLDURAS",f_22_bold));
                    PdfPCell cel2_1 = new PdfPCell(new Phrase("Av. Caracol No.23 Col. Cruz con casitas, Tuxtla Gutierrez,", f_15_normal_c));
                    PdfPCell cel3_1 = new PdfPCell(new Phrase("Chiapas CP 29019 Tel. 01 (961) 656 60 72", f_15_normal_c));

                    cel1_1.VerticalAlignment = Element.ALIGN_CENTER;
                    cel1_1.HorizontalAlignment = Element.ALIGN_CENTER;

                    cel2_1.VerticalAlignment = Element.ALIGN_CENTER;
                    cel2_1.HorizontalAlignment = Element.ALIGN_CENTER;

                    cel3_1.VerticalAlignment = Element.ALIGN_CENTER;
                    cel3_1.HorizontalAlignment = Element.ALIGN_CENTER;

                    cel1_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel2_1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel3_1.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    cel1_1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);
                    cel2_1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);
                    cel3_1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);


                    table1.AddCell(cel1_1);
                    table1.AddCell(cel2_1);
                    table1.AddCell(cel3_1); 

                    PdfPTable table2 = new PdfPTable(2);

                    table2 = new PdfPTable(2);

                    table2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    PdfPCell cel1 = new PdfPCell(new Phrase("Cantidad", f_17_bold_c));
                    PdfPCell cel2 = new PdfPCell(new Phrase("" + string.Format("{0:C2}", Convert.ToDouble(monto)), f_15_normal));
                    PdfPCell cel3 = new PdfPCell(new Phrase("N° recibo",f_17_bold_c));
                    PdfPCell cel4 = new PdfPCell(new Phrase("" + id_pago, f_15_normal));
                    PdfPCell cel5 = new PdfPCell(new Phrase("Fecha emisión", f_17_bold_c));
                    PdfPCell cel6 = new PdfPCell(new Phrase("" + fecha, f_15_normal));

                    cel1.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    cel2.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    cel3.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    cel4.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    cel5.HorizontalAlignment = Element.ALIGN_MIDDLE;
                    cel6.HorizontalAlignment = Element.ALIGN_MIDDLE;

                    cel1.BackgroundColor = new iTextSharp.text.BaseColor(152, 110, 91);
                    cel3.BackgroundColor = new iTextSharp.text.BaseColor(152, 110, 91);
                    cel5.BackgroundColor = new iTextSharp.text.BaseColor(152, 110, 91);

                    table2.AddCell(cel1);
                    table2.AddCell(cel2);
                    table2.AddCell(cel3);
                    table2.AddCell(cel4);
                    table2.AddCell(cel5);
                    table2.AddCell(cel6);

                    

                    PdfPTable table_1 = new PdfPTable(2);
                    table_1 = new PdfPTable(2);
                    table_1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    table_1.AddCell(table1);
                    table_1.AddCell(table2);
                    table_1.WidthPercentage = 100;

                    //

                    PdfPTable table3 = new PdfPTable(1);
                    table3 = new PdfPTable(1);

                    PdfPCell cel1_3 = new PdfPCell(new Phrase(""));
                    PdfPCell cel2_3 = new PdfPCell(new Phrase(" Recibí de:", f_17_bold));
                    PdfPCell cel3_3 = new PdfPCell(new Phrase(" "+nombre, f_15_normal));
                    PdfPCell cel4_3 = new PdfPCell(new Phrase(" La cantidad:", f_17_bold));
                    PdfPCell cel5_3 = new PdfPCell(new Phrase(" "+string.Format("{0:C2}", Convert.ToDouble(monto)), f_15_normal));
                    PdfPCell cel6_3 = new PdfPCell(new Phrase(" La suma de:", f_17_bold));
                    PdfPCell cel7_3 = new PdfPCell(new Phrase(" "+pago_letras +" PESOS 00/100 MN", f_15_normal));
                    PdfPCell cel8_3 = new PdfPCell(new Phrase(" Por concepto de:", f_17_bold));
                    PdfPCell cel9_3 = new PdfPCell(new Phrase(" "+concepto, f_15_normal));

                    cel1_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel2_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel3_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel4_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel5_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel6_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel7_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel8_3.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel9_3.HorizontalAlignment = Element.ALIGN_LEFT;

                    cel1_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel2_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel3_3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    cel4_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel5_3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    cel6_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel7_3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    cel8_3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel9_3.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    table3.AddCell(cel1_3);
                    table3.AddCell(cel2_3);
                    table3.AddCell(cel3_3);
                    table3.AddCell(cel4_3);
                    table3.AddCell(cel5_3);
                    table3.AddCell(cel6_3);
                    table3.AddCell(cel7_3);
                    table3.AddCell(cel8_3);
                    table3.AddCell(cel9_3);

                    table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //
                    PdfPTable table4 = new PdfPTable(2);
                    table4 = new PdfPTable(2);


                    if (forma.Equals("1"))
                    {
                        forma = "Transferencia";
                    }
                    else if (forma.Equals("2"))
                    {
                        forma = "Depósito";
                    }
                    else if (forma.Equals("3"))
                    {
                        forma = "Efectivo";
                    }
                    else {
                        forma = " ";
                    }
                    PdfPCell cel1_4 = new PdfPCell(new Phrase("Forma de pago:", f_17_bold));
                    PdfPCell cel2_4 = new PdfPCell(new Phrase("Total recibido:", f_17_bold_c));
                    PdfPCell cel3_4 = new PdfPCell(new Phrase("" + forma+"\n", f_17_bold));
                    PdfPCell cel4_4 = new PdfPCell(new Phrase(""+ string.Format("{0:C2}", Convert.ToDouble(monto)) + "\n", f_20_bold));

                    cel1_4.MinimumHeight = 30f;
                    cel2_4.MinimumHeight = 30f;
                    cel3_4.MinimumHeight = 50f;
                    cel4_4.MinimumHeight = 50f;

                    cel1_4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel2_4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel3_4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel4_4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cel2_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cel3_4.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cel4_4.VerticalAlignment = Element.ALIGN_MIDDLE;

                    
                    cel1_4.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    cel2_4.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    cel3_4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cel4_4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    cel1_4.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    cel2_4.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    cel3_4.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                    cel4_4.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                    
                    cel2_4.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 209);
                    cel4_4.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 209);

                    table4.AddCell(cel1_4);
                    table4.AddCell(cel2_4);
                    table4.AddCell(cel3_4);
                    table4.AddCell(cel4_4);



                    table4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    table4.WidthPercentage = 100;
                    //

                    table_general.AddCell(table_1);
                    table_general.AddCell(table3);
                    table_general.AddCell(table4);
                    table_general.WidthPercentage = 100;


                    doc.Add(table_general);

                    doc.Close();
                    System.Diagnostics.Process.Start(@"PDF\recibo_No." + id_pago + ".pdf");
                    //System.Diagnostics.Process.Start("recibo_No." + id_pago + ".pdf");
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
           
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch



            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }

    public Pagos(Listados padre, int bandera, string tipo_usuario, string id, int tareaBandera, int idCotizacion, DateTime t)
        {
            InitializeComponent();
            this.Padre = padre;
            this.bandera = bandera;
            this.tareaBandera = tareaBandera;
            this.tipo_usuario = tipo_usuario;
            this.id = id;
            this.idCotizacion = idCotizacion;
            this.t = t;
        }

        public Pagos(CotizacionesRealizadas padreN, int idCotizacion, int bandera,DateTime t)
        {
            InitializeComponent();
            this.pad = padreN;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            this.t = t;
            
        }
        public Pagos(Produccion padreP, int idCotizacion, int bandera,DateTime t)
        {

            InitializeComponent();
            this.pod = padreP;
            this.idCotizacion = idCotizacion;
            this.bandera = bandera;
            this.t = t;

        }



        private void Pagos_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(new ThreadStart(this.CargarDatosHilo));
            hilo.Start();
        }

        public void CargarDatosHilo() {
            pagado = 0;
            int i = 0;
            datosCuenta = BD.listarCuenta(idCotizacion);
            datosPagos = BD.listarPagos(Convert.ToInt32(datosCuenta.Rows[0]["id_cuenta_cliente"]));
            lista.DataSource = datosPagos;
            lista.Columns["monto_pagado"].DefaultCellStyle.Format = "C2";
            lista.Columns["Imagen"].Visible = false;
            try
            {
                foreach (DataGridViewRow row in lista.Rows)
                {
                    pagado = pagado + Convert.ToDouble(datosPagos.Rows[i]["monto_pagado"]);
                    i++;
                }
                txtPagado.Text = string.Format("{0:c2}", pagado); 
            }
            catch {
                txtPagado.Text = "$"+"00.00";
            }
            total = Convert.ToDouble(datosCuenta.Rows[0]["monto_total"]);
            txtTotal.Text = string.Format("{0:c2}", total); 
            Double restante = total - pagado;
            txtResta.Text = string.Format("{0:c2}", restante);
        }

 
    }
}
