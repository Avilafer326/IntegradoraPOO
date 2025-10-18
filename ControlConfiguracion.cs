using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlConfiguracion : UserControl
    {
        private Button button1;

        public ControlConfiguracion()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            var etiqueta = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(30, 32, 37),
                Text = "CONFIGURACIÓN",
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(etiqueta);
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ControlConfiguracion
            // 
            this.Controls.Add(this.button1);
            this.Name = "ControlConfiguracion";
            this.Size = new System.Drawing.Size(453, 325);
            this.ResumeLayout(false);

        }
    }
}
