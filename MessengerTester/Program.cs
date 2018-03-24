using System;
using System.Threading.Tasks;
using Messenger;
using Messenger.MessageModels;

namespace MessengerTester
{
    class Program
    {
        static void Receiver()
        {
            while(true)
            {
                MessageReceiver receiver = new MessageReceiver("127.0.0.1", 7777);
                Packet packet = receiver.ReceivePacket();
                TestMessage message = (TestMessage)packet.message;
                Console.WriteLine(message.text);
            }
        }

        static void Sender()
        {
            while(true)
            {
                MessageSender sender = new MessageSender("127.0.0.1", 7777);
                Packet packet = new Packet();
                packet.message = new TestMessage();
                ((TestMessage)packet.message).text = "teste";
                sender.SendPacket(packet);
            }
        }

        static void Main(string[] args)
        {
            Task taskReceiver = new Task(() => Receiver());
            Task taskSender = new Task(() => Sender());
            taskReceiver.Start();
            taskSender.Start();
            taskSender.Wait();
            taskReceiver.Wait();
        }
    }
}
