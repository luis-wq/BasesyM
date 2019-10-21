﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class GenerarPDF : MetroFramework.Forms.MetroForm
    {
        Produccion Padre;
        String tipo;
        int idCotizacion;
        static internal String fecha,num_cotizacion;
        String combo,observacion,nombre,ciudad,estado,cp,cotizacion_cliente,direccion,colonia,numero_ext,num_cel,envio,cantidad,id_cliente;
        float subtotal,total,envio_float;
        MySqlDataReader datosCliente;
        private Produccion produccion;
        private int idTablaSelect;

        public GenerarPDF(Produccion padre, String tipo, int idCotizacion)
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
            panelTotal.Visible = true;
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosCotizacion(tablaProductos, idCotizacion, tipo);

            for (int i = 0; i < tablaProductos.RowCount; i++) {
                subtotal += float.Parse(tablaProductos.Rows[i].Cells["IMPORTE"].Value.ToString());
            }


            tablaProductos.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
            tablaProductos.Columns["IMPORTE"].DefaultCellStyle.Format = "C2";

            envio_float = float.Parse(envio);
            total = subtotal + envio_float;

            string subtotal_c = subtotal.ToString("C2");
            string envio_c = envio_float.ToString("C2");
            string total_c = total.ToString("C2");

            lblSub.Text = subtotal_c;
            lblEnvio.Text = envio_c;
            lblTotal.Text =total_c;
            piezas();
        }

        private void LblEstado_Click(object sender, EventArgs e)
        {

        }

        private void listarTablaProduccion()
        {
            panelTotal.Visible = false;
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosProduccion(tablaProductos, idCotizacion);
            piezas();
        }
        private void listarTablaMakila()
        {
            panelTotal.Visible = false;
            tablaProductos.DataSource = 0;
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosMakila(tablaProductos, idCotizacion);
            piezas();
        }
        private void GenerarPDF_Load(object sender, EventArgs e)
        {
            llenarDatos();
            llenarTipo();
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
            try
            {
                if (combo.Equals("COTIZACIÓN"))
                {
                    generarDocumentoPDFCotizacion();
                }
                else if (combo.Equals("PRODUCCIÓN"))
                {
                    generarDocumentoPDFProduccion(1);
                }
                else if (combo.Equals("MAKILA"))
                {
                    generarDocumentoPDFProduccion(2);
                }
            }
            catch (Exception) {
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Ya se ha generado este documento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void generarDocumentoPDFCotizacion()
        {
            Document doc = new Document(PageSize.A4, 30f, 20f, 50f, 40f);
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            var FontColour = new BaseColor(255, 255, 255);

            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Font f_14_bold = new iTextSharp.text.Font(arial, 14, iTextSharp.text.Font.BOLD);

            iTextSharp.text.Font f_10_bold = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD,FontColour);
            iTextSharp.text.Font f_10_bold_2 = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_9_normal = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.NORMAL);

            String name = "cotizacion_" + num_cotizacion + "_cliente_" + id_cliente+"_pedido_"+num_cotizacion;
            FileStream os = new FileStream("pedido_" + name.ToString() + ".pdf", FileMode.Create);

            using (os)
            {
                PdfWriter pw = PdfWriter.GetInstance(doc, os);
                pw.PageEvent = new HeaderFooter() { fecha_c = fecha, cotizacion_c = num_cotizacion };


                doc.Open();
                ///////////////////////////////////////////////////////////////////////////
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };

                table1 = new PdfPTable(1);

                PdfPCell cel1 = new PdfPCell(new Phrase("DATOS DEL CLIENTE", f_10_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("NOMBRE: " + nombre, f_9_normal));
                PdfPCell cel3 = new PdfPCell(new Phrase("DIRECCIÓN: " + direccion + ", " + numero_ext + ", " + colonia, f_9_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("C. POSTAL: " + cp, f_9_normal));
                PdfPCell cel5 = new PdfPCell(new Phrase("LOCALIDAD: " + ciudad, f_9_normal));
                PdfPCell cel6 = new PdfPCell(new Phrase("ESTADO: " + estado, f_9_normal));
                PdfPCell cel7 = new PdfPCell(new Phrase("NUMERO DE PEDIDO: " + cotizacion_cliente, f_9_normal));

                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel5.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel6.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel7.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel7.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cel1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel5);
                table1.AddCell(cel6);
                table1.AddCell(cel7);



                //table1.SpacingAfter = 50;
                //table1.SpacingBefore = 50;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.WidthPercentage = 100;
                doc.Add(table2);
                doc.Add(new Paragraph(" "));
                ///////////////////////////////////////////////////////////////////////////
                int cantidadColumnaTabla = tablaProductos.ColumnCount;
                int cantidadFilaTabla = tablaProductos.RowCount;
                table1 = new PdfPTable(cantidadColumnaTabla);

                for (int j = 0; j < cantidadColumnaTabla; j++)
                {
                    cel1 = new PdfPCell(new Phrase(tablaProductos.Columns[j].HeaderText, f_10_bold));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    cel1.BackgroundColor = new iTextSharp.text.BaseColor(226, 107, 10);
                    table1.AddCell(cel1);
                }

                for (int i = 0; i < cantidadFilaTabla; i++)
                {

                    for (int j = 0; j < cantidadColumnaTabla; j++)
                    {
                        if (j == 4 || j == 6)
                        {
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

                }
                table1.WidthPercentage = 100;
                width = new float[] { 20f, 100f, 100f, 150f, 60f, 80f, 70f };
                table1.SetWidths(width);
                //table1.SpacingBefore = 20;
                doc.Add(table1);

                /////////////////////////////////////////////////////////////////
                PdfPTable table3 = new PdfPTable(1);
                PdfPCell celt1 = new PdfPCell(new Phrase("TOTAL DE PIEZAS: " + cantidad, f_10_bold_2));
                celt1.HorizontalAlignment = Element.ALIGN_CENTER;
                celt1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table3.AddCell(celt1);

                PdfPTable table4 = new PdfPTable(1);
                table4.AddCell(table3);
                table4.HorizontalAlignment = Element.ALIGN_CENTER;
                table4.WidthPercentage = 100;
                doc.Add(table4);

                ///////////////////////////////////////////////////////////////
                doc.Add(new Paragraph(" "));
                PdfPTable tableTotal = new PdfPTable(2);
            
                PdfPCell cellt1 = new PdfPCell(new Phrase("Subtotal: ", f_12_normal));
                PdfPCell cellt2 = new PdfPCell(new Phrase(string.Format("{0:C2}", subtotal), f_12_normal));
                PdfPCell cellt3 = new PdfPCell(new Phrase("Envio: ", f_12_normal));
                PdfPCell cellt4 = new PdfPCell(new Phrase(string.Format("{0:C2}", envio_float), f_12_normal));
                PdfPCell cellt5 = new PdfPCell(new Phrase("Total: ", f_12_normal));
                PdfPCell cellt6 = new PdfPCell(new Phrase(string.Format("{0:C2}", total), f_14_bold));

                cellt1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellt2.HorizontalAlignment = Element.ALIGN_LEFT;
                cellt3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellt4.HorizontalAlignment = Element.ALIGN_LEFT;
                cellt5.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellt6.HorizontalAlignment = Element.ALIGN_LEFT;

                cellt1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellt2.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cellt3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellt4.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cellt5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellt6.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;

                tableTotal.AddCell(cellt1);
                tableTotal.AddCell(cellt2);
                tableTotal.AddCell(cellt3);
                tableTotal.AddCell(cellt4);
                tableTotal.AddCell(cellt5);
                tableTotal.AddCell(cellt6);


                tableTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                tableTotal.WidthPercentage = 30;
                doc.Add(tableTotal);
                //////////////////////////////////////////////////////////////
                doc.Add(new Paragraph(" "));
                PdfPTable tableObservacion = new PdfPTable(1);

                PdfPCell cello1 = new PdfPCell(new Phrase("Observaciones: ", f_12_normal));
                PdfPCell cello2 = new PdfPCell(new Phrase(observacion, f_10_bold_2));

                cello1.HorizontalAlignment = Element.ALIGN_LEFT;
                cello2.HorizontalAlignment = Element.ALIGN_LEFT;

                cello1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cello2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableObservacion.AddCell(cello1);
                tableObservacion.AddCell(cello2);

                tableObservacion.HorizontalAlignment = Element.ALIGN_LEFT;
                tableObservacion.WidthPercentage = 45;
                doc.Add(tableObservacion);
                /////////////////////////////////////////////////////////////
                //Chunk linebreak = new Chunk(new LineSeparator(1f, 100f, colorBlue, Element.ALIGN_CENTER, -1));
                //doc.Add(linebreak);

                doc.Close();
                System.Diagnostics.Process.Start(@"pedido_" + name.ToString() + ".pdf");
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void generarDocumentoPDFProduccion(int m)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 30f, 20f, 50f, 40f);
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            var FontColour = new BaseColor(255, 255, 255);

            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_12_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_11_normal = new iTextSharp.text.Font(arial, 11, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_10_bold = new iTextSharp.text.Font(arial, 10,iTextSharp.text.Font.BOLD,FontColour);
            iTextSharp.text.Font f_9_normal = new iTextSharp.text.Font(arial, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_10_bold_2 = new iTextSharp.text.Font(arial, 10, iTextSharp.text.Font.BOLD);

            String name = "cotizacion_" + num_cotizacion + "_cliente_" + id_cliente + "_pedido_" + num_cotizacion;
            FileStream os;
            if (m == 1)
            {
                os = new FileStream("produccion_" + name + ".pdf", FileMode.Create);
            }
            else
            {
                os = new FileStream("makila_" + name + ".pdf", FileMode.Create);
            }
            using (os)
            {
                PdfWriter pw = PdfWriter.GetInstance(doc, os);
                pw.PageEvent = new HeaderFooter() { fecha_c = fecha, cotizacion_c = num_cotizacion };

                doc.Open();
                if (m == 1)
                {
                    Paragraph p = new Paragraph("PRODUCCIÓN", f_15_bold);
                    p.Alignment = Element.ALIGN_CENTER;
                    doc.Add(p);
                    doc.Add(new Paragraph(10, "\u00a0"));
                }
                else
                {
                    Paragraph p = new Paragraph("MAKILA", f_15_bold);
                    p.Alignment = Element.ALIGN_CENTER;
                    doc.Add(p);
                    doc.Add(new Paragraph(10, "\u00a0"));
                }

                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };

                //doc.Add(new Paragraph(100, "\u00a0"));
                //////////////////////////////////////////////////////////////
                table1 = new PdfPTable(1);

                PdfPCell cel1 = new PdfPCell(new Phrase("DATOS DEL CLIENTE", f_10_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("NOMBRE: " + nombre, f_9_normal));
                PdfPCell cel3 = new PdfPCell(new Phrase("NUMERO DE CLIENTE: " + id_cliente, f_9_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("NUMERO DE PEDIDO: " + cotizacion_cliente, f_9_normal));

                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;


                cel1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;


                cel1.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 66);

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.WidthPercentage = 100;
                doc.Add(table2);
                doc.Add(new Paragraph(" "));
                //////////////////////////////////////////////////////////////
                int cantidadColumnaTabla = tablaProductos.ColumnCount;
                int cantidadFilaTabla = tablaProductos.RowCount;
                table1 = new PdfPTable(cantidadColumnaTabla);

                for (int j = 0; j < cantidadColumnaTabla; j++)
                {
                    cel1 = new PdfPCell(new Phrase(tablaProductos.Columns[j].HeaderText, f_10_bold));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    cel1.BackgroundColor = new iTextSharp.text.BaseColor(226, 107, 10);
                    
                    table1.AddCell(cel1);
                }

                for (int i = 0; i < cantidadFilaTabla; i++)
                {

                    for (int j = 0; j < cantidadColumnaTabla; j++)
                    {
                        cel1 = new PdfPCell(new Phrase(tablaProductos.Rows[i].Cells[j].Value.ToString(), f_9_normal));
                        cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.FixedHeight = 20;
                        table1.AddCell(cel1);
                    }

                }

                table1.WidthPercentage = 100;

                if (m == 1)
                {
                    width = new float[] { 130f, 130f, 100f, 100f, 100f, 100f, 70f };
                }
                else
                {
                    width = new float[] { 130f, 130f, 100f, 100f, 100f, 70f };
                }
                table1.SetWidths(width);
                //table1.SpacingBefore = 20;
                doc.Add(table1);

                /////////////////////////////////////////////////////////////////
                PdfPTable table3 = new PdfPTable(1);
                PdfPCell celt1 = new PdfPCell(new Phrase("TOTAL DE PIEZAS: " + cantidad, f_10_bold_2));
                celt1.HorizontalAlignment = Element.ALIGN_CENTER;
                celt1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table3.AddCell(celt1);

                PdfPTable table4 = new PdfPTable(1);
                table4.AddCell(table3);
                table4.HorizontalAlignment = Element.ALIGN_CENTER;
                table4.WidthPercentage = 100;
                doc.Add(table4);

                ///////////////////////////////////////////////////////////////
                doc.Add(new Paragraph(" "));
                PdfPTable tableObservacion = new PdfPTable(1);

                PdfPCell cello1 = new PdfPCell(new Phrase("Observaciones: ", f_12_normal));
                PdfPCell cello2 = new PdfPCell(new Phrase(observacion, f_10_bold_2));

                cello1.HorizontalAlignment = Element.ALIGN_LEFT;
                cello2.HorizontalAlignment = Element.ALIGN_LEFT;

                cello1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cello2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableObservacion.AddCell(cello1);
                tableObservacion.AddCell(cello2);

                tableObservacion.HorizontalAlignment = Element.ALIGN_LEFT;
                tableObservacion.WidthPercentage = 45;
                doc.Add(tableObservacion);
                /////////////////////////////////////////////////////////////
                doc.Close();

                if (m == 1)
                {
                    System.Diagnostics.Process.Start(@"produccion_" + name + ".pdf");
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    System.Diagnostics.Process.Start(@"makila_" + name + ".pdf");
                    DialogResult pregunta;
                    pregunta = MetroFramework.MetroMessageBox.Show(this, "\nDocumento generado con exito", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
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
            tipo = datosCliente.GetString(14);
            id_cliente = datosCliente.GetUInt32(15).ToString();

            lblNombre.Text = nombre;
            lblCodigo.Text = cp;
            lblEstado.Text = estado;
            lblLocal.Text = ciudad;
            lblNP.Text = cotizacion_cliente;
            lblFecha.Text = fecha;
            lblDirec.Text = direccion + ", " + colonia + ", " + numero_ext;
            lblCelular.Text = num_cel;
            lblCotizacion.Text = num_cotizacion;
            lblTipo.Text = tipo;



           


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
        private void piezas() {
            int cantidad_piezas = 0;

            for (int i = 0; i < tablaProductos.RowCount; i++)
            {
                cantidad_piezas += int.Parse(tablaProductos.Rows[i].Cells["CANTIDAD"].Value.ToString());
            }

            cantidad = cantidad_piezas.ToString();
            lblPiezas.Text = cantidad;
        }
    }
}

class HeaderFooter : PdfPageEventHelper
{
    public String fecha_c { get; set; }
    public String cotizacion_c { get; set; }

    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
        document.Add(new Paragraph(65, "\u00a0"));

    }
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        base.OnEndPage(writer, document);
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

        String IMG1 = "Resources/logo.jpg";
        PdfPCell _cel2 = new PdfPCell(new Paragraph());
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(IMG1);
        img.ScaleAbsolute(125f, 50f);
        _cel2.AddElement(img);
        _cel2.HorizontalAlignment = Element.ALIGN_LEFT;
        _cel2.Border = 0;
        tbHeader.AddCell(_cel2);
        
        PdfPCell _cell1 = new PdfPCell(new Paragraph(encabezado, f_10_normal));
        _cell1.HorizontalAlignment = Element.ALIGN_CENTER;
        _cell1.Border = 0;
        tbHeader.AddCell(_cell1);

        PdfPCell _cell2 = new PdfPCell(new Paragraph("COTIZACION: "+cotizacion_c+"\n\n FECHA: "+fecha_c, f_10_normal));
        _cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
        _cell2.Border = 0;
        tbHeader.AddCell(_cell2);

        tbHeader.AddCell(new Paragraph());
        tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin)+20, writer.DirectContent);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        PdfPTable tbFooter = new PdfPTable(3);
        tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        tbFooter.DefaultCell.Border = 0;

        tbFooter.AddCell(new Paragraph());

        PdfPCell _cell = new PdfPCell(new Paragraph("www.basesymolduras.com"));
        _cell.HorizontalAlignment = Element.ALIGN_CENTER;
        _cell.Border = 0;
        tbFooter.AddCell(_cell);

        _cell = new PdfPCell(new Paragraph("Página "+writer.PageNumber));
        _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        _cell.Border = 0;
        tbFooter.AddCell(_cell);

        tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) -5, writer.DirectContent);
    }

}