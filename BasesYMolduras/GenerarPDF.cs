using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class GenerarPDF : MetroFramework.Forms.MetroForm
    {
        Listados Padre;
        String tipo;
        int idCotizacion;
        String combo,observacion,nombre,ciudad,estado,cp,cotizacion_cliente,direccion,colonia,numero_ext,num_cel, fecha, num_cotizacion,envio;
        float total;
        MySqlDataReader datosCliente;

        public GenerarPDF(Listados padre, String tipo, int idCotizacion)
        {
            this.Padre = padre;
            this.tipo = tipo;
            this.idCotizacion = idCotizacion;
            InitializeComponent();
        }

        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void listarTablaCotizacion()
        {
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosCotizacion(tablaProductos, idCotizacion);

            tablaProductos.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";

           // for (int i = 0; i < tablaProductos.RowCount; i++) {
           //
           //     total += tablaProductos.Columns["IMPORTE"].Float
           // }

        }

        private void LblEstado_Click(object sender, EventArgs e)
        {

        }

        private void listarTablaProduccion()
        {
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosProduccion(tablaProductos, idCotizacion);
        }
        private void listarTablaMakila()
        {
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosMakila(tablaProductos, idCotizacion);
        }
        private void GenerarPDF_Load(object sender, EventArgs e)
        {
            llenarTipo();
            llenarDatos();
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo = comboBoxTipo.Text;
            llenarTabla();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }

        private void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (combo.Equals("COTIZACIÓN"))
            {
                generarDocumentoPDFCotizacion();
            }
            else if (combo.Equals("PRODUCCIÓN"))
            {
                generarDocumentoPDFProduccion();
            }
            else if (combo.Equals("MAKILA"))
            {
                generarDocumentoPDFProduccion();
            }
        }

        private void generarDocumentoPDFCotizacion()
        {
            Document doc = new Document(PageSize.A4, 30f, 20f, 50f, 40f);
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Font f_10_bold = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_9_normal = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.NORMAL);

            Random rnd = new Random();
            int name = rnd.Next(1, 1000);
            FileStream os = new FileStream("Cotizacion" + name.ToString() + ".pdf", FileMode.Create);

            using (os)
            {
                PdfWriter pw = PdfWriter.GetInstance(doc, os);
                pw.PageEvent = new HeaderFooter();
                
                doc.Open();
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };
                /*
                //Encabezado

                float[] width = new float[] { 40f, 60f };

                PdfPCell cel1 = new PdfPCell(new Phrase("\nDirección:                Av.Caracol.", f_12_normal));
                PdfPCell cel2 = new PdfPCell(new Phrase("Colonia:              Cruz con casitas.", f_12_normal));
                PdfPCell cel3 = new PdfPCell(new Phrase("C.Postal:                         29019", f_12_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("Localidad:     Tuxtla Gutiérrez Chiapas", f_12_normal));
                PdfPCell cel5 = new PdfPCell(new Phrase("Estado:                         Chiapas", f_12_normal));
                PdfPCell cel6 = new PdfPCell(new Phrase("Tel Móvil:               01 961 6566072", f_12_normal));

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel6.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel5.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel6.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                //table1.WidthPercentage = 40;
                table1.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel5);
                table1.AddCell(cel6);

                //table1.SpacingAfter = 20;
                //table1.SpacingBefore = 50;
                //doc.Add(table1);

                PdfPTable table3 = new PdfPTable(1);
                table3.AddCell(table1);
                table3.HorizontalAlignment = Element.ALIGN_LEFT;
                table3.WidthPercentage = 40;
                doc.Add(table3);

                //
                */
                doc.Add(new Paragraph(70, "\u00a0"));

                table1 = new PdfPTable(1);

                PdfPCell cel1 = new PdfPCell(new Phrase("DATOS DEL CLIENTE", f_10_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("NOMBRE: "+nombre, f_9_normal));
                PdfPCell cel3 = new PdfPCell(new Phrase("DIRECCIÓN: "+ direccion + ", " + numero_ext + ", " + colonia, f_9_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("C. POSTAL: "+cp, f_9_normal));
                PdfPCell cel5 = new PdfPCell(new Phrase("LOCALIDAD: "+ciudad, f_9_normal));
                PdfPCell cel6 = new PdfPCell(new Phrase("ESTADO: "+estado, f_9_normal));

                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel5.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel6.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel6.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cel1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel5);
                table1.AddCell(cel6);



                //table1.SpacingAfter = 50;
                //table1.SpacingBefore = 50;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.WidthPercentage = 100;
                doc.Add(table2);
                
                //FECHA
                Paragraph paragraph = new Paragraph(new Phrase("Fecha: "+fecha+" \n", f_12_normal));
                paragraph.Add(new Phrase(":V\n", f_12_normal));
                paragraph.Add(new Phrase("Cotización: "+num_cotizacion+"\n", f_12_normal));
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(paragraph);

                //CONTENIDO
                int cantidadColumnaTabla = tablaProductos.ColumnCount;
                int cantidadFilaTabla = tablaProductos.RowCount;
                table1 = new PdfPTable(cantidadColumnaTabla);
                decimal ht = 0, tva = 0, ttc = 0;

                for (int j = 0; j < cantidadColumnaTabla; j++)
                {
                    cel1 = new PdfPCell(new Phrase(tablaProductos.Columns[j].HeaderText,f_10_bold));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    cel1.BackgroundColor = new iTextSharp.text.BaseColor(226, 107, 10);
                    table1.AddCell(cel1);
                }

                for (int i = 0; i < cantidadFilaTabla; i++)
                {

                    for (int j = 0; j < cantidadColumnaTabla; j++)
                    {
                        if (j == 4 || j == 6) {
                            double precio = Convert.ToDouble(tablaProductos.Rows[i].Cells[j].Value.ToString());
                            cel1 = new PdfPCell(new Phrase(string.Format("{0:C2}", precio), f_9_normal));
                            
                        }
                        else
                        {
                            cel1 = new PdfPCell(new Phrase(tablaProductos.Rows[i].Cells[j].Value.ToString(), f_9_normal));
                        }

                        cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cel1.FixedHeight = 20;
                        table1.AddCell(cel1);
                    }

                    //ht = decimal.Parse(lista.Rows[i].Cells[4].Value as string);

                }


                //tva = (ht * 20) / (100);
                //ttc = ht + tva;

                table1.WidthPercentage = 100;
                width = new float[] { 20f, 100f, 100f, 100f, 100f, 100f ,100f};
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);



                doc.Close();
                System.Diagnostics.Process.Start(@"Cotizacion" + name.ToString() + ".pdf");
            }
        }
        private void generarDocumentoPDFProduccion()
        {
            Document doc = new Document(PageSize.A4.Rotate(), 30f, 20f, 50f, 40f);
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_12_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_11_normal = new iTextSharp.text.Font(arial, 11, iTextSharp.text.Font.NORMAL);

            Random rnd = new Random();
            int name = rnd.Next(1, 1000);
            FileStream os = new FileStream("Cotizacion" + name.ToString() + ".pdf", FileMode.Create);

            using (os)
            {
                PdfWriter pw = PdfWriter.GetInstance(doc, os);
                pw.PageEvent = new HeaderFooter();

                doc.Open();
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };

                doc.Add(new Paragraph(100, "\u00a0"));

                table1 = new PdfPTable(1);

                PdfPCell cel1 = new PdfPCell(new Phrase("", f_12_normal));
                PdfPCell cel2 = new PdfPCell(new Phrase("Nombre:" + nombre, f_12_normal));
                PdfPCell cel3 = new PdfPCell(new Phrase("DIRECCION:", f_12_normal));

                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);

                //table1.SpacingAfter = 50;
                //table1.SpacingBefore = 50;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                table2.WidthPercentage = 40;
                doc.Add(table2);

                //FECHA
                Paragraph paragraph = new Paragraph(new Phrase("FECHA:" + fecha + " \n", f_12_normal));
                paragraph.Add(new Phrase(":V\n", f_12_normal));
                paragraph.Add(new Phrase("COTIZACION:" + num_cotizacion + "\n", f_12_normal));
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(paragraph);

                //CONTENIDO
                int cantidadColumnaTabla = tablaProductos.ColumnCount;
                int cantidadFilaTabla = tablaProductos.RowCount;
                table1 = new PdfPTable(cantidadColumnaTabla);
                decimal ht = 0, tva = 0, ttc = 0;

                for (int j = 0; j < cantidadColumnaTabla; j++)
                {
                    cel1 = new PdfPCell(new Phrase(tablaProductos.Columns[j].HeaderText, f_12_bold));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    cel1.BackgroundColor = new iTextSharp.text.BaseColor(226, 107, 10);
                    
                    table1.AddCell(cel1);
                }

                for (int i = 0; i < cantidadFilaTabla; i++)
                {

                    for (int j = 0; j < cantidadColumnaTabla; j++)
                    {
                        cel1 = new PdfPCell(new Phrase(tablaProductos.Rows[i].Cells[j].Value.ToString(), f_11_normal));
                        cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.FixedHeight = 20;
                        table1.AddCell(cel1);
                    }

                    //ht = decimal.Parse(lista.Rows[i].Cells[4].Value as string);

                }

                //tva = (ht * 20) / (100);
                //ttc = ht + tva;

                table1.WidthPercentage = 100;
                width = new float[] { 130f, 130f, 100f, 100f, 100f, 100f, 70f };
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);



                doc.Close();
                System.Diagnostics.Process.Start(@"Cotizacion" + name.ToString() + ".pdf");
            }
        }
        private void llenarTipo() {
            String tipo = Login.tipo;
            if (tipo.Equals("ADMINISTRADOR") || tipo.Equals("VENDEDOR"))
            {
                comboBoxTipo.Items.Add("COTIZACIÓN");
            }
            comboBoxTipo.Items.Add("PRODUCCIÓN");
            comboBoxTipo.Items.Add("MAKILA");
            comboBoxTipo.SelectedIndex = 0;
        }
        private void llenarDatos()
        {
            BD metodos = new BD();
            BD.ObtenerConexion();
            
            datosCliente = metodos.consultarCliente(idCotizacion);

            observacion = datosCliente.GetString(0);
            fecha = datosCliente.GetDateTime(1).ToShortDateString();
            nombre = datosCliente.GetString(2);
            ciudad = datosCliente.GetString(3);
            estado = datosCliente.GetString(4);
            cp = datosCliente.GetUInt32(5).ToString();
            cotizacion_cliente = datosCliente.GetUInt32(6).ToString();
            num_cotizacion = datosCliente.GetUInt32(7).ToString();
            direccion = datosCliente.GetString(8);
            colonia = datosCliente.GetString(9);
            numero_ext = datosCliente.GetString(10);
            num_cel = datosCliente.GetString(11);
            envio = datosCliente.GetFloat(12).ToString();

            lblNombre.Text = nombre;
            lblCodigo.Text = cp;
            lblEstado.Text = estado;
            lblLocal.Text = ciudad;
            lblNP.Text = cotizacion_cliente;
            lblFecha.Text = fecha;
            lblDirec.Text = direccion + ", " + colonia + ", " + numero_ext;
            lblCelular.Text = num_cel;
            lblCotizacion.Text = num_cotizacion;


            //GetUInt32(15).ToString();datosUsuario.GetString(3);

            BD.CerrarConexion();
        }
        private void llenarTabla() {

            if(combo.Equals("COTIZACIÓN"))
            {
                listarTablaCotizacion();
            }
            else if(combo.Equals("PRODUCCIÓN"))
            {
                listarTablaProduccion();
            }
            else if(combo.Equals("MAKILA"))
            {
                listarTablaMakila();
            }

        }
    }
}

class HeaderFooter : PdfPageEventHelper
{
    private BaseColor colorBlue;
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        iTextSharp.text.Font f_10_normal = new iTextSharp.text.Font(arial, 11, iTextSharp.text.Font.NORMAL);

        PdfPTable tbHeader = new PdfPTable(3);
        tbHeader.HorizontalAlignment = Element.ALIGN_LEFT;
        tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        tbHeader.DefaultCell.Border = 0;

        String encabezado = "Dirección: Av.Caracol\n" +
                            "Colonia: Cruz con casitas\n" +
                            "C.Postal: 29019\n" +
                            "Localidad: Tuxtla Gutiérrez\n" +
                            "Estado: Chiapas\n" +
                            "Tel Móvil: 01 961 6566072\n";

        //tbHeader.AddCell(new Paragraph());
        /*
        String IMG1 = "C:/Users/Alejandro/Source/Repos/BasesYMolduras/BasesYMolduras/Resources/logo.jpg";
        PdfPCell _cel2 = new PdfPCell(new Paragraph());
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(IMG1);
        img.ScaleAbsolute(125f, 50f);
        _cel2.AddElement(img);
        _cel2.HorizontalAlignment = Element.ALIGN_LEFT;
        _cel2.Border = 0;
        tbHeader.AddCell(_cel2);
        */
        PdfPCell _cell1 = new PdfPCell(new Paragraph(encabezado, f_10_normal));
        _cell1.HorizontalAlignment = Element.ALIGN_CENTER;
        _cell1.Border = 0;
        tbHeader.AddCell(_cell1);

        tbHeader.AddCell(new Paragraph());

        tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin)+20, writer.DirectContent);

        Chunk linebreak = new Chunk(new LineSeparator(1f, 100f, colorBlue, Element.ALIGN_CENTER, -1));
        //tbHeader.Add(linebreak);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        PdfPTable tbFooter = new PdfPTable(3);
        tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        tbFooter.DefaultCell.Border = 0;

        tbFooter.AddCell(new Paragraph());

        PdfPCell _cell = new PdfPCell(new Paragraph("www.basesymolduras.com"));
        _cell.HorizontalAlignment = Element.ALIGN_CENTER;
        _cell.Border = 0;
        tbFooter.AddCell(_cell);

        _cell = new PdfPCell(new Paragraph("Página "+writer.PageNumber+" de "+ document.PageNumber));
        _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        _cell.Border = 0;
        tbFooter.AddCell(_cell);

        tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) -5, writer.DirectContent);

    }
}
