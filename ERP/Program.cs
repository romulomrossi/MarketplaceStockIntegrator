using System;
using System.Threading.Tasks;
using AddressConfig;
using Messenger;
using Messenger.MessageModels;

namespace ERP
{
    class Program
    {
        static void SendToManager(Packet packet)
        {
            AddressManager manager = new AddressManager();
            AddressPair address =  manager.GetManagerAddress();

            MessageSender sender = new MessageSender(address.ip, address.port);
            sender.SendPacket(packet);
        }
        
        static void Main(string[] args)
        {
            while(true){
                string message = Console.ReadLine();
                Task.Run(() => 
                {
                    SendToManager(new Packet()
                    {
                         type = PacketEnum.Test,
                         message = new TestMessage()
                         {
                             text = message
                         }
                    });
                });
            }
        }
    }
}
