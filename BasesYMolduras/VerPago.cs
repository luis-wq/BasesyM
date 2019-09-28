using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class VerPago : Form
    {
        public VerPago()
        {
            InitializeComponent();
        }

        private void VerPago_Load(object sender, EventArgs e)
        {

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
    }
}
