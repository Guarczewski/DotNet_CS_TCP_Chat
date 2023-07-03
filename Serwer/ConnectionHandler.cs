using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Serwer {
    public class ConnectionHandler {

        private TcpClient _myTcpClient;
        private NetworkStream _myNetworkStream;
        private String _myClientName;

        private Thread _myListeningThread;
        private Thread _mySpeakingThread;

        private BinaryFormatter _binaryFormatter;

        private List<MyPacket> _packetsToSend;

        public ConnectionHandler(object tcpClient) {

            _packetsToSend = new List<MyPacket>();
            _packetsToSend.Add(new MyPacket("Serwer", "Połączono z Serwerem",0));

            _myTcpClient = (TcpClient)tcpClient;
            _myNetworkStream = _myTcpClient.GetStream();
           // _myClientName = clientName;

            _binaryFormatter = new BinaryFormatter();

            _myListeningThread = new Thread(Listen);
            _myListeningThread.Start();

            _mySpeakingThread = new Thread(Shout);
            _mySpeakingThread.Start();

        }

        private void Listen() {
            while (true) {
                try {
                    object collectedObject = _binaryFormatter.Deserialize(_myNetworkStream);
                    List<MyPacket> collectedPacket = (List<MyPacket>)collectedObject;

                    foreach (MyPacket packet in collectedPacket) {
                        Serwer._logList.Add(packet.toString());

                        foreach (ConnectionHandler connectionHandler in Serwer.clientHandlers) { 
                            connectionHandler._packetsToSend.Add((MyPacket)packet);
                        }

                    }

                }
                catch (Exception) {
                    Console.WriteLine("Error");
                }

            }
        }

        private void Shout() {
            while (true) {
                if (_packetsToSend.Count > 0) { 
                    try {
                        _binaryFormatter.Serialize(_myNetworkStream, _packetsToSend);
                        _packetsToSend.Clear();
                    }
                    catch (Exception) {
                        Console.WriteLine("Error");
                    }
                }
            }
        }
    }

}

