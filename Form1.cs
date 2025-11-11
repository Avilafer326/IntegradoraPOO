using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Diagnostics.Contracts;


namespace IntegradoraPOO
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            label1.Text = "¿No tienes cuenta?";
            linkLabel1.Text = "Crea una aquí";
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label2.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
            RedondearBoton(button1, 60);
            Estilizado(button1, 25);
            RedondearPanel(panel1, 30);
            
            TextHolders();

            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

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
                MessageBox.Show("=" + ex);
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

        //-----------------------Parte para los textBoxs---------------------//

        public void TextHolders()
        {
            // Configurar placeholder para usuario
            UsuarioText.Text = "Usuario";
            UsuarioText.ForeColor = Color.Gray;

            // Configurar placeholder para contraseña
            ContraText.Text = "Contraseña";
            ContraText.ForeColor = Color.Gray;
        }





        //---------------------------------------------------Métodos para el diseño del form-----------------//

        //--------------------------------------------------------------------------Diseño del botón---------//
        private void RedondearBoton(Button btn, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(btn.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(btn.Width - radio, btn.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, btn.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
        // Variables globales para la animación
        private Timer gradienteTimer;
        private float animacionOffset = 0f;
        private readonly Color[] coloresDegradado = new Color[]
        {
            Color.FromArgb(255, 255, 120, 120),  // rojo suave
            Color.FromArgb(255, 255, 180, 80),   // amarillo cálido
            Color.FromArgb(255, 255, 130, 200),  // rosa pastel
            Color.FromArgb(255, 255, 100, 150)   // magenta suave
        };

        //--------------------------------------------------Diseño del botón con animacion--------------------
        private void Estilizado(Button btn, int radio)
        {
            // Mantiene su fuente, texto y tamaño originales
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.Font = btn.Font;
            //btn.DoubleBuffered = true; // evita parpadeo

            // Crear la forma redondeada del botón
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(btn.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(btn.Width - radio, btn.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, btn.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);



            btn.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = btn.ClientRectangle;

                // Fondo degradado dinámico
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    InterpolarColor(animacionOffset, coloresDegradado),
                    InterpolarColor(animacionOffset + 0.3f, coloresDegradado),
                    45f))
                {
                    g.FillPath(brush, path);
                }

                // Contorno blanco translúcido
                using (Pen pen = new Pen(Color.FromArgb(150, Color.White), 2))
                {
                    g.DrawPath(pen, path);
                }

                TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // Animación del degradado

            // Dibuja el degradado animado solo debajo del texto

            gradienteTimer = new Timer();
            gradienteTimer.Interval = 60; // velocidad
            gradienteTimer.Tick += (s, e) =>
            {
                animacionOffset += 0.02f;
                if (animacionOffset > 1f) animacionOffset = 0f;
                btn.Invalidate(); // fuerza repintado
            };
            gradienteTimer.Start();
        }




        // Función auxiliar: interpola entre colores para suavizar la animación
        private Color InterpolarColor(float t, Color[] colores)
        {
            t = t % 1f;
            int num = colores.Length;
            float pos = t * num;
            int idx1 = (int)Math.Floor(pos) % num;
            int idx2 = (idx1 + 1) % num;
            float frac = pos - (float)Math.Floor(pos);

            return Color.FromArgb(
                255,
                (int)(colores[idx1].R + (colores[idx2].R - colores[idx1].R) * frac),
                (int)(colores[idx1].G + (colores[idx2].G - colores[idx1].G) * frac),
                (int)(colores[idx1].B + (colores[idx2].B - colores[idx1].B) * frac)
            );
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
        //Redondear el panel del formulario del log in
        private void RedondearPanel(Panel panel, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radio, 0, radio, radio), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radio, panel.Height - radio, radio, radio), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioLabel_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioText_TextChanged(object sender, EventArgs e)
        {
            UsuarioText.ForeColor = Color.Black;
        }

        private void ContraLabel_Click(object sender, EventArgs e)
        {

        }

        private void ContraText_TextChanged(object sender, EventArgs e)
        {
            ContraText.ForeColor = Color.Black;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UsuarioText_Enter(object sender, EventArgs e)
        {

        }

        private void UsuarioText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsuarioText.Text))
            {
                UsuarioText.Text = "Usuario";
                UsuarioText.ForeColor = Color.Black;
            }
        }
    }
}