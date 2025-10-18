using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlSubMenuUno : UserControl
    {
        public ControlSubMenuUno()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            var etiqueta = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(30, 32, 37),
                Text = "SUBMENÚ 1",
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(etiqueta);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlSubMenuUno
            // 
            this.Name = "ControlSubMenuUno";
            this.Load += new System.EventHandler(this.ControlSubMenuUno_Load);
            this.ResumeLayout(false);

        }

        private void ControlSubMenuUno_Load(object sender, System.EventArgs e)
        {

        }
    }
}
