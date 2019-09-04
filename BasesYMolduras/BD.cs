using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BasesYMolduras
{
    class BD
    {
        public static  MySqlConnection conexion = new MySqlConnection();
        public static MySqlConnection ObtenerConexion()
        {
            conexion.ConnectionString = "Server=avancedigitaltux.com;Database=avancedi_basesymoldes; Uid=avancedi_wp551;Pwd=karteldesanta1;";
            conexion.Open();
            return conexion;
        }

        public static void CerrarConexion()
        {
            conexion.Close();
        }



        public MySqlDataReader consultaUsuario() {

            //string query = "Select  From contribuyentes Where Cedula = ?pId AND Nacio = ?Nci";
            string query = "SELECT nombre_usuario,tipo_usuario FROM Usuario";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            //mycomand.Parameters.AddWithValue("?pId", pId)

            //mycomand.Parameters.AddWithValue("?Nci", Nci)


            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();

            /*if (myreader.Read())
            {
                datos = new List<string>();
                datos.Add(myreader["Nombre"].ToString());
                datos.Add(myreader["Correo"].ToString());
                return datos;
            }*/

            return myreader;

        }

        public Boolean consultaLogin(String usuario,String contrasena)
        {
            
            string query = "SELECT Count(*) id_usuario FROM Usuario WHERE nombre_usuario = '" + usuario + "' AND contrasena = '" + contrasena + "' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            String count = myreader.GetInt32(0).ToString();

            Console.WriteLine(count);

            if (count == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean agregarUsuario(String tipo, String nombre, String ap , String am, String usuario, String pin) {
            try {
                String nombre_completo = "" + nombre + " " + ap + " " + am;
                string query = "INSERT INTO Usuario(nombre_usuario,contrasena,tipo_usuario,nombre_completo)VALUES('" + usuario + "','" + pin + "','" + tipo + "','" + nombre_completo + "')";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                return true;

            }
            catch
            {
                return false;
            }
        }


        //HORAAAAA
        public static DateTime ObtenerFecha() {
            var myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();

            string[] dt = response.Headers.GetValues("Date");
            DateTime t = Convert.ToDateTime(dt[0]);
            return t;
        }

        public static DataTable listarUsuarios(DataGridView gridview) {
            ObtenerConexion();
            string query = "SELECT id_usuario AS ID, nombre_usuario AS USUARIO, contrasena AS CONTRASEÑA, tipo_usuario AS TIPO, nombre_completo AS NOMBRE  FROM Usuario";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }

        public static void listarUsuariosFiltro(DataGridView gridView,string nombre) {
            ObtenerConexion();
            try
            {
                string query = "SELECT id_usuario AS ID, nombre_usuario AS USUARIO, contrasena AS CONTRASEÑA, tipo_usuario AS TIPO, nombre_completo AS NOMBRE  FROM Usuario WHERE nombre_usuario like '%'+@nom+'%'";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nom", nombre);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridView.DataSource = dt;
            }
            catch (Exception ex) {
                
            }
            conexion.Close();     

        }
    }
}
