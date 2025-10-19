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
        private int _idPublicacion;
        private string _usuarioLogueado;
        private DBHelper _dbHelper = new DBHelper();
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

            int margenEntreControles = 8;
            label3.Top = richTextBox1.Bottom + margenEntreControles;
            label3.Top = richTextBox1.Bottom + margenEntreControles;
            button1.Top = label3.Bottom + margenEntreControles;
            button2.Top = label3.Bottom + margenEntreControles;

            int margenInferiorFinal = 30;

       
            this.Height = button1.Bottom + margenInferiorFinal;
        }

      
        public Publicaciones()
        {
            InitializeComponent();
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
                button1.Text = "❤️ Quitar Me Gusta";
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
