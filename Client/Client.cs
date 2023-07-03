using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client
{
    public partial class Client : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        List<String> outputString = new List<String>();
        public static List<String> _logList= new List<String>();
        ConnectionHandler _connectionHandler;

        private String _userNickname;


        public Client()
        {
            InitializeComponent();

        }

        private void UpadteLogBox() {
            while (true) {
                try {
                    Invoke(new Action(() => {
                        ClientDefaultRoomLogBox.Text = "";

                        for (int i = 0; i < _logList.Count; i++) {
                            ClientDefaultRoomLogBox.Text += _logList[i];
                        }

                    }));

                    Thread.Sleep(1000);

                }
                catch (Exception) {
                    Console.WriteLine("Error Accured Somewhere xD");
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e) {


            String host = AddressInput.Text;
            int port = System.Convert.ToInt16(PortInput.Value);

            try {

                _tcpClient = new TcpClient(host, port);
                _networkStream = _tcpClient.GetStream();
                _userNickname = NicknameInput.Text;

                Connect.Enabled = false;
                AddressInput.ReadOnly = true;
                PortInput.ReadOnly = true;
                NicknameInput.ReadOnly = true;

            }
            catch (Exception ignored) {
                Console.WriteLine(ignored);
                return;
            }

            _connectionHandler = new ConnectionHandler(_tcpClient);
            Thread localThread = new Thread(UpadteLogBox);
            localThread.Start();

        }

        private void SendMessage_Click(object sender, EventArgs e) {
            if (_connectionHandler != null) {
                _connectionHandler._packetsToSend.Add(new MyPacket(NicknameInput.Text, MessageInput.Text, 0));
                MessageInput.Text = "";
            }
        }
        private void NewRoomRequestButton_Click(object sender, EventArgs e) {

        }

    }
}
