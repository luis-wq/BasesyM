using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class AgregarPago : MetroFramework.Forms.MetroForm
    {
        Pagos padre;
        int idCuentaCliente;
        double total, pagado, newPago;
        string imagen, path, extensionArcivo, nombreArchivo;
        byte[] buffer, imagenN = null;
        DateTime t;
        public AgregarPago(Pagos padre, int idAgregarPago, double total,double pagado,DateTime t)
        {
            InitializeComponent();
            this.idCuentaCliente = idAgregarPago;
            this.total = total;
            this.padre = padre;
            this.pagado = pagado;
            this.t = t;
        }

        private void AgregarPago_Load(object sender, EventArgs e)
        {
            
            txtTotal.Text = " /" + total.ToString("N4") + "";
        }

        private void TxtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            padre.Enabled = true;
            padre.FocusMe();
            this.Close();
        }

        private string obtenerFecha()
        {
            DateTime t = BD.ObtenerFecha();
            return t.Year + "-" + t.Month + "-" + t.Day + t.Hour + t.Minute + t.Second;
        }

        private void TxtMontoPagado_Leave(object sender, EventArgs e)
        {
            try
            {
                newPago = Convert.ToDouble(txtMontoPagado.Text);
                txtMontoPagado.Text = string.Format("{0:c2}", newPago);
                //CargarTextoPrecios();
            }
            catch
            {
                txtMontoPagado.Text = string.Format("{0:c2}", newPago);
                //CargarTextoPrecios();
            }
        }

        private string obtenerFechaSinHora()
        {
            DateTime t = BD.ObtenerFecha();
            return t.Year + "-" + t.Month + "-" + t.Day;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "JPEG|*.jpg";
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    if (System.IO.File.Exists(openFileDialog1.FileName))
                    {
                        Image Imagen = Image.FromFile(openFileDialog1.FileName);
                        pictureBox1.Image = Imagen;
                        buffer = ImageAArray(Imagen);
                    }
                }
            
                /*OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    extensionArcivo = Path.GetExtension(imagen);
                    imagen = openFileDialog1.FileName;
                    path = Path.GetDirectoryName(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(imagen);
                }*/
            }
            catch {

            }
        }

        
        public void Upload(string strServer, string strUser, string strPassword,
                           string strFileNameLocal, string strPathFTP)
        {
                string fecha = ""+t.Year + t.Month + t.Day + t.Hour + t.Minute + t.Second;
                nombreArchivo = fecha + Path.GetExtension(imagen);
                
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(string.Format("ftp://{0}/{1}", strServer,
                                                                        nombreArchivo));

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(strUser, strPassword);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                //RUTA DONDE ESTA UBICADO EL ARCHIVO
                FileStream stream = File.OpenRead(strPathFTP + strFileNameLocal);

                buffer = new byte[stream.Length];
                
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
        }


        public void UploadN(string strServer, string strUser, string strPassword,
                           string strFileNameLocal, string strPathFTP)
        {
            nombreArchivo =  Path.GetExtension(imagen);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(string.Format("ftp://{0}/{1}", strServer,
                                                                    nombreArchivo));

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(strUser, strPassword);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            //RUTA DONDE ESTA UBICADO EL ARCHIVO
            FileStream stream = File.OpenRead(strPathFTP + strFileNameLocal);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            /*Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Flush();
            reqStream.Close();*/
        }

        public byte[] ImageAArray(Image Imagen)
        {
            MemoryStream ms = new MemoryStream();
            Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        ///De byte [] a image:
        public Image ArrayAImage(byte[] ArrBite)
        {
            MemoryStream ms = new MemoryStream(ArrBite);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                if (txtTotal.Text.Equals(""))
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "Introduce el monto a agregar.", "Error al agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //var str = System.Text.Encoding.Default.GetString(b);
                    //Upload("ftp.avancedigitaltux.com/incoming", "ftp@avancedigitaltux.com", "d)Y3Gd47uCQ:0q", "/" + Path.GetFileName(imagen), path);
                    double NuevoTotalP = pagado + newPago;
                    if (NuevoTotalP > total)
                    {
                        MetroFramework.MetroMessageBox.
                        Show(this, "El monto que agregó supera el total de la cuenta, verifique que es correcto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        string fechasinhora = t.Year + "-" + t.Month + "-" + t.Day; 
                        if (BD.AgregarPago(idCuentaCliente, nombreArchivo, fechasinhora, newPago, buffer))
                        {
                            BD.ModificarMontoPagado(idCuentaCliente, NuevoTotalP);
                                MetroFramework.MetroMessageBox.
                                Show(this, "Pago Agregado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.None);
                                padre.Enabled = true;
                                padre.FocusMe();
                                padre.CargarDatosHilo();
                                this.Close();
                        }
                        else
                        {
                            this.Enabled = true;
                            MetroFramework.MetroMessageBox.
                            Show(this, "Error al agregar pago, verifica tu conexión a internet.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch {
                this.Enabled = true;
                MetroFramework.MetroMessageBox.
            Show(this, "Error de conexión o monto incorrecto.", "Error al agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        }
        
}
