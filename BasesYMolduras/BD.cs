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
            try
            {
                //McXKtvl[0bN
                //u165588053_bases_mold_res
                //u165588053_basesYmold_res
                conexion.ConnectionString = "Server=sql358.main-hosting.eu;Database=u165588053_bases_molduras; Uid=u165588053_basesYmolduras;Pwd=fN^chD1K|l;;Allow User Variables=True";
           // conexion.ConnectionString = "Server=sql358.main-hosting.eu;Database=u165588053_bases_mold_res; Uid=u165588053_basesYmold_res;Pwd=McXKtvl[0bN;;Allow User Variables=True";
                conexion.Open();
                return conexion;
                //cambios
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return conexion;
            }


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
        public Boolean consultaProduccion(int idCotizacion)
        {
            string query = "SELECT Count(*) id_cotizacion FROM Cotizacion WHERE id_cotizacion = " + idCotizacion + " AND IsProduccion = 1";
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
        public String consultaTipo(String usuario, string contrasena)
        {
            string query = "SELECT  tipo_usuario FROM Usuario WHERE nombre_usuario = '" + usuario + "' AND contrasena = '" + contrasena + "' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            string tipo = myreader.GetString(0);
            return tipo;
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

        public static Boolean agregarControl(int idCotizacion,string fecha)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Control`(`id_cotizacion`, `nombre`, `estado`, `makilaF`, `lijadoF`, `selladoF`, `pulidoF`, `pinturaF`, `empaquetadoF`, `envioF`) VALUES (" + idCotizacion + ",'" + fecha + "','NINGUNO','','','','','','','') ON DUPLICATE KEY UPDATE `id_cotizacion` = " + idCotizacion + "";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean agregarCaja(int idCotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Caja`(`numero_cajas`, `id_cotizacion`, `peso_total`, `titulo`) VALUES (1,"+idCotizacion+",'0.00','Sin titulo')";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean aprobarProduccion(int idCotizacion,int isUltima)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Cotizacion` SET `IsProduccion` = 1,IsUltimaProduccion = "+isUltima+" WHERE `Cotizacion`.`id_cotizacion` = "+idCotizacion;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            { 
                return false;
            }
        } 

        public static DataTable obtenerIsUltimaProduccion()
        {
            ObtenerConexion();
            string query = "SELECT IsUltimaProduccion FROM Cotizacion WHERE IsProduccion = 1 ORDER BY IsUltimaProduccion DESC LIMIT 1";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable obtenerIdEmergente(int IsUltimaProduccion)
        {
            ObtenerConexion();
            string query = "SELECT id_cotizacion, Cliente.razon_social FROM Cotizacion INNER JOIN Cliente WHERE IsUltimaProduccion = "+IsUltimaProduccion+" AND Cliente.id_cliente = Cotizacion.id_cliente";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
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
        public Boolean agregarCliente(String razonsocial, String rfc, String correo, String sitioweb, String calle, String colonia, String numE, String numI, String referencia, String ciudad, String estado, String pais, String codigoPostal, String cel1, String cel2, String telefonoO, String tipo, String Observaciones,String id_usuario)
        {
            try
            {
                string query = "INSERT INTO Cliente(razon_social, RFC, correo_electronico, sitio_web, calle, colonia, num_ext, num_int, referencia, ciudad, estado, pais, codigo_postal, cel_1, cel_2, telefono_oficina, tipo_cliente, Observaciones,id_usuario) " +
                    "VALUES ('" + razonsocial + "','" + rfc + "','" + correo + "','" + sitioweb + "','" + calle + "'," +
                    "'" + colonia + "','" + numE + "','" + numI + "','" + referencia + "','" + ciudad + "','" + estado + "','" + pais + "','" + codigoPostal + "','" + cel1 + "','" + cel2 + "','" + telefonoO + "','" + tipo + "','" + Observaciones + "','" + id_usuario + "')";
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

        public static Boolean AgregarDetalleCotizacion(int idProducto,int idColor,int idTipo,int idCotizacion,int cantidad,int cantidadA,int cantidadP, Double precioN)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Detalle_Cotizacion`(`id_producto`, `id_color`, `id_tipo`, `id_cotizacion`, `cantidad`, `precio`, `cantidadInventario`, `cantidadProduccion`) " +
                    "VALUES("+idProducto+","+idColor+","+idTipo+","+idCotizacion+","+cantidad+ "," + precioN + "," + cantidadA+","+cantidadP+")";
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
        public static Boolean eliminarCantidadProducto(int idProducto,int cantidad)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE Productos SET cantidad = cantidad - "+cantidad+" WHERE id_producto ="+idProducto;
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
        public static Boolean AgregarPago(int idCuentaCliente, string nombreArchivo, string fecha, double monto, byte[] imagen, int tipo, string concepto)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Pago`(`id_cuenta`, `URL_pago`, `fecha`, `monto_pagado`,`Imagen`, `forma_pago`, `concepto`) VALUES (" + idCuentaCliente+",'"+nombreArchivo+"','"+fecha+"',"+monto+ ",@imagen,"+tipo+ ",'"+concepto+"')";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                mycomand.Parameters.Add(new MySqlParameter("@imagen",imagen));
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                CerrarConexion();
                return true;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(""+ e);
                return false;
            }
        }

        public static Boolean AgregarCuentaCliente(int idCotizacion,double montoTotal)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Cuenta_Cliente`(`id_cotizacion`, `monto_total`, `total_pagado`) VALUES (" + idCotizacion+","+montoTotal+",0.00)";
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
        public static Boolean ingresarTablasCotizacion(int idCotizacion, double tablaMDF, double tablaMOLDURA, double tablaPINO)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE Cotizacion SET TablaMDF="+tablaMDF+",TablaPino="+tablaPINO+", TablaMoldura="+tablaMOLDURA+" WHERE id_cotizacion="+idCotizacion;
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
        public static Boolean modificarDetallesCotizacion(int idCotizacion, String observacion, float envio, Double cargo_extra, String prioridad, float peso_total, float iva, string tipo_envio)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE Cotizacion SET observacion= '" + observacion + "',envio=" + envio + ", cargoExtra=" + cargo_extra + ", " +
                    " Prioridad='"+prioridad+"',pesoTotal="+peso_total+",iva="+iva+", tipoEnvio = '"+tipo_envio+"' WHERE id_cotizacion=" + idCotizacion;
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

        public static Boolean modificarCuentaCotizacion(int idCotizacion, float monto_total)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE Cuenta_Cliente SET monto_total="+monto_total+" WHERE id_cotizacion=" + idCotizacion;
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
        public static Boolean ModificarMontoPagado(int idCuenta, double pagado)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Cuenta_Cliente` SET `total_pagado` = "+pagado+" WHERE `Cuenta_Cliente`.`id_cuenta_cliente` = "+idCuenta;
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


        public static Boolean insertarCaja(int numeroCaja,int idCotizacion,string peso,string titulo)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Caja`(`numero_cajas`, `id_cotizacion`, `peso_total`, `titulo`) VALUES (" + numeroCaja+","+idCotizacion+",'"+peso+"','"+titulo+"')";
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

        public static Boolean insertarDetalleCaja(int idCotizacion, int idCaja)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Detalle_Caja` (`peso`, `id_detalle_cotizacion`, `id_caja`) VALUES ('0.00', "+idCotizacion+", "+idCaja+");";
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

        public static Boolean FechaControl(string control, string fecha,int cotizacion,string estado)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Control` SET `"+control+"` = '"+fecha+ "',`estado`='"+estado+"' WHERE `Control`.`id_cotizacion` = " + cotizacion;
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
            try
            {
                var myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
                var response = myHttpWebRequest.GetResponse();
                string[] dt = response.Headers.GetValues("Date");
                DateTime t = Convert.ToDateTime(dt[0]);
                return t;
            }
            catch {
                DateTime t = new DateTime();
                return t;
            }

        }

        public static DataTable listarUsuarios(DataGridView gridview) {
            ObtenerConexion();
            string query = "SELECT id_usuario AS ID, nombre_usuario AS USUARIO, tipo_usuario AS TIPO, nombre_completo AS NOMBRE, Apellido_P AS 'APELLIDO PAT', Apellido_M AS 'APELLIDO MAT' FROM Usuario";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable ObtenerUltimaCaja(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT MAX(`id_caja`) AS id_caja FROM `Caja` WHERE id_cotizacion = " + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarUsuariosPrueba()
        {
            string query = "SELECT id_usuario AS ID, nombre_usuario AS USUARIO, tipo_usuario AS TIPO, nombre_completo AS NOMBRE, Apellido_P AS 'APELLIDO PAT', Apellido_M AS 'APELLIDO MAT' FROM Usuario";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaCajas(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT `id_caja`, `numero_cajas` AS '#', `id_cotizacion`, `peso_total`, `titulo` AS TITULO FROM `Caja` WHERE id_cotizacion = " + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaDetalleCajas(int idCaja)
        {
            ObtenerConexion();
            string query = "SELECT `id_detalle_caja`,`peso`,`id_detalle_cotizacion`,`id_caja` FROM `Detalle_Caja` WHERE id_caja = "+idCaja;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarProducciones(DataGridView gridview,String tipo,int id_usuario)
        {
            /*
             *  string query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Cotizacion.Fecha AS FECHA, Cotizacion.NoCotizacionesCliente AS COTIZACION,Cuenta_Cliente.monto_total AS TOTAL," +
                "Cuenta_Cliente.total_pagado AS PAGADO, Cuenta_Cliente.monto_total-Cuenta_Cliente.total_pagado AS RESTA " +
                "FROM Cotizacion " +
                "INNER JOIN Cliente ON Cliente.id_cliente = Cotizacion.id_cliente " +
                "INNER JOIN Cuenta_Cliente ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                "WHERE Cotizacion.IsProduccion=0 AND (ROUND(Cuenta_Cliente.monto_total,2) != ROUND(Cuenta_Cliente.total_pagado,2) OR ROUND(Cuenta_Cliente.monto_total,2) = ROUND(Cuenta_Cliente.total_pagado,2))";
             */
            ObtenerConexion();
            string query = "";
            if (tipo.Equals("ADMINISTRADOR"))
            {
                query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Usuario.nombre_usuario AS VENDEDOR,Cotizacion.NoCotizacionesCliente AS 'COTIZACION' ,Cotizacion.Fecha AS FECHA, " +
                         "Prioridad AS PRIORIDAD,Cuenta_Cliente.monto_total AS TOTAL,Cuenta_Cliente.total_pagado AS PAGADO, ROUND(Cuenta_Cliente.monto_total-Cuenta_Cliente.total_pagado) AS RESTA " +
                         "FROM Cotizacion " +
                         "INNER JOIN Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                         "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +
                         "INNER JOIN Cuenta_Cliente ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                         "WHERE isProduccion = 1";
            }
            else if (tipo.Equals("PRODUCCION"))
            {
                query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Usuario.nombre_usuario AS VENDEDOR,Cotizacion.Fecha AS FECHA, " +
                         "Prioridad AS PRIORIDAD " +
                         "FROM Cotizacion " +
                         "INNER JOIN Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                         "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +
                         "WHERE isProduccion = 1";
            } else if (tipo.Equals("VENDEDOR"))
            {
                query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Usuario.nombre_usuario AS VENDEDOR,Cotizacion.NoCotizacionesCliente AS 'COTIZACION' ,Cotizacion.Fecha AS FECHA, " +
                         "Prioridad AS PRIORIDAD,Cuenta_Cliente.monto_total AS TOTAL,Cuenta_Cliente.total_pagado AS PAGADO, ROUND(Cuenta_Cliente.monto_total-Cuenta_Cliente.total_pagado) AS RESTA " +
                         "FROM Cotizacion " +
                         "INNER JOIN Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                         "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +
                         "INNER JOIN Cuenta_Cliente ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                         "WHERE isProduccion = 1 AND Usuario.id_usuario=" + id_usuario;
            }

            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarProduccionesCotizacionPorPrioridad(String tipo, int id_usuario)
        {

            ObtenerConexion();
            string query = "";
            if (tipo.Equals("VENDEDOR"))
            {
                query = "SELECT Cotizacion.id_cotizacion, Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, " +
                         "Cotizacion.Prioridad, Control.estado " +
                         "FROM Cotizacion " +
                         "INNER JOIN Cliente " +
                         "INNER JOIN Control ON Control.id_cotizacion = Cotizacion.id_cotizacion " +
                         "INNER JOIN Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                         "WHERE Cotizacion.IsProduccion = 1 " +
                         "AND Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = Cotizacion.id_cotizacion AND " +
                         "Control.envioF = '' AND Usuario.id_usuario= '" + id_usuario + "' ORDER BY Cotizacion.id_cotizacion";
            }
            else
            {
                query = "SELECT Cotizacion.id_cotizacion, Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, Cotizacion.Prioridad, Control.estado FROM Cotizacion INNER JOIN Cliente, Control WHERE Cotizacion.IsProduccion = 1 AND Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = Cotizacion.id_cotizacion AND Control.envioF = '' ORDER BY Cotizacion.id_cotizacion ";

            }
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public MySqlDataReader consultarProductoDetalle(int idProducto)
        {
            string query = "SELECT Productos.id_producto AS ID, Productos.modelo AS MODELO, Tamanos.tamano AS TAMAÑO," +
                "Material.nombre AS MATERIAL, Categoria.nombre AS CATEGORIA, Productos.cantidad AS CANTIDAD," +
                "Tipo.nombre AS TIPO, Productos.precio_publico AS PRECIO_PUBLICO, Productos.precio_frecuente AS " +
                "PRECIO_FRECUENTE, Productos.precio_mayorista AS PRECIO_MAYORISTA, Tamanos.descripcion AS DESCRIPCION, Productos.peso AS PESO " +
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
        public DataTable consultarProductoDetalleReporte()
        {
            string query = "SELECT Productos.id_producto AS ID, Productos.modelo AS MODELO, Tamanos.tamano AS TAMAÑO, Material.nombre AS MATERIAL, Categoria.nombre AS CATEGORIA, Productos.cantidad AS CANTIDAD, Tipo.nombre AS TIPO, Productos.precio_publico AS PRECIO_PUBLICO, Productos.precio_frecuente AS PRECIO_FRECUENTE, Productos.precio_mayorista AS PRECIO_MAYORISTA, Tamanos.descripcion AS DESCRIPCION, Productos.peso AS PESO FROM Productos INNER JOIN Material ON Productos.id_material = Material.id_material INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo WHERE cantidad > 0 ORDER BY cantidad ASC";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            DataTable datosProductos = new DataTable();
            datosProductos.Load(mycomand.ExecuteReader());
            conexion.Close();
            return datosProductos;
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

        public static DataTable listarProductosFiltroMaterialCombo(int idCategoria, int idMaterial)
        {
            ObtenerConexion();
            string query = "SELECT modelo AS MODELO FROM `Productos` WHERE fk_categoria = " + idCategoria + " AND id_material=" + idMaterial + " GROUP BY modelo ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;

        }
        public static DataTable listarTipoCombo(int id_categoria)
        {
            ObtenerConexion();
            string query = "SELECT `id_tipo`, `nombre` AS NOMBRE FROM `Tipo` WHERE `fk_categoria` = "+ id_categoria;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;

        }

        public static DataTable listarTamanoCombo(int id_categoria)
        {
            ObtenerConexion();
            string query = "SELECT `id_tamano`, `tamano` AS TAMANO, `descripcion` FROM `Tamanos` WHERE `id_categoria` = " + id_categoria;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;

        }
        public String getDescripcionTamano(int id_tamano)
        {
            ObtenerConexion();
            string query = "SELECT `descripcion` FROM `Tamanos` WHERE `id_tamano` = "+ id_tamano;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            string tipo = myreader.GetString(0);
            conexion.Close();
            return tipo;
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
            string query = "SELECT Tamanos.id_tamano AS ID, Tamanos.tamano AS TAMAÑO FROM " +
                "Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "WHERE fk_categoria = " + idCategoria + " AND modelo = '"+modelo+"' AND id_material="+idMaterial+" " +
                "GROUP BY tamano, descripcion";
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
        public Boolean modificarPrecio(float precioP, float precioF , float precioM ,float peso,int idProducto)
        {
            try
            {
                Console.WriteLine("id:" + idProducto);
                string query = "UPDATE Productos SET precio_publico="+precioP+",precio_frecuente="+precioF+",precio_mayorista="+precioM+",peso= "+peso+" " +
                    "WHERE id_producto = "+idProducto;
                Console.WriteLine(query);
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

        public static Boolean modificarCaja(string pesototal,string titulo,int idCaja)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Caja` SET `peso_total`='"+pesototal+"',`titulo`='"+titulo+"' WHERE id_caja = "+idCaja;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean modificarInCaja(int inCaja, int idDetalleCotizacion,int caja)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Detalle_Caja` SET `inCaja`= "+inCaja+" WHERE id_detalle_cotizacion = "+idDetalleCotizacion+" AND id_caja = "+caja;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean insertarInCaja(int inCaja, int idDetalleCotizacion, int caja)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Detalle_Caja` (`peso`, `id_detalle_cotizacion`, `id_caja`, `inCaja`) VALUES ('0.00', "+idDetalleCotizacion+", "+caja+", "+inCaja+")";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean modificarIsProduccion(int idCotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE `Cotizacion` SET `IsProduccion` = '2' WHERE `Cotizacion`.`id_cotizacion` = "+idCotizacion;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
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
        public static DataTable listarClientes(DataGridView gridview,int idUsuario)
        {
            ObtenerConexion();
            string query = "SELECT id_cliente AS ID, razon_social AS 'RAZON SOCIAL', RFC, tipo_cliente AS TIPO, cel_1 AS 'CELULAR 1', ciudad AS CIUDAD FROM Cliente WHERE id_usuario = "+idUsuario;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarClientesAdmin(DataGridView gridview)
        {
            ObtenerConexion();
            string query = "SELECT id_cliente AS ID, razon_social AS 'RAZON SOCIAL', RFC, tipo_cliente AS TIPO, cel_1 AS 'CELULAR 1', ciudad AS CIUDAD FROM Cliente";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            gridview.DataSource = datosUsuarios;
            conexion.Close();
            return datosUsuarios;
        }


        public static DataTable consultarExistenciaEnCaja(int idDetalleCotizacion, int idCaja)
        {
            ObtenerConexion();
            string query = "SELECT `id_detalle_caja` FROM Detalle_Caja WHERE id_detalle_cotizacion = "+idDetalleCotizacion+" AND id_caja = "+idCaja;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }


        public static DataTable listarClientesForCotizacion(int idUsuario)
        {

            ObtenerConexion();
            string query = "SELECT id_cliente, tipo_cliente, nocotizacion, razon_social AS RAZONSOCIAL FROM Cliente WHERE id_usuario = " + idUsuario;

            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarClientesForCotizacionAdmin()
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
            try
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
            catch (Exception ex)
            {
                throw ex; //TODO: Please log it or remove the catch
            }
            finally
            {
                conexion.Close();
            }

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
        public static DataTable listarMaterialesForCategoriasCotizacion(DataGridView gridview, int id)
        {
            ObtenerConexion();
            string query = "SELECT id_material AS ID, nombre AS MATERIAL FROM `Material` WHERE fk_categoria = " + id+ " ORDER BY nombre ASC";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosMateriales = new DataTable();
            seleccionar.Fill(datosMateriales);
            gridview.DataSource = datosMateriales;
            conexion.Close();
            return datosMateriales;

        }
        public static DataTable listarMaterialesForTipo(int idCategoria,int idMaterial,int idTamano, String modelo)
        {
            ObtenerConexion();
            string query = "SELECT Productos.id_producto AS ID, Tipo.nombre AS TIPO, Tamanos.tamano AS TAMAÑO " +
                "FROM Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                "WHERE Productos.fk_categoria="+idCategoria+" AND Productos.id_material="+idMaterial+" AND Tamanos.id_tamano="+idTamano+" AND Productos.modelo='"+modelo+"' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable listarMaterialesForCotizacion(DataGridView gridview, int idCategoria, int idMaterial, int idTamano, String modelo)
        {
            ObtenerConexion();
            string query = "SELECT Tipo.id_tipo AS ID, Tipo.nombre AS TIPO " +
                "FROM Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                "WHERE Productos.fk_categoria=" + idCategoria + " AND Productos.id_material=" + idMaterial + " AND Tamanos.id_tamano=" + idTamano + " AND Productos.modelo='" + modelo + "' ";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosTipos = new DataTable();
            seleccionar.Fill(datosTipos);
            gridview.DataSource = datosTipos;
            conexion.Close();
            return datosTipos;
        }
        public static DataTable listarTiposForCotizacion(DataGridView gridview, int idCategoria)
        {
            ObtenerConexion();
            string query = "SELECT Tipo.id_tipo AS ID, Tipo.nombre AS TIPO " +
                "FROM Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                "WHERE Productos.fk_categoria=" + idCategoria+ " GROUP BY Tipo.nombre";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosTipos = new DataTable();
            seleccionar.Fill(datosTipos);
            gridview.DataSource = datosTipos;
            conexion.Close();
            return datosTipos;
        }
        public static DataTable listarProductoForCotizacion(DataGridView gridview, int idCategoria,int idMaterial, String modelo, int idTamano, int idTipo,String tipo_cliente)
        {
            string tipo_precio = "";

            if (tipo_cliente.Equals("PUBLICO"))
            {
                tipo_precio = "publico";
            }
            else if (tipo_cliente.Equals("FRECUENTE"))
            {
                tipo_precio = "frecuente";
            }
            else if (tipo_cliente.Equals("MAYORISTA"))
            {
                tipo_precio = "mayorista";
            }
            ObtenerConexion();
            string query = "SELECT Productos.id_producto AS ID, Categoria.nombre AS Categoria, Material.nombre AS MATERIAL, Productos.modelo AS MODELO, Tamanos.tamano AS TAMAÑO, Tamanos.descripcion AS DESCRIPCION, Tipo.nombre AS TIPO, Productos.precio_" + tipo_precio + " AS PRECIO, " +
                "Productos.peso AS PESO, Productos.porcentaje AS PORCENTAJE, Productos.cantidad AS CANTA " +
                "FROM Productos " +
                "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                "INNER JOIN Material ON Productos.id_material = Material.id_material " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo "+
                "WHERE Productos.fk_categoria=" + idCategoria + " AND Productos.id_material=" + idMaterial + " AND Tamanos.id_tamano=" + idTamano + " AND Productos.modelo='" + modelo + "' AND Productos.id_tipo="+idTipo;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosTipos = new DataTable();
            seleccionar.Fill(datosTipos);
            gridview.DataSource = datosTipos;
            conexion.Close();
            return datosTipos;
        }
        public static DataTable listarColoresForCotizacion(DataGridView gridview)
        {
            ObtenerConexion();
            string query = "SELECT id_color AS ID, nombre AS COLOR FROM `Color` ORDER BY `nombre` ASC";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosColor = new DataTable();
            seleccionar.Fill(datosColor);
            gridview.DataSource = datosColor;
            conexion.Close();
            return datosColor;
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

        public static DataTable DatosCotizacion(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, Cotizacion.Prioridad, Control.estado FROM Cotizacion INNER JOIN Cliente, Control WHERE Cotizacion.id_cotizacion = "+idCotizacion+" AND Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = Cotizacion.id_cotizacion";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable ConsultaCotizacionById(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT * FROM `Cotizacion` WHERE id_cotizacion = "+ idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable DatosControlForCotizacion(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT Cotizacion.id_cotizacion, Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, Cotizacion.Prioridad, Control.nombre, Control.estado, Control.makilaF, Control.lijadoF, Control.selladoF, Control.pulidoF, Control.pinturaF, Control.empaquetadoF, Control.envioF FROM Cotizacion INNER JOIN Cliente, Control WHERE Cotizacion.IsProduccion = 1 AND Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = "+idCotizacion+" AND Cotizacion.id_cotizacion = "+idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable DatosControlForCotizacionesRealizadas(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT Cotizacion.id_cotizacion, Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, Cotizacion.Prioridad, Control.nombre, Control.estado, Control.makilaF, Control.lijadoF, Control.selladoF, Control.pulidoF, Control.pinturaF, Control.empaquetadoF, Control.envioF FROM Cotizacion INNER JOIN Cliente, Control WHERE Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = " + idCotizacion + " AND Cotizacion.id_cotizacion = " + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable DatosCotizacionForPrioridad()
        {
            try
            {
                ObtenerConexion();
                string query = "SELECT Cotizacion.id_cotizacion, Cliente.razon_social, Cotizacion.Fecha, Cotizacion.NoCotizacionesCliente, Cotizacion.Prioridad, Control.estado FROM Cotizacion INNER JOIN Cliente, Control WHERE Cotizacion.IsProduccion = 1 AND Cliente.id_cliente = Cotizacion.id_cliente AND Control.id_cotizacion = Cotizacion.id_cotizacion AND Control.envioF = '' ORDER BY Cotizacion.id_cotizacion ";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataAdapter seleccionar = new MySqlDataAdapter();
                seleccionar.SelectCommand = mycomand;
                DataTable datosUsuarios = new DataTable();
                seleccionar.Fill(datosUsuarios);
                conexion.Close();
                return datosUsuarios;
            }
            finally {

            }
        }

        public static DataTable listarCotizacionesByUser(DataGridView gridview, string iduser)
        {

            ObtenerConexion();
            string query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Cotizacion.Fecha AS FECHA, Cotizacion.NoCotizacionesCliente AS 'COTIZACION',Cuenta_Cliente.monto_total AS TOTAL," +
                "Cuenta_Cliente.total_pagado AS PAGADO, ROUND(Cuenta_Cliente.monto_total-Cuenta_Cliente.total_pagado) AS RESTA " +
                "FROM Cotizacion " +
                "INNER JOIN Cliente ON Cliente.id_cliente = Cotizacion.id_cliente " +
                "INNER JOIN Cuenta_Cliente ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                "WHERE Cotizacion.IsProduccion=0 AND (ROUND(Cuenta_Cliente.monto_total,2) != ROUND(Cuenta_Cliente.total_pagado,2) OR ROUND(Cuenta_Cliente.monto_total,2) = ROUND(Cuenta_Cliente.total_pagado,2)) AND Cotizacion.id_usuario = " + iduser + "";
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
            string query = "SELECT `id_pago`,`id_cuenta`,`URL_pago`,`fecha`,`monto_pagado`,`Imagen` FROM `Pago` WHERE id_cuenta = " + idCuenta;
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
            try
            {
                //NUMERO DE PEDIDO, TOTAL, PAGADO Y RESTA
                ObtenerConexion();
                string query = "SELECT Cotizacion.id_cotizacion AS ID, Cliente.razon_social AS CLIENTE, Cotizacion.Fecha AS FECHA, Cotizacion.NoCotizacionesCliente AS 'COTIZACION',Cuenta_Cliente.monto_total AS TOTAL," +
                    "Cuenta_Cliente.total_pagado AS PAGADO, ROUND(Cuenta_Cliente.monto_total-Cuenta_Cliente.total_pagado) AS RESTA " +
                    "FROM Cotizacion " +
                    "INNER JOIN Cliente ON Cliente.id_cliente = Cotizacion.id_cliente " +
                    "INNER JOIN Cuenta_Cliente ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                    "WHERE Cotizacion.IsProduccion=0 AND (ROUND(Cuenta_Cliente.monto_total,2) != ROUND(Cuenta_Cliente.total_pagado,2) OR ROUND(Cuenta_Cliente.monto_total,2) = ROUND(Cuenta_Cliente.total_pagado,2))";
                //WHERE Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion AND Cuenta_Cliente.monto_total != Cuenta_Cliente.total_pagado AND Cotizacion.isProduccion != 2
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataAdapter seleccionar = new MySqlDataAdapter();
                seleccionar.SelectCommand = mycomand;
                DataTable datosUsuarios = new DataTable();
                seleccionar.Fill(datosUsuarios);
                gridview.DataSource = datosUsuarios;
                conexion.Close();
                return datosUsuarios;
            }
            catch (Exception ex)
            {
                throw ex; //TODO: Please log it or remove the catch
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable listarCotizacionesRealizadas()
        {
            ObtenerConexion();
            string query = "SELECT `id_cotizacion` AS ID, Cliente.razon_social AS CLIENTE, Usuario.nombre_usuario AS USUARIO, `observacion` AS OBSERVACIONES, `envio` AS ENVIO, `NoCotizacionesCliente` AS NOCLIENTE, `Fecha` AS FECHA, `cargoExtra` AS CARGOEXTRA, TRUNCATE(`TablaMDF`,4) AS MDF, TRUNCATE(`TablaPino`,4) AS PINO, TRUNCATE(`TablaMoldura`,4) AS MOLDURAS, `Prioridad` AS PRIORIDAD, `pesoTotal` AS PESO FROM `Cotizacion` INNER JOIN Cliente, Usuario WHERE Cliente.id_cliente = Cotizacion.id_cliente AND Usuario.id_usuario = Cotizacion.id_usuario AND Cotizacion.IsProduccion = 2";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable listarCotizacionesRealizadasUsuario(int id_usuario)
        {
            ObtenerConexion();
            string query = "SELECT `id_cotizacion` AS ID, Cliente.razon_social AS CLIENTE, Usuario.nombre_usuario AS USUARIO, `observacion` AS OBSERVACIONES, " +
                "`envio` AS ENVIO, `NoCotizacionesCliente` AS NOCLIENTE, `Fecha` AS FECHA, `cargoExtra` AS CARGOEXTRA, TRUNCATE(`TablaMDF`,4) AS MDF, TRUNCATE(`TablaPino`,4) AS PINO, " +
                "TRUNCATE(`TablaMoldura`,4) AS MOLDURAS, `Prioridad` AS PRIORIDAD, `pesoTotal` AS PESO FROM `Cotizacion` " +
                "INNER JOIN Cliente ON Cliente.id_cliente = Cotizacion.id_cliente " +
                "INNER JOIN  Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                "WHERE Cotizacion.id_usuario=" + id_usuario+ " AND Cotizacion.IsProduccion = 2";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
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
        public Boolean eliminarProductoCotizacion(int idDetalle, int idCotizacion)
        {
            try
            {
                string query = "DELETE FROM Detalle_Cotizacion WHERE id_detalle_cotizacion = "+idDetalle+" AND id_cotizacion = "+idCotizacion+"" ;
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
        public Boolean updateInventario(int idDetalle, int idCotizacion)
        {
            try
            {
                string query = "UPDATE Productos JOIN Detalle_Cotizacion ON Productos.id_producto = Detalle_Cotizacion.id_producto " +
                    " SET Productos.cantidad = Productos.cantidad + Detalle_Cotizacion.cantidadInventario" +
                    " WHERE Detalle_Cotizacion.id_detalle_cotizacion="+idDetalle+ " AND Detalle_Cotizacion.id_cotizacion="+idCotizacion;
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
        public Boolean borrarCotizacion(int id)
        {
            try
            {
                string query = "DELETE FROM Cotizacion WHERE id_cotizacion=" + id;
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



        public static DataTable consultaPrecio(string modelo, int id_tamano, int id_material, int id_categoria,int id_tipo)
        {
            ObtenerConexion();
            string query = "SELECT `id_producto`,`precio_publico`,`precio_frecuente`,`precio_mayorista`,`peso`,`porcentaje`, `cantidad` FROM `Productos` WHERE modelo = '" + modelo + "' AND id_tamano = " + id_tamano + " AND id_material = " + id_material + " AND fk_categoria = " + id_categoria + " AND id_tipo = "+id_tipo;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaMaxCotizacion()
        {
            try
            {
                ObtenerConexion();
                string query = "SELECT MAX(id_cotizacion) AS id_cotizacion, COUNT(IsProduccion) AS produccion FROM Cotizacion WHERE IsProduccion = 1";
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataAdapter seleccionar = new MySqlDataAdapter();
                seleccionar.SelectCommand = mycomand;
                DataTable datosUsuarios = new DataTable();
                seleccionar.Fill(datosUsuarios);
                seleccionar = null;
                
                conexion.Close();
                return datosUsuarios;
            }
            catch (Exception ex)
            {
                throw ex; //TODO: Please log it or remove the catch
            }
            finally
            {
                conexion.Close();
            }
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
        public static DataTable consultaDetalleCotizacionCajas(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT Detalle_Cotizacion.`id_detalle_cotizacion`, Productos.modelo, Color.nombre AS Color, Tamanos.tamano,Tamanos.descripcion, Material.nombre, Productos.peso, Tipo.nombre AS Tipo, Detalle_Cotizacion.cantidad FROM `Detalle_Cotizacion` INNER JOIN Tipo, Color, Productos, Material, Tamanos WHERE Productos.id_producto = Detalle_Cotizacion.id_producto AND Material.id_material = Productos.id_material AND Tamanos.id_tamano = Productos.id_tamano AND Color.id_color = Detalle_Cotizacion.id_color AND Tipo.id_tipo = Detalle_Cotizacion.id_tipo AND Detalle_Cotizacion.id_cotizacion = " + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable consultaCantidadInCaja(int idDetalleCotizacion)
        {
           
            try { 
            ObtenerConexion();
            string query = "SELECT `inCaja` FROM `Detalle_Caja` WHERE id_detalle_cotizacion = "+idDetalleCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
            }
            catch (Exception ex)
            {
                throw ex; //TODO: Please log it or remove the catch
            }
            finally
            {
                conexion.Close();
            }

        }
        public static DataTable consultaDetalleCotizacionInCajas(int idCotizacion,int idCaja)
        {
            ObtenerConexion();
            string query = "SELECT Detalle_Cotizacion.`id_detalle_cotizacion`, Productos.modelo, Color.nombre AS Color, Tamanos.tamano, Tamanos.descripcion, Material.nombre, Productos.peso, Tipo.nombre AS Tipo, Detalle_Cotizacion.cantidad, Detalle_Caja.inCaja FROM Detalle_Caja INNER JOIN Tipo, Color, Detalle_Cotizacion, Productos, Material, Tamanos WHERE Productos.id_producto = Detalle_Cotizacion.id_producto AND Material.id_material = Productos.id_material AND Tamanos.id_tamano = Productos.id_tamano AND Detalle_Caja.id_caja = " + idCaja + " AND Detalle_Caja.id_detalle_cotizacion = Detalle_Cotizacion.id_detalle_cotizacion AND Color.id_color = Detalle_Cotizacion.id_color AND Tipo.id_tipo = Detalle_Cotizacion.id_tipo AND Detalle_Cotizacion.id_cotizacion = " + idCotizacion ;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaDetalleCotizacionCajasInCaja(int idDetalleCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT Detalle_Caja.inCaja FROM `Detalle_Caja` WHERE Detalle_Caja.id_detalle_cotizacion = "+idDetalleCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }
        public static DataTable consultaCaja(int idCotizacion)
        {
            ObtenerConexion();
            string query = "SELECT `id_caja`, `numero_cajas`, `id_cotizacion`, `peso_total`, `titulo` FROM `Caja` WHERE id_cotizacion = " + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosUsuarios = new DataTable();
            seleccionar.Fill(datosUsuarios);
            conexion.Close();
            return datosUsuarios;
        }

        public static DataTable consultaCajaActual(int idCaja)
        {
            ObtenerConexion();
            string query = "SELECT `id_caja`, `numero_cajas`, `id_cotizacion`, `peso_total`, `titulo` FROM `Caja` WHERE id_caja = " + idCaja;
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
            double tablaMOLDURA, string prioridad,double pesoTotal,double iva, string tipo_envio)
        {
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Cotizacion`(`id_cliente`, `id_usuario`, `observacion`, `envio`, " +
                    "`NoCotizacionesCliente`, `IsProduccion`, `Fecha`, `cargoExtra`, `TablaMDF`, `TablaPino`, `TablaMoldura`, " +
                    "`Prioridad`,`pesoTotal`,`iva`,`tipoEnvio`) VALUES (" + idCliente+","+idUsuario+",'"+observaciones+"',"+envio+","+nocotizacion+","+isProduccion+"" +
                    ",'"+fecha+"',"+cargo+","+tablaMDF+","+tablaPINO+","+tablaMOLDURA+",'"+prioridad+"',"+pesoTotal+ "," + iva + " ,'"+tipo_envio+"')";
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
        public static DataTable listarProductosCotizacion(DataGridView gridview, int idCotizacion, string tipo)
        {


            ObtenerConexion();
            /*
            string query = "SET @row=0; SELECT (@row:=@row+1) AS '#',Tamanos.tamano AS 'TAMAÑO', Tamanos.descripcion AS 'DESCRIPCION', Categoria.nombre AS 'CATEGORIA', Material.nombre AS FONDO, " +
                "Productos.precio_" + tipo_precio + " AS 'PRECIO' , Detalle_Cotizacion.cantidad AS 'CANTIDAD' , Detalle_Cotizacion.cantidad * Productos.precio_" + tipo_precio+" AS 'IMPORTE'" +
                "" +
                "FROM Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                "INNER JOIN Material ON Productos.id_material = Material.id_material " +
                "INNER JOIN Detalle_Cotizacion ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                "WHERE Detalle_Cotizacion.id_cotizacion ="+idCotizacion;*/
            string query = "SET @row=0; SELECT (@row:=@row+1) AS '#',Productos.modelo AS MODELO ,Tipo.nombre as TIPO,Color.nombre AS COLOR, Tamanos.tamano AS 'TAMAÑO', Tamanos.descripcion AS 'DESCRIPCION', " +
                           "Detalle_Cotizacion.precio AS 'PRECIO' , Detalle_Cotizacion.cantidad AS 'CANTIDAD' , Detalle_Cotizacion.cantidad * Detalle_Cotizacion.precio AS 'IMPORTE', " +
                           "(SELECT Prioridad FROM Cotizacion WHERE id_cotizacion = "+idCotizacion+") AS PRIORIDAD ," +
                           "(SELECT SUM(Detalle_Cotizacion.cantidad) FROM `Detalle_Cotizacion` INNER JOIN Cotizacion ON Detalle_Cotizacion.id_cotizacion = Cotizacion.id_cotizacion INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto WHERE Cotizacion.id_cotizacion = "+idCotizacion+" AND Productos.fk_categoria >= 1 AND Productos.fk_categoria <=6) AS CANTIDAD_CATEGORIA " +
                           "FROM Productos " +
                           "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                           "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                           "INNER JOIN Material ON Productos.id_material = Material.id_material " +
                           "INNER JOIN Detalle_Cotizacion ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                           "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                           "INNER JOIN Tipo ON Tipo.id_tipo = Detalle_Cotizacion.id_tipo " +
                           "WHERE Detalle_Cotizacion.id_cotizacion =" + idCotizacion;
            Console.WriteLine(query);
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            gridview.DataSource = datosCotizacion;
            conexion.Close();
            return datosCotizacion;
        }

        public static DataTable listarProductosCotizacionModificar(int idCotizacion)
        {

            ObtenerConexion(); 
            string query = "SELECT Detalle_Cotizacion.id_detalle_cotizacion AS ID_DETALLE, Detalle_Cotizacion.id_producto AS ID , " +
                "Productos.modelo AS MODELO, Categoria.nombre AS CATEGORIA, Material.nombre AS MATERIAL, Color.nombre AS COLOR, Tamanos.tamano AS TAMAÑO, Tipo.nombre AS TIPO," +
                " Productos.peso AS PESO, Detalle_Cotizacion.cantidad AS CANTIDAD , Detalle_Cotizacion.precio AS 'PRECIO',Detalle_Cotizacion.cantidad * Detalle_Cotizacion.precio AS 'IMPORTE' , Color.id_color AS COLOR_ID " +
                "FROM Detalle_Cotizacion " +
                "INNER JOIN Productos ON Productos.id_producto = Detalle_Cotizacion.id_producto " +
                "INNER JOIN Categoria ON Categoria.id_categoria = Productos.fk_categoria " +
                "INNER JOIN Material ON Material.id_material = Productos.id_material " +
                "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                "INNER JOIN Tamanos ON Tamanos.id_tamano = Productos.id_tamano " +
                "INNER JOIN Tipo ON Tipo.id_tipo = Detalle_Cotizacion.id_tipo " +
                "WHERE Detalle_Cotizacion.id_cotizacion =" + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable listarProductosCotizacionTablas(int idCotizacion)
        {

            ObtenerConexion();
            string query = "SELECT Detalle_Cotizacion.id_detalle_cotizacion AS ID_DETALLE, Detalle_Cotizacion.id_producto AS ID , " +
                "Productos.modelo AS MODELO, Categoria.nombre AS CATEGORIA, Material.nombre AS MATERIAL, Color.nombre AS COLOR, Tamanos.tamano AS TAMAÑO, Tipo.nombre AS TIPO," +
                " Productos.peso AS PESO, Detalle_Cotizacion.cantidad AS CANTIDAD ,Productos.porcentaje AS PORCENTAJE ,Detalle_Cotizacion.precio AS 'PRECIO' , Color.id_color AS COLOR_ID, Productos.porcentaje AS PORCENTAJE, Detalle_Cotizacion.cantidadProduccion AS CANTIDAD " +
                "FROM Detalle_Cotizacion " +
                "INNER JOIN Productos ON Productos.id_producto = Detalle_Cotizacion.id_producto " +
                "INNER JOIN Categoria ON Categoria.id_categoria = Productos.fk_categoria " +
                "INNER JOIN Material ON Material.id_material = Productos.id_material " +
                "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                "INNER JOIN Tamanos ON Tamanos.id_tamano = Productos.id_tamano " +
                "INNER JOIN Tipo ON Tipo.id_tipo = Detalle_Cotizacion.id_tipo " +
                "WHERE Detalle_Cotizacion.id_cotizacion =" + idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable listarProductosProduccion(DataGridView gridview, int idCotizacion)
        {
            ObtenerConexion();
            //Categoria.nombre AS 'CATEGORIA'
            string query = "SELECT Productos.modelo AS 'MODELO',Material.nombre AS 'MATERIAL' " +
                ",Tipo.nombre AS 'TIPO', Color.nombre AS 'COLOR', Tamanos.tamano AS 'TAMAÑO',Tamanos.descripcion AS 'DESCRIPCION',Detalle_Cotizacion.cantidadInventario AS 'PZA. INV', Detalle_Cotizacion.cantidadProduccion AS 'PZA. PRODUC', " +
                "Detalle_Cotizacion.cantidadInventario+Detalle_Cotizacion.cantidadProduccion AS 'TOTAL PZAS', " +
                "(SELECT Prioridad FROM Cotizacion WHERE id_cotizacion = " + idCotizacion + ") AS PRIORIDAD, " +
                "(SELECT SUM(Detalle_Cotizacion.cantidad) FROM `Detalle_Cotizacion` INNER JOIN Cotizacion ON Detalle_Cotizacion.id_cotizacion = Cotizacion.id_cotizacion INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto WHERE Cotizacion.id_cotizacion = " + idCotizacion + " AND Productos.fk_categoria >= 1 AND Productos.fk_categoria <=6) AS CANTIDAD_CATEGORIA " +
                "FROM Productos " +
                "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                "INNER JOIN Detalle_Cotizacion ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                "INNER JOIN Material ON Material.id_material = Productos.id_material " +
                "WHERE Detalle_Cotizacion.id_cotizacion="+idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            gridview.DataSource = datosCotizacion;
            conexion.Close();
            return datosCotizacion;
        }
        public MySqlDataReader tablasCotizacion(int idCotizacion)
        {
            string query = "SELECT `TablaMDF`,`TablaPino`,`TablaMoldura`, `iva` FROM `Cotizacion` WHERE id_cotizacion="+idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            //conexion.Close();
            return myreader;

        }
        public static DataTable listarProductosMakila(DataGridView gridview, int idCotizacion, int opcion)
        {
            ObtenerConexion();
            string query = "";
            if(opcion == 1)
            {
                query = "SELECT Productos.modelo AS 'MODELO',Material.nombre AS 'MATERIAL' " +
                    ", Tipo.nombre AS 'TIPO', Tamanos.tamano AS 'TAMAÑO',Tamanos.descripcion AS DESCRIPCION, SUM(Detalle_Cotizacion.cantidadInventario) AS 'PZA. INV', " +
                    "SUM(Detalle_Cotizacion.cantidadProduccion) AS 'PZA. PRODUC', " +
                    "SUM(Detalle_Cotizacion.cantidadInventario + Detalle_Cotizacion.cantidadProduccion) AS 'TOTAL PZAS', " +
                    "(SELECT Prioridad FROM Cotizacion WHERE id_cotizacion = " + idCotizacion + ") AS PRIORIDAD, " +
                    "(SELECT SUM(Detalle_Cotizacion.cantidad) FROM `Detalle_Cotizacion` INNER JOIN Cotizacion ON Detalle_Cotizacion.id_cotizacion = Cotizacion.id_cotizacion INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto WHERE Cotizacion.id_cotizacion = " + idCotizacion + " AND Productos.fk_categoria >= 1 AND Productos.fk_categoria <=6) AS CANTIDAD_CATEGORIA " +
                    "FROM Productos " +
                    "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                    "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                    "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                    "INNER JOIN Detalle_Cotizacion ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                    "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                    "INNER JOIN Material ON Material.id_material = Productos.id_material " +
                    "WHERE Detalle_Cotizacion.id_cotizacion = " + idCotizacion + " AND Productos.fk_categoria >= 1 AND Productos.fk_categoria <= 6 GROUP BY Productos.id_producto";
            }
            else
            {
                query = "SELECT Productos.modelo AS 'MODELO',Material.nombre AS 'MATERIAL' " +
                    ", Tipo.nombre AS 'TIPO', Tamanos.tamano AS 'TAMAÑO',Tamanos.descripcion AS DESCRIPCION, SUM(Detalle_Cotizacion.cantidadInventario) AS 'PZA. INV', " +
                    "SUM(Detalle_Cotizacion.cantidadProduccion) AS 'PZA. PRODUC', " +
                    "SUM(Detalle_Cotizacion.cantidadInventario + Detalle_Cotizacion.cantidadProduccion) AS 'TOTAL PZAS', " +
                    "(SELECT Prioridad FROM Cotizacion WHERE id_cotizacion = " + idCotizacion + ") AS PRIORIDAD, " +
                    "(SELECT SUM(Detalle_Cotizacion.cantidad) FROM `Detalle_Cotizacion` INNER JOIN Cotizacion ON Detalle_Cotizacion.id_cotizacion = Cotizacion.id_cotizacion INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto WHERE Cotizacion.id_cotizacion = " + idCotizacion + " AND Productos.fk_categoria >= 1 AND Productos.fk_categoria <=6) AS CANTIDAD_CATEGORIA " +
                    "FROM Productos " +
                    "INNER JOIN Tamanos ON Productos.id_tamano = Tamanos.id_tamano " +
                    "INNER JOIN Categoria ON Productos.fk_categoria = Categoria.id_categoria " +
                    "INNER JOIN Tipo ON Productos.id_tipo = Tipo.id_tipo " +
                    "INNER JOIN Detalle_Cotizacion ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                    "INNER JOIN Color ON Color.id_color = Detalle_Cotizacion.id_color " +
                    "INNER JOIN Material ON Material.id_material = Productos.id_material " +
                    "WHERE Detalle_Cotizacion.id_cotizacion = " + idCotizacion + " AND Productos.fk_categoria >= 7 AND Productos.fk_categoria <= 13 GROUP BY Productos.id_producto";
            }


            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            gridview.DataSource = datosCotizacion;
            conexion.Close();
            return datosCotizacion;
        }
        public MySqlDataReader consultarCliente(int idCotizacion)
        {
            string query = "SELECT Cotizacion.observacion,Cotizacion.Fecha, " +
                "Cliente.razon_social,Cliente.ciudad, Cliente.estado, Cliente.codigo_postal," +
                "Cotizacion.NoCotizacionesCliente, Cotizacion.id_cotizacion, Cliente.calle, Cliente.colonia, Cliente.num_ext,Cliente.cel_1, Cotizacion.envio," +
                "Cotizacion.cargoExtra, Cliente.tipo_cliente, Cliente.id_cliente, Cuenta_Cliente.monto_total, Cotizacion.cargoExtra, Cotizacion.pesoTotal, Cotizacion.iva, Cotizacion.Prioridad, Cotizacion.tipoEnvio " +
                "FROM Cotizacion " +
                "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +
                "INNER JOIN Cuenta_Cliente ON Cotizacion.id_cotizacion = Cuenta_Cliente.id_cotizacion " +
                "WHERE Cotizacion.id_cotizacion =" +idCotizacion;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            //conexion.Close();
            return myreader;
        }
        public MySqlDataReader consultarClienteTipo(int idCliente)
         {
            string query = "SELECT tipo_cliente FROM Cliente WHERE id_cliente="+idCliente;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            //conexion.Close();
            return myreader;
        }

        public int agregarTamanoNuevo(String tamano, String descripcion,int id_categoria)
        {
            int id = -1;
            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Tamanos` (`tamano`, `descripcion`, `id_categoria`) VALUES (?tamano,?descripcion,?id_categoria)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("?tamano", MySqlDbType.VarChar).Value = tamano;
                    cmd.Parameters.Add("?descripcion", MySqlDbType.VarChar).Value = descripcion;
                    cmd.Parameters.Add("?id_categoria", MySqlDbType.Int32).Value = id_categoria;
                    cmd.ExecuteNonQuery();
                    id = Convert.ToInt32(cmd.LastInsertedId);
                }

                return id;
            }
            catch(Exception ex)
            {
                return id;
            }
        }

        public Boolean agregarProductoNuevo(String modelo, int id_tamano, float pp , float pf, float pm, float porcentaje, float peso, int id_material, int id_categoria, int id_tipo)
        {

            try
            {
                ObtenerConexion();
                string query = "INSERT INTO `Productos`(`modelo`, `id_tamano`, `precio_publico`, `precio_frecuente`, `precio_mayorista`, `porcentaje`, `cantidad`, `peso`, `id_material`, `fk_categoria`, `id_tipo`) " +
                    "VALUES (?modelo,?id_tamano,?pp,?pf,?pm,?porcentaje,?cantidad,?peso,?id_material,?fk_categoria,?id_tipo)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {

                    cmd.Parameters.Add("?modelo", MySqlDbType.VarChar).Value = modelo;
                    cmd.Parameters.Add("?id_tamano", MySqlDbType.Int32).Value = id_tamano;
                    cmd.Parameters.Add("?pp", MySqlDbType.Float).Value = pp;
                    cmd.Parameters.Add("?pf", MySqlDbType.Float).Value = pf;
                    cmd.Parameters.Add("?pm", MySqlDbType.Float).Value = pm;
                    cmd.Parameters.Add("?porcentaje", MySqlDbType.Float).Value = porcentaje;
                    cmd.Parameters.Add("?cantidad", MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("?peso", MySqlDbType.Float).Value = peso;
                    cmd.Parameters.Add("?id_material", MySqlDbType.Int32).Value = id_material;
                    cmd.Parameters.Add("?fk_categoria", MySqlDbType.Int32).Value = id_categoria;
                    cmd.Parameters.Add("?id_tipo", MySqlDbType.Int32).Value = id_tipo;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:"+ex);
                return false;
            }
        }

        public Boolean existeTamano(String tamano, String descripcion, int id_categoria) {

            try
            {
                ObtenerConexion();
                int i = 0;
                MySqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Tamanos WHERE tamano = '" + tamano + "' AND descripcion = '" + descripcion + "' AND id_categoria = "+ id_categoria + " ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);


                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {
                    return false;
                }
                else {
                    return true;
                }
            }
            catch(Exception ex) {
                
                return false;
            }

        }

        public Boolean existeProducto(String modelo, int id_tamano, int id_material, int id_categoria, int id_tipo)
        {
            try
            {
                ObtenerConexion();
                int i = 0;
                MySqlCommand cmd = conexion.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Productos WHERE modelo = '"+modelo+"' AND id_tamano = "+id_tamano+" AND id_material = "+id_material+" AND fk_categoria = "+id_categoria+" AND id_tipo = "+id_tipo+" ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);


                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public static DataTable tableReporteador(String fecha1, String fecha2)
        {
            ObtenerConexion();

            string query = "SELECT Cotizacion.id_cotizacion AS 'No. Cotizacion', Usuario.nombre_usuario AS 'Vendedor', Cliente.razon_social AS 'Cliente'," +
                            "Cotizacion.NoCotizacionesCliente AS 'No. Pedido', Cotizacion.Fecha AS 'Fecha' , 0 AS 'T. Cajas'," +
                            "0 AS 'T. Cuadros', 0 AS 'T. Placas', Cuenta_Cliente.total_pagado AS 'T. Abonado', " +
                            "Cuenta_Cliente.monto_total - Cuenta_Cliente.total_pagado AS 'T. Resta', Cuenta_Cliente.monto_total AS 'Total', " +
                            "Control.estado AS 'Estatus del pedido' FROM Cotizacion " +
                            "INNER JOIN Usuario ON Cotizacion.id_usuario = Usuario.id_usuario " +
                            "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +                          
                            "INNER JOIN Detalle_Cotizacion ON Cotizacion.id_cotizacion = Detalle_Cotizacion.id_cotizacion " +
                            "INNER JOIN Cuenta_Cliente ON Cotizacion.id_cotizacion = Cuenta_Cliente.id_cotizacion " +
                            "INNER JOIN Control ON Cotizacion.id_cotizacion = Control.id_cotizacion " +
                            "WHERE Fecha >= '"+fecha1+"' AND Fecha <= '"+fecha2+"' " +
                            "GROUP BY Cotizacion.id_cotizacion";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable totalCuadros(String fecha1, String fecha2)
        {
            ObtenerConexion();

            string query = "SELECT Cotizacion.id_cotizacion AS ID, SUM(Detalle_Cotizacion.cantidad) AS NUM " +
                            "FROM Cotizacion " +
                            "INNER JOIN Detalle_Cotizacion ON Cotizacion.id_cotizacion = Detalle_Cotizacion.id_cotizacion " +
                            "INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                            "WHERE Productos.fk_categoria >= 1 and Productos.fk_categoria <= 6 " +
                            "AND Fecha >= '" + fecha1 + "' AND Fecha <= '" + fecha2 + "' " +
                            "GROUP BY Cotizacion.id_cotizacion";;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable totalPlacas(String fecha1, String fecha2)
        {
            ObtenerConexion();

            string query = "SELECT Cotizacion.id_cotizacion AS ID, SUM(Detalle_Cotizacion.cantidad) AS NUM " +
                            "FROM Cotizacion " +
                            "INNER JOIN Detalle_Cotizacion ON Cotizacion.id_cotizacion = Detalle_Cotizacion.id_cotizacion " +
                            "INNER JOIN Productos ON Detalle_Cotizacion.id_producto = Productos.id_producto " +
                            "WHERE Productos.fk_categoria >= 8 and Productos.fk_categoria <= 11 " +
                            "AND Fecha >= '" + fecha1 + "' AND Fecha <= '" + fecha2 + "' " +
                            "GROUP BY Cotizacion.id_cotizacion";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable totalCajas(String fecha1, String fecha2)
        {
            ObtenerConexion();

            string query = "SELECT Cotizacion.id_cotizacion AS 'ID',COUNT(Caja.id_caja) AS 'NUM' " +
                            "FROM Cotizacion " +
                            "INNER JOIN Caja ON Cotizacion.id_cotizacion = Caja.id_cotizacion " +
                            "WHERE Fecha >= '" + fecha1 + "' AND Fecha <= '" + fecha2 + "' " +
                            "GROUP BY Cotizacion.id_cotizacion";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }
        public static DataTable informacionPago(int id_pago)
        {
            ObtenerConexion();

            string query = "SELECT Pago.id_pago AS ID, Pago.id_cuenta AS CUENTA, Pago.fecha AS FECHA, Pago.monto_pagado AS PAGADO, Pago.forma_pago AS FORMA , Pago.concepto AS CONCEPTO, Cliente.razon_social AS NOMBRE "+
                            "FROM Pago " +
                            "INNER JOIN Cuenta_Cliente ON Pago.id_cuenta = Cuenta_Cliente.id_cuenta_cliente " +
                            "INNER JOIN Cotizacion ON Cuenta_Cliente.id_cotizacion = Cotizacion.id_cotizacion " +
                            "INNER JOIN Cliente ON Cotizacion.id_cliente = Cliente.id_cliente " +
                            "WHERE id_pago = "+ id_pago;
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataAdapter seleccionar = new MySqlDataAdapter();
            seleccionar.SelectCommand = mycomand;
            DataTable datosCotizacion = new DataTable();
            seleccionar.Fill(datosCotizacion);
            conexion.Close();
            return datosCotizacion;
        }

        //DESAPROBAR COTIZACION
        public static Boolean desaprobarCotizacion(int idCotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "UPDATE Cotizacion SET isUltimaProduccion = 0 , IsProduccion = 0 WHERE id_cotizacion = " + idCotizacion;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean eliminarControlCotizacion(int idCotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "DELETE FROM Control WHERE id_cotizacion = " + idCotizacion;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean eliminarCajaCotizacion(int idCotizacion)
        {
            try
            {
                ObtenerConexion();
                string query = "DELETE FROM Caja WHERE id_cotizacion = " + idCotizacion;
                MySqlCommand mycomand = new MySqlCommand(query, conexion);
                MySqlDataReader myreader = mycomand.ExecuteReader();
                myreader.Read();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static MySqlDataReader precioPaqueteria()
        {
           
            string query = "SELECT * FROM `PaqueteriaPrecios` WHERE idPaqueteriaPrecio = 1";
            MySqlCommand mycomand = new MySqlCommand(query, conexion);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            myreader.Read();
            //conexion.Close();
            return myreader;
        }
    }
}
