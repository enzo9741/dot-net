using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ProjetBadgeVirtuel
{
    class TcpSocket
    {
        String host = "127.0.0.1";
        int port = 1234;
        IPEndPoint ip;

        public TcpSocket()
        {
            this.ip = new IPEndPoint(IPAddress.Parse(host), port);
        }

        public void SetHost(String host)
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
            //Connection
            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                return;
            }

            //Try catch
            server.Send(Encoding.ASCII.GetBytes(message));
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
