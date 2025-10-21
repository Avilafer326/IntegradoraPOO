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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace IntegradoraPOO
{
    public partial class ControlTablero : UserControl
    {
        
    

        int idPublicacion;
        private string usuariologeado;
        private DBHelper _dbHelper = new DBHelper();
        public  ControlTablero(string usuario)
        {
           
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlConfiguracion";
            this.Size = new System.Drawing.Size(400, 325);
            this.Load += new System.EventHandler(this.ControlTablero_Load);
            this.ResumeLayout(false);
            usuariologeado = usuario;
            InitializeComponent();
            CargarPublicaciones2();
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
        public void CargarPublicaciones2()
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

                    publicacionUC.BotonPresionadoParaMostrarGroupBox += PublicacionUC_BotonPresionadoParaMostrarGroupBox;
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
        private void PublicacionUC_BotonPresionadoParaMostrarGroupBox(object sender, EventArgs e)
        {
            // 'sender' es la instancia de Publicaciones que disparó el evento.
            if (sender is Publicaciones publicacion)
            {
                // El ID de la publicación está en la variable privada de la instancia.
                int idDelPost = publicacion.GetIdPublicacion();

                // Llama al método para mostrar el GroupBox en ControlTablero.
                MostrarGroupBoxComentarios(idDelPost);
            }
        }

        private void ControlTablero_Load(object sender, EventArgs e)
        {
        
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void publicaciones1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        { 
            //boton quitar comentarios
            groupBox2.Visible = false;
            richTextBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //confirmar comentario
            if (!string.IsNullOrEmpty(richTextBox2.Text))
            {
                _dbHelper.AddComment(usuariologeado, idPublicacion, richTextBox2.Text);
                richTextBox2.Clear();
                MessageBox.Show("comentario añadido");
               
                CargarComentarios();
            }
        }
        public void CargarComentarios()
        {
            flowLayoutPanel2.Controls.Clear();

            // Usamos el método de DBHelper para obtener los datos
            DataTable comentariosDT = _dbHelper.GetCommentsForPost(idPublicacion);

            foreach (DataRow row in comentariosDT.Rows)
            {
                string usuario = row["fk_usuario"].ToString();
                string contenido = row["contenido"].ToString();
                DateTime fecha = (DateTime)row["FechaComentado"];

                // 1. Crea el nuevo UserControl por cada comentario
                ControlComentario commentUC = new ControlComentario(usuario, contenido, fecha);

                // 2. Ajusta el tamaño para que llene el ancho del FlowLayoutPanel
                commentUC.Width = flowLayoutPanel2.ClientSize.Width;
                // Opcional: Si el control tiene un método para ajustar su propia altura
                // commentUC.AjustarAltura(); 

                // 3. Añade el control al panel
                flowLayoutPanel2.Controls.Add(commentUC);
            }
        }
        public void SetGroupBoxState(bool isVisible)
        {
            // Asumiendo que tu GroupBox se llama 'groupBox1' en este control.
            groupBox2.Visible = isVisible;
        }
        public void MostrarGroupBoxComentarios(int idPost)
        {
            // Almacena el ID de la publicación que disparó el evento para usarlo en button8_Click.
            this.idPublicacion = idPost;
            CargarComentarios();
            // Muestra el GroupBox deseado
            groupBox2.Visible = true;

            // Opcional: Cargar comentarios del post actual si es necesario
            // CargarComentarios(idPost); 
        }
    }
}
