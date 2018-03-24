using System;

namespace Messenger
{
    [Serializable()]
    public class Packet
    {
        public PacketEnum type;
        public Message message;
    }
}