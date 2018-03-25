//https://stackoverflow.com/questions/10182751/server-client-send-receive-simple-text

using System;
using System.Net;
using System.Net.Sockets;

namespace Messenger
{
    public class MessageReceiver
    {
        private string ip;
        private int port;

         TcpListener listener;
        
        public MessageReceiver(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            IPAddress localAdd = IPAddress.Parse(this.ip);
            listener = new TcpListener(localAdd, this.port);
            listener.Start();
        } 

        public Packet ReceivePacket()
        {
            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();

            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            Packet message = ByteArrayParser.Deserialize<Packet>(buffer, bytesRead);
            
            nwStream.Close();
            return message;
        }
    }
}