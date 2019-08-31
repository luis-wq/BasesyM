using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //HORAAAAA
        public static DateTime ObtenerFecha() {
            var myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();

            string[] dt = response.Headers.GetValues("Date");
            DateTime t = Convert.ToDateTime(dt[0]);
            return t;
        }
    }
}
