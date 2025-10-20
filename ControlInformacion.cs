using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace IntegradoraPOO
{
    public class ControlInformacion : UserControl
    {
        private Label label1;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
        string usuariologeado;
        public ControlInformacion(string usuario)
        {
            usuariologeado = usuario;
            InitializeComponent();
        }
        MySqlConnection connection = Conexion.conexion();
        

        private void ControlInformacion_Load(object sender, System.EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Que estas pensando?";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(28, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(427, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Publicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ControlInformacion
            // 
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "ControlInformacion";
            this.Size = new System.Drawing.Size(484, 247);
            this.Load += new System.EventHandler(this.ControlInformacion_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ControlInformacion_Load_1(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            using (MySqlCommand comando = new MySqlCommand())
            {
                comando.Connection = connection;
                try
                {
                    connection.Open();

                    comando.CommandText = @"INSERT INTO publicacionestb (User, Contenido, FechaCreacion)" +
                                                "VALUES(@User, @Contenido, @Fecha)";
                    comando.Parameters.AddWithValue("@user", usuariologeado);
                    comando.Parameters.AddWithValue("@Contenido", richTextBox1.Text);
                    comando.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("se logro");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex);
                }
                connection.Close();
            }
        
        }
    }
}