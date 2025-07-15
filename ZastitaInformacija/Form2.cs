using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacija
{
    public partial class Form2 : Form
    {
        private Socket serverSocket;
        public Form2()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        async Task ServerAsync()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, Int32.Parse(txtPortServer.Text)));
                serverSocket.Listen(5);
                UpdateStatus(sslServer, "Server je spreman i osluškuje konekcije");

                while (true)
                {
                    Socket clientSocket = await serverSocket.AcceptAsync();
                    UpdateStatus(sslServer, "Klijent je povezan");

                    Task.Run(() => HandleClientAsyncBasic(clientSocket));
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(sslServer, $"Error: {ex.Message}");
            }
            finally
            {
                serverSocket.Close();
            }
        }
    }
}
