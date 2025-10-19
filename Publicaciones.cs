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
        public Publicaciones(string usuario, string contenido,DateTime Fecha)
        {
            InitializeComponent();
       
            label1.Text = usuario;
            richTextBox1.Text = contenido;
            label2.Text = Fecha.ToString();
      
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
            button1.Top = richTextBox1.Bottom + margenEntreControles;
            button2.Top = richTextBox1.Bottom + margenEntreControles;

       
            int margenInferiorFinal = 10;

       
            this.Height = button1.Bottom + margenInferiorFinal;
        }

      
        public Publicaciones()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
