using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlInformacion : UserControl
    {
        public ControlInformacion()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            var etiqueta = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(30, 32, 37),
                Text = "INFORMACIÓN",
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(etiqueta);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlInformacion
            // 
            this.Name = "ControlInformacion";
            this.Size = new System.Drawing.Size(460, 327);
            this.ResumeLayout(false);

        }
    }
}
