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
    public partial class VerPago : MetroFramework.Forms.MetroForm
    {
        Pagos Padre;
        string nombreArchivo;
        public VerPago(Pagos padre, string nombreArchivo)
        {
            this.Padre = padre;
            this.nombreArchivo = nombreArchivo;
            InitializeComponent();
        }

        private void VerPago_Load(object sender, EventArgs e)
        {
            try
            {
                DownloadEXE_FTP(nombreArchivo);
                imagen.Image = Image.FromFile("C:\\Users\\" + Environment.UserName + "\\Pictures\\" + nombreArchivo);
            }
            catch {

            }
        }
        public void DownloadEXE_FTP(String nombreArchivoFTP)
        {
            string ftpfullpath = "ftp://avancedigitaltux.com/" + nombreArchivoFTP;

            using (WebClient request = new WebClient())
            {
                try
                {
                    request.Credentials = new NetworkCredential("ftp@avancedigitaltux.com", "d)Y3Gd47uCQ:0q");
                    byte[] fileData = request.DownloadData(ftpfullpath);
                    using (FileStream file = File.Create("C:\\Users\\"+Environment.UserName+"\\Pictures\\"+nombreArchivoFTP))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                }
                catch (Exception ex)
                {
                    //Log.Error("ERROR  descagando fichero", new Exception(ex.Message));
                    
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Padre.Enabled = true;
            Padre.FocusMe();
            this.Close();
        }
    }
}

