using System;
using Messenger;
using Messenger.MessageModels;
using AddressConfig;

namespace Manager
{
    class Program
    {
        static void StartReceiverThread()
        {
            AddressManager addressManager = new AddressManager();
            AddressPair address = addressManager.GetManagerAddress();

            MessageReceiver receiver = new MessageReceiver(address.ip, address.port);

            while(true)
            {
                Packet packet = receiver.ReceivePacket();
                TestMessage message = (TestMessage)packet.message;
                Console.WriteLine(message.text);
            }
        } 


        static void Main(string[] args)
        {
            StartReceiverThread();
            Console.WriteLine("Hello World!");
        }
    }
}
