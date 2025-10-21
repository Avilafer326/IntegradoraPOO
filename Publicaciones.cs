using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public partial class Publicaciones : UserControl
    {


        private string _usuarioLogueado;
        private DBHelper _dbHelper = new DBHelper();
        int contador;
        string palabraantesde;

        public delegate void PublicacionEliminadaHandler(object sender, EventArgs e);

        // 1. Define el delegado y el evento
        public event EventHandler BotonPresionadoParaMostrarGroupBox;

        // Define el evento que el control padre suscribirá
        public event PublicacionEliminadaHandler PublicacionEliminada;

        private int _idPublicacion;
        public Publicaciones(int idPublicacion, string usuario, string contenido, DateTime Fecha, string usuarioLogueado)
        {

            InitializeComponent();
            _idPublicacion = idPublicacion;
            _usuarioLogueado = usuarioLogueado;
            label1.Text = usuario;
            richTextBox1.Text = contenido;
            label2.Text = Fecha.ToString();
            LoadLikeStatus();
            AjustarAlturaContenido();
            if (usuario == usuarioLogueado)
            {
                button3.Visible = true;
            }

        }
        public void AjustarAlturaContenido()
        {

            int padding = 10;
            int anchoMaximo = richTextBox1.Width;

            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(
                    richTextBox1.Text,
                    richTextBox1.Font,
                    anchoMaximo,
                    StringFormat.GenericTypographic
                );

                int alturaContenido = (int)Math.Ceiling(size.Height) + padding;


                richTextBox1.Height = alturaContenido;
            }

            int margenEntreControles = 15;
            label3.Top = richTextBox1.Bottom + margenEntreControles;
            label3.Top = richTextBox1.Bottom + margenEntreControles;
            button1.Top = label3.Bottom + margenEntreControles;
            button2.Top = label3.Bottom + margenEntreControles;



            int margenInferiorFinal = 8;


            this.Height = button2.Bottom + margenInferiorFinal;
        }


        public Publicaciones()
        {
            InitializeComponent();
            AjustarAlturaContenido();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadLikeStatus()
        {
            // Obtener el contador total y si el usuario actual ya dio like
            var status = _dbHelper.GetLikeStatus(_usuarioLogueado, _idPublicacion);

            // Actualizar el contador de likes (asumiendo label3 es el contador)
            label3.Text = status.count.ToString() + " Me gusta";

            // Actualizar la apariencia del botón (asumiendo button1 es el like)
            if (status.userLiked)
            {
                // El usuario ya dio like (muestra el estado para QUITAR el like)
                button1.Text = "❤️ No me gusta";
            }
            else
            {
                // El usuario NO ha dado like (muestra el estado para DAR like)
                button1.Text = "🤍 Me Gusta";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Llama a la lógica de la base de datos para añadir/quitar el like
            _dbHelper.ToggleLike(_usuarioLogueado, _idPublicacion);

            // Actualiza la interfaz para reflejar el nuevo estado (contador y texto del botón)
            LoadLikeStatus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected virtual void OnBotonPresionadoParaMostrarGroupBox(EventArgs e)
        {
            BotonPresionadoParaMostrarGroupBox?.Invoke(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //comentarios
            OnBotonPresionadoParaMostrarGroupBox(EventArgs.Empty);

        }

        public void button3_Click(object sender, EventArgs e)
        {
            contador++;
            groupBox1.Visible = true;
            if (contador == 2)
            {
                groupBox1.Visible = false;
                contador = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControlTablero controlTablero = new ControlTablero(_usuarioLogueado);
            string deleteQuery = @"
        DELETE FROM publicacionestb 
        WHERE id_publicacion = @PostId;";

            using (MySqlConnection connection = Conexion.conexion())
            {
                ;
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);

                    // Usamos parámetros para seguridad
                    cmd.Parameters.AddWithValue("@PostId", _idPublicacion);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Publicación eliminada exitosamente.");

                        // **LÍNEA DE ACTUALIZACIÓN (Línea 159)**
                        // 1. Ocultar el control eliminado
                        this.Visible = false;

                        // 2. Notificar al contenedor principal para que recargue la lista
                        PublicacionEliminada?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Error: La publicación no fue encontrada.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al eliminar la publicación: " + ex.Message);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            palabraantesde = richTextBox1.Text;
            richTextBox1.ReadOnly = false;
            richTextBox1.BackColor = Color.Gray;
            richTextBox1.Text = "editalo";
            button6.Visible = true;
            button7.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            ControlTablero controlTablero = new ControlTablero(_usuarioLogueado);
            string EditQuery = @"
            UPDATE publicacionestb
            SET Contenido = @contenido
            WHERE id_publicacion = @PostId";
            using (MySqlConnection connection = Conexion.conexion())
            {
                ;
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(EditQuery, connection);

                    // Usamos parámetros para seguridad
                    cmd.Parameters.AddWithValue("@PostId", _idPublicacion);
                    cmd.Parameters.AddWithValue("contenido", richTextBox1.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("editada");
                        this.Update();
                        richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                        groupBox1.Visible = false;
                        button6.Visible = false;
                        button7.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Error: La publicación no fue encontrada.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al eliminar la publicación: " + ex.Message);
                }
                richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                groupBox1.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                richTextBox1.ReadOnly = true;
            }

        }
        public int GetIdPublicacion()
        {
            return _idPublicacion;
        }
        private void button7_Click(object sender, EventArgs e)
        {

            richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            groupBox1.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            richTextBox1.Text = palabraantesde;
            this.Update();
            richTextBox1.ReadOnly = true;
            MessageBox.Show("Cancelado");
        }

    }
}