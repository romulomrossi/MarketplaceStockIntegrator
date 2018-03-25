using System;
using Messenger;
using Messenger.MessageModels;

namespace Manager
{
    public class TestPacketProcessor : IManagerPacketProcessor
    {
        public void ProcessMessage(Packet packet)
        {
            TestMessage message = (TestMessage)packet.message;
            Console.WriteLine("Teste message received.");
            Console.WriteLine("Message: ");
            Console.WriteLine(message.text);
        }
    }
}