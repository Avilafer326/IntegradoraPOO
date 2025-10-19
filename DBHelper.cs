using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class DBHelper
    {

        public (int count, bool userLiked) GetLikeStatus(string nombreUsuario, int idPublicacion)
        {
            int likeCount = 0;
            bool userLiked = false;

            // Consulta para obtener el conteo total y verificar el voto del usuario actual en una sola llamada
            string countAndCheckQuery = @"
                SELECT 
                    (SELECT COUNT(*) FROM likes WHERE id_publicacion = @PostId) as Count,
                    (SELECT COUNT(*) FROM likes WHERE id_publicacion = @PostId AND usuario = @User) as UserVoted;";

            // Usamos tu método estático para obtener la conexión
            using (MySqlConnection connection = Conexion.conexion())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(countAndCheckQuery, connection);
                    cmd.Parameters.AddWithValue("@PostId", idPublicacion);
                    cmd.Parameters.AddWithValue("@User", nombreUsuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lee los resultados de las subconsultas
                            likeCount = reader.GetInt32("Count");
                            userLiked = reader.GetInt32("UserVoted") > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el estado de likes: " + ex.Message);
                }
            }
            return (likeCount, userLiked);
        }

        // Método principal para añadir o quitar un like (Toggle)
        public void ToggleLike(string nombreUsuario, int idPublicacion)
        {
            // Intenta insertar el like. Si ya existe, fallará por la clave única (Error 1062).
            string insertQuery = @"
                INSERT INTO likes (usuario, id_publicacion) 
                VALUES (@User, @PostId);";

            using (MySqlConnection connection = Conexion.conexion())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@User", nombreUsuario);
                    cmd.Parameters.AddWithValue("@PostId", idPublicacion);

                    cmd.ExecuteNonQuery();
                    // Si el INSERT fue exitoso, el like fue añadido.
                }
                catch (MySqlException ex)
                {
                    // Error 1062 = Violación de índice Único (El like ya existe, ¡debemos quitarlo!)
                    if (ex.Number == 1062)
                    {
                        RemoveLike(nombreUsuario, idPublicacion);
                        // Si se llama RemoveLike, el like fue quitado.
                    }
                    else
                    {
                        MessageBox.Show("Error de base de datos: " + ex.Message);
                    }
                }
            }
        }

        // Método auxiliar para eliminar el like
        private void RemoveLike(string nombreUsuario, int idPublicacion)
        {
            string deleteQuery = @"
                DELETE FROM likes 
                WHERE usuario = @User AND id_publicacion = @PostId;";

            using (MySqlConnection connection = Conexion.conexion())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@User", nombreUsuario);
                    cmd.Parameters.AddWithValue("@PostId", idPublicacion);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el like: " + ex.Message);
                }
            }
        }
    }
}
