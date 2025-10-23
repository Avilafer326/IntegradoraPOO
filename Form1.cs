using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace IntegradoraPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // se cambia el texto de las etiquetas
            label1.Text = "¿No tienes cuenta?";
            linkLabel1.Text = "Crea una aquí";

            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;

        }
        //llamas a otras ventanas y connecion a mysql
        CrearCuenta llamdaCrear = new CrearCuenta();
        MySqlConnection connection = Conexion.conexion();
        MySqlCommand codigo = new MySqlCommand();

        private void button2_Click(object sender, EventArgs e)
        {
            //llamdaCrear.Show();
            //this.Hide();
        }

        private bool VerificarHash(string contra)
        {
            try
            {
                //se abre la conexion a la base de datos
                connection.Open();
                //se crea el lector de comandos en mysql
                MySqlCommand codigo = new MySqlCommand();
                codigo.Connection = connection;

                // Obtener el hash almacenado en la base de datos
                codigo.CommandText = "SELECT Contra FROM usuarios WHERE User = @username";
                codigo.Parameters.AddWithValue("@username", UsuarioText.Text);
                //se ejecuta el comando y el resultado se guarda 
                var result = codigo.ExecuteScalar();
                connection.Close();
                if (result != null)
                {
                    //se guarda la contraseña en hash 
                    string hash = result.ToString().Trim();

                    // Verificar con Bcrypt
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(contra, hash);
                    if (isValidPassword)
                    {

                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarHash(ContraText.Text))
            {
                FormularioPrincipal llamadaUsuario = new FormularioPrincipal(UsuarioText.Text);
                llamadaUsuario.Show();
                this.Hide();
            }
            else { MessageBox.Show("Usuario o contraseña incorrectos"); }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llamdaCrear.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }













        //Métodos para pintar el fondo

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Color de fondo base: hsla(345,67%,61%,1)
            Color baseColor = ColorFromHSL(345, 0.67, 0.61);

            // Color de los gradientes radiales: hsla(16,78%,67%,1) y hsla(16,79%,67%,1)
            Color gradientColor1 = ColorFromHSL(16, 0.78, 0.67);
            Color gradientColor2 = ColorFromHSL(16, 0.79, 0.67);

            // Llenar con el color base
            using (SolidBrush baseBrush = new SolidBrush(baseColor))
            {
                g.FillRectangle(baseBrush, this.ClientRectangle);
            }

            // Primer gradiente radial: at 27% 95%
            DrawRadialGradient(g, this.ClientRectangle,
                0.27f, 0.95f, gradientColor1, 0.5f);

            // Segundo gradiente radial: at 84% 77%
            DrawRadialGradient(g, this.ClientRectangle,
                0.84f, 0.77f, gradientColor2, 0.5f);
        }

        private void DrawRadialGradient(Graphics g, Rectangle bounds,
        float xPercent, float yPercent, Color centerColor, float radiusPercent)
        {
            // Calcular posición del centro
            int centerX = (int)(bounds.Width * xPercent);
            int centerY = (int)(bounds.Height * yPercent);

            // Calcular radio (50% del tamaño más grande)
            int radius = (int)(Math.Max(bounds.Width, bounds.Height) * radiusPercent);

            // Crear el path del gradiente
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(centerX - radius, centerY - radius, radius * 2, radius * 2);

            // Crear el gradiente radial
            using (PathGradientBrush brush = new PathGradientBrush(path))
            {
                brush.CenterPoint = new PointF(centerX, centerY);
                brush.CenterColor = centerColor;
                brush.SurroundColors = new Color[] { Color.Transparent };

                // Mezclar con el fondo
                g.FillRectangle(brush, bounds);
            }

            path.Dispose();
        }
        private Color ColorFromHSL(double h, double s, double l)
        {
            h = h / 360.0;

            double r, g, b;

            if (s == 0)
            {
                r = g = b = l; // Gris
            }
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;
                r = HueToRgb(p, q, h + 1.0 / 3.0);
                g = HueToRgb(p, q, h);
                b = HueToRgb(p, q, h - 1.0 / 3.0);
            }

            return Color.FromArgb(
                (int)Math.Round(r * 255),
                (int)Math.Round(g * 255),
                (int)Math.Round(b * 255)
            );
        }
        private double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioLabel_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContraLabel_Click(object sender, EventArgs e)
        {

        }

        private void ContraText_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}