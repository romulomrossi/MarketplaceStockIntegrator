//https://stackoverflow.com/questions/10182751/server-client-send-receive-simple-text

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Messenger
{
    public class MessageSender
    {
        private string ip;
        private int port;

        public MessageSender(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void SendPacket(Packet packet)
        {
            int tries = 3;
            TcpClient client = null;

            while((tries--) > 0)
            {
                try
                {
                    client = new TcpClient(this.ip, this.port);
                    NetworkStream networkStream = client.GetStream();
                    byte[] bytesToSend = ByteArrayParser.Serialize(packet);
                    Console.WriteLine("Sending message...");
                    networkStream.Write(bytesToSend, 0, bytesToSend.Length);
                    client.Close();
                    break;
                }
                catch
                {
                    if(tries == 0)
                        Console.WriteLine("It's not possible to send message.. (tries=3)");
                    if(client != null)
                        client.Close();
                }
            }
        }  
    }
}