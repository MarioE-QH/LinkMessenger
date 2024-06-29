using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace winProyEnlace
{
    class classEnlace
    {
        public delegate void ManejadorTxRx(string mensajeRX);
        public event ManejadorTxRx llegoMensaje;

        SerialPort sPuerto;
        private string mensajeEnvio;
        private string mensajeRecibido;
        private byte[] tramaRecibido;
        private byte[] tramaEnvio;
        private byte[] tramaRelleno;

        private Thread hebraEnvioMensaje;
        public string Usuario { get; set; }

        public void inicializa()
        {
            sPuerto = new SerialPort();
            sPuerto.DataReceived += new SerialDataReceivedEventHandler(SPuerto_DataReceived);
            sPuerto.PortName = "COM1";
            sPuerto.DataBits = 8;
            sPuerto.Parity = System.IO.Ports.Parity.Odd;
            sPuerto.StopBits = System.IO.Ports.StopBits.Two;
            sPuerto.BaudRate = 9600;
            sPuerto.WriteBufferSize = 4096;
            sPuerto.ReadBufferSize = 2048;
            sPuerto.ReceivedBytesThreshold = 1024;
            sPuerto.Open();

            tramaEnvio = new byte[1024];
            tramaRecibido = new byte[1024];
            tramaRelleno = new byte[1024];
            for (int i = 0; i <= 1023; i++)
                tramaRelleno[i] = 64;

            MessageBox.Show("SE ABRIO EL PUERTO DE COMUNICACIONES");
        }

        public void enviandoTrama()
        {
            string mensajeTruncado = mensajeEnvio.Length > 1024 ? mensajeEnvio.Substring(0, 1024) : mensajeEnvio;

            // Convertir el mensaje truncado en bytes
            tramaEnvio = ASCIIEncoding.UTF8.GetBytes(mensajeTruncado); // Se codifica el mensaje
            int messageLength = tramaEnvio.Length;

            // Se envía el mensaje
            sPuerto.Write(tramaEnvio, 0, messageLength);

            // Se verifica si se necesita enviar bytes de relleno
            if (messageLength < 1024)
            {
                byte[] paddingBytes = new byte[1024 - messageLength];
                sPuerto.Write(paddingBytes, 0, paddingBytes.Length);
            }
        }

        public void enviarMensaje(string mensajito)
        {
            hebraEnvioMensaje = new Thread(enviandoTrama);
            mensajeEnvio = mensajito;
            hebraEnvioMensaje.Start();
        }

        private void SPuerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sPuerto.BytesToRead >= 1024)
            {
                sPuerto.Read(tramaRecibido, 0, 1024);
                mensajeRecibido = ASCIIEncoding.UTF8.GetString(tramaRecibido, 0, 1024).Trim();
                onLlegoMensaje();
            }
        }

        protected virtual void onLlegoMensaje()
        {
            if (llegoMensaje != null)
                llegoMensaje(mensajeRecibido);
        }
    }
}
