using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
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
        }
        CrearCuenta llamdaCrear = new CrearCuenta();
        MySqlConnection connection = Conexion.conexion();
        MySqlCommand codigo = new MySqlCommand();

        private void button2_Click(object sender, EventArgs e)
        {
            llamdaCrear.Show();
            this.Hide();
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
                MessageBox.Show("=" + ex );
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
    }
}
