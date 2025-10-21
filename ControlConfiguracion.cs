using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlConfiguracion : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private Publicaciones publicaciones1;
        string usuariologeado;
        
        public ControlConfiguracion(string usuario)
        {
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlConfiguracion";
            this.Size = new System.Drawing.Size(400, 325);
            this.Load += new System.EventHandler(this.ControlConfiguracion_Load);
            this.ResumeLayout(false);
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

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.publicaciones1 = new IntegradoraPOO.Publicaciones();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.publicaciones1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(544, 325);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // publicaciones1
            // 
            this.publicaciones1.Location = new System.Drawing.Point(0, 0);
            this.publicaciones1.Margin = new System.Windows.Forms.Padding(0);
            this.publicaciones1.Name = "publicaciones1";
            this.publicaciones1.Size = new System.Drawing.Size(544, 333);
            this.publicaciones1.TabIndex = 0;
            // 
            // ControlConfiguracion
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlConfiguracion";
            this.Size = new System.Drawing.Size(549, 333);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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


                codigo = new MySqlCommand($"SELECT id_publicacion, User, Contenido, FechaCreacion FROM publicacionestb WHERE User = '{usuariologeado}' ORDER BY FechaCreacion DESC", connection);


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
                        usuariologeado 
                    );
                    publicacionUC.PublicacionEliminada += RecargarPublicaciones;


                    publicacionUC.Width = flowLayoutPanel1.ClientSize.Width;
                    publicacionUC.AjustarAlturaContenido();

                    flowLayoutPanel1.Controls.Add(publicacionUC);
                }

            }
            catch (MySqlException mySqlEx)
            {

                MessageBox.Show("Error de base de datos MySQL: " + mySqlEx);
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
        private void RecargarPublicaciones(object sender, EventArgs e)
        {
            // Llama al método que limpia y vuelve a cargar los datos de la DB
            CargarPublicaciones();
        }

        private void ControlConfiguracion_Load(object sender, System.EventArgs e)
        {

        }
    }
}
