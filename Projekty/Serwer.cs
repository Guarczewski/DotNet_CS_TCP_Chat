using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekty
{
    public class ClientHandler
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;

        private String _clientNickname;

        public ClientHandler(object tcpClient) {
            _tcpClient = (TcpClient)tcpClient;
            _networkStream = _tcpClient.GetStream();
            Thread localThread = new Thread(HandleClient);
            localThread.Start();
        }

        private void HandleClient() {
            while (true) {
                try {
                    String message = "ELO";
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(_networkStream, message);
                    var collectedObject = binaryFormatter.Deserialize(_networkStream);
                    Console.WriteLine(collectedObject); // Log Collected Object
                }
                catch (Exception e) {
                    _tcpClient.Close();
                }
            }
        }
    }

    public partial class Form1 : Form {

        private TcpListener Server;
        private List<TcpClient> _tcpClients = new List<TcpClient>();
        private List<ClientHandler> _clientHandlers = new List<ClientHandler>();

        public Form1() {
            InitializeComponent();
        }

        private void HostButton_Click(object sender, EventArgs e) {
            IPAddress ipAddress;

            try {
                ipAddress = IPAddress.Parse(AddressInput.Text);
            }
            catch (Exception) {
                AddressInput.Text = String.Empty;
                return;
            }

            int port = System.Convert.ToInt16(PortInput.Value);

            Server = new TcpListener(ipAddress, port);
            Server.Start();

            Thread localThread = new Thread(Listen);
            localThread.Start();

        }

        private void Listen()
        {
            bool isListening = true;

            while (isListening) {
                Console.WriteLine("Nasłuchuję");
                try {
                    TcpClient tcpClient = Server.AcceptTcpClient();
                    _tcpClients.Add(tcpClient);
                    _clientHandlers.Add(new ClientHandler(tcpClient));

                    Console.WriteLine("Połączono z Klientem");
                }
                catch (Exception) {
                    Console.WriteLine("Error"); isListening = false;
                }
            }
            Server.Stop();
        }

    }
}
