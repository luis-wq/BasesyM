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
        public static MySqlConnection conexion = new MySqlConnection();
        public static MySqlConnection ObtenerConexion()
        {
            conexion.ConnectionString = "Server=avancedigitaltux.com;Database=avancedi_basesymoldes; Uid=avancedi_cabo;Pwd=karteldesanta1;";
            conexion.Open();
            return conexion;
        }

        public static void CerrarConexion()
        {
            conexion.Close();
        }



        public MySqlDataReader consultaUsuario(string id) {

            //string query = "Select  From contribuyentes Where Cedula = ?pId AND Nacio = ?Nci";
            string query = "SELECT nombre_usuario,tipo_usuario FROM Usuario WHERE id_usuario =" + id;
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

        public MySqlDataReader consultaUsuarioDetalles(int id) {


            string query = "SELECT nombre_usuario,contrasena,tipo_usuario,nombre_completo,Apellido_P,Apellido_M FROM Usuario WHERE id_usuario =" + id;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);

            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();

            return myreader;
        }
        public MySqlDataReader consultaClienteDetalles(int id)
        {

            string query = "SELECT razon_social, RFC, correo_electronico, sitio_web, calle, colonia, num_ext, num_int, referencia, ciudad, estado, pais, codigo_postal, cel_1, cel_2, telefono_oficina, tipo_cliente, Observaciones FROM Cliente WHERE id_cliente =" + id;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);

            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();

            return myreader;
        }

        public Boolean consultaLogin(String usuario, String contrasena)
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
        public Boolean consultaAdmin(int id, String contrasena) {
            string query = "SELECT Count(*) id_usuario FROM Usuario WHERE id_usuario = " + id + " AND contrasena = '" + contrasena + "' ";
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

        public int consultaId(String usuario, string contrasena) {
            string query = "SELECT  id_usuario FROM Usuario WHERE nombre_usuario = '" + usuario + "' AND contrasena = '" + contrasena + "' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            int id = myreader.GetInt32(0);
            return id;
        }

        public MySqlDataReader ObtenerIdUsuario(String usuario, String contrasena)
        {

            string query = "SELECT id_usuario FROM Usuario WHERE nombre_usuario = '" + usuario + "' AND contrasena = '" + contrasena + "' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();

            return myreader;

        }

        public Boolean agregarUsuario(String tipo, String nombre, String ap, String am, String usuario, String pin) {
            try {

                string query = "INSERT INTO Usuario(nombre_usuario,contrasena,tipo_usuario,nombre_completo,Apellido_P,Apellido_M)VALUES('" + usuario + "','" + pin + "','" + tipo + "','" + nombre + "','" + ap + "','" + am + "')";
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

        public Boolean usuarioExiste(String usuario)
        {
            string query = "SELECT Count(*) id_usuario FROM Usuario WHERE nombre_usuario = '" + usuario + "'";
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
        public Boolean clienteExiste(String RFC)
        {
            string query = "SELECT Count(*) id_cliente FROM Cliente WHERE RFC = '" + RFC + "'";
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
        public Boolean modificarUsuario(String tipo, String nombre, String ap, String am, String usuario, String pin, int id)
        {
            try
            {

                string query = "UPDATE Usuario SET nombre_usuario = '" + usuario + "', contrasena = '" + pin + "', tipo_usuario = '" + tipo + "', nombre_completo = '" + nombre + "', Apellido_P = '" + ap + "', Apellido_M = '" + am + "' WHERE id_usuario = " + id;
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
        public Boolean agregarCliente(String razonsocial, String rfc, String correo, String sitioweb, String calle, String colonia, String numE, String numI, String referencia, String ciudad, String estado, String pais, String codigoPostal, String cel1, String cel2, String telefonoO, String tipo, String Observaciones)
        {
            try
            {
                string query = "INSERT INTO Cliente(razon_social, RFC, correo_electronico, sitio_web, calle, colonia, num_ext, num_int, referencia, ciudad, estado, pais, codigo_postal, cel_1, cel_2, telefono_oficina, tipo_cliente, Observaciones) " +
                    "VALUES ('" + razonsocial + "','" + rfc + "','" + correo + "','" + sitioweb + "','" + calle + "'," +
                    "'" + colonia + "','" + numE + "','" + numI + "','" + referencia + "','" + ciudad + "','" + estado + "','" + pais + "','" + codigoPostal + "','" + cel1 + "','" + cel2 + "','" + telefonoO + "','" + tipo + "','" + Observaciones + "')";
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

        public static Boolean AgregarDetalleCotizacion(int idProducto,int idColor,int idTipo,int idCotizacion,int cantidad)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Detalle_Cotizacion`(`id_producto`, `id_color`, `id_tipo`, `id_cotizacion`, `cantidad`) " +
                    "VALUES("+idProducto+","+idColor+","+idTipo+","+idCotizacion+","+cantidad+")";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean AgregarPago(int idCuentaCliente, string nombreArchivo, string fecha, double monto)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Pago`(`id_cuenta`, `URL_pago`, `fecha`, `monto_pagado`) VALUES ("+idCuentaCliente+",'"+nombreArchivo+"','"+fecha+"',"+monto+")";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean AgregarCuentaCliente(int idCotizacion,double montoTotal)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Cuenta_Cliente`(`id_cotizacion`, `monto_total`) VALUES ("+idCotizacion+","+montoTotal+")";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean modificarCliente(String razonsocial, String rfc, String correo, String sitioweb, String calle, String colonia, String numE, String numI, String referencia, String ciudad, String estado, String pais, String codigoPostal, String cel1, String cel2, String telefonoO, String tipo, String Observaciones, int id) {

            try
            {
                string query = "UPDATE Cliente SET razon_social = '" + razonsocial + "', RFC = '" + rfc + "', correo_electronico = '" + correo + "', sitio_web = '" + sitioweb + "'," +
                    " calle = '" + calle + "', colonia = '" + colonia + "', num_ext = '" + numE + "', num_int = '" + numI + "', referencia = '" + referencia + "', ciudad = '" + ciudad + "'" +
                    ", estado = '" + estado + "', pais = '" + pais + "', codigo_postal = '" + codigoPostal + "', cel_1 = '" + cel1 + "', cel_2 = '" + cel2 + "'," +
                    " telefono_oficina = '" + telefonoO + "', tipo_cliente = '" + tipo + "', Observaciones ='" + Observaciones + "' WHERE id_cliente = " + id;
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
            string query = "SELECT id_usuario AS ID, nombre_usuario AS USUARIO, tipo_usuario AS TIPO, nombre_completo AS NOMBRE, Apellido_P AS APELLIDO_P, Apellido_M AS APELLIDO_M FROM Usuario";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }
        public MySqlDataReader consultarProductoDetalle(int idProducto)
        {
            string query = "SELECT Productos.id_producto AS ID, Productos.modelo AS MODELO, Tamanos.tamano AS TAMAÑO," +
                "Material.nombre AS MATERIAL, Categoria.nombre AS CATEGORIA, Productos.cantidad AS CANTIDAD," +
                "Tipo.nombre AS TIPO, Productos.precio_publico AS PRECIO_PUBLICO, Productos.precio_frecuente AS " +
                "PRECIO_FRECUENTE, Productos.precio_mayorista AS PRECIO_MAYORISTA " +
                "FROM Productos " +
                "INNER JOIN Material ON Productos.id_material = Material.id_material " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                "WHERE id_producto="+idProducto;

            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            return myreader;
        }
        public static DataTable listarProductosFiltroMaterial(DataGridView gridview, int idCategoria, int idMaterial)
        {
            ObtenerConexion();
            string query = "SELECT modelo AS MODELO FROM `Productos` WHERE fk_categoria = " + idCategoria + " AND id_material=" +idMaterial + " GROUP BY modelo ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosProductos = new DataTable();
            seleccionar.Fill(datosProductos);
            gridview.DataSource = datosProductos;
            conexion.Close();
            return datosProductos;
        }
        public static DataTable listarProductosFiltroCategoria(DataGridView gridview, int idCategoria)
        {
            ObtenerConexion();
            string query = "SELECT modelo AS MODELO FROM `Productos` WHERE fk_categoria = " + idCategoria + " GROUP BY modelo ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosProductos = new DataTable();
            seleccionar.Fill(datosProductos);
            gridview.DataSource = datosProductos;
            conexion.Close();
            return datosProductos;
        }
        public static DataTable listarProductosFiltroTamano(DataGridView gridview, int idCategoria,int idMaterial, String modelo)
        {
            ObtenerConexion();
            string query = "SELECT Productos.id_producto AS ID , Tamanos.tamano AS TAMAÑO FROM " +
                "Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "WHERE fk_categoria = " + idCategoria + " AND modelo = '"+modelo+"' AND id_material="+idMaterial+" ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosProductos = new DataTable();
            seleccionar.Fill(datosProductos);
            gridview.DataSource = datosProductos;
            conexion.Close();
            return datosProductos;
        }
        public Boolean modificarProducto(int idProducto, int cantidad)
        {
            try
            {
                string query = "UPDATE Productos SET cantidad=" + cantidad + " WHERE id_producto=" + idProducto;
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

        public static Boolean modificarNoCotizacion(int idCliente, int nocotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Cliente` SET `nocotizacion`= " + nocotizacion + " WHERE id_cliente = " + idCliente;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable listarClientes(DataGridView gridview)
        {
            ObtenerConexion();
            string query = "SELECT id_cliente AS ID, razon_social AS RAZONSOCIAL, RFC, tipo_cliente AS TIPO, cel_1 AS CELULAR1, telefono_oficina AS TELEFONO FROM Cliente";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }


        public static DataTable listarClientesForCotizacion()
        {

            ObtenerConexion();
            string query = "SELECT id_cliente, tipo_cliente, nocotizacion, razon_social AS RAZONSOCIAL FROM Cliente";

            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarCategoriasForCotizacion()
        {

            string query = "SELECT id_categoria, nombre AS NOMBRE FROM `Categoria`";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarMaterialesForCategorias(int id)
        {
            ObtenerConexion();
            string query = "SELECT id_material, nombre AS NOMBRE, fk_categoria FROM `Material` WHERE fk_categoria = " + id;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarColores()
        {
            ObtenerConexion();
            string query = "SELECT nombre AS NOMBRE, id_color FROM `Color`";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarTamaniosForCategoria(int id)
        {
            ObtenerConexion();
            string query = "SELECT tamano AS NOMBRE, id_tamano, descripcion, id_categoria FROM `Tamanos` WHERE id_categoria = " + id;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarTiposForCategoria(int id)
        {
            ObtenerConexion();
            string query = "SELECT nombre AS NOMBRE, id_tipo, fk_categoria FROM `Tipo` WHERE fk_categoria = " + id;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarModelosForMaterial(int idmaterial, int idcategoria)
        {
            ObtenerConexion();
            string query = "SELECT id_producto, id_tamano, precio_publico, precio_frecuente, precio_mayorista, porcentaje, cantidad, peso, id_material, fk_categoria, id_tipo, modelo AS NOMBRE FROM `Productos` WHERE id_material = " + idmaterial + " AND fk_categoria = " + idcategoria;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarModelosLimitName(int idmaterial, int idcategoria)
        {
            ObtenerConexion();
            string query = "SELECT modelo AS NOMBRE FROM `Productos` WHERE id_material = " + idmaterial + " AND fk_categoria = " + idcategoria + " GROUP BY modelo ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarCotizacionesByUser(DataGridView gridview, string iduser)
        {
            ObtenerConexion();
            string query = "SELECT id_cotizacion AS ID, Cliente.razon_social AS Cliente, Fecha, Observaciones FROM Cotizacion INNER JOIN Cliente WHERE id_usuario = " + iduser;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarPagos(int idCuenta)
        {
            ObtenerConexion();
            string query = "SELECT `id_pago`,`id_cuenta`,`URL_pago`,`fecha`,`monto_pagado` FROM `Pago` WHERE id_cuenta = " + idCuenta;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarCuenta(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT `id_cuenta_cliente`,`id_cotizacion`,`monto_total` FROM `Cuenta_Cliente` WHERE id_cotizacion = "+idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarCotizacionesByUserAdmin(DataGridView gridview)
        {
            ObtenerConexion();
            string query = "SELECT id_cotizacion AS ID, Cliente.razon_social AS Cliente, Fecha, Observacion FROM Cotizacion INNER JOIN Cliente WHERE Cliente.id_cliente = Cotizacion.id_cliente";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }



        public Boolean borrarCliente(string id)
        {
            try
            {
                string query = "DELETE FROM Cliente WHERE id_cliente = " + id;
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

        public Boolean borrarUsuario(string id)
        {
            try
            {
                string query = "DELETE FROM Usuario WHERE id_usuario = " + id;
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



        public static DataTable consultaPrecio(string modelo, int id_tamano, int id_material, int id_categoria)
        {
            ObtenerConexion();
            string query = "SELECT `id_producto`,`precio_publico`,`precio_frecuente`,`precio_mayorista`,`peso`,`porcentaje` FROM `Productos` WHERE modelo = '" + modelo + "' AND id_tamano = " + id_tamano + " AND id_material = " + id_material + " AND fk_categoria = " + id_categoria;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaIdCotizaion(int idCliente, int idUsuario)
        {
            ObtenerConexion();
            string query = "SELECT MAX(id_cotizacion) AS id_cotizacion FROM `Cotizacion` WHERE id_cliente = "+idCliente+" AND id_usuario = "+idUsuario;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static Boolean InsertarCotizacion(int idCliente, int idUsuario, string observaciones, 
            double envio, int nocotizacion, int isProduccion, string fecha, double cargo, double tablaMDF, double tablaPINO, 
            double tablaMOLDURA, string prioridad,double pesoTotal)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Cotizacion`(`id_cliente`, `id_usuario`, `observacion`, `envio`, " +
                    "`NoCotizacionesCliente`, `IsProduccion`, `Fecha`, `cargoExtra`, `TablaMDF`, `TablaPino`, `TablaMoldura`, " +
                    "`Prioridad`,`pesoTotal`) VALUES (" + idCliente+","+idUsuario+",'"+observaciones+"',"+envio+","+nocotizacion+","+isProduccion+"" +
                    ",'"+fecha+"',"+cargo+","+tablaMDF+","+tablaPINO+","+tablaMOLDURA+",'"+prioridad+"',"+pesoTotal+")";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
