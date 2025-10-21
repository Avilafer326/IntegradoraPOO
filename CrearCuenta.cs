using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IntegradoraPOO
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }
        MySqlConnection connection = Conexion.conexion();
        MySqlCommand codigo = new MySqlCommand();
       
        string dominioCorreo = "@utch.edu.mx";
        public bool ContieneMayuscula(string contrasena)
        {
            string patronMayuscula = @"^.*[A-Z].*$";
            return Regex.IsMatch(contrasena, patronMayuscula);
        }
        public bool VerificarCorreo(string correo, string dominioInstitucional)
        {
       
            return correo.ToLower().EndsWith(dominioInstitucional.ToLower());
        }
        public bool UsuarioOcupado(string newUser)
        {

            string cadena = "SELECT COUNT(*) FROM usuarios WHERE User = @user";

            using (MySqlCommand comando = new MySqlCommand(cadena, connection))
            {
     
                comando.Parameters.AddWithValue("@user", newUser);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    connection.Close();

                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error " + ex);
                    return true;
                }
            }
        }
        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            codigo.Connection = connection;

            if (!string.IsNullOrWhiteSpace(UsuarioTextBox.Text) && !string.IsNullOrWhiteSpace(CorreoText.Text) && !string.IsNullOrWhiteSpace(ContraText.Text) && !string.IsNullOrWhiteSpace(ContraVeriText.Text))
            {
                if (UsuarioTextBox.Text.Length >= 2 && UsuarioTextBox.Text.Length <= 15)
                {
                    if (UsuarioOcupado(UsuarioTextBox.Text) == false)
                    {
                        if (VerificarCorreo(CorreoText.Text, dominioCorreo))
                        {
                            if (ContraText.Text.Length >= 8 && ContieneMayuscula(ContraText.Text) == true)
                            {
                                if (ContraText.Text == ContraVeriText.Text)
                                {
                                    try
                                    {
                                        connection.Open();
                                        MySqlCommand codigo = new MySqlCommand();
                                        codigo.Connection = connection;

                                        codigo.CommandText = "INSERT INTO usuarios (User, Contra, Correo, FechaCreacion) " +
                                                    "VALUES(@User, @Contra,@Correo, @Fecha)";
                                        codigo.Parameters.AddWithValue("@User", UsuarioTextBox.Text);
                                        codigo.Parameters.AddWithValue("@Contra", BCrypt.Net.BCrypt.HashPassword(ContraText.Text));
                                        codigo.Parameters.AddWithValue("@Correo", BCrypt.Net.BCrypt.HashPassword(CorreoText.Text));
                                        codigo.Parameters.AddWithValue("@Fecha", DateTime.Now);

                                        int filas = codigo.ExecuteNonQuery();
                                        if (filas > 0)
                                        {
                                            MessageBox.Show("usuario creado");
                                            UsuarioTextBox.Clear(); ContraText.Clear(); ContraVeriText.Clear(); CorreoText.Clear();
                                        }
                                        else
                                        {
                                            MessageBox.Show("usuario no creado");
                                            UsuarioTextBox.Clear(); ContraText.Clear(); ContraVeriText.Clear(); CorreoText.Clear();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("error " + ex);
                                    }
                                    connection.Close();
                                }
                                else { MessageBox.Show("las contraseñas no coinciden"); ; ContraText.Clear(); ContraVeriText.Clear(); }
                            }
                            else { MessageBox.Show("la contraseña debe tener al menos 8 Caracteres e incluir una mayuscula"); ContraText.Clear(); ContraVeriText.Clear(); }
                        }
                        else { MessageBox.Show("el correo debe ser el institucional"); }
                    }
                    else { MessageBox.Show("el nombre de usuario esta ocupado"); }
                }
                else { MessageBox.Show("El usuario debe tener entre 2 y 15 caracteres"); }
            }
            else { MessageBox.Show("falta llenar algun campo"); }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Form1 llamdainicio = new Form1();
            llamdainicio.Show();
            this.Close();

        }
    }
}
