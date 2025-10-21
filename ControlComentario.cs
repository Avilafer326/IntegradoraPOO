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
    public partial class ControlComentario : UserControl
    {
        public ControlComentario(string id_publicacion)
        {
            InitializeComponent();
        }
        private DBHelper _dbHelper = new DBHelper();
        private int _idPublicacionActual;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public ControlComentario(string usuario, string contenido, DateTime fecha)
        {
            InitializeComponent();

            // Asignar los datos recibidos a los controles de la UI
            label1.Text = usuario;
            label2.Text = contenido;
            label3.Text = fecha.ToString("dd/MM/yyyy HH:mm"); // Formato de fecha legible

            // Opcional: Llamar a una función para ajustar la altura del contenido
          
        }

        // Constructor vacío (necesario para el diseñador de WinForms)
        public ControlComentario()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Función para ajustar la altura del UserControl al contenido del comentario

    }
}
