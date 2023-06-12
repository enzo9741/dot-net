using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProjetBadgeVirtuel2.Models
{
    public class TcpSocket
    {
        string host = "127.0.0.1";
        int port = 1234;
        IPEndPoint ip;

        public TcpSocket()
        {
            this.ip = new IPEndPoint(IPAddress.Parse(host), port);
        }

        public void SetHost(string host)
        {
            this.host = host;
            this.ip = new IPEndPoint(IPAddress.Parse(host), port);
        }

        public void SetPort(int port)
        {
            this.port = port;
            this.ip = new IPEndPoint(IPAddress.Parse(host), port);
        }

        public void SendMessage(string message)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                return;
            }

            server.Send(Encoding.ASCII.GetBytes(message));
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
