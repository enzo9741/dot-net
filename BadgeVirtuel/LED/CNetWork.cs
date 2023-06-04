using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LED
{
    public delegate void MyEventHandler(string Message);
    class CNetWork
    {
        byte[] bytes = new Byte[1024];
        string data;
        TcpListener tcpListener;
        Socket sockerForClient;
        NetworkStream networkStream;
        StreamReader streamReader;
        int port;
        public event MyEventHandler SomethingHappened;
        public event MyEventHandler RecevedMessage;
        public CNetWork(int port)
        {
            this.port = port;
            tcpListener = new TcpListener(System.Net.IPAddress.Any, this.port);
            tcpListener.Start();

        }
        public void StartListener()
        {
            try
            {

                SomethingHappened?.Invoke("Ecoute sur le port " + this.port);
                string line;
                while (true)
                {
                    sockerForClient = tcpListener.AcceptSocket();
                    networkStream = new NetworkStream(sockerForClient);
                    streamReader = new StreamReader(networkStream);
                    SomethingHappened?.Invoke("Client " + sockerForClient.RemoteEndPoint.ToString() + " connecté.");

                    line = streamReader.ReadLine();
                    SomethingHappened?.Invoke("Réception de " + line.Length.ToString() + " octets");
                    RecevedMessage?.Invoke(line);
                }

            }
            catch (Exception e)
            {
                SomethingHappened?.Invoke("Erreur " + e.ToString());
            }
        }
    }
}
