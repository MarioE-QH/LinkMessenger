using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace winProyEnlace
{
    public partial class Form1 : Form
    {
        private classEnlace enlaceComunica;
        private Bitmap usuario1Icono; // Icono del usuario 1 (Mario)
        private Bitmap usuario2Icono; // Icono del usuario 2 (Paolo)
        private static readonly object clipboardLock = new object(); // Objeto de bloqueo para el acceso al portapapeles

        public Form1()
        {
            InitializeComponent();

            // Inicialización de los iconos de usuario
            usuario1Icono = Properties.Resources.Foto; // Icono para Mario
            usuario2Icono = Properties.Resources.icons8_cerrar_sesión_30; // Icono para Paolo

            // Redimensionar y aplicar máscara circular a los iconos de usuario
            usuario1Icono = ResizeImage(usuario1Icono, 15, 15);
            usuario1Icono = ApplyCircularMask(usuario1Icono);
            usuario2Icono = ResizeImage(usuario2Icono, 15, 15);
            usuario2Icono = ApplyCircularMask(usuario2Icono);

            // Crear una instancia de classEnlace para esta instancia de Form1
            enlaceComunica = new classEnlace();
            enlaceComunica.Usuario = "Mario"; // Asignar el nombre del usuario actual
            enlaceComunica.llegoMensaje += new classEnlace.ManejadorTxRx(enlaceComunica_LlegoMensaje);

            
            RichTxtConversacion.Text = "";
            PicBox.Image = Properties.Resources.Foto;
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enlaceComunica.inicializa();
            ControlExtension.Draggable(this, true);
            name.Text = enlaceComunica.Usuario;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensajeEnvio.Text.Trim();

            // Verificar si el mensaje está vacío
            if (string.IsNullOrEmpty(mensaje))
            {
                // Puedes mostrar un mensaje de advertencia si lo deseas
                MessageBox.Show("El mensaje no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si el mensaje está vacío
            }

            // Enviar el mensaje
            enlaceComunica.enviarMensaje(mensaje);

            Bitmap iconoEnvio = enlaceComunica.Usuario == "Mario" ? usuario1Icono : usuario2Icono;

            // Agregar el mensaje enviado al RichTextBox con la hora y un espacio en blanco
            AppendMessageWithIcon(RichTxtConversacion, $"Yo [{DateTime.Now:HH:mm}]:", mensaje, iconoEnvio);
            txtMensajeEnvio.Clear();

            // Asegurarse de que el RichTextBox se desplace hasta el final
            ScrollToBottom();
        }

        private void enlaceComunica_LlegoMensaje(string n)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(enlaceComunica_LlegoMensaje), n);
            }
            else
            {
                Bitmap iconoRecibido = enlaceComunica.Usuario == "Mario" ? usuario2Icono : usuario1Icono;
                string usuarioRemitente = enlaceComunica.Usuario == "Mario" ? "Paolo" : "Mario";

                // Mostrar el mensaje en el RichTextBox con el icono y salto de línea
                AppendMessageWithIcon(RichTxtConversacion, $"{usuarioRemitente} [{DateTime.Now:HH:mm}]:", n.Trim(), iconoRecibido);

                // Asegurarse de que el RichTextBox se desplace hasta el final
                ScrollToBottom();
            }
        }

        private void AppendMessageWithIcon(RichTextBox richTextBox, string header, string message, Bitmap icon)
        {
            // Guardar la posición actual de la selección
            int selectionStart = richTextBox.SelectionStart;

            // Mover el cursor al final del texto
            richTextBox.SelectionStart = richTextBox.Text.Length;

            // Insertar un salto de línea antes del icono y el mensaje, si no es el primer mensaje
            if (richTextBox.Text.Length > 0)
            {
                richTextBox.AppendText(Environment.NewLine);
            }

            // Insertar el icono con bloqueo (si se requiere, el código para esto va aquí)
            lock (clipboardLock)
            {
                Clipboard.SetImage(icon);
                richTextBox.ReadOnly = false;
                richTextBox.Paste();
                richTextBox.ReadOnly = true;
            }

            // Agregar el encabezado en negrita
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText($" {header}{Environment.NewLine}");

            // Cambiar el color de la selección antes de agregar el mensaje
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
            richTextBox.SelectionColor = Color.Blue;

            // Agregar el mensaje
            richTextBox.AppendText($" {message}");
            richTextBox.AppendText(Environment.NewLine);

            // Restaurar el color de la selección a su color predeterminado
            richTextBox.SelectionColor = richTextBox.ForeColor;

            // Restaurar la posición de la selección
            richTextBox.SelectionStart = selectionStart;
            richTextBox.SelectionLength = 0; // Asegurarse de que no haya selección
        }

        private void ScrollToBottom()
        {
            RichTxtConversacion.SelectionStart = RichTxtConversacion.Text.Length;
            RichTxtConversacion.ScrollToCaret();
        }

        private Bitmap ResizeImage(Bitmap originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }
            return resizedImage;
        }

        private Bitmap ApplyCircularMask(Bitmap originalImage)
        {
            Bitmap circularImage = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(circularImage))
            {
                // Define un path circular
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, originalImage.Width - 1, originalImage.Height - 1);

                // Rellena el path con color transparente
                g.Clear(Color.Transparent);
                g.SetClip(path);
                g.DrawImage(originalImage, 0, 0);

                return circularImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
