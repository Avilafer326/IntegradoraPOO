namespace IntegradoraPOO
{
    partial class CrearCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CorreoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ContraText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ContraVeriText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ConfirmarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioTextBox.Location = new System.Drawing.Point(34, 56);
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(210, 29);
            this.UsuarioTextBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CorreoText
            // 
            this.CorreoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorreoText.Location = new System.Drawing.Point(34, 141);
            this.CorreoText.Name = "CorreoText";
            this.CorreoText.Size = new System.Drawing.Size(210, 29);
            this.CorreoText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Correo ";
            // 
            // ContraText
            // 
            this.ContraText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContraText.Location = new System.Drawing.Point(34, 229);
            this.ContraText.Name = "ContraText";
            this.ContraText.Size = new System.Drawing.Size(210, 29);
            this.ContraText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // ContraVeriText
            // 
            this.ContraVeriText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContraVeriText.Location = new System.Drawing.Point(34, 314);
            this.ContraVeriText.Name = "ContraVeriText";
            this.ContraVeriText.Size = new System.Drawing.Size(210, 29);
            this.ContraVeriText.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Verificar Contraseña";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(512, 371);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(210, 46);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // ConfirmarButton
            // 
            this.ConfirmarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmarButton.Location = new System.Drawing.Point(34, 371);
            this.ConfirmarButton.Name = "ConfirmarButton";
            this.ConfirmarButton.Size = new System.Drawing.Size(210, 46);
            this.ConfirmarButton.TabIndex = 10;
            this.ConfirmarButton.Text = "Crear";
            this.ConfirmarButton.UseVisualStyleBackColor = true;
            this.ConfirmarButton.Click += new System.EventHandler(this.ConfirmarButton_Click);
            // 
            // CrearCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConfirmarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.ContraVeriText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ContraText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CorreoText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CrearCuenta";
            this.Text = "CrearCuenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsuarioTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox CorreoText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ContraText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ContraVeriText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button ConfirmarButton;
    }
}