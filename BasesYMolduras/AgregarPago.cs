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
        double total;
        string imagen, path;
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

        private string obtenerFecha()
        {
            DateTime t = BD.ObtenerFecha();
            return t.Year + "-" + t.Month + "-" + t.Day;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    imagen = openFileDialog1.FileName;
                    path = Path.GetDirectoryName(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(imagen);
                }
            }
            catch {

            }
        }

        
        public static void Upload(string strServer, string strUser, string strPassword,
                           string strFileNameLocal, string strPathFTP)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(string.Format("ftp://{0}/{1}", strServer,
                                                                    Path.GetFileName(strFileNameLocal)));

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
            request.Timeout = 6000000;
            Stream reqStream = request.GetRequestStream();

            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Flush();
            reqStream.Close();
        }

        public static void DesconectarFTP(string dir, string user, string pass)
        {
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(string.Format("ftp://{0}", dir));
            NetworkCredential cred = new NetworkCredential(user, pass);
            ftp.Credentials = cred;
            ftp.KeepAlive = false;
            ftp.AuthenticationLevel = AuthenticationLevel.MutualAuthRequested;
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
            Stream responseStream = null;
            StreamReader readStream = null;

            try
            {
                responseStream = response.GetResponseStream();
                readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            }
            finally
            {
                if (readStream != null)
                    readStream.Close();
                if (response != null)
                    response.Close();
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DesconectarFTP("ftp.avancedigitaltux.com/incoming", "ftp@avancedigitaltux.com", "d)Y3Gd47uCQ:0q");
            Download("ftp.avancedigitaltux.com/incoming", "ftp@avancedigitaltux.com", "d)Y3Gd47uCQ:0q", "21-10-141pic.png", "C:\\Users\\Marcelo\\Pictures\\21-10-141pic.png");
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTotal.Text.Equals(""))
                {
                    MetroFramework.MetroMessageBox.
                    Show(this, "Introduce el monto a agregar.", "Error al agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String nombrePago = Path.GetFileName(imagen);
                    Upload("ftp.avancedigitaltux.com/incoming", "ftp@avancedigitaltux.com", "d)Y3Gd47uCQ:0q", "/" + Path.GetFileName(imagen), path);
                    MetroFramework.MetroMessageBox.
                    Show(this, "Pago Agregado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.None);


                }

            }
            catch {
                MetroFramework.MetroMessageBox.
            Show(this, "Error de conexión.", "Error al agregar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Download(string strServer, string strUser, string strPassword,
                             string strFileNameFTP, string strFileNameLocal)
        {
            FtpWebRequest ftpRequest;

            // Crea el objeto de conexión del servidor FTP
            ftpRequest = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}/{1}", strServer,
                                                                        strFileNameFTP));
            // Asigna las credenciales
            ftpRequest.Credentials = new NetworkCredential(strUser, strPassword);
            // Asigna las propiedades
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.UsePassive = false;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = true;
            // Descarga el archivo y lo graba
            using (FileStream stmFile = File.OpenWrite(strFileNameLocal + strFileNameFTP))
            { // Obtiene el stream sobre la comunicación FTP
                using (Stream responseStream = ((FtpWebResponse)ftpRequest.GetResponse()).GetResponseStream())
                {
                    int cnstIntLengthBuffer = 0;
                    byte[] arrBytBuffer = new byte[cnstIntLengthBuffer];
                    int intRead;

                    // Lee los datos del stream y los graba en el archivo
                    while ((intRead = responseStream.Read(arrBytBuffer, 0, cnstIntLengthBuffer)) != 0)
                        stmFile.Write(arrBytBuffer, 0, intRead);
                    // Cierra el stream FTP	
                    responseStream.Close();
                }
                // Cierra el archivo de salida
                stmFile.Flush();
                stmFile.Close();
            }
        }

        public void downloadFile(string servidor, string usuario, string password, string archivoOrigen, string carpetaDestino, int bufferdes)
        {
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(servidor + archivoOrigen);
                reqFTP.Credentials = new NetworkCredential(usuario, password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.UsePassive = true;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(@carpetaDestino, FileMode.Create);
                int Length = bufferdes;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
            }
            catch (WebException wEx)
            {
                throw wEx;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
