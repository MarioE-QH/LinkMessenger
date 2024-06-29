namespace winProyEnlace
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RichTxtConversacion = new System.Windows.Forms.RichTextBox();
            this.txtMensajeEnvio = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.PicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTxtConversacion
            // 
            this.RichTxtConversacion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RichTxtConversacion.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTxtConversacion.Location = new System.Drawing.Point(12, 33);
            this.RichTxtConversacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RichTxtConversacion.Name = "RichTxtConversacion";
            this.RichTxtConversacion.Size = new System.Drawing.Size(613, 251);
            this.RichTxtConversacion.TabIndex = 1;
            this.RichTxtConversacion.Text = "";
            // 
            // txtMensajeEnvio
            // 
            this.txtMensajeEnvio.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeEnvio.Location = new System.Drawing.Point(12, 292);
            this.txtMensajeEnvio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMensajeEnvio.Multiline = true;
            this.txtMensajeEnvio.Name = "txtMensajeEnvio";
            this.txtMensajeEnvio.Size = new System.Drawing.Size(457, 39);
            this.txtMensajeEnvio.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Image = global::winProyEnlace.Properties.Resources.icons8_cerrar_sesión_30;
            this.button2.Location = new System.Drawing.Point(582, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 38);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::winProyEnlace.Properties.Resources.icons8_subir_archivo_32;
            this.button1.Location = new System.Drawing.Point(533, 293);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 38);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Cyan;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.Image = global::winProyEnlace.Properties.Resources.icons8_email_send_24;
            this.btnEnviar.Location = new System.Drawing.Point(478, 292);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(46, 39);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "LinkMessenger";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Navy;
            this.name.Font = new System.Drawing.Font("Rockwell", 12F);
            this.name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Location = new System.Drawing.Point(530, 8);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(0, 22);
            this.name.TabIndex = 6;
            // 
            // PicBox
            // 
            this.PicBox.Location = new System.Drawing.Point(501, 5);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(23, 22);
            this.PicBox.TabIndex = 7;
            this.PicBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(640, 339);
            this.Controls.Add(this.PicBox);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMensajeEnvio);
            this.Controls.Add(this.RichTxtConversacion);
            this.Controls.Add(this.btnEnviar);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHAT COM2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox RichTxtConversacion;
        private System.Windows.Forms.TextBox txtMensajeEnvio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox PicBox;
    }
}

