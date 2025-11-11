using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace IntegradoraPOO
{
    internal class Conexion
    {

        public static MySqlConnection conexion()
        {
<<<<<<< HEAD
            //la cadena para conectar a base de datos
            string servidor = "127.0.0.1";
=======
            string servidor = "10.1.124.255";
>>>>>>> master
            string bd = "chismes";
            string user = "vivianos";
            string password = "vivianos123";
            string port = "3310";

            string cadenaConexion = $"SERVER=" + servidor + ";DATABASE=" + bd + ";UID=" + user + ";PASSWORD=" + password + ";PORT=" + port;
            MySqlConnection conexionBase = new MySqlConnection(cadenaConexion);
            try
            {

                return conexionBase;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }

}
      