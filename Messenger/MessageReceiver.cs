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
        
        public MessageReceiver(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        } 

        public Message ReceiveMessage()
        {
            IPAddress localAdd = IPAddress.Parse(this.ip);
            TcpListener listener = new TcpListener(localAdd, this.port);
            Console.WriteLine("Waiting for messages...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();

            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            Message message = ByteArrayParser.Deserialize<Message>(buffer, bytesRead);
            
            nwStream.Close();
            listener.Stop();
            return message;
        }
    }
}