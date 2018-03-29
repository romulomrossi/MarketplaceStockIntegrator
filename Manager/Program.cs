using System;
using Messenger;
using Messenger.MessageModels;
using AddressConfig;
using System.Threading.Tasks;

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
                IManagerPacketProcessor processor = ManagerPacketProcessor.FactoryProcessor(packet);
                Task.Run(() => processor.ProcessMessage(packet));
            }
        } 

        static void Main(string[] args)
        {
            StartReceiverThread();
        }
    }
}