using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serwer {
    public partial class Serwer : Form {
        private TcpListener Server;
        public static List<String> _logList = new List<String>();
        public static List<ConnectionHandler> clientHandlers = new List<ConnectionHandler>();
        public Serwer() {
            InitializeComponent();
        }
        private void Listen() {
            bool isListening = true;

            Thread updateLogBoxThread = new Thread(UpadteLogBox);
            updateLogBoxThread.Start();

            while (isListening) {
                _logList.Add("Nasłuchuję");
                try {
                    TcpClient tcpClient = Server.AcceptTcpClient();
                    clientHandlers.Add(new ConnectionHandler(tcpClient));
                    _logList.Add("Połączono z Klientem");
                }
                catch (Exception) {
                    _logList.Add("Error"); 
                    isListening = false;
                }
            }
            Server.Stop();
        }

        private void UpadteLogBox() {
            while (true) {
                try {
                    Invoke(new Action(() => {
                        LogBox.Text = "";

                        for (int i = 0; i < _logList.Count; i++) {
                            LogBox.Text += _logList[i];
                        }

                    }));

                    Thread.Sleep(1000);

                }
                catch(Exception) {
                    Console.WriteLine("Error Accured Somewhere xD");
                }
                
            }
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

    }

}
