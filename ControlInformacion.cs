using System.Drawing;
using System.Windows.Forms;

namespace IntegradoraPOO
{
    public class ControlInformacion : UserControl
    {
        private Label label1;
        private RichTextBox richTextBox1;

        public ControlInformacion()
        {
        }


        private void ControlInformacion_Load(object sender, System.EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.richTextBox1.Size = new System.Drawing.Size(358, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // ControlInformacion
            // 
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "ControlInformacion";
            this.Size = new System.Drawing.Size(484, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
