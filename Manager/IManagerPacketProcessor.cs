using Messenger;

namespace Manager
{
    public interface IManagerPacketProcessor
    {
        void ProcessMessage(Packet packet);    
    }
}