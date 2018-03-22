using System;
using System.Threading.Tasks;
using Messenger;

namespace Manager
{
    class Program
    {
        static void Receiver()
        {
            while(true)
            {
                MessageReceiver receiver = new MessageReceiver("127.0.0.1", 7777);
                Message message = receiver.ReceiveMessage();
                Console.WriteLine(message.text);
            }
        }

        static void Sender()
        {
            while(true)
            {
                MessageSender sender = new MessageSender("127.0.0.1", 7777);
                Message message = new Message();
                message.text = "teste";
                sender.SendMessage(message);
            }

        }

        static void Main(string[] args)
        {
            Task task = new Task(() => Receiver());
            Task task2 = new Task(() => Sender());
            task.Start();
            task2.Start();
            
            task2.Wait();
            task.Wait();
        }
    }
}
