using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlSubMenuDos : UserControl
    {
        public ControlSubMenuDos()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            var etiqueta = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(30, 32, 37),
                Text = "SUBMENÚ 2",
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(etiqueta);
        }
    }
}
