using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IntegradoraPOO
{
    public partial class ControlTablero : UserControl
    {
        private string usuariologeado;
        public  ControlTablero(string usuario)
        {
            usuariologeado = usuario;
            InitializeComponent();
            CargarPublicaciones();
            if (flowLayoutPanel1 != null)
            {
                flowLayoutPanel1.Margin = new Padding(0);
                flowLayoutPanel1.Padding = new Padding(0);
            }
            this.Padding = new Padding(0);
    
        }
  

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void CargarPublicaciones()
        {
            // Limpiamos el FlowLayoutPanel antes de cargar nuevos datos
            flowLayoutPanel1.Controls.Clear();

      
            MySqlConnection connection = null;
            MySqlCommand codigo = null;
            MySqlDataReader reader = null; 

            try
            {
          
                connection = Conexion.conexion();

          
                connection.Open();

      
                codigo = new MySqlCommand("SELECT id_publicacion, User, Contenido, FechaCreacion FROM publicacionestb ORDER BY FechaCreacion DESC", connection);

       
                reader = codigo.ExecuteReader();
               

                while (reader.Read())
                {
                    int idPublicacion = reader.GetInt32("id_publicacion");
                    string usuario = reader.GetString("User");
                    string contenido = reader.GetString("Contenido");

                    DateTime fecha = reader.GetDateTime("FechaCreacion");

                    Publicaciones publicacionUC = new Publicaciones(
                        idPublicacion,
                        usuario,
                        contenido,
                        fecha,
                        usuariologeado // ¡Pasamos el usuario logueado!
                    );


                    publicacionUC.Width = flowLayoutPanel1.ClientSize.Width;
                    publicacionUC.AjustarAlturaContenido();
               
                    flowLayoutPanel1.Controls.Add(publicacionUC);
                }
            }
            catch (MySqlException mySqlEx)
            {
 
                MessageBox.Show("Error de base de datos MySQL: " + mySqlEx.Message);
            }
            catch (Exception ex)
            {
        
                MessageBox.Show("Error al cargar las publicaciones: " + ex.Message);
            }
            finally
            {
       
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void ControlTablero_Load(object sender, EventArgs e)
        {
        
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
