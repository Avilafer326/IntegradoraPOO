using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IntegradoraPOO
{
    public partial class FormularioPrincipal : Form
    {
        private const int AnchoBarraExpandida = 210;
        private const int AnchoBarraContraida = 58;
        private const int AlturaMenuExpandido = 150;
        private const int AlturaMenuContraido = 50;

        private bool barraExpandida = false;
        private bool menuExpandido = false;
        public string usuariologeado;

        private ControlTablero controlTablero;
        private ControlInformacion controlInformacion;
        private ControlConfiguracion controlConfiguracion;
        private readonly ControlSubMenuUno controlSubMenuUno = new ControlSubMenuUno();
        private readonly ControlSubMenuDos controlSubMenuDos = new ControlSubMenuDos();

    
      
        public FormularioPrincipal(string usuario)
        {
        
            InitializeComponent();
            usuariologeado = usuario;
            ConfigurarEstadoInicial();
            controlTablero.CargarPublicaciones2();
            
        }




        private void ConfigurarEstadoInicial()
        {
 
            controlTablero = new ControlTablero(usuariologeado);
            controlInformacion = new ControlInformacion(usuariologeado);
            controlConfiguracion = new ControlConfiguracion(usuariologeado);
            DoubleBuffered = true;
            panelBarraLateral.Width = AnchoBarraContraida;
            contenedorMenu.Height = AlturaMenuContraido;
            RefrescarElementosBarra();
            MostrarControl(controlTablero);
        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            transicionBarra.Start();
        }

        private void BotonMenuPrincipal_Click(object sender, EventArgs e)
        {
            transicionMenu.Start();
        }

        private void TransicionBarra_Tick(object sender, EventArgs e)
        {
            if (barraExpandida)
            {
                panelBarraLateral.Width -= 10;
                if (panelBarraLateral.Width <= AnchoBarraContraida)
                {
                    transicionBarra.Stop();
                    barraExpandida = false;
                    RefrescarElementosBarra();
                }
            }
            else
            {
                panelBarraLateral.Width += 10;
                if (panelBarraLateral.Width >= AnchoBarraExpandida)
                {
                    transicionBarra.Stop();
                    barraExpandida = true;
                    RefrescarElementosBarra();
                }
            }
        }
       
        private void TransicionMenu_Tick(object sender, EventArgs e)
        {
            if (!menuExpandido)
            {
                contenedorMenu.Height += 10;
                if (contenedorMenu.Height >= AlturaMenuExpandido)
                {
                    contenedorMenu.Height = AlturaMenuExpandido;
                    transicionMenu.Stop();
                    menuExpandido = true;
                }
            }
            else
            {
                contenedorMenu.Height -= 10;
                if (contenedorMenu.Height <= AlturaMenuContraido)
                {
                    contenedorMenu.Height = AlturaMenuContraido;
                    transicionMenu.Stop();
                    menuExpandido = false;
                }
            }
        }

        private void BotonTablero_Click(object sender, EventArgs e)
        {
            controlTablero.CargarPublicaciones2();
            MostrarControl(controlTablero);
            controlTablero.CargarPublicaciones2();
           
           
            
    
        }

        private void BotonInformacion_Click(object sender, EventArgs e)
        {
            
            MostrarControl(controlInformacion);
          
        }

        private void BotonConfiguracion_Click(object sender, EventArgs e)
        {
            controlConfiguracion.CargarPublicaciones();
            MostrarControl(controlConfiguracion);
            controlConfiguracion.CargarPublicaciones();
        }

        private void BotonSubMenuUno_Click(object sender, EventArgs e)
        {
            MostrarControl(controlSubMenuUno);
        }

        private void BotonSubMenuDos_Click(object sender, EventArgs e)
        {
            MostrarControl(controlSubMenuDos);
        }

        private void BotonSalir_Click(object sender, EventArgs e)
        {
            Form1 llamada = new Form1();
            llamada.Show();
            Close();
        }

        private void BotonCerrar_Click(object sender, EventArgs e)
        {
        
            Close();
           
        }

        private void MostrarControl(UserControl control)
        {
       
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(control);
            control.BringToFront();
        
    
          
            
        }

        private void RefrescarElementosBarra()
        {
            bool mostrarTexto = barraExpandida;
            botonTablero.Text = mostrarTexto ? "Tablero" : "T";
            botonMenuPrincipal.Text = mostrarTexto ? "Menú principal" : "M";
            botonInformacion.Text = mostrarTexto ? "Crear Publicacion" : "CC";
            botonConfiguracion.Text = mostrarTexto ? "Mis Publicaciones" : "MP";
            botonSalir.Text = mostrarTexto ? "Salir" : "S";
            botonSubMenuUno.Text = mostrarTexto ? "Submenú 1" : "1";
            botonSubMenuDos.Text = mostrarTexto ? "Submenú 2" : "2";

            botonTablero.Padding = new Padding(mostrarTexto ? 20 : 0, 0, 0, 0);
            botonMenuPrincipal.Padding = new Padding(mostrarTexto ? 20 : 0, 0, 0, 0);
            botonInformacion.Padding = new Padding(mostrarTexto ? 20 : 0, 0, 0, 0);
            botonConfiguracion.Padding = new Padding(mostrarTexto ? 20 : 0, 0, 0, 0);
            botonSalir.Padding = new Padding(mostrarTexto ? 20 : 0, 0, 0, 0);

            botonSubMenuUno.Padding = new Padding(mostrarTexto ? 40 : 0, 0, 0, 0);
            botonSubMenuDos.Padding = new Padding(mostrarTexto ? 40 : 0, 0, 0, 0);

            botonTablero.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonMenuPrincipal.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonInformacion.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonConfiguracion.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonSalir.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonSubMenuUno.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            botonSubMenuDos.TextAlign = mostrarTexto ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
        }

        private void PanelEncabezado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void BotonMenu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pincel = new Pen(Color.White, 2))
            {
                int margen = 8;
                int separacion = 8;
                for (int i = 0; i < 3; i++)
                {
                    int y = margen + i * separacion;
                    e.Graphics.DrawLine(pincel, margen, y, botonMenu.Width - margen, y);
                }
            }
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
